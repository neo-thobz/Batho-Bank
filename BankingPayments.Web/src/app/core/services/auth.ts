
import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

import { API_CONFIG } from '../config/api.config';

export interface LoginRequest {
  email: string;
  password: string;
}

export interface LoginResponse {
  accessToken: string;
  expiresAtUtc: string;
}

export interface CurrentUser {
  userId: string;
  email: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly http = inject(HttpClient);

  private readonly tokenKey = 'banking_access_token';

  login(credentials: LoginRequest): Observable<LoginResponse> {
    return this.http
      .post<LoginResponse>(
        `${API_CONFIG.baseUrl}/auth/login`,
        credentials
      )
      .pipe(
        tap(response => {
          localStorage.setItem(
            this.tokenKey,
            response.accessToken
          );
        })
      );
  }

  getCurrentUser(): Observable<CurrentUser> {
    const token = this.getToken();

    return this.http.get<CurrentUser>(
      `${API_CONFIG.baseUrl}/auth/me`,
      {
        headers: {
          Authorization: `Bearer ${token}`
        }
      }
    );
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  logout(): void {
    localStorage.removeItem(this.tokenKey);
  }
}
