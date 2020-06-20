import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from "@angular/common/http";
import { Observable } from "rxjs/internal/Observable";
import { catchError } from "rxjs/operators";
import { Router } from "@angular/router";
import { throwError } from "rxjs";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    constructor(private router: Router) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(catchError(err => {

            if (!req.url.endsWith('Token/GetToken')) {
                if (err.status === 401) {
                    console.debug("eeeee", req);
                    sessionStorage.removeItem('token');
                    this.router.navigate(['/login']);
                }
                else {
                    return throwError(err);
                }

            }
            else {
                return throwError(err);
            }
        }));
    }
}