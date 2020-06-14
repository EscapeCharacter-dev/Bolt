#lex a string

import sys

def lex(str):
    print("Hello, i can call lexer")
    if (RepresentInt(str) == True):
        print(int(str))
        return
        
    print("Error here: ", str, " cannot be lexed!")


def RepresentInt(str):
    try:
        int(str)
        return True
    except ValueError:
        return False


