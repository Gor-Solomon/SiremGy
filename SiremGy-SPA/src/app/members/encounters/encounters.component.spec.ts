/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { EncountersComponent } from './encounters.component';

describe('EncountersComponent', () => {
  let component: EncountersComponent;
  let fixture: ComponentFixture<EncountersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EncountersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EncountersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
