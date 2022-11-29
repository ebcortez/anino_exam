# Slot Machine Game Skill Exam for Anino Inc.


List of Classes:
UserManager
  - This handles the player's progress like current coins, roun winnings, current bet, etc. 

ReelsManager
  - This contains the references for all the reels in the scene and checks the result of the spin for winnings calculations.

Reel
  - This handles the spinning logic and the saves the result of each spin.

SymbolsData
  - This is an ScriptableObject that acts as the data container for the symbols' data like ID, name, sprite, etc.

Symbols
  - This contains the sprite renderer reference of symbols within the reels.

GameplayUI
  - Handles the all gameplay ui of the game.
