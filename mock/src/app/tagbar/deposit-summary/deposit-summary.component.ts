import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-deposit-summary',
  templateUrl: './deposit-summary.component.html',
  styleUrls: ['./deposit-summary.component.css']
})
export class DepositSummaryComponent implements OnInit {

  constructor(
    private router : Router
  ) { }

  ngOnInit() {
  }

  edit(text:string){
    this.router.navigate(['/edit/deposit-edit/'+ text +'']);
  }

  depositDel(number:number){
    if(confirm('test'+number+'を削除します。よろしいですか？')){
      
    }
  }
}
