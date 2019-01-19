# ArithmeticParser
A simple parser for evaluating simple arithmetic expressions. Made to learn recursive-descent parsers, Backus-Naur form, and hopefully have fun along the way :)
Inspired by [this great tutorial](http://blog.roboblob.com/2014/12/16/recursive-descent-parser-for-arithmetic-expressions-with-real-numbers/).

## Extended Backus-Naur Form Representation
The EBNF representation of the syntax the parser should be able to parse is as follows.

```
Digit := '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9'
Integer := Digit{Digit}
Number := [-](Integer | Integer.Integer)

Operator := '+' | '-' | '*' | '/'

Factor := Number | '(' Expression ')'
Expression := Factor {Operator Factor}
```
