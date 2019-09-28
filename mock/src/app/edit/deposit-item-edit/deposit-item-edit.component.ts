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
    private router : ActivatedRoute
  ) { }

  ngOnInit() {
    const text = this.router.snapshot.queryParamMap.get('test2');
    alert(text);
    this.router.queryParams.subscribe(
      params => {
        alert(params['name']);
        console.log(params);
      }
    )
  }

}
