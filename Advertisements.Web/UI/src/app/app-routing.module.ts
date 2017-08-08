import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RegistrationComponent }   from './registration-component/registration.component';
import { StartComponent } from './start-component/start.component';

const routes: Routes = [
  { path: '', redirectTo: '/registration', pathMatch: 'full' },
  { path: 'start', component: StartComponent },
  { path: 'registration',  component: RegistrationComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}