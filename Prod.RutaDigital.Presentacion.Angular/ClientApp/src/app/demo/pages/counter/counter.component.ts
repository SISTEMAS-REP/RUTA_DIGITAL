import { Component, OnInit } from '@angular/core';
import { ExtranetUser } from '../../../shared/interfaces/extranet-user';
import { CounterRepository } from '../../repositories/counter.repository.ts';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html',
})
export class CounterComponent implements OnInit {
  user: ExtranetUser;

  public currentCount = 0;

  constructor(private repository: CounterRepository) {}

  ngOnInit(): void {
    this.repository.getUser().subscribe((user) => {
      this.user = user;
    });
  }

  public incrementCounter() {
    this.currentCount++;
  }
}
