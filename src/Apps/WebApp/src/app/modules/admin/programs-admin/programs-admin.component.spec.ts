import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProgramsAdminComponent } from './programs-admin.component';

describe('ProgramsAdminComponent', () => {
  let component: ProgramsAdminComponent;
  let fixture: ComponentFixture<ProgramsAdminComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProgramsAdminComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProgramsAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
