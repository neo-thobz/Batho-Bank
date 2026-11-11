
import { Component, inject, signal } from '@angular/core';
import { ReactiveFormsModule, FormControl, FormGroup, Validators } from '@angular/forms';
import { JsonPipe } from '@angular/common';

import { AuthService } from '../../../../core/services/auth';
import { AppButtonComponent } from '../../../../shared/components/app-button/app-button';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    JsonPipe,
    AppButtonComponent
  ],
  templateUrl: './login.html'
})
export class LoginComponent {
  private readonly authService = inject(AuthService);

  isLoading = signal(false);
  errorMessage = signal('');
  currentUser = signal<unknown | null>(null);

  loginForm = new FormGroup({
    email: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required, Validators.email]
    }),
    password: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required]
    })
  });

  onSubmit(): void {
    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    this.isLoading.set(true);
    this.errorMessage.set('');
    this.currentUser.set(null);

    this.authService.login(this.loginForm.getRawValue()).subscribe({
      next: () => {
        this.authService.getCurrentUser().subscribe({
          next: user => {
            this.currentUser.set(user);
            this.isLoading.set(false);
          },
          error: () => {
            this.errorMessage.set(
              'Login succeeded, but retrieving your user profile failed.'
            );
            this.isLoading.set(false);
          }
        });
      },
      error: error => {
        this.errorMessage.set(
          error.status === 401
            ? 'Invalid email address or password.'
            : 'Unable to connect to the banking API. Please try again.'
        );

        this.isLoading.set(false);
      }
    });
  }

  logout(): void {
    this.authService.logout();
    this.currentUser.set(null);
    this.loginForm.reset();
    this.errorMessage.set('');
  }
}


// import { Component } from '@angular/core';

// @Component({
//   selector: 'app-login',
//   imports: [],
//   templateUrl: './login.html',
//   styleUrl: './login.css',
// })
// export class Login {

// }
