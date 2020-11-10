# BattleShipCSharp
### Description
The game begins with a small menu which allows you to choose whether to play 1v1(SOON) or 1v1 against the computer, the comments of the game are originally in Spanish but feel free to convert it to your language 🤓
### Contents
- [¿ How to use ?](https://github.com/DanielReyes03/BattleShipCSharp#-how-to-use- " How to use")
- [Customize](https://github.com/DanielReyes03/BattleShipCSharp#customize "Customize")
- [¿ How does it work ?](https://github.com/DanielReyes03/BattleShipCSharp#How-does-it-works "How does it works")


### ¿ How to use ?
 The game is developed in c # so to run you can use your preferred IDE clone the [repo](https://github.com/DanielReyes03/BattleShipCSharp "repo") and start to play🚀
 - Go to your favorite folder for example:
 `Cd myAwesomeProject`
 
 - Clone the repo
 `Git clone https://github.com/DanielReyes03/BattleShipCSharp`
 
 - In your favorite terminal type `Dotnet Run` ✍🏽
 
 - Finally Start playing 👾
 
### Customize

1. You can customize the positions of the boats in the files player.txt and opponent.txt. 📚
2. You can customize all the texts and menus to your imagination. ✍🏽
3. You can change the horizontal or vertical position of the boat in the file player.txt and opponent.txt the position is represented by a (H) of horizontal and a (V) of vertical. ⛴
4. You can change the size of the positions that the ship occupies on the board, this can be done in the player.txt and opponent.txt file 🎯

### ¿ How does it work ?

------------



#### 1. Board
Battleship works with a matrix, these matrices are built from the file player.txt and opponent.txt where the first line will determine the size of the matrix. 🎯

#### 2. Ships
The position of the ships and how many spaces it will occupy is determined in the files player.txt and opponent.txt, which from line 3 to 7 is the configuration of the ships, the first two positions of each line will say in which coordinate they will be located, Next will be the position of the boat if it is horizontal or vertical and finally comes how many positions the boat will occupy which can be 2,3 and 4 🛳
	
#### 3. Points
The player will have infinite shots until he can knock down all the ships, but if the player is confused 3 times, the game will end, each hit will have a score of 10 points, the one with the highest score will be the winner 👾
	
	
