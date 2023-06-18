# Game Basic Information

This project was approved by the TA due to unforseen circumstances, leading to me not being able to find a group. 

## Summary

In this project, I create a player with many abilities and the option to change abilities. As we change these abilities,
the enemies will dynamically change their abilities as well in response to the players change to try to counter the player's
abilities.

## Gameplay Explanation

### Players

As of now, Players have 7 abilities.

### Attacks

#### Attack1

A tap fire of projectile prefabs. 

#### Attack2

A burst fire of projectile prefabs.

#### Attack3

A spray/shotgun fire of projectile prefabs.

### Melees

#### Melee1

A knife attack.

#### Melee2

A bash attack that is suppose to stun enemies.

#### Melee3(Unfinished)

A hook attack that is suppose to lure enemies in.

### Specials

#### Speical1

Self-healing.

#### Special2

Dashing or teleporting.

#### Special3(Unfinished)

### Swapping ability sets

Enter.

### Swapping individual abilities within a set
 
1, 2, 3.

### Main Camera

The camera chosen was a position lock camera as it was easiest to implement with the time given. 
Additionally, it may have been better as the character could dash around.

### Enemy Abilities

#### Ability1(Unfinished)

It's own projectile weapon to counter melee abilities.

#### Ability2(Unfinished)

Vertically dodging to counter projectile abilities.

#### Ability3(Unfinished)

Regeneration to counter special abilities, as the player will also be healing or dashing around. 


## Reflections

Although only a week was given, and much of the game was left unfinished, I learned many valuable skills while building this project.

The first major hurdle, was learning how to set up a new game with basic player mechanics like move left, move right, and jump. 
I had built on games from the exercises before, but it was a new learning curve to set everything up myself, and build from scratch. 
After following through exercise 1, setting up a player command interface, and creating a player, I loaded the player up with the many abilities listed below. 

While making these abilties, I learned how to implement projectiles by using an object pooling method on a projectile prefab. I built on top of
projectile to make several unique projectiles giving my player a tap fire, burst fire, and spray fire inspired from fps games like csgo and valorant, but 2D. 

Later on, I was able to add health system and damage system. I added a health bar component by creating a canvas with a slider component. I would mofidy this slider
as players and enemies lost or gained health from abilities. 

Afterwards, I also created melee abilities for the player. I learned how to set up a layer of enemies for collision detection in these abilities. 
The first ability, a slash, would utilize a Overlapcircleall in order to detect for enemies within a circle radius centered at the player's hand. The
second ability, a bash, would utilize a Overlapboxall to detect for bashing enemies inside a square to stun their abilites. This was also intended to do less
damage as compared to a slash. 

All of these abilties were all very dependent on the direction the player was facing, which I solved using a SetDirection function which found with the dot product 
of the player's position right and its normalized velocity. 

After, implementing the functionality of changing the player's attack, I realized that I had run out of time to implement enemies counter abilities for the player's switch.
However, I had counter ideas listed below, and was in the process creating a enemy switch to counter a player's switch that would be triggered in the PlayerController's Inputs. 

## Sources

[2D tutorial series](https://www.youtube.com/watch?v=TcranVQUQ5U&list=PLgOEwFbvGm5o8hayFB6skAfa8Z-mw4dPV&index=1&ab_channel=Pandemonium)
[2D melee](https://www.youtube.com/watch?v=I2Uo8eEmSFQ&t=394s&ab_channel=SunnyValleyStudio)
[2D melee series](https://www.youtube.com/watch?v=1QfxdUpVh5I&list=PLA0C6X3bTBNBI9eZ3umNMj7zUS6-y9VZQ&ab_channel=Blackthornprod)
[Healthbar](https://www.youtube.com/watch?v=BLfNP4Sc_iA&ab_channel=Brackeys)