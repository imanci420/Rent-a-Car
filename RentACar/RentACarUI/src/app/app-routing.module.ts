import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './components/admin-pages/admin/admin.component';
import { CarAdministrationComponent } from './components/admin-pages/car-administration/car-administration.component';
import { CityCreationComponent } from './components/admin-pages/city-administration/city-creation/city-creation.component';
import { CityEditingComponent } from './components/admin-pages/city-administration/city-editing/city-editing.component';
import { CityAdministrationComponent } from './components/admin-pages/city-administration/city-main-page/city-administration.component';
import { MarkCreationComponent } from './components/admin-pages/mark-administration/mark-creation/mark-creation.component';
import { MarkEditingComponent } from './components/admin-pages/mark-administration/mark-editing/mark-editing.component';
import { MarkAdministrationComponent } from './components/admin-pages/mark-administration/mark-main-page/mark-administration.component';
import { LoginComponent } from './components/login/login.component';
import { SearchComponent } from './components/menu/search/search.component';
import { RegisterCustomerComponent } from './components/register-customer/register-customer.component';
import { AuthGuard } from './services/auth.guard';
import { UserAuthGuard } from './services/user-auth.guard';


const routes: Routes = [
  { path: 'register/customer', component: RegisterCustomerComponent },
  { path: 'login', component: LoginComponent },
  
  { path: 'search', component: SearchComponent, canActivate: [UserAuthGuard]},

  { path: 'admin/car', component: CarAdministrationComponent, canActivate: [AuthGuard]},
  
  { path: 'admin/city', component: CityAdministrationComponent, canActivate: [AuthGuard]},
  { path: 'admin/city/create', component: CityCreationComponent, canActivate: [AuthGuard]},
  { path: 'admin/city/details/:id', component: CityEditingComponent, canActivate: [AuthGuard]},

  { path: 'admin/mark', component: MarkAdministrationComponent, canActivate: [AuthGuard]},
  { path: 'admin/mark/create', component: MarkCreationComponent, canActivate: [AuthGuard]},
  { path: 'admin/mark/details/:id', component: MarkEditingComponent, canActivate: [AuthGuard]},
  { path: 'admin', component: AdminComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    FormsModule  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
