import { HttpClient as HttpFetch } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject('apiRoot', HttpFetch)
export class ValuesRespository {
  constructor(apiRoot, httpFetch) {
    this.httpFetch = httpFetch;
    this.apiRoot = apiRoot;
  }

  getValuesController() {
    return this.httpFetch.fetch(`${this.apiRoot}/api/v1/values`)
        .then(response => response.json());
  }
}