import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-ticket-ui',
  templateUrl: './ticket-ui.component.html',
  styleUrls: ['./ticket-ui.component.scss']
})
export class TicketUiComponent implements OnInit {
  @Input() seat;
  @Input() screening;
  @Input() hall;
  @Input() movie;
  constructor() { }

  ngOnInit(): void {
    console.log(this.screening)
  }
}
