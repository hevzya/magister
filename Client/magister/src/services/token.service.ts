import { Injectable } from "@angular/core";
import { JwtHelperService } from "@auth0/angular-jwt";

export const ACCESS_TOKEN: string = "access_token";
export const REFRESH_TOKEN: string = "refresh_token";

export interface Claims {
    aud?: string,
    exp?: string,
    role?: string,
    name?: string,
    userId?: string,
    iss?: string,
    jti?: string,
    email?: string,
} 

@Injectable({
    providedIn: 'root'
})
export class TokenService {

    decodedToken: any = null;

    constructor(private jwtHelperService: JwtHelperService) { }

    setToken(token: string): void {
        localStorage.setItem(ACCESS_TOKEN, token);
        this.decodedToken = this.jwtHelperService.decodeToken(token);
    }

    setRefreshToken(refreshToken: string): void {
        localStorage.setItem(REFRESH_TOKEN, refreshToken);
    }

    isTokenValid(): boolean {
        const token = this.getToken();
        return (token != null && !this.jwtHelperService.isTokenExpired(token));
    }

    getToken(): string | null {
        return localStorage.getItem(ACCESS_TOKEN);
    }

    getTokenPayload(): any {
        if (this.decodedToken == null) {
            const token = localStorage.getItem(ACCESS_TOKEN);
            if (token) {
                this.decodedToken = this.jwtHelperService.decodeToken(token);
            }
        }
        return this.decodedToken;
    }

    removeToken(): void {
        localStorage.removeItem(ACCESS_TOKEN);
        localStorage.removeItem(REFRESH_TOKEN);
    }

    getClaims(): Claims {
        if (this.decodedToken == null) {
            const token = localStorage.getItem(ACCESS_TOKEN);
            if (token) {
                this.decodedToken = this.jwtHelperService.decodeToken(token);
            }
        }
        

        return {
            aud: this.decodedToken['aud'],
            email: this.decodedToken['sub'],
            exp: this.decodedToken['exp'],
            iss: this.decodedToken['iss'],
            jti: this.decodedToken['jti'],
            name: this.decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'],
            role: this.decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'],
            userId: this.decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'],
        }
    }

}