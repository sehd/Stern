import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../../services/auth/authentication.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private authService:AuthenticationService) { }

  ngOnInit(): void {
  }

  logout() {
    this.authService.logout();
    window.location.reload();
  }
}
