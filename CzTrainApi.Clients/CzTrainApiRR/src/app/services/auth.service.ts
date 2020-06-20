import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { ApiEndpoints } from '../api.endpoints';

@Injectable()
export class AuthService {

    constructor(private http: HttpClient) {
    }

    login(username: string, passwort: string) {
        return this.http.post<any>(ApiEndpoints.Token.Get, { user: username, password: passwort })
            .pipe(map(response => {
                console.debug('response', response)
                sessionStorage.setItem('token', response.token);
                sessionStorage.setItem('rolle', response.rolle);
                return response;
            }));
    }
}
