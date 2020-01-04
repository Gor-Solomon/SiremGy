import { appRoutes } from './routes';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule, HAMMER_GESTURE_CONFIG, HammerGestureConfig} from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { LikesComponent } from './likes/likes.component';
import { MessagesComponent } from './messages/messages.component';
import { EncountersComponent } from './members/encounters/encounters.component';
import { MemberCardComponent } from './members/member-card/member-card.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';

import { AuthService } from './_services/auth.service';
import { ErroInterceptorProviders } from './_services/error.interceptor';

import { BsDropdownModule, TabsModule } from 'ngx-bootstrap';
import { NgxGalleryModule } from 'ngx-gallery';
import { MemberDetailResolver } from './_resolvers/member-detail.resolver';
import { EncountersResolver } from './_resolvers/encounters.resolver';
import { AlertifyService } from './_services/Alertify.service';
import { AuthGuard } from './_guards/auth.guard';
import { UserService } from './_services/user.service';


export function tokenGetterLocal() {
   return localStorage.getItem('token');
}

export class CustomHammerConfig extends HammerGestureConfig  {
   overrides = {
       pinch: { enable: false },
       rotate: { enable: false }
   };
}

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      LikesComponent,
      EncountersComponent,
      MessagesComponent,
      MemberCardComponent,
      MemberDetailComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BrowserAnimationsModule,
      NgxGalleryModule,
      BsDropdownModule.forRoot(),
      TabsModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      JwtModule.forRoot({
         config: {
            tokenGetter: tokenGetterLocal,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
      })
   ],
   providers: [
      AuthService,
      ErroInterceptorProviders,
      MemberDetailResolver,
      EncountersResolver,
      AlertifyService,
      AuthGuard,
      UserService,
      {
         provide: HAMMER_GESTURE_CONFIG,
         useClass: CustomHammerConfig
      }
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
