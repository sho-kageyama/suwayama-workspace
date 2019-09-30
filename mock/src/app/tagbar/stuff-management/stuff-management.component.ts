import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { ConfirmDialogComponent } from '../../tools/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-stuff-management',
  templateUrl: './stuff-management.component.html',
  styleUrls: ['./stuff-management.component.css']
})
export class StuffManagementComponent implements OnInit {

  constructor(
    private dialog: MatDialog
  ) { }

  ngOnInit() {
  }

  edit(name:string) {
    let dialogRef = this.dialog.open(ConfirmDialogComponent,{
      width:'500px',
      data : {
        title: '氏名変更',
        name: name
      }
    });
    dialogRef.afterClosed().subscribe(res => {
      if(res == null){
        alert('更新に失敗しました。');
      }else{
      }
    });
  }

  stuffDel() {
    if(confirm('ボーイを削除します。よろしいですか？')){
      
    }
  }
}
