%Connected flights, in the same graph
flight(singapore,london) :- write('Flight From Singapore to London'), nl.
flight(london,edinburgh) :- write('Flight From London to Edinburgh'), nl.
flight(london,paris) :- write('Flight From London to Paris'), nl.
flight(london,greece) :- write('Flight From London to Greece'), nl.
flight(paris,rome) :- write('Flight From Paris to Rome'), nl.
flight(greece,rome) :- write('Flight From Greece to Rome'), nl.
flight(edinburgh,london) :- write('Flight From Edinburgh to London'), nl.
flight(london,singapore) :- write('Flight From London to Singapore'), nl.
flight(greece,london) :- write('Flight From Greece to London'), nl.
flight(paris,london) :- write('Flight From Paris to London'), nl.
flight(rome,paris) :- write('Flight From Rome to Paris'), nl.
flight(rome,greece) :- write('Flight From Rome to Greece'), nl.

%Unconnected flights, outside the graph
flight(malaysia,indonesia) :- write('Flight From Malaysia to Indonesia'), nl.
flight(indonesia,malaysia) :- write('Flight From Indonesia to Malaysia'), nl.

%Associations - Limit the Solution Depth up to 3
hasflight(X,Y) :-  write('-= Test 1 Hops =-'), 
							nl,
							flight(X,Y).
hasflight(X,Y) :-  write('-= Test 2 Hops =-'), 
							nl,
							flight(X,Z), 
							flight(Z,Y),!.
hasflight(X,Y) :-  write('-= Test 3 Hops =-'), 
							nl,
							flight(X,A), 
							flight(A,B), 
							flight(B,Y).


