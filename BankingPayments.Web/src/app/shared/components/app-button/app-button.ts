
import { Component, input } from '@angular/core';

@Component({
  selector: 'app-button',
  standalone: true,
  templateUrl: './app-button.html'
})
export class AppButtonComponent {
  type = input<'button' | 'submit'>('button');
  disabled = input(false);
  loading = input(false);
  variant = input<'primary' | 'secondary'>('primary');

  buttonClasses(): string {
    const base =
      'inline-flex w-full items-center justify-center rounded-lg px-4 py-3 ' +
      'text-sm font-semibold transition-colors duration-200 ' +
      'focus:outline-none focus:ring-2 focus:ring-offset-2 ' +
      'disabled:cursor-not-allowed disabled:opacity-50';

    const variants = {
      primary:
        'bg-blue-600 text-white hover:bg-blue-700 focus:ring-blue-500',
      secondary:
        'border border-slate-300 bg-white text-slate-700 hover:bg-slate-50'
    };

    return `${base} ${variants[this.variant()]}`;
  }
}
