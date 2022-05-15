import { BaseModel } from "./base";

export interface Shipping extends BaseModel {
    price: number;
    package: number;
}