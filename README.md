


<h1 style="text-align: center;">Tower4Defense</h1> 
Project by Mehdi Chakhchoukh, Quentin Lemasson

![ImageEx](/game.PNG?raw=true "") 

<hr> <p> <strong style="color: #000;">What is Tower4Defence: </strong> </p>

 Our project Tower4Defence is a real time, 4-dimensional, Tower defence AR game that you can play on your smartphone. Depending on which way you look at the game (out of North, South, East, West), you will see a different game “universe” (dimension) taking place before you. see parallel universes video demo [here](https://www.youtube.com/watch?v=gCURxKNXDcc&feature=youtu.be).
 
The goal of the game is to defend your “treasure” from enemies trying to reach it in all 4 dimensions. 
 
To do that you have 4 tower tiles that you can place anywhere on the board to shoot enemies. Each tower has 4 different forms (Arrow, Bomb, Fire and Water Tower) depending on its orientation relative to the camera of the player and exists in all 4 planes of existence in its different forms. See rotation video demo [here](https://www.youtube.com/watch?v=du3nK9W3kMQ&feature=youtu.be).


![ImageEx](/towerTiles.PNG?raw=true "") 


<hr> <p> <strong style="color: #000;">Image Target Rotation Interaction:  </strong> </p>

To implement our game Tower4Defence, we had to design and implement a novel way to interact with AR objects using their orientations relative to the camera of the player. 
 
 <strong style="color: #000;">Software part: </strong> </p>
 
We Implemented a functional prototype of the game with a demo level that has 3 (quite difficult) waves of enemies using Unity and Vuforia. 
 
We decided to make all 3D objects/assets ourselves to ensure that the 3D objects were as low poly as possible so that the game runs smoothly on a smartphone without any performance issues   Our Game is comprised of:
 • 4 parallel “universes” with different level designs (landscapes, roads and enemy spawns).
 • 5 different types of enemies each with their strengths and weaknesses to different types of towers as well as attributes like life points speed and spawn rate. o Enemies are weak against the tower that has their color (ex: red enemies weak against fire tower). This gameplay feature ensures that the players spend most of their time moving and rotating the pieces around to keep them engaged as well as think in 4D for extra challenge.
 • A pause button to let the players explore the 4 parallel universes in a calm way and think of an optimal placement and orientation for their towers. This feature was also thought out to unsure that our game is accessible to people with less mobility / mobility impairment. 
![ImageEx](/boards.PNG?raw=true "") 
![ImageEx](/towers.PNG?raw=true "")
![ImageEx](/enemies.PNG?raw=true "") 

<strong style="color: #000;">Tangible part:   </strong> </p>

The tangible part of our project is comprised of:  • 4 wooden tower tiles with magnets embedded in them and a unique image target on top. • A board divided in 5x5 tiles with each tile being 10x10cm in size. Each tile has a 7x7cm centered magnetic core (to make tower tiles stick and stabilize the game). And an extruded image target in the middle. It is extruded to prevent users from hiding it by sliding a tower tile on top of it. 

![ImageEx](/woodboard.PNG?raw=true "") 


<strong style="color: #000;">Making process of the tangibles:    </strong> </p>

We experimented with 6 different paper prototypes with tiles that were respectively sized 5x5cm, 7x7cm, 9x9cm, 11x11cm, 13x13cm, 15x15cm. 
We settled for tiles of 10x10 cm for optimal image target recognition without the tiles being too big 
 
We made the final version of the game tangibles out of wood to have tangible pieces that were both sturdy and nice to hold in hand as well as completely flat for better image target tracking. 
The tower tiles were made of 2 layers of laser cut 5mm plywood with 4 neodymium magnets embedded in them. 5mm tiles were uncomfortable to pick so we doubled the thickness by sticking together 2 layers of wood. We also put colored stickers on the sides of each tile to make the switching between the forms of the tower easier for users

![ImageEx](/magnets.PNG?raw=true "") 


<hr> <p> <strong style="color: #000;">Challenges faced during this project:   </strong> </p>

• Working with Vuforia’s limitation of 5 simultaneous image targets only: This made us redesign our entire game and made us come up with the idea of having parallel universes to extract more content out of the 5 image targets.  
• Implementing the rotation interaction was quite hard and took lots of days of painful debugging and complicated 3D geometry while juggling with 3 different referential (image target, game-world and camera referential)   
• Learning how to use the laser printer/cutter 
• Finding materials  

<hr> <p> <strong style="color: #000;">Observations during the exhibition:    </strong> </p>

We presented the project at an exhibition at Paris-Saclay.
Here we noticed 2 types of behavior:  
-Some people played the game on their own see gameplay [demo video](https://www.youtube.com/watch?v=oFp9YAHoBZ8&feature=youtu.be).
-Whereas groups of friends decided to play the game in a collaborative way: a person holding the phone and looking around while giving instructions to their friends about where to put each tower and how to rotate them.

<hr> <p> <strong style="color: #000;">What is Next:   </strong> </p>
From here the possibilities are endless, some upgrades and future features we thought about are: -Porting the game on the HoloLens for an even better AR experience. -Customizing the look of the different universes even more ( with colors of different 3D models)  -Adding an upgrading area for the towers next to the board where you need to put a tower for a minute to have a stronger tower but in the meantime you only play with 3 towers, making the levels more challenging. -Stopping a tower from shooting if it is placed on a road (so that you need to take into account the roads of all 4 dimensions before placing the tower) -Adding network synchronization to play the game in multiplayer on different smartphones. 


 


