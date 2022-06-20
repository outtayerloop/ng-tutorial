import { Component, Input, OnInit } from '@angular/core';
import { ValidationResult } from 'src/app/_models/validation-result';

@Component({
  selector: 'app-validation-errors',
  templateUrl: './validation-errors.component.html',
  styleUrls: ['./validation-errors.component.css']
})
export class ValidationErrorsComponent implements OnInit {
  @Input() errors !: ValidationResult[];

  ngOnInit(): void {}

}
