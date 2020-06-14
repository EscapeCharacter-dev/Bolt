import sys


# Main method here
def main():
    print("Running with arguments ", str(sys.argv))
    print("Argument count: ", len(sys.argv))
    print("File input: ", str(sys.argv[0]))





#If statement that calls main
if (__name__ == '__main__'):
    main()