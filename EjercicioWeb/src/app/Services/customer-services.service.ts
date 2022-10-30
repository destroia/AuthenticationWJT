import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Customer } from '../Models/customer';
@Injectable({
  providedIn: 'root'
})
export class CustomerServicesService {

  constructor(private http: HttpClient) { }

  public GetCustomers(page: number, row: number): Observable<Customer[]>{

    return this.http.get<Customer[]>(environment.urlServices + "Customer/GetPag/" + page + "/" + row);
  }
}
