import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

<<<<<<< HEAD
import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

=======
import 'jquery';
import 'bootstrap/dist/js/bootstrap';
import 'bootstrap/dist/css/bootstrap.css';
import 'font-awesome/css/font-awesome.css'

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

import { LoginService } from './app/services/login.service';

>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
if (environment.production) {
  enableProdMode();
}

<<<<<<< HEAD
=======

>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
platformBrowserDynamic().bootstrapModule(AppModule);
