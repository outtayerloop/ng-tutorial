import { HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, Input, Output } from '@angular/core';
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
export class ProductUploadComponent {
  @Output() readonly onCreatedProducts: EventEmitter<Product[]> = new EventEmitter<Product[]>();
  @Input() currentProducts !: Product[];
  @Output() readonly onValidationErrors: EventEmitter<ValidationResult[]> = new EventEmitter<ValidationResult[]>();

  constructor(
    private readonly fileService: FileService,
    private readonly productService: ProductService,
    private readonly validationService: ValidationService) { }

  onUploadedProducts(event: Event): void {
    const input = <HTMLInputElement>event.target;
    const files = <FileList>input.files;
    const uploadedFile: File = files[0];
    const reader = new FileReader();
    reader.readAsBinaryString(uploadedFile);
    reader.onload = _ => {
      this.onLoadedProductsReader(reader);
      input.value = ``;
    }
  }

  private onLoadedProductsReader(reader: FileReader): void {
    const json = this.fileService.xlsxToJson<Product>(reader);
    const products: Product[] = Array.from(json).map(product => new Product(product));
    const validationResults = this.validationService.validateProductRange(products);
    if(validationResults.some(r => !r.isValid()))
      this.onValidationErrors.emit(validationResults);
    else
      this.addProductRange(products);
  }

  private addProductRange(products: Product[]): void {
    console.log(`addProductRange`);
    this.productService.addProductRange(products).subscribe({
      next: (res: Product[]) => {
        this.onNewlyAddedProducts(res);
        this.onValidationErrors.emit([]);
      },
      error: (err: HttpErrorResponse) => this.onValidationErrors.emit(<ValidationResult[]>(err.error))
    });
  }

  private onNewlyAddedProducts(products: Product[]): void {
    products = products.filter(product => !this.currentProducts.includes(product));
    if(products.length > 0 ) 
      this.onCreatedProducts.emit(products)
  }
}
