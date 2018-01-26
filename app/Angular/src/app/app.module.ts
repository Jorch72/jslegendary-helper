import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { CustomMaterialModule } from './custom-material/custom-material.module';

import { AppComponent } from './app.component';
import { PlayerComponent } from './player/player.component';
import { EditionComponent } from './edition/edition.component';
import { VillainComponent } from './villain/villain.component';
import { HeroComponent } from './hero/hero.component';

import { PlayerService } from './services/player.service';
import { EditionService } from './services/edition.service';
import { VillainService } from './services/villain.service';
import { HeroService } from './services/hero.service';
import { RulesComponent } from './rules/rules.component';


@NgModule({
  declarations: [
    AppComponent,
    PlayerComponent,
    VillainComponent,
    EditionComponent,
    HeroComponent,
    RulesComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    CustomMaterialModule
  ],
  providers: [
    PlayerService,
    EditionService,
    VillainService,
    HeroService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
