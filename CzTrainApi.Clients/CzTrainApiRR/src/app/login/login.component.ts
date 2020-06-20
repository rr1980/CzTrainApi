import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})

export class LoginComponent {
    // ToDo: Hier muss dann noch eine Lösung über die Datenbank mit Verschlüsselung rein
    benutzer: any = {
        beutzername: '',
        passwort: ''
    }

    laedNoch: Boolean = false;
    fehlerText: String = '';

    constructor(private router: Router, private authService: AuthService) {

    }
    onClickLogin() {

        if (this.benutzer.beutzername !== '' && this.benutzer.passwort !== '') {
            this.laedNoch = true;
            this.authService.login(this.benutzer.beutzername, this.benutzer.passwort).subscribe(response => {
                this.router.navigate(['/intern']);
                this.laedNoch = false;
            }, error => {
                if(error.status === 401){
                    this.fehlerText = "Benutze oder Passwort falsch!";
                }

                this.laedNoch = false;
            });
        } else {
            this.fehlerText = "Es fehlt Benutzer und Passwort!";
        }
    }
}