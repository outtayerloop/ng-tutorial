export abstract class BaseModel {
    id: number;

    constructor(jsonData: any){
        this.id = jsonData.id;
    }
}