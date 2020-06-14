import sys
from lexer import lex

testline = 0

# Main method here
def main():
    lex(testline)


if (__name__ == '__main__'):
    print("Running with arguments ", str(sys.argv))
    print("Argument count: ", len(sys.argv))
    testline = input()
    main()