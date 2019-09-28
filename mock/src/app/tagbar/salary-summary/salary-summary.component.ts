import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-salary-summary',
  templateUrl: './salary-summary.component.html',
  styleUrls: ['./salary-summary.component.css']
})
export class SalarySummaryComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  salaryDell(){
    if(confirm('遅刻を削除します。よろしいですか?')){
      
    }
  }
}
