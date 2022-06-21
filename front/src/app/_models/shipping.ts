import { BaseModel } from "./base";

export class Shipping extends BaseModel {
    price: number;
    package: number;

    constructor(jsonData: any){
        super(jsonData);
        this.price = jsonData.price;
        this.package = jsonData.shippingPackage;
    }
}