# VolaTile

## OOP2 CA

### Description

VolaTile is a fast paced, multi-tasking onslaught where you'll be controlling between 1 - 9 seperate and uniquely different smaller games at the same time

The catch, while you're focused on one of your games the others will be slowed to a twentieth of its speed to give you time to micro manage each individual game you have up

Put your micro-managing skills to the test as you try to stay alive with each game effecting each other with powerups and a currency system
with danger creeping in from all sides

Currently 3 games are functional :
- A reverse bullet hell where the player has enemies approaching from all sides as he fends them off upgrading his abilites and stats along the way

- A laser dodging game similar to [Ikaruga](https://en.wikipedia.org/wiki/Ikaruga) where your aim is to survive as long as possible amist a huge volume projectiles aimed your way

- A tower defense where ramping waves of enemies slowly attempt to overwhelm you as you build towers with currency you've collected from other games. Watch them slowly creep to the end as you try to grab any currency you can in other games to build a strong enough defence

### Interesting things to note

- In game 5 the wave is managed using a currency system where the spawn manager is allocated a ramping amount of currency to spend on enemies each round
- In game both game 4 and 5 the enemies / lasers are spawned around you in a circular range around your position that moves with you
- In game 6 turrets use an array of raycasts to pick an enemy to target
- The Viewmanager / TimeMnager / DefaultSpeeds control the slowdown mechanic instead of using timeScale to allow for more dynamic and interesting slowdown mechanics
- The song playing is an original produced by myself

### Future plans

While there will only have a maximum of 9 games running at any one time the plan is to have well over 15 possible games to keep the gameplay loop fresh and interesting aswell as to allow for more interesting and unique experiances upon multiple runs

More original music will be added for differnt stages of the game while keeping the current track as a main menu / pause theme

Original 2D pixel sprites, background art, GUI components and animations

Eventually a full commercial release!

### Notes

The slow down mechanic is by far the most complicated aspect of the game in regards to development time. There was a lot of restructuring how exactly it worked and what values it did and didn't effect. However it's coded with future sight in mind as now whenever a new game is added the only changes that have to be made are related to adding the new variables into the slow motion related scritps. Therefore a new game can simply be slotted in as soon as it finishes initial testing. This means we can scale the amound of differnt games we have available quickly and easily

Each game has every part of it from scripts, prefabs, in editor objects and other related files seperated into game specific folders corresponding to the number the game has on the grid so as to encapsulate all related materials into their own sections. Global files are usually titled as such

The game is far from finished but there are very few bandaid fixes in place. Most of the functionality already included can be assumed to be fully tested and debugged

Each script is extensively commented to avoid any confusion. This is most likely on the potentially confusing variable naming schemes

Almost everything is done with distinct methods as many scripts interact with each other in differnt ways that cause a need for clear seperation of concerns for functionality

A lot of static variables are used for the slow motion mechanic which effect all members of the class related to that variable. A lot of tracking of differnt stats are needed to make this consistent with turning the slow motion on and off


## TRAILER
[Youtube Link](https://youtu.be/od-m_1xl40s)

Developed by Tadhg Mulvey / C22410612
