import {
  ApplicationConfig,
  provideBrowserGlobalErrorListeners,
  provideZoneChangeDetection,
} from '@angular/core';
import { provideRouter, TitleStrategy } from '@angular/router';
import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';
import { kafkerTitleStrategy } from './services/kafker-title-strategy/kafker-title-strategy';
import { LoggerService } from './services/logger/logger';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(),
    { provide: TitleStrategy, useClass: kafkerTitleStrategy },
    { provide: LoggerService, useFactory: () => new LoggerService(environment.logLevel) },
  ],
};
