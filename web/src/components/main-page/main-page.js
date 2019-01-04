import { inject } from 'aurelia-framework';
import { ValuesRespository } from '../../repositories/values-repository';

@inject(ValuesRespository)
export class MainClass {

  constructor(valuesRespository) {
    this.valuesRespository = valuesRespository;
    this.message = 'Data from the values controller';
    this.valuesRespository.getValuesController().then((data) => {
      this.values = data;
    });
  }
}