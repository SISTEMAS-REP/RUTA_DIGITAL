import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LocalStorageService {
  getAny(key: string): any {
    const value = localStorage.getItem(key) || {};
    return value;
  }

  get(key: string): Observable<any> {
    const value = localStorage.getItem(key);
    if (value) return of(value);
    return of(null);
  }

  set(name: string, value: string): void {
    localStorage.setItem(name, value);
  }

  remove(name: string): void {
    localStorage.removeItem(name);
  }
}
