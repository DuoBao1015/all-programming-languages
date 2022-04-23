def diff_squares(number1, number2):
    n1 = int(number1) * int(number1)
    n2 = int(number2) * int(number2)
    n3 = int(n1) - int(n2)
    print('The difference between the squares of '+str(number1)+' and '+str(number2)+' is:'+str(n3))
diff_squares(number1, number2)