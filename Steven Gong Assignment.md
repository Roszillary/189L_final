The goal of this project is to combine elements from each assignment into one cohesive project. Finally, an additional stage will focus on applying experimental techniques (Procedural Content Generation). 

### Art
As for the art of this project, it will be primarily programmer art. As in use basic shapes, colors, and materials. Effectively the art of assignment four is what's expected for the art in this project.

### Sound 
Any sounds added can be taken from free online resources--or you can make your own. Just don't spend too much time on it :)

### Story
Because this is the final project, I must mention this section... Don't worry about it since there isn't much time left. 


### Readings:
While this project can be done without these readings, I think they are important to better understand why I decided on this project. (Also they can help give some inspiration for the stages :))
- [[PDF] Tanagra: Reactive Planning and Constraint Solving for Mixed-Initiative Level Design | Semantic Scholar](https://www.semanticscholar.org/paper/Tanagra%3A-Reactive-Planning-and-Constraint-Solving-Smith-Whitehead/4b933fd0bd6a091821bdd7909edd7cc3658bbe72)
- [Towards an Agency-centered Ontology of Game Mechanics | Semantic Scholar](https://www.semanticscholar.org/paper/Towards-an-Agency-centered-Ontology-of-Game-Mitchell-Mccoy/2920e05921d24c0c77441b9b5af5c1d99309eadf)
- Some kind of PCG paper.

Project Synopsis:

### Stage 1: Player mechanics

The main goal of this stage is to create *set* of mechanics per button action. Consider how some games will allow the player to change items and therefore change the player's abilities. (Like in Legend of Zelda, when the player equips a new item.)

First, design multiple mechanics that you will implement. (Make sure to design these as in having pseudocode and explanations for why you choose these mechanics/abilities.)


The first stage will focus on creating various player mechanics for the project. Since this will be building off exercise 1, focus on creating mechanics that follow the command pattern structure, for the end goal for thisYou may choose whatever mechanics you would like to implement, however, make sure to have multiple mechanics. 

As for inspiration for these mechanics, please look at the ontology of game mechanics paper for inspiration or consider the mechanics in your favorite games!

Make a set of player actions, akin to the command pattern from assignment 1. Have a fire 1, a fire 2, and a special ability. 

Below is an example of some action sets for each button. 

Fire1: [Melee, Range,..., etc]
Fire2: [Block, dodge,..., etc]
special: [Heal, Disrupt,..., etc]

Ideally I would like to see at least three, however two actions per set would be fine, if explained why that was done.

At this point I'd like you to look ahead to stage 3 and read through the bit about enemy abilities. The reason I ask for you to do this now is that if you wish, you can design abilities to be *asymmetrical*. While this might seem like a brand new topic, it's something I imagine you've experienced many times in games. It just means to make a abilities that already have *true* counters to each other. Something like rock, paper, scissors! (If this doesn't make sense, then please reach out to me.) 
 
By the end of this stage you should have a player character (it can totally just be a cylinder with a material applied to it) and some way to use abilities/change abilities. (It would be nice if there was some text or way to tell the player that they changed ability, but I understand if you can't get to this in time.)
### Stage 2: Choosing a camera

Following exercise 2, choose a camera controller that you think would most fit the game *you* want to make. The goal of this stage is to hopefully finalize an idea of the game prototype you'd like to make. 

This is rather a freeform stage mostly because I want you to choose how you'd like to design your own game. There are no wrong answers here as long as you justify the choices you made. 

As for picking out which camera controller you'd like to use, I usually recommend thinking of games that you like and would like to better understand and choose the camera that best suits what you want to make. 

Do note that whatever game you make, I hope you have considered some enemies.

### Stage 3: Making the first of the enemies. 

This stage isn't exactly based off any of the assignments but an important step for the final implementation as you'll need enemies for your player to fight!

As for the goal of this stage, design enemies and their overall design to help denote to the player about what they are fighting. 

You can do something simple as making red boxes denote melee grunts while blue cylinders are range enemies. You can also do something like the pikmini where a combination of basic shapes can denote an enemy--so something like two boxes on top of each other to denote a turret. While this might seem silly, please remember Franz's talk on how oftentimes games are made, then polished into the refined products that we know. You gotta start somewhere. 

Also: At this stage it would be ideal to make counter abilities to the the player's ability, as these are the abilities you will want to give your enemies. Do note that you are free to have some shared abilities. I imagine things like melee, range, and block will be things that both the player and the enemies can do--but I imagine that there will be some abilities that the player won't have that the enemies will. 

(If you decided to go down the asymmetrical ability design, this will make more sense, I think.)

By the end of this stage you should have enemy prefabs that denote enemy *types* and a set of enemy abilities that counter the player. 

### Stage 4: Building enemies by watching the player. 

This stage is actually a mix between exercise 3 and 4. Effectively you should have a factory that generates enemies over some fixed point of time (like the projectiles in assignment 4), but the enemies that are produced shouldn't always be the same as they should be in *response* to the type of ability the player has. 

Now, this might sound daunting, but one implementation could be to have a set of factories that are all listening to some watcher, and when the player changes abilities, the factors that are subscribed to that watcher will activate and create enemies. If you don't like this solution then you are free to do your own (which I recommend as I have provided a pretty bad one, but the goal is to give you something to work from.)

Ideally, at the end of this stage you should have a working demo where a camera will follow around the player (or force the player to move like the autoscroller), and the player can attack enemies using the abilities they have. The enemies themselves should be able to respond to the player by attacking, defending, or whatever abilities you decide on. 

It would be nice to have some of the usual game stuff like a count of enemies defeated on the UI. (It would also be nice to have a UI.)

### Stage 5: Building the world. 
If you have reached this point, know that you have finished effectively all the main requirements for this project as this stage will be brand new information.

Once you reach this stage, please contact me (the TA) as this stage is going to be primarily focused on PCG with the level itself. (If all goes well, I will be sending you more information about this stage as I think you already have a lot on your plate.)