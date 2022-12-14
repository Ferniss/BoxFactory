import { Component, OnInit } from '@angular/core';
import {customAxios, HttpService} from "../../service/http.service";
import {faBoxOpen} from "@fortawesome/free-solid-svg-icons"

@Component({
  selector: 'app-box',
  templateUrl: './box.component.html',
  styleUrls: ['./box.component.scss']
})
export class BoxComponent implements OnInit {
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


  async triggerEdit(name: string, price: number, description: string){
    this.editName = name
    this.editPrice = price
    this.editDescription = description
  }
}
