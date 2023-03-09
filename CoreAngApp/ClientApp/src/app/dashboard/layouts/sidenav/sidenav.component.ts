import { Component, OnInit, ViewChild, ElementRef, HostListener } from '@angular/core';

const WIDTH_FOR_RESPONSIVE = 1280;

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {
  isFixed = false;
  isOpen = true;

  @ViewChild('sidenav', { static: true }) sidenavElement!: ElementRef;

  @HostListener('window:resize', ['$event']) onResize(e: any) {
    this.changeToResponsiveViewIfNeed(e.target.innerWidth);
  }

  constructor() { }

  ngOnInit(): void {
    this.changeToResponsiveViewIfNeed(window.innerWidth);
    this.setMenusExperienceScripts();
  }

  setMenusExperienceScripts(): void {
    // your code here
  }

  toggle(): void {
    this.isOpen = !this.isOpen;
  }

  private changeToResponsiveViewIfNeed(windowsWidth: number): void {
    if (windowsWidth <= WIDTH_FOR_RESPONSIVE) {
      this.isOpen = false;
      this.isFixed = true;
    } else {
      this.isOpen = true;
      this.isFixed = false;
    }
  }
}
