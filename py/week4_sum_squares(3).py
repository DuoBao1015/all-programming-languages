def sum_squares(max):
    '''print the sum of squares of integers 1 to max.'''
    sum = 0
    print('x-x**2')
    print('------')
    for i in range(max):
        num = i + 1
        square = num**2
        print(num, '-', square)
        sum = sum + square
    print()
    print('Sum of squares for 1 through', max, ":", sum)
sum_squares(max)

# if sum_squares(3) output is:
# x - x**2
# --------
# 1 - 1
# 2 - 4
# 3 - 9
#
# Sum of squares for 1 through 3 : 14