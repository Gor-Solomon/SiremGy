import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { EncountersComponent } from './members/encounters/encounters.component';
import { MessagesComponent } from './messages/messages.component';
import { LikesComponent } from './likes/likes.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { EncountersResolver } from './_resolvers/encounters.resolver';
import { MemberDetailResolver } from './_resolvers/member-detail.resolver';

export const appRoutes: Routes = [
    {path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'encounters', component: EncountersComponent, resolve: { EncountersResolver}},
            {path: 'member/:id', component: MemberDetailComponent, resolve: {users: MemberDetailResolver}},
            {path: 'messages', component: MessagesComponent},
            {path: 'likes', component: LikesComponent}
        ]
    },
    {path: '**', redirectTo: '', pathMatch: 'full'}
];
