import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MajorsAdminComponent } from './majors-admin.component';

describe('MajorsAdminComponent', () => {
  let component: MajorsAdminComponent;
  let fixture: ComponentFixture<MajorsAdminComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MajorsAdminComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MajorsAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
