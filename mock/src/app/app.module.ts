import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatDialogModule } from '@angular/material/dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { MenuComponent } from './menu/menu.component';
import { TagbarComponent } from './tagbar/tagbar.component';
import { BaranceStatementComponent } from './menu/barance-statement/barance-statement.component';
import { CashRegisterComponent } from './menu/cash-register/cash-register.component';
import { DailyReportComponent } from './menu/daily-report/daily-report.component';
import { ProdactTotalizationComponent } from './menu/prodact-totalization/prodact-totalization.component';
import { StuffComponent } from './menu/stuff/stuff.component';
import { SummaryComponent } from './menu/summary/summary.component';
import { TagTotalizationComponent } from './menu/tag-totalization/tag-totalization.component';
import { DeleteHistoryComponent } from './tagbar/delete-history/delete-history.component';
import { DepositSummaryComponent } from './tagbar/deposit-summary/deposit-summary.component';
import { ItemSummaryComponent } from './tagbar/item-summary/item-summary.component';
import { KyastManagementComponent } from './tagbar/kyast-management/kyast-management.component';
import { MemoSummaryComponent } from './tagbar/memo-summary/memo-summary.component';
import { MoneyFlowComponent } from './tagbar/money-flow/money-flow.component';
import { PrintHistoryComponent } from './tagbar/print-history/print-history.component';
import { SalarySummaryComponent } from './tagbar/salary-summary/salary-summary.component';
import { StoreSettingComponent } from './tagbar/store-setting/store-setting.component';
import { StuffManagementComponent } from './tagbar/stuff-management/stuff-management.component';
import { TagSummaryComponent } from './tagbar/tag-summary/tag-summary.component';
import { TimeCardComponent } from './tagbar/time-card/time-card.component';
import { ExpenseRegistrationComponent } from './edit/expense-registration/expense-registration.component';
import { DepositItemRegistrationComponent } from './edit/deposit-item-registration/deposit-item-registration.component';
import { DepositItemEditComponent } from './edit/deposit-item-edit/deposit-item-edit.component';
import { MemoEditComponent } from './edit/memo-edit/memo-edit.component';
import { MoneyFlowEditComponent } from './edit/money-flow-edit/money-flow-edit.component';
import { PaydayRegistrationComponent } from './edit/payday-registration/payday-registration.component';
import { SalaryItemRegistrationComponent } from './edit/salary-item-registration/salary-item-registration.component';
import { SalaryEditComponent } from './edit/salary-edit/salary-edit.component';
import { StuffRegistrationComponent } from './edit/stuff-registration/stuff-registration.component';
import { KyastDetailsComponent } from './details/kyast-details/kyast-details.component';
import { StuffDetailsComponent } from './details/stuff-details/stuff-details.component';
import { KyastManagementDetailsComponent } from './details/kyast-management-details/kyast-management-details.component';
import { KyastComponent } from './menu/kyast/kyast.component';
import { RangePipe } from './tools/range-pipe';
import { ItemComponent } from './details/item/item.component';
import { CashRegisterMonthComponent } from './details/cash-register-month/cash-register-month.component';
import { TagDailyComponent } from './details/tag-daily/tag-daily.component';
import { MoneyFlowMonthComponent } from './details/money-flow-month/money-flow-month.component';
import { DeleteHistoryDetailsComponent } from './details/delete-history-details/delete-history-details.component';
import { PrintHistoryDetailsComponent } from './details/print-history-details/print-history-details.component';
import { ConfirmDialogComponent } from './tools/confirm-dialog/confirm-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    MenuComponent,
    TagbarComponent,
    BaranceStatementComponent,
    CashRegisterComponent,
    DailyReportComponent,
    ProdactTotalizationComponent,
    StuffComponent,
    SummaryComponent,
    TagTotalizationComponent,
    DeleteHistoryComponent,
    DepositSummaryComponent,
    ItemSummaryComponent,
    KyastManagementComponent,
    MemoSummaryComponent,
    MoneyFlowComponent,
    PrintHistoryComponent,
    SalarySummaryComponent,
    StoreSettingComponent,
    StuffManagementComponent,
    TagSummaryComponent,
    TimeCardComponent,
    ExpenseRegistrationComponent,
    DepositItemRegistrationComponent,
    DepositItemEditComponent,
    MemoEditComponent,
    MoneyFlowEditComponent,
    PaydayRegistrationComponent,
    SalaryItemRegistrationComponent,
    SalaryEditComponent,
    StuffRegistrationComponent,
    KyastDetailsComponent,
    StuffDetailsComponent,
    KyastManagementDetailsComponent,
    KyastComponent,
    RangePipe,
    ItemComponent,
    CashRegisterMonthComponent,
    TagDailyComponent,
    MoneyFlowMonthComponent,
    DeleteHistoryDetailsComponent,
    PrintHistoryDetailsComponent,
    ConfirmDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatDialogModule,
    BrowserAnimationsModule
  ],
  entryComponents: [
    ConfirmDialogComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
