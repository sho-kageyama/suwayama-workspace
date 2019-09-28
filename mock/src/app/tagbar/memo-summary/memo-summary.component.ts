import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-memo-summary',
  templateUrl: './memo-summary.component.html',
  styleUrls: ['./memo-summary.component.css']
})
export class MemoSummaryComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  memoDel(){
    if(confirm('testを削除します。よろしいですか?')){
      
    }
  }
}
