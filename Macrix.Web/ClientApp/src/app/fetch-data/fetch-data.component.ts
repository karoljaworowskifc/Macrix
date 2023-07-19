import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public data: Person[] = [];
  public personForm: FormGroup;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, fb: FormBuilder) {
    this.personForm = fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      streetName: ['', Validators.required],
      houseNumber: ['', Validators.required],
      apartment: [''],
      postalCode: ['', Validators.required],
      town: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
    });
    http.get<Person[]>(baseUrl + 'person').subscribe(result => {
      this.data = result;
    }, error => console.error(error));
  }
}

interface Person {
  id: string;
  firstName: string;
  lastName: string;
  streetName: string;
  houseNumber: string;
  apartment: string;
  postalCode: string;
  town: string;
  phoneNumber: string;
  dateOfBirth: string
  age: number;
}
