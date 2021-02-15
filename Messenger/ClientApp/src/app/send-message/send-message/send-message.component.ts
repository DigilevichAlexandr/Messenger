import { Component, Input, OnInit } from '@angular/core';
import { Params } from '@angular/router';

@Component({
  selector: 'app-send-message',
  templateUrl: './send-message.component.html',
  styleUrls: ['./send-message.component.css']
})
export class SendMessageComponent implements OnInit {
  constructor(public id:number) { }

  ngOnInit() {

    debugger;
  }

}
