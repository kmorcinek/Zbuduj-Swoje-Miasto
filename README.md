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
- How to allow comunication over http?

Answers:
- API should take indexes cause it will communicate over network

Next to implement:
- http Server and one/two clients (on one ConsoleUI process first)
- Architect
- Take 5 out of 7 at the begginging
- Do not build - take 1 out of 5 cards.
- Finish game (by 50? points)
- Allow only one Per Game


Card for later:
- Ekipa budowlana
- Szkoła
- Park przemysłowy