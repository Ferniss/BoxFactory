import {Component, OnInit} from '@angular/core';
import {faBoxOpen} from "@fortawesome/free-solid-svg-icons"
import {faBox} from "@fortawesome/free-solid-svg-icons"
import {NgbOffcanvas, NgbPanelChangeEvent, OffcanvasDismissReasons} from "@ng-bootstrap/ng-bootstrap";
import {angularFontawesomeVersion} from "@fortawesome/angular-fontawesome/schematics/ng-add/versions";
import {Observable} from "rxjs";
import * as url from "url";
import {customAxios, HttpService} from "../service/http.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  productName: string = "";
  productPrice: number = 0;
  productDescription: string = "";
  products: any[] = [];
  faBoxOpen = faBoxOpen;
  editName: string = "";
  editPrice: number = 0;
  editDescription: string = "";


  constructor(private http: HttpService) {

  }

  async ngOnInit() {
    const products = await this.http.getProducts();
    this.products = products;
  }

  async createProduct() {
    let dto = {
      price: this.productPrice,
      name: this.productName,
      description: this.productDescription,
    }

    const result = await this.http.createProduct(dto);
    console.log(result)
    this.products.push(result)
  }

  async deleteProduct(id: any) {
    const product = await this.http.deleteProduct(id);
    this.products = this.products.filter(p => p.id != product.id)
  }

  async updateProduct(dto: { id: any; productName: any; productPrice: any; productDescription: any }){
    const httpResult = await customAxios.put("")
    console.log(httpResult.data);
  }

  async triggerEdit(name: string, price: number, description: string){
    this.editName = name
    this.editPrice = price
    this.editDescription = description
  }
}




