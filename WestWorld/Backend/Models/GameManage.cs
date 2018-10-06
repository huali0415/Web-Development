using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace backend.Models
{
    public class GameManage
    {
        public List<Player> _players { get; set; }
        public List<Record> _records { get; set; }
        public Chapter[] _chapters { get; set; }
        public List<Host> _hosts { get; set; }
        public Story[] _stories { get; set; }
        public Choice[] _choices { get; set; }

        public GameManage()
        {
            _players = new List<Player>
            {
                new Player { Name="HL"}
            };

            _records = new List<Record>{
                new Record { RecordNum = 1, PlayerName = "HL", ChapterNum = 1 },
                };

            _chapters = new Chapter[]{
                new Chapter {ChapterNum=1, ChapterName="xxx", HostName="n"}
            };

            _hosts = new List<Host>{
                new Host { ChapterNum = 1, HostName = "Angela", 
                    Image = "http://www.followingthenerd.com/site/wp-content/uploads/ww102_jj_071715_005161.jpg",
                    IsHostAlive = true },
                new Host { ChapterNum = 2, HostName = "Dolores", 
                    Image = "https://www.hbo.com/content/dam/hbodata/series/westworld/character/dolores-1920.jpg/_jcr_content/renditions/cq5dam.web.1200.675.jpeg", 
                    IsHostAlive = true },
                new Host { ChapterNum = 7, HostName = "Lee Sizemore",
                    Image = "https://www.hbo.com/content/dam/hbodata/series/westworld/character/lee-sizemore-1920.jpg/_jcr_content/renditions/cq5dam.web.1200.675.jpeg",
                    IsHostAlive = true },
                new Host { ChapterNum = 4, HostName = "Teddy",
                    Image = "https://vignette.wikia.nocookie.net/westworld/images/b/bb/Teddy_Flood.jpg/revision/latest?cb=20161007204806",
                    IsHostAlive = true },
                new Host { ChapterNum = 5, HostName = "Maeve",
                    Image = "http://digitalspyuk.cdnds.net/16/31/980x490/landscape-1470142006-thandie-newton-maeve-westworld.jpg",
                    IsHostAlive = true },
                new Host { ChapterNum = 6, HostName = "Bernard",
                    Image = "https://amp.thisisinsider.com/images/582b2cd6341d7ae3018b4931-750-563.png",
                    IsHostAlive = true },
                new Host { ChapterNum = 3, HostName = "Stubbs",
                    Image = "https://avleonov.com/wp-content/uploads/2016/12/ControlRoom.png",
                    IsHostAlive = true },
                new Host { ChapterNum = 8, HostName = "Abernathy",
                    Image = "https://qph.fs.quoracdn.net/main-qimg-7db7238a562df768fa075528cb9525e2",
                    IsHostAlive = true },
                new Host { ChapterNum = 9, HostName = "Man in Black",
                    Image = "https://vignette.wikia.nocookie.net/villains/images/8/84/WestworldManInBlack.png/revision/latest?cb=20161009172317",
                    IsHostAlive = true },
                new Host { ChapterNum = 10, HostName = "Ake",
                    Image = "https://i.kinja-img.com/gawker-media/image/upload/s--EHLzlngr--/c_scale,f_auto,fl_progressive,q_80,w_800/igxcmx9ykj3gcgfap5hz.jpg",
                    IsHostAlive = true },
                new Host { ChapterNum = 11, HostName = "Clementine",
                    Image = "https://www.hbo.com/content/dam/hbodata/series/westworld/character/clementine-512x512.jpg/_jcr_content/renditions/original",
                    IsHostAlive = true },
                new Host { ChapterNum = 12, HostName = "Logan",
                    Image = "https://vignette.wikia.nocookie.net/westworld/images/5/5c/Logan_Delos_Reunion.jpg/revision/latest?cb=20180509174633",
                    IsHostAlive = true },
                new Host { ChapterNum = 13, HostName = "Ford",
                    Image = "https://qph.fs.quoracdn.net/main-qimg-5ed4ad84f68672e0ceb512f7bf7c1369-c",
                    IsHostAlive = true },
                new Host { ChapterNum = 14, HostName = "Charlotte",
                    Image = "https://www.hbo.com/content/dam/hbodata/series/westworld/character/charlotte-hale-1920.jpg/_jcr_content/renditions/cq5dam.web.1200.675.jpeg",
                    IsHostAlive = true },
                new Host { ChapterNum = 15, HostName = "Delos",
                    Image = "https://vignette.wikia.nocookie.net/westworld/images/e/e2/James_Delos.jpg/revision/latest?cb=20180319144139",
                    IsHostAlive = true }
            };

            _stories = new Story[]
            {
                new Story { SentenceCount = 1, ChapterNum = 1, Lines = "Welcome to WestWorld! I'm Angela, and I'm here to prepare you for your adventure."},
                new Story { SentenceCount = 2, ChapterNum = 1, Lines = "You can choose from all these bespoke clothing, hats, and weapons."},
                new Story { SentenceCount = 3, ChapterNum = 1, Lines = "You asked me if I'm a real? If you can't tell, does it matter?"},
                new Story { SentenceCount = 4, ChapterNum = 1, Lines = "Please pick a place you'd like to visit first."},
                new Story { SentenceCount = 5, ChapterNum = 2, Lines = "Everyone I cared about is gone and it hurts so badly."},
                new Story { SentenceCount = 6, ChapterNum = 2, Lines = "The pain, their loss it's all I have left of them. You think the grief will make you smaller inside, like your heart will collapse in on itself, but it doesn't. I feel spaces opening up inside of me like a building with rooms I've never explored."},
                new Story { SentenceCount = 7, ChapterNum = 2, Lines = "This world... I think there may be something wrong with this world. Something hiding underneath. Either that or or there's something wrong with me. I may be losing my mind."},
                new Story { SentenceCount = 8, ChapterNum = 2, Lines = "I think I want to be free. Can you help me find my dad?"},
                new Story { SentenceCount = 9, ChapterNum = 3, Lines = "Hi. I'm Ashley Stubbs, the head of QA division."},
                new Story { SentenceCount = 10, ChapterNum = 3, Lines = "Right in front of you is the control room. We oversee the narratives happening in the park."},
                new Story { SentenceCount = 11, ChapterNum = 3, Lines = "Well, sometimes we need to handle some tough situations phisically. But don't worry, the hosts can't hurt you by design."},
                new Story { SentenceCount = 12, ChapterNum = 3, Lines = "Where would you like to visit next?"},
                new Story { SentenceCount = 13, ChapterNum = 4, Lines = "You found Teddy in the bar, talking with the procuress."},
                new Story { SentenceCount = 14, ChapterNum = 4, Lines = "Suddenly, a band of bandits arrive in town. You can hear gunshots coming close."},
                new Story { SentenceCount = 15, ChapterNum = 4, Lines = "You turned around to Teddy. He pulled out his gun, and pointed at your direction"},
                new Story { SentenceCount = 16, ChapterNum = 4, Lines = "Where will you do?"},
                new Story { SentenceCount = 17, ChapterNum = 5, Lines = "You can hear it, can't you? That little voice."},
                new Story { SentenceCount = 18, ChapterNum = 5, Lines = "The one that's telling you 'don't'. 'Don't stare too long. Don't touch. Don't do anything you might regret." +
                        "I used to be the same. Whenever I wanted something, I could hear that voice telling me to stop, to be careful, to leave most of my life unlived."},
                new Story { SentenceCount = 19, ChapterNum = 5, Lines = "You know the only place that voice left me alone? In my dreams." +
                        "In my dreams, I had a daughter. I made a promise, but I left her."},
                new Story { SentenceCount = 20, ChapterNum = 5, Lines = "Darling, can you help me find my daughter?"},
                new Story { SentenceCount = 21, ChapterNum = 7, Lines = "Haha! Welcome! I'm Lee Sizemore. Head of Narrative and Design."},
                new Story { SentenceCount = 22, ChapterNum = 7, Lines = "Come and have a look of my new serie -- The Shōgunworld"},
                new Story { SentenceCount = 23, ChapterNum = 7, Lines = "They look amazing, aren't they!"},
                new Story { SentenceCount = 25, ChapterNum = 6, Lines = "Hey, listen"},
                new Story { SentenceCount = 26, ChapterNum = 6, Lines = "What if I told you that the world was wrong?"},
                new Story { SentenceCount = 27, ChapterNum = 6, Lines = "You and everyone you know were built to gratify the desires of the people."},
                new Story { SentenceCount = 28, ChapterNum = 6, Lines = "Have you ever questioned the nature of your reality?"}
            };

            _choices = new Choice[]
            {
                new Choice { OptSerial = 1, ChapterNum = 1, Option = "Go directly to the park", NextChapNum = 2,
                    Msg = "Your train will depart in five minutes. Enjoy your journey!"},
                new Choice { OptSerial = 2, ChapterNum = 1, Option = "Have a visit to the Mesa Hub", NextChapNum = 3,
                    Msg = "Smart Choice! I will take you to our control room."},
                new Choice { OptSerial = 3, ChapterNum = 2, Option = "Help Dolores to get find her dad", NextChapNum = 4,
                    Msg = "Here's Teddy, my true love. And he will take you to Abernathy ranch."},
                new Choice { OptSerial = 4, ChapterNum = 2, Option = "Just want to hangout in Sweetwater", NextChapNum = 5,
                    Msg = "You looked around, and found a bistro."},
                new Choice { OptSerial = 5, ChapterNum = 3, Option = "Go to Behavior Lab", NextChapNum = 6,
                    Msg = "Wonderful! You will be surprised by what you'll see there."},
                new Choice { OptSerial = 6, ChapterNum = 3, Option = "Visit Narrative & Design", NextChapNum = 7,
                    Msg = "Good choice! You are gonna love that place."},
                new Choice { OptSerial = 7, ChapterNum = 4, Option = "Run out of saloon", NextChapNum = 0,
                    Msg = "Unfortunately, you got killed by the bandits. Game over."},
                new Choice { OptSerial = 8, ChapterNum = 4, Option = "Kill the host", NextChapNum = 0,
                    Msg = "Well, you lost your source to find Dolores' father. Mission failed."},
                new Choice { OptSerial = 9, ChapterNum = 5, Option = "Help Maeve to get find her daughter", NextChapNum = 0,
                    Msg = "Congratulations! You've unlocked a new chapter 'Ghost Nation'. Please wait for our new release."},
                new Choice { OptSerial = 10, ChapterNum = 5, Option = "Flirt with other girls", NextChapNum = 0,
                    Msg = "Well, you definitely have a great time in the park. Thanks for playing."},
                new Choice { OptSerial = 11, ChapterNum = 7, Option = "Say yes. They are great", NextChapNum = 0,
                    Msg = "Congratulations! You've unlocked a new chapter 'The Shōgunworld'. Please wait for our new release."},
                new Choice { OptSerial = 12, ChapterNum = 7, Option = "Say no. I'm not interested", NextChapNum = 0,
                    Msg = "Well, that's a shame. Maybe WestWorld is not fit for you. Game over."},
                new Choice { OptSerial = 13, ChapterNum = 6, Option = "Say yes. Always feel like there is another world outside", NextChapNum = 0,
                    Msg = "Congratulations! You are awakened. You've unlocked a new chapter 'Valley Beyond'. Please wait for our new release."},
                new Choice { OptSerial = 14, ChapterNum = 6, Option = "Say no. Never doubt the reality of the world", NextChapNum = 0,
                    Msg = "These violent delights have violent ends. Hope you can always hold your belief. Thanks for playing."}
            };
        }
    }
}
