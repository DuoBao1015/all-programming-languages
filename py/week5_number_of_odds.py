def number_of_odds(number):
    odd = number//2
    odds = number/2
    if odds > odd:
        n1=odd + 1
        print('number_of_odds('+str(number)+')'+' '*2+'-->'+' '*2+str(n1))
    else:
        print('number_of_odds('+str(number)+')'+' '*2+'-->'+' '*2+str(odd))
number_of_odds(number)