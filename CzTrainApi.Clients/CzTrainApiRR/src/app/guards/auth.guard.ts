import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, UrlTree, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/internal/Observable';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        // Vergleicht die Rollenangabe in der Session mit der in der Authentifizierung 'auth'.
        const benoetigteRolle = route.data['rolle'];
        if (benoetigteRolle) {
            const besitzendeRolle = sessionStorage.getItem('rolle');

            if (benoetigteRolle !== besitzendeRolle) {
                alert('Ihnen fehlt die benötigte Rolle!');
                return false;
            }
        }

        // Holt den Token aus dem SessionStorage und prüft diesen auf vorhandensein
        const token = sessionStorage.getItem('token');
        if (token) {
            return true;
        } else {
            // Wenn der Token felht, dann wir man auf die LoginSeite geleitet
            this.router.navigate(['/login']);
            return false;
        }
    }
}