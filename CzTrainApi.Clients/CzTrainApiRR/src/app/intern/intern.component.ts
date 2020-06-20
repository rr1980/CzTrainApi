import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiEndpoints } from '../api.endpoints';

@Component({
  selector: 'app-login',
  templateUrl: './intern.component.html',
  styleUrls: ['./intern.component.scss']
})
export class InternComponent implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  go(){
    this.http.post<any>(ApiEndpoints.Intern.Katalog.Anrede.GettAll, null).subscribe(response => {
      console.debug('response', response);
    })
  }
}
