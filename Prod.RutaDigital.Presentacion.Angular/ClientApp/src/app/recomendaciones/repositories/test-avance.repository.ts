import { Injectable } from '@angular/core';
import { TestAvanceService } from '../services/test-avance.service';

@Injectable({
  providedIn: 'root',
})
export class TestAvanceRepository {
  constructor(private testAvanceService: TestAvanceService) {}
}
