import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { Product } from 'src/app/_models/product';
import { ValidationResult } from 'src/app/_models/validation-result';
import { FileService } from 'src/app/_services/file.service';
import { ProductService } from 'src/app/_services/product.service';
import { ValidationService } from 'src/app/_services/validation/validation.service';

@Component({
  selector: 'app-product-upload',
  templateUrl: './product-upload.component.html',
  styleUrls: ['./product-upload.component.css']
})
export class ProductUploadComponent implements OnInit, OnDestroy {
  @Output() readonly onCreatedProducts: EventEmitter<Product[]> = new EventEmitter<Product[]>();
  private createdProductsSubscription!: Subscription;
  @Input() currentProducts !: Product[];
  @Output() readonly onValidationErrors: EventEmitter<ValidationResult[]> = new EventEmitter<ValidationResult[]>();

  constructor(
    private readonly fileService: FileService,
    private readonly productService: ProductService,
    private readonly validationService: ValidationService) { }

  ngOnInit(): void {
    this.createdProductsSubscription = this.productService.createdProducts.subscribe(
      products => this.onNewlyAddedProducts(products)
    );
  }

  ngOnDestroy(): void {
    this.createdProductsSubscription.unsubscribe();
  }

  onUploadedProducts(event: Event): void {
    const input = <HTMLInputElement>event.target;
    const files = <FileList>input.files;
    const uploadedFile: File = files[0];
    const reader = new FileReader();
    reader.readAsBinaryString(uploadedFile);
    reader.onload = _ => this.onLoadedProductsReader(reader);
  }

  private onLoadedProductsReader(reader: FileReader): void {
    const json = this.fileService.xlsxToJson<Product>(reader);
    const products: Product[] = Array.from(json).map(product => new Product(product));
    const validationResults = this.validationService.validateProductRange(products);
    if(validationResults.some(r => !r.isValid()))
      this.onValidationErrors.emit(validationResults);
    else{
      this.productService.addProductRange(products);
      this.onValidationErrors.emit([]);
    }
  }

  private onNewlyAddedProducts(products: Product[]): void {
    products = products.filter(product => !this.currentProducts.includes(product));
    if(products.length > 0 ) 
      this.onCreatedProducts.emit(products)
  }
}
