E1	: E1 '+' E2
	| E2;

E2	: E2 '*' E3
	| E3;

E3	: 'falso'
	| 'verdadero';