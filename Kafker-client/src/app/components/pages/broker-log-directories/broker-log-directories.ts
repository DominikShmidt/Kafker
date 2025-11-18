import { Component, inject } from '@angular/core';
import { kafkerTableDirective } from '@app/directives/kafker-table/kafker-table';
import { BrokerDetailsStore } from '@app/store/broker-details/broker-details-store';

@Component({
  selector: 'app-broker-log-directories',
  imports: [kafkerTableDirective],
  templateUrl: './broker-log-directories.html',
})
export class BrokerLogDirectories {
  store = inject(BrokerDetailsStore);
}
