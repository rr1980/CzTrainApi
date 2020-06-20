import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { LoginComponent } from './login/login.component';
import { InternComponent } from './intern/intern.component';


const routes: Routes = [
  { path: '', redirectTo: 'intern', pathMatch: 'full' },
  { path: '*', redirectTo: 'intern', pathMatch: 'full' },
  {
    path: 'intern', component: InternComponent, canActivate: [AuthGuard], children: [
      // { path: '', redirectTo: 'personen', pathMatch: 'full' },
      // { path: '*', redirectTo: 'personen', pathMatch: 'full' },
      // {
      //   path: 'personen', component: PersonenComponent, children: [
      //     { path: '', redirectTo: 'suche', pathMatch: 'full' },
      //     { path: '*', redirectTo: 'suche', pathMatch: 'full' },
      //     { path: 'suche', component: PersonenSucheComponent },
      //     { path: 'bearbeiten/:id', component: PersonenBearbeitenComponent },
      //   ]
      // },
      // {
      //   path: 'pressemitteilungen', component: PressemitteilungenComponent, children: [
      //     { path: '', redirectTo: 'suche', pathMatch: 'full' },
      //     { path: '*', redirectTo: 'suche', pathMatch: 'full' },
      //     { path: 'suche', component: PressemitteilungenSucheComponent },
      //     { path: 'bearbeiten/:id', component: PressemitteilungenBearbeitenComponent },
      //   ]
      // },
      // {
      //   path: 'adminbereich', component: AdminbereichComponent, canActivate: [AuthGuard], data: { rolle: 'Admin' }, children: [
      //     { path: '', redirectTo: 'kataloge', pathMatch: 'full' },
      //     { path: '*', redirectTo: 'kataloge', pathMatch: 'full' },
      //     {
      //       path: 'kataloge', component: KatalogeComponent, children: [
      //         { path: '', redirectTo: 'anrede', pathMatch: 'full' },
      //         { path: '*', redirectTo: 'anrede', pathMatch: 'full' },
      //         {
      //           path: 'anrede', component: AnredeComponent, children: [
      //             { path: '', redirectTo: 'suche', pathMatch: 'full' },
      //             { path: '*', redirectTo: 'suche', pathMatch: 'full' },
      //             { path: 'suche', component: AnredeSucheComponent },
      //             { path: 'bearbeiten/:id', component: AnredeBearbeitenComponent },
      //           ]
      //         },
      //         {
      //           path: 'titel', component: TitelComponent, children: [
      //             { path: '', redirectTo: 'suche', pathMatch: 'full' },
      //             { path: '*', redirectTo: 'suche', pathMatch: 'full' },
      //             { path: 'suche', component: TitelSucheComponent },
      //             { path: 'bearbeiten/:id', component: TitelBearbeitenComponent },
      //           ]
      //         },
      //         {
      //           path: 'prioritaet', component: PrioritaetComponent, children: [
      //             { path: '', redirectTo: 'suche', pathMatch: 'full' },
      //             { path: '*', redirectTo: 'suche', pathMatch: 'full' },
      //             { path: 'suche', component: PrioritaetSucheComponent },
      //             { path: 'bearbeiten/:id', component: PrioritaetBearbeitenComponent },
      //           ]
      //         },
      //       ]
      //     },
      //     { path: 'benutzerverwaltung', component: BenutzerverwaltungComponent },
      //   ]
      // },
    ]
  },
  { path: 'login', component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
