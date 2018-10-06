import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { Player } from '../../models/player';
import { Record } from '../../models/record';
import { Story } from '../../models/story';
import { Choice } from '../../models/choice';
import { Host } from '../../models/host'

@Component({
    selector: "story-component",
    templateUrl: "./story.component.html",
    styleUrls: ["./story.component.css"]
})

export class StoryComponent {
    url = "http://localhost:63148/api"
    imagePath: string = "";
    record: Record;
    host: Host;
    stories: Story[] = [];
    choices: Choice[] = [];
    msg: string[] = [];
    nextChap: number[] = [];
    playerName: string = Player.player.Name;
    currentChapter: number = 1;
    nextChapter: number;
    isHostAlive: boolean = false;
    lines: string[] = [];
    options: string[] = [];
    displayMessage: string = "";
    ending: string = "";
    showNextChapterButton: boolean = false;
    showHomeButton: boolean = false;
    hostName:string = "";

    constructor(public http: Http, private router: Router) {
        this.getData();
    }

    getData() {
        this.http.get(this.url + "/record/" + this.playerName).subscribe(result => {
            this.record = result.json();
            console.log(this.record);
            this.currentChapter = result.json().chapterNum;
            this
        });

        this.http.get(this.url + "/host/" + this.currentChapter).subscribe(result => {
            this.host = result.json(); 
            //console.log(this.host);
            this.isHostAlive = result.json().isHostAlive;
            this.hostName = result.json().hostName;
            this.imagePath = result.json().image;
            if (!this.isHostAlive) {
                this.displayMessage = `You are late! ${this.hostName} has already been killed, 
                    game is over! Please start from the beginning!`
                this.gameOver();
            }
            console.log(this.imagePath);
        });


        this.http.get(this.url + "/story/" + this.currentChapter).subscribe(result => {
            this.stories = result.json(); 

            for (var i in this.stories) {
                //console.log(result.json()[i]);
                this.lines.push(result.json()[i].lines);
            }
        });

        this.http.get(this.url + "/choice/" + this.currentChapter).subscribe(result => {
            this.choices = result.json();
            this.msg[0] = result.json()[0].msg;
            this.msg[1] = result.json()[1].msg;
            this.nextChap[0] = result.json()[0].nextChapNum;
            this.nextChap[1] = result.json()[1].nextChapNum;
            for (var i in this.choices) {
                //console.log(result.json()[i]);
                this.options.push(result.json()[i].option);
            }
            this.options[0] = result.json()[0].option;
        });
        //this.choices.forEach(o => this.options.push(o.Option));
    }
      
    chooseAction(option: string): void {
        this.displayMessage = `You decide to ${option}.`;
        setTimeout(() => {
            if (option == "Kill the host") {
                this.isHostAlive = false;
                this.updateHost(this.currentChapter, this.hostName, this.imagePath, this.isHostAlive);
                if (this.options[0] == "Kill the host") {
                    this.ending = `You killed ${this.hostName}!`+ this.msg[0];
                    if (this.nextChap[0] == 0) {
                        this.showHomeButton = true;
                    } else {
                        this.nextChapter = this.nextChap[0];
                        this.showNextChapterButton = true;
                    }
                } else {
                    this.ending = `You killed ${this.hostName}! `+ this.msg[1];
                    if (this.nextChap[1] == 0) {
                        this.showHomeButton = true;
                    } else {
                        this.nextChapter = this.nextChap[1];
                        this.showNextChapterButton = true;
                    }
                }
            }
            else if(option == this.options[0])
            {
                this.ending = this.msg[0];
                if (this.nextChap[0] == 0) {
                    this.showHomeButton = true;
                } else {
                    this.nextChapter = this.nextChap[0];
                    this.showNextChapterButton = true;
                }
            } else
            {
                this.ending = this.msg[1];
                if (this.nextChap[1] == 0) {
                    this.showHomeButton = true;
                } else {
                    this.nextChapter = this.nextChap[1];
                    this.showNextChapterButton = true;
                }
            }
            console.log(this.isHostAlive);
        }, 1500);
    }

    nextStory(): void {
        this.updateRecord(this.playerName, this.nextChapter);
        this.lines = [];
        this.options = [];
        this.displayMessage = "";
        this.ending = "";
        this.hostName = "";
        this.imagePath = "";
        this.showNextChapterButton = false;
        //this.router.navigate(["/story"]);
        this.currentChapter = this.nextChapter;
        this.getData();
    }

    gameOver(): void {
        //this.deleteRecord(this.playerName);
        this.updateRecord(this.playerName, 1);
        this.lines = [];
        this.options = [];
        this.displayMessage = "";
        this.ending = "";
        this.hostName = "";
        this.imagePath = "";
        this.showHomeButton = false;
        this.router.navigateByUrl("/start");
    }
    
    updateRecord(playerName: string, nextChapter: number): void{
        this.record = { RecordNum: 1, PlayerName: this.playerName, ChapterNum: this.nextChapter}
        this.http.put(this.url + "/record/" + this.playerName, this.record).subscribe(result => {
            result.json();  
        });
    }

    deleteRecord(playerName: string): void{
        this.http.delete(this.url + "/record/" + this.playerName).subscribe(result => {
            result.json();  
        });
    }

    updateHost(currentChapter: number, hostName: string, image: string, isHostAlive: boolean) {
        this.host = { ChapterNum: this.currentChapter, HostName: this.hostName, Image: this.imagePath, IsHostAlive: this.isHostAlive}
        this.http.put(this.url + "/host/" + this.currentChapter, this.host).subscribe(result => {
            result.json();  
        });
    }
}