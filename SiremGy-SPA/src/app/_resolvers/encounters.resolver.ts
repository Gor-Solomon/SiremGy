import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { UserModel } from '../models/userModel';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/Alertify.service';
import { catchError } from 'rxjs/operators';
import { templateJitUrl } from '@angular/compiler';
import { of, Observable } from 'rxjs';

@Injectable()
export class EncountersResolver implements Resolve<UserModel[]> {


    constructor(private userServie: UserService,
                private router: Router,
                private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<UserModel[]>  {

        return this.userServie.getUsers().pipe(
            catchError(error => {
                this.alertify.error('Problem loading data');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }

}