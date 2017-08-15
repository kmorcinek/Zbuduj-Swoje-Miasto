# Zbuduj-Swoje-Miasto
Card game about building city

Based on:
http://www.planszomania.pl/karciane/4006/Zbuduj-swoje-miasto.html


Rewrite to not be so immutable,
objects like Game should have methods that change its state

Board should have all actions as methods
Game should orchestrate, play agains Board and take inputs

Questions:
- Should the API take Cards on indexes?
- How to allow comunication over http? Two processes? Two separate player classes? with on Console UI playing two players?

Next to implement:
- Two players game, by color
- Finish game (by 50? points)
- Architect
- Take 5 out of 7 at the begginging
- Do not build - take 1 out of 5 cards.
- Allow only one Per Game


Card for later:
- Ekipa budowlana
- Szkoła