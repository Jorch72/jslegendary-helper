import { NgModule } from '@angular/core';
import { 
  MatButtonModule,
  MatCheckboxModule,
  MatCardModule,
  MatFormFieldModule,
  MatSelectModule,
  MatOptionModule
} from '@angular/material';

@NgModule({
  imports: [
    MatButtonModule,
    MatCheckboxModule,
    MatCardModule,
    MatFormFieldModule,
    MatSelectModule,
    MatOptionModule
  ],
  exports: [
    MatButtonModule,
    MatCheckboxModule,
    MatCardModule,
    MatFormFieldModule,
    MatSelectModule,
    MatOptionModule
  ]
})
export class CustomMaterialModule { }
