import { Injectable } from '@angular/core';
// import decode from 'jwt-decode';
import {tokenNotExpired} from 'angular2-jwt'
import { HttpRequest } from '@angular/common/http';
@Injectable()
export class AuthService {
  public getToken(): string {
     return localStorage.getItem('token');
   }
  public isAuthenticated(): boolean {
    // get the token
    const token = this.getToken();
    // return a boolean reflecting s
    // whether or not the token is expired
    return tokenNotExpired(null, token);
  }
  cachedRequests: Array<HttpRequest<any>> = [];
  public collectFailedRequest(request): void {
      this.cachedRequests.push(request);
    }
  public retryFailedRequests(): void {
      // retry the requests. this method can
      // be called after the token is refreshed
    }
}