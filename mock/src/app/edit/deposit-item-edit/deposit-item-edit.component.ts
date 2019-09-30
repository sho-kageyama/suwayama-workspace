import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router'

@Component({
  selector: 'app-deposit-item-edit',
  templateUrl: './deposit-item-edit.component.html',
  styleUrls: ['./deposit-item-edit.component.css']
})
export class DepositItemEditComponent implements OnInit {

  name:string;

  constructor(
    private route : ActivatedRoute
  ) { }

  ngOnInit() {
    const text = this.route.snapshot.paramMap.get('name');
    this.name = text;
  }

}
