import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { TokenService } from './token.service';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {

    constructor(private router: Router, private tokenService: TokenService) { }

    canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        const isAuthorized = this.checkIsAuthrorized();

        if (isAuthorized) return true;

        this.router.navigate(['login']);
        return false;
    }

    checkIsAuthrorized(): boolean {
        const isTokenValid = this.tokenService.isTokenValid();
        return isTokenValid;
    }
}