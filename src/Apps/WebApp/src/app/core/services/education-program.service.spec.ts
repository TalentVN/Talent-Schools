import { TestBed } from '@angular/core/testing';

import { EducationProgramService } from './education-program.service';

describe('EducationProgramService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EducationProgramService = TestBed.get(EducationProgramService);
    expect(service).toBeTruthy();
  });
});
