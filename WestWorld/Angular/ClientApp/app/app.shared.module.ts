import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { StartComponent } from './components/start/start.component';
import { StoryComponent } from './components/story/story.component';
import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  { path: "", component: StartComponent},
  { path: "story", component: StoryComponent},
  // { path: "player", component: PlayerComponent},
  { path: "**", redirectTo: ""},
  { path: 'home', component: HomeComponent },
  //{ path: 'counter', component: CounterComponent },
  //{ path: 'fetch-data', component: FetchDataComponent },
]
@NgModule({
    declarations: [
        AppComponent,
        StartComponent,
        // PlayerComponent,
        StoryComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot(routes)
    ]
})
export class AppModuleShared {
}
