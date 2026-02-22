import { Component, computed, inject, OnInit, signal } from '@angular/core';
import { MemberService } from '../../../core/services/member-service';
import {
  ActivatedRoute,
  NavigationEnd,
  Router,
  RouterLink,
  RouterLinkActive,
  RouterOutlet,
} from '@angular/router';
import { Member } from '../../../types/Member';
import { filter, Observable } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { AgePipe } from '../../../core/pipes/age-pipe';
import { AccountService } from '../../../core/services/account-service';

@Component({
  selector: 'app-member-detailed',
  imports: [RouterLink, RouterLinkActive, RouterOutlet, AgePipe],
  templateUrl: './member-detailed.html',
  styleUrl: './member-detailed.css',
})
export class MemberDetailed implements OnInit {
  private accountService = inject(AccountService);
  private route = inject(ActivatedRoute);
  protected memberService = inject(MemberService);

  private router = inject(Router);
  protected title = signal<string | undefined>('Profile');
  protected isCurrentUser = computed(
    () => this.accountService.CurrentUser()?.id === this.route.snapshot.paramMap.get('id')
  );

  ngOnInit(): void {

    this.title.set(this.route.firstChild?.snapshot?.title || 'Profile');
    this.router.events.pipe(filter((event) => event instanceof NavigationEnd)).subscribe({
      next: () => {
        this.title.set(this.route.firstChild?.snapshot?.title || 'Profile');
      },
    });
  }
}
