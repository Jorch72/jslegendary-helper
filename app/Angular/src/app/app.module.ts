import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { CustomMaterialModule } from './custom-material/custom-material.module';

import { AppComponent } from './app.component';
import { VillainComponent } from './villain/villain.component';


@NgModule({
  declarations: [
    AppComponent,
    VillainComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CustomMaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
