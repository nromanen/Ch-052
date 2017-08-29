import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent }   from './login-component/login.component';
import { StartComponent } from './start-component/start.component';
import { FeedbackComponent } from './feedback-component/feedback.component';
import { UsersAdvComponent } from './usersAdv-component/usersAdv.component';
import { CategoryComponent } from './category-component/category.component';
import { TypeComponent } from './type-component/type.component';


const routes: Routes = [
  { path: '', redirectTo: '/type', pathMatch: 'full' },
  { path: 'start', component: StartComponent },
  { path: 'login',  component: LoginComponent },
  { path: 'myAdv', component: UsersAdvComponent },
  { path: 'feedback',  component: FeedbackComponent },
  { path: 'category',  component: CategoryComponent },
  { path: 'type',  component: TypeComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  
  exports: [ RouterModule ]
})
export class AppRoutingModule {}