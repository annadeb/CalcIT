import { Injectable } from '@angular/core';
// import decode from 'jwt-decode';
import {tokenNotExpired} from 'angular2-jwt'
import { HttpRequest } from '@angular/common/http';
@Injectable()
export class AuthService {
  public getToken(): string {
     //return localStorage.getItem('token');
     return 'asdasd'
   // return 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhc2Rhc2RhQGFzZC5wbCIsImp0aSI6IjAzMzNjYWJiLTM3OTktNDAyMC1iYWJiLWE2NDRiNDQzMWEwMyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiODZlYzAzMTAtZWFlNC00Yjk0LTk3ZGYtYWFhOTBmN2EwZDU4IiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJleHAiOjE1OTg0Mzc5MTcsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzUzIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzNTMifQ.CfrWSiAsvwhq0dgnWYsYBBq3y6f7yEbLSOO3QvS6u-M'
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