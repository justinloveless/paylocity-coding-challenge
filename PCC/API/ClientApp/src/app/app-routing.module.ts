import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./components/home/home.component";
import {ApiTestsComponent} from "./components/api-tests/api-tests.component";

const routes: Routes = [
  {path: "", component: HomeComponent},
  {path: "tests", component: ApiTestsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
