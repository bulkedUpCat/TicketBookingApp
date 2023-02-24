import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EmailService } from 'src/app/reports/data-access/email.service';
import { NotifierService } from 'src/app/shared/services/notifier.service';

@Component({
  selector: 'app-send-reservation',
  templateUrl: './send-reservation.component.html',
  styleUrls: ['./send-reservation.component.scss']
})
export class SendReservationComponent implements OnInit {
  email: string = '';
  constructor(private emailService: EmailService,
    private notifier: NotifierService,
    private dialogRef: MatDialogRef<SendReservationComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,) { }

  ngOnInit(): void {
  }

  onSendEmail(){
    if (this.email == null) return;
    const model = {email: ''};
    model.email = this.email;

    this.emailService.sendTickets(this.data.id, model).subscribe(r => {
      this.notifier.showNotification('Tickets sent', 'SUCCESS');
      this.dialogRef.close();
    }, err => {
      this.notifier.showNotification('Something went wrong', 'ERROR');
    });
  }
}
