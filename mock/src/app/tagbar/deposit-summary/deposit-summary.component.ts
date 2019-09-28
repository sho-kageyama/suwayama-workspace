import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-deposit-summary',
  templateUrl: './deposit-summary.component.html',
  styleUrls: ['./deposit-summary.component.css']
})
export class DepositSummaryComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  depositDel(number:number){
    if(confirm('test'+number+'を削除します。よろしいですか？')){
      
    }
  }
}
