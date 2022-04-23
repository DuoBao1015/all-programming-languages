import csv
from collections import Counter
from typing import ValuesView

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
        print("There are "+str(value)+" "+dataInput1+" in the US")
        value1 = value

dataInput2 = input("Please Enter Another Restaurant Name For Compare:")

for key, value in counter.items():
    if dataInput2 == key:
        print("There are "+str(value)+" "+dataInput2+" in the US")
        value2 = value
        a = value1 - value2
        if a > 0:
            print('There are ' + str(value1-value2) +' more restaurants ' +str(dataInput1) +
                  ' than restaurants ' + str(dataInput2)+'.')
        if a < 0:
            print('There are ' + str(value2-value1) + ' fewer restaurants ' +  str(dataInput1) +
                  ' than restaurants ' + str(dataInput2)+'.')
        if value1 == value2:
            print('There are ' + str(value) +' restaurants '+' in '+ str(dataInput1)+' and '+str(dataInput2)+'.')


dataInput3 = input("Do You Want To Compare By State (yes/no)?")
if dataInput3 == "yes":
    state = input("Please Enter The State:")
    count_state1 =  0
    count_total = 0
    with open(filename) as f:
        reader=csv.reader(f)
        header_row=next(reader)
        for row in reader:
            if row[12] == state and row[10] == dataInput1:
                count_state1 += 1
            if row[12] == state:
                count_total += 1
    percent1 = count_state1 / count_total * 100
    print("There are " + str(count_state1) + "(" + str(round(percent1, 2))+ "%) " + dataInput1 + " in state: " + state + '.')
    count_state2 =  0
    with open(filename) as f:
        reader=csv.reader(f)
        header_row=next(reader)
        for row in reader:
            if row[12] == state and row[10] == dataInput2:
                count_state2 += 1
    percent2 = count_state2 / count_total * 100
    print("There are " + str(count_state2) + "(" + str(round(percent2, 2))+ "%) " + dataInput2 + " in state: " + state + '.')
    a = count_state1 - count_state2
    percenta = round(percent1 - percent2, 2)
    if a > 0:
        print('There are ' + str(a) + '(' + str(percenta) +'%) more restaurants ' +str(dataInput1) +
                ' than restaurants ' + str(dataInput2)+' in state ' + state + '.')
    if a < 0:
        print('There are ' + str(-a) + '(' + str(-percenta) +'%) fewer restaurants ' +  str(dataInput1) +
                ' than restaurants ' + str(dataInput2)+' in state ' + state + '.')
    if value1 == value2:
        print('There are ' + str(count_state1) + '(' + str(percenta) +'%) restaurants '+' in '+ str(dataInput1)+' and '+str(dataInput2)+' in state ' + state + '.')



