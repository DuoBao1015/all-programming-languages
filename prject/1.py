import csv
from collections import Counter

import matplotlib.pyplot as plt

filename='Starbucks_Locations.csv'
with open(filename) as f:
    reader=csv.reader(f)
    header_row=next(reader)

    highs=[]
    for row in reader:
        highs.append(row[11])
    list = highs
    list.sort()
    counter = Counter(list)
    print(counter)
    print(dict(counter))
    list2 = []
    for num,count in enumerate(dict(counter).items()):
        print(count)
        list1=['AL','AK','AZ','AR','CA','CO','CT','DE','DC','FL',
               'GA','HI','ID','IL','IN','IA','KS','KY','LA','ME',
               'MD','MA','MI','MN','MS','MO','MT','NE','NV','NH',
               'NJ','NM','NY','NC','ND','OH','OK','OR','PA','RI',
               'SC','SD','TN','TX','UT','VT','VA','WA','WV','WI','WY']
        if count[0] in list1:
            list2.append(count)
    print(list2)
    plt.bar(range(len(list2)),list2)
    plt.show()




