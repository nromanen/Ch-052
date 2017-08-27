import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent }   from './login-component/login.component';
import { StartComponent } from './start-component/start.component';
import { FeedbackComponent } from './feedback-component/feedback.component';
import { UsersAdvComponent } from './usersAdv-component/usersAdv.component';
import {RegistrationComponent} from './registration-component/registration.component'
const routes: Routes = [
  { path: '', redirectTo: '/start', pathMatch: 'full' },
  { path: 'start', component: StartComponent },
  { path: 'login',  component: LoginComponent },
  { path: 'myAdv', component: UsersAdvComponent },
  { path: 'feedback',  component: FeedbackComponent },
  {path: 'register', component: RegistrationComponent}
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  
  exports: [ RouterModule ]
})
export class AppRoutingModule {}