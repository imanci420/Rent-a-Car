import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterCustomerComponent } from './components/register-customer/register-customer.component';
import { LoginComponent } from './components/login/login.component';
import { SearchComponent } from './components/menu/search/search.component';
import { MenuComponent } from './components/menu/menu/menu.component';
import { AdminComponent } from './components/admin-pages/admin/admin.component';
import { CarAdministrationComponent } from './components/admin-pages/car-administration/car-administration.component';
import { CityCreationComponent } from './components/admin-pages/city-administration/city-creation/city-creation.component';
import { CityEditingComponent } from './components/admin-pages/city-administration/city-editing/city-editing.component';
import { CityAdministrationComponent } from './components/admin-pages/city-administration/city-main-page/city-administration.component';
import { MarkAdministrationComponent } from './components/admin-pages/mark-administration/mark-main-page/mark-administration.component';
import { MarkEditingComponent } from './components/admin-pages/mark-administration/mark-editing/mark-editing.component';
import { MarkCreationComponent } from './components/admin-pages/mark-administration/mark-creation/mark-creation.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterCustomerComponent,
    LoginComponent,
    SearchComponent,
    MenuComponent,
    AdminComponent,
    CarAdministrationComponent,
    MarkAdministrationComponent,
    CityAdministrationComponent,
    CityCreationComponent,
    CityEditingComponent,
    MarkEditingComponent,
    MarkCreationComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
