def letter_square(string,number):
    square = string * number
    high = len(square) - 2
    print(square)
    for i in range(high):
        hight = (high-high+1)
        space = len(square)-2
        print((hight * string)+(space * ' ')+(hight * string))
    print(square)
letter_square(string,number)