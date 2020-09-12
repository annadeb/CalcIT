import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChildrenDosesComponent } from './children-doses.component';

describe('ChildrenDosesComponent', () => {
  let component: ChildrenDosesComponent;
  let fixture: ComponentFixture<ChildrenDosesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChildrenDosesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChildrenDosesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
