import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';

@Component({
  selector: 'app-fetch-employees',
  templateUrl: './fetch-employees.component.html'
})
export class FetchEmployeesComponent {
  public employees: Employee[];
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
  public pageOptions: PageOptions =
    {
      pageNumber: 1,
      pageSize: 10
    };
  public baseUrl: string;
  public http: HttpClient;
  public Editor = ClassicEditor;

  public model = {
    editorData: '<p>Hello, world!</p>'
  };

  visibality = false;
  id = -1;

  messages: Message[];
  public employeeToMessage: Employee;

  data: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.getAll(this.pageOptions);
  }

  save() {
    this.http.post(this.baseUrl + 'employees', this.employee)
      .subscribe(result => {
        this.getAll(this.pageOptions);
      }, error => console.error(error));
  }

  edit(employee: Employee) {
    this.http.put(this.baseUrl + 'employees', employee)
      .subscribe(result => {
        this.getAll(this.pageOptions);
      }, error => console.error(error));
  }

  delete(id: number) {
    let httpParams = new HttpParams().set('id', id.toString());
    let options = { params: httpParams };
    this.http.delete(this.baseUrl + 'employees', options)
      .subscribe(result => {
        this.getAll(this.pageOptions);
      }, error => console.error(error));
  }

  getAll(pageOptions: PageOptions = this.pageOptions) {
    let httpParams = new HttpParams().set('pageOptions', JSON.stringify(pageOptions));
    let options = { params: httpParams };
    this.http.get<Employee[]>(this.baseUrl + 'employees', options)
      .subscribe(result => {
        this.employees = result;
      }, error => console.error(error));
  }

  sendMessage() {
    this.http.post(this.baseUrl + 'messages', { id: this.id, message: this.model.editorData })
      .subscribe(result => {
        this.getAll(this.pageOptions);
      }, error => console.error(error));
  }

  revealMessageEditor(employee: Employee) {
    this.id = employee.id;
    this.visibality = !this.visibality;
    this.employeeToMessage = employee;
  }

  getMessages() {
    let httpParams = new HttpParams().set('id', JSON.stringify(this.id));
    let options = { params: httpParams };
    this.http.get<Message[]>(this.baseUrl + 'messages', options)
      .subscribe(result => {
        this.messages = result;
        this.data = result.map(m => m.text).join();
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

class PageOptions {
  pageNumber: number;
  pageSize: number;
  // public IDictionary<string, string> Filter { get; set; }
  // public SortOrder SortOrder { get; set; }
}

class Message {
  id: number;
  text: string;
  employee: Employee;
  rowVersion: string;
}
