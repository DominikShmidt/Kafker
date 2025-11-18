import { Component, computed, inject, signal } from '@angular/core';
import { Search } from '@app/components/shared/search/search/search';
import { kafkerTableDirective } from '@app/directives/kafker-table/kafker-table';
import { BrokerDetailsStore } from '@app/store/broker-details/broker-details-store';
import { PageWrapper } from '@app/components/shared/page-wrapper/page-wrapper';

@Component({
  selector: 'app-broker-configs',
  imports: [kafkerTableDirective, Search, PageWrapper],
  templateUrl: './broker-configs.html',
})
export class BrokerConfigs {
  store = inject(BrokerDetailsStore);
  search = signal('');

  configs = computed(() => {
    const search = this.search().toLowerCase();
    const configs = this.store.collection();

    return configs?.filter((cfg) => cfg.name.toLowerCase().includes(search));
  });
}
