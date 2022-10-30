import { Component, OnInit } from '@angular/core';
import { Customer } from '../../Models/customer';
import { CustomerServicesService } from '../../Services/customer-services.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  constructor(private CustomerService: CustomerServicesService) { }

  CustomarList: Customer[];
  ngOnInit(): void {
    this.GetCustomersList(1, 20);
    
  }

  GetCustomersList(page: number, row: number) {
    this.CustomerService.GetCustomers(page, row)
      .subscribe(x => this.GetCustomersListReq(x), err => console.error(err));
  }
  GetCustomersListReq(x: Customer[]): void {
    if (x.length > 0) {
      this.CustomarList = x
      console.log(this.CustomarList)
      }
    }
}
