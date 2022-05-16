import { HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { Product } from 'src/app/_models/product';
import { FileService } from 'src/app/_services/file.service';
import { ProductService } from 'src/app/_services/product.service';

@Component({
  selector: 'app-product-upload',
  templateUrl: './product-upload.component.html',
  styleUrls: ['./product-upload.component.css']
})
export class ProductUploadComponent implements OnInit, OnDestroy {
  @Output() onCreatedProducts: EventEmitter<Product[]> = new EventEmitter<Product[]>();
  private createdProductsSubscription!: Subscription;
  @Input() currentProducts !: Product[];

  constructor(
    private fileService: FileService,
    private productService: ProductService) { }

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
    reader.onload = _ => {
      const products = this.fileService.xlsxToJson<Product>(reader);
      this.productService.addProductRange(<Product[]>products);
    }
  }

  onNewlyAddedProducts(products: Product[]): void {
    products = products.filter(product => this.currentProducts.includes(product));
    if(products.length > 0 ) 
      this.onCreatedProducts.emit(products)
  }
}
