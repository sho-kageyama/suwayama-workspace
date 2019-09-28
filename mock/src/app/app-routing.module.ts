import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {LoginComponent} from './login/login.component'
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
import { ItemComponent } from './details/item/item.component';
import { CashRegisterMonthComponent } from './details/cash-register-month/cash-register-month.component';
import { TagDailyComponent } from './details/tag-daily/tag-daily.component';
import { MoneyFlowMonthComponent } from './details/money-flow-month/money-flow-month.component';
import { DeleteHistoryDetailsComponent } from './details/delete-history-details/delete-history-details.component';
import { PrintHistoryDetailsComponent } from './details/print-history-details/print-history-details.component';


const routes: Routes = [
  {path: '', component: LoginComponent},
  {path: 'menu/barance-statement', component: BaranceStatementComponent},
  {path: 'menu/summary', component: SummaryComponent},
  {path: 'menu/kyast', component: KyastComponent},
  {path: 'menu/cash-register', component: CashRegisterComponent},
  {path: 'menu/daily-report', component: DailyReportComponent},
  {path: 'menu/prodacts', component: ProdactTotalizationComponent},
  {path: 'menu/stuff', component: StuffComponent},
  {path: 'menu/tags', component: TagTotalizationComponent},
  {path: 'tag/delete-history', component: DeleteHistoryComponent},
  {path: 'tag/deposit-summary', component: DepositSummaryComponent},
  {path: 'tag/items', component: ItemSummaryComponent},
  {path: 'tag/kyast-management', component: KyastManagementComponent},
  {path: 'tag/memo-summary', component: MemoSummaryComponent},
  {path: 'tag/money-flow', component: MoneyFlowComponent},
  {path: 'tag/print-history', component: PrintHistoryComponent},
  {path: 'tag/salary-summary', component: SalarySummaryComponent},
  {path: 'tag/store-setting', component: StoreSettingComponent},
  {path: 'tag/stuff-management', component: StuffManagementComponent},
  {path: 'tag/tag-summary', component: TagSummaryComponent},
  {path: 'tag/time-card', component: TimeCardComponent},
  {path: 'edit/expese-regist', component: ExpenseRegistrationComponent},
  {path: 'edit/deposit-regist', component: DepositItemRegistrationComponent},
  {path: 'edit/deposit-edit/:name', component: DepositItemEditComponent},
  {path: 'edit/memo-edit', component: MemoEditComponent},
  {path: 'edit/money-flow', component: MoneyFlowEditComponent},
  {path: 'edit/payday-regist', component: PaydayRegistrationComponent},
  {path: 'edit/salary-regist', component: SalaryItemRegistrationComponent},
  {path: 'edit/salary-edit', component: SalaryEditComponent},
  {path: 'edit/stuff-regist', component: StuffRegistrationComponent},
  {path: 'details/kyast', component: KyastDetailsComponent},
  {path: 'details/stuff', component: StuffDetailsComponent},
  {path: 'details/kyast-management', component: KyastManagementDetailsComponent},
  {path: 'details/item-totalization', component: ItemComponent},
  {path: 'details/cash-register-month', component: CashRegisterMonthComponent},
  {path: 'details/tag-daily', component: TagDailyComponent},
  {path: 'details/delete-history', component: DeleteHistoryDetailsComponent},
  {path: 'details/print-history', component: PrintHistoryDetailsComponent},
  {path: 'details/money-flow-month', component: MoneyFlowMonthComponent},
  {path: '**', redirectTo: '/'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
