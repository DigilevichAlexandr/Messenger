import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { first, catchError } from 'rxjs/operators';

@Component({
  selector: 'app-fetch-employees',
  templateUrl: './fetch-employees.component.html'
})
export class FetchEmployeesComponent {
  public employees: Employee[];
  //public employee: Employee;
  public employee: Employee =
    {
      id: 0,
      fullName: {
        firstName: '',
        lastName: '',
        middleName: '',
      },
      position: '',
      workingPlace: {
        address: '',
        companyName: ''
      }
    };
  //public employee: string = 'test';

  public baseUrl: string;
  public http: HttpClient

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Employee[]>(baseUrl + 'employees').subscribe(result => {
      this.employees = result;
    }, error => console.error(error));

    this.http = http;
    this.baseUrl = baseUrl;
  }

  save() {
    this.http.post(this.baseUrl + 'employees', this.employee)
      .subscribe(result => {
        this.http.get<Employee[]>(this.baseUrl + 'employees').subscribe(result => {
          this.employees = result;
        }, error => console.error(error));
      }, error => console.error(error));
  }

  edit(employee: Employee) {
    this.http.put(this.baseUrl + 'employees', employee)
      .subscribe(result => {
        this.http.get<Employee[]>(this.baseUrl + 'employees').subscribe(result => {
          this.employees = result;
        }, error => console.error(error));
      }, error => console.error(error));
  }

  delete(id: number) {
    let httpParams = new HttpParams().set('id', id.toString());
    let options = { params: httpParams };
    this.http.delete(this.baseUrl + 'employees', options)
      .subscribe(result => {
        this.http.get<Employee[]>(this.baseUrl + 'employees').subscribe(result => {
          this.employees = result;
        }, error => console.error(error));
      }, error => console.error(error));
  }
}

class Employee {
  id: number;
  fullName: FullName;
  position: string;
  workingPlace: WorkingPlace;
}

class FullName {
  firstName: string;
  lastName: string;
  middleName: string;
}

class WorkingPlace {
  companyName: string;
  address: string;
}

