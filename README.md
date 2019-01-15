# ArithmeticParser
A simple parser for evaluating simple arithmetic expressions. Made to learn recursive-descent parsers, Backus-Naur form, and hopefully have fun along the way :)

## Extended Backus-Naur Form Representation
The EBNF representation of the syntax the parser should be able to parse is as follows.

```
Digit := '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9'
Integer := Digit{Digit}

Operator := '+' | '-' | '*'

Expression := (Expression|Integer) {Operator (Expression|Integer)}
```
