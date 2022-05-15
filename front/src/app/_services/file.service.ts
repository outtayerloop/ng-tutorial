import { Injectable } from '@angular/core';
import * as XLSX from 'xlsx';
import { Product } from '../_models/product';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  constructor() { }

  /**
   * Returns an array with the extracted data if the file reader was correctly
   * initialized and has already read data from a file,
   * otherwise returns null.
   * @param reader provided file reader
   * @returns an array of the extracted models
   */
  xlsxToJson<BaseModel>(reader: FileReader): BaseModel[] | null {
    const data = reader.result;
    if(reader.result){
      const workBook = XLSX.read(data, { type: 'binary' });
      const jsonData = workBook.SheetNames.reduce((_, name) => {
        const sheet = workBook.Sheets[name];
        return XLSX.utils.sheet_to_json<BaseModel>(sheet);
      }, {});
      return <BaseModel[]>jsonData;
    }
    return null;
  }
}
