import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-scroll-bar-ui',
  templateUrl: './scroll-bar-ui.component.html',
  styleUrls: ['./scroll-bar-ui.component.scss']
})
export class ScrollBarUiComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    let scrollPercentage = () => {
      let scrollProgress = document.getElementById("progress");

      let position = document.documentElement.scrollTop;
      let calcHeight = document.documentElement.scrollHeight - document.documentElement.clientHeight;
      let scrollValue = Math.round(position * 100 / calcHeight);
      scrollProgress.style.background = `conic-gradient(#e70634 ${scrollValue}%, #2b2f38 ${scrollValue}%)`;

      // menu.classList.remove("bx-x");
      // navbar.classList.remove("active");
    }

    window.onscroll = scrollPercentage;
    window.onload = scrollPercentage;
  }

}
