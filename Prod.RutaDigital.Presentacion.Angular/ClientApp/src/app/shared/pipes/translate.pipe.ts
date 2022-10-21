import { PipeTransform, Pipe, Injectable } from '@angular/core';
import { AppService } from '../services/app.service';

@Injectable()
@Pipe({
  name: 'translate',
})
export class TranslatePipe implements PipeTransform {
  constructor(private appService: AppService) {}

  transform(query: string): any {
    return this.appService.appData.content[query] || query;
  }
}
