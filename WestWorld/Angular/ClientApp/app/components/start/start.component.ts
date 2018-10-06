import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { Record } from '../../models/record';
import { Player } from '../../models/player';

@Component({
    selector: "start-component",
    templateUrl: "./start.component.html",
    styleUrls: ["./start.component.css"]
})
export class StartComponent {
    gameTitle = "Welcome to WestWorld";
    url = "http://localhost:63148/api"
    record: Record;
    name: string = "";
    playerComplete: boolean = false;
    message: string = "";

    constructor(public http: Http, private router: Router) {

    }

    checkCompleted() {
        this.playerComplete = this.name !== ""
    }

    createPlayer(playerName: string): void {
        this.record = { RecordNum: 1, PlayerName: this.name, ChapterNum: 1};
        Player.player.Name = this.name;
        this.http.post(this.url + "/record/" + this.name, this.record).subscribe(result => {
            console.log(result);
            var response = result.json(); 
            if (response == "Already Finished! Please Start a New Story!") {
                alert("Already Register!");
                this.message = response;
            } else {
                setTimeout(() => {
                    Player.player = new Player();
                    this.message = "Welcome!!" + response.playerName;
                    Player.player.Name = response.playerName;
                }, 1500);
            }
            this.router.navigate(['/story']);
        });

    }
}