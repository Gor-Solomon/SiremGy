import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { EncountersComponent } from './encounters/encounters.component';
import { MessagesComponent } from './messages/messages.component';
import { LikesComponent } from './likes/likes.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    {path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'encounters', component: EncountersComponent},
            {path: 'messages', component: MessagesComponent},
            {path: 'likes', component: LikesComponent}
        ]
    },
    {path: '**', redirectTo: '', pathMatch: 'full'}
];
