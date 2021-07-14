import { TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [
        AppComponent
      ],
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'RpsGameAngular'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('Marks SuperCool Demo');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(AppComponent);//create the fixture that IS the entire component with all files
    fixture.detectChanges();// run a change detection cycle
    const compiled = fixture.nativeElement;// get the whole document
    expect(compiled.querySelector('#demoId').textContent).toContain('Marks SuperCool Demo app is running!');
  });
});
