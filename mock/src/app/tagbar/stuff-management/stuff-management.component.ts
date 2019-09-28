import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-stuff-management',
  templateUrl: './stuff-management.component.html',
  styleUrls: ['./stuff-management.component.css']
})
export class StuffManagementComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  stuffDel() {
    if(confirm('ボーイを削除します。よろしいですか？')){
      
    }
  }
}
