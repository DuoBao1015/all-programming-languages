lst = []
def bluebird_count(number):
    for i in range(number):
        n = i+1
        print('---- Observer '+ str(n) + ' ----')
        numbers = int(input('Enter number spotted by this observer: '))
        print()
        lst.append(numbers)
    print(sum(lst))
bluebird_count(number)