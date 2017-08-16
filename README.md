# Zbuduj-Swoje-Miasto
Card game about building city

Based on:
http://www.planszomania.pl/karciane/4006/Zbuduj-swoje-miasto.html


Rewrite to not be so immutable, objects like Game should have methods that change its state
- done.

Board should have all actions as methods, Game should orchestrate, play agains Board and take inputs
- done

Questions:
- Will Monad Serialize correctly over network?

Answers:
- API should take indexes cause it will communicate over network

Next to implement:
- StyleCop
  - important!
- each separate Console App to the same Server (2) - just to check
  - Problem:
    - only me testing is going to use it
    - ?explicit ask to cancel of game?
    - even after finishing a game (50p) we have to start another one (new id?)
  - pass an argument that will (--restart) old game and start new.
- How Move is implemented on UI side is up to the consumer, focus on Server API
- Make Move distinction (Architect, Card, NoCard) on UI part - check
- Architect
- Take 5 out of 7 at the begginging
- Do not build - take 1 out of 5 cards.
- Finish game (by 50? points)
- Allow only one Per Game


Card for later:
- Ekipa budowlana
- Szkoła
- Park przemysłowy