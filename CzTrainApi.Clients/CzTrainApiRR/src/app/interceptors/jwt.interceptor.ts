import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from "@angular/common/http";
import { Observable } from "rxjs/internal/Observable";

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor() {
    }

    // Check wenn alles Fertig ist ob es einen Token im SessionStorage gibt und wenn ja wird der Header überarbeitet
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // Holt einen Token aus der SessionStorage sofern vorhanden.
        const token = sessionStorage.getItem('token');
        // Prüft ob ein Token vorhanden ist
        if(token){
            // Hier Clonen wir den HTTP-Request, damit wir diesen Überarbeiten können und den Token im Header hinzufügen
            req = req.clone(
                {
                    // Hier wird der Token in den Header gesetzt
                    setHeaders: {
                        Authorization: 'Bearer ' + token
                    }
                }
            );
        }
        // Gibt den HTTP-Request zurück, entweder mit oder ohne Token
        return next.handle(req);
    }
}