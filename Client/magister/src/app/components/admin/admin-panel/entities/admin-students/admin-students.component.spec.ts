import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminStudentsComponent } from './admin-students.component';

describe('AdminStudentsComponent', () => {
  let component: AdminStudentsComponent;
  let fixture: ComponentFixture<AdminStudentsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminStudentsComponent]
    });
    fixture = TestBed.createComponent(AdminStudentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
