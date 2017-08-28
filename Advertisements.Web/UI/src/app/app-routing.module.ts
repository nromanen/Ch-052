import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent }   from './login-component/login.component';
import { StartComponent } from './start-component/start.component';
import { FeedbackComponent } from './feedback-component/feedback.component';
import { UsersAdvComponent } from './usersAdv-component/usersAdv.component';
import { EditAdvComponent } from './editAdv-component/editAdv.component';
import { CreateAdvComponent } from './createAdv-component/createAdv.component';
import { AdvInfoComponent } from './advInfo-component/advInfo.component';

const routes: Routes = [
  { path: '', redirectTo: '/start', pathMatch: 'full' },
  { path: 'start', component: StartComponent },
  { path: 'login',  component: LoginComponent },
  { path: 'myAdv', component: UsersAdvComponent },
  { path: 'feedback',  component: FeedbackComponent },
  { path: 'info/:id', component: AdvInfoComponent },
  { path: 'edit/:id', component: EditAdvComponent },
  { path: 'create', component: CreateAdvComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  
  exports: [ RouterModule ]
})
export class AppRoutingModule {}