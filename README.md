# Zbuduj-Swoje-Miasto
Card game about building city

Based on:
http://www.planszomania.pl/karciane/4006/Zbuduj-swoje-miasto.html

# How to Debug
### Web Server communication:
- Run multiple startup projects (Web and ConsoleUi)
- pass "--restart" to ConsoleUI, can be set in Properties->Debug->"Command line arguments:"
- (see how it works in Program.cs)
- based on colors you are player 1 or 2.

### Running bot locally
- pass "--bot" to ConsoleUI, can be set in Properties->Debug->"Command line arguments:"


# Next to implement:
- Maybe instead of index play cards (CardEnum) in PlayCard()
  - How to handle situation when I have two Houses and play one and discard another.
- Bots:
  - Bots fighting:
    - There is Server and multiple bots
    - Server decides which two Bots will fight together and sends them to a "Game"
    - Bots play there like 100 games and best average is winner.
  - How to choose best card?
    - gives you best Cash
  - nie ma sensu grać przeciwko sobie, bo to jest bardziej OnePlayer game
  - Play against bot, a lot of interaction here
- each separate Console App to the same Server (2) - just to check
  - Problem:
    - only me testing is going to use it
    - ?explicit ask to cancel of game?
    - even after finishing a game (50p) we have to start another one (new id?)
- How Move is implemented on UI side is up to the consumer, focus on Server API
- Take 5 out of 7 at the begginging
- Allow only one Per Game


# Other

Rewrite to not be so immutable, objects like Game should have methods that change its state
- done.

Board should have all actions as methods, Game should orchestrate, play agains Board and take inputs
- done

Questions:
- Will Monad Serialize correctly over network?

Answers:
- API should take indexes cause it will communicate over network


Card for later:
- Ekipa budowlana
- Szkoła
- Park przemysłowy


#learing resources:

https://github.com/cezarypiatek/FGameOfLife