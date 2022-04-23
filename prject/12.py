import csv
from collections import Counter

filename='restaurant.csv'
with open(filename) as f:
    reader=csv.reader(f)
    header_row=next(reader)

    restaurant=[]
    for row in reader:
        restaurant.append(row[10])
    list_1 = restaurant
    list_1.sort()
    counter = Counter(list_1)
    print(counter)
dataInput1 = input("Please Enter Restaurant Name:")

for key, value in counter.items():
    if dataInput1 == key:
        print(value)
        value1 = value

dataInput2 = input("Please Enter Another Restaurant Name For Compare:")

for key, value in counter.items():
    if dataInput2 == key:
        print(value)
        value2 = value
        a = value1 - value2
        if a > 0:
            print('There are ' + str(value1-value2) +' more restaurants ' +str(dataInput1) +
                  ' than restaurants ' + str(dataInput2)+'.')
            print(('percent: {:.2%}').format(value1/value2))
        if a < 0:
            print('There are ' + str(value2-value1) + ' fewer restaurants ' +  str(dataInput1) +
                  ' than restaurants ' + str(dataInput2)+'.')
            print(('percent: {:.2%}').format(value2 / value1))
        if value1 == value2:
            print('There are ' + str(value) +' restaurants '+' in '+ str(dataInput1)+' and '+str(dataInput2)+'.')





