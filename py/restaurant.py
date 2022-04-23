import pandas as pd
import matplotlib.pyplot as plt
import sys
import numpy as np

data = pd.read_csv('restaurant.csv', dtype=object)

input_rest = input("Enter your restaurant: ").upper()

rest_df = data
rest_df = rest_df.drop(rest_df[rest_df['name'].str.upper() != input_rest].index)

rest_dic = {'AL':0,'AK':0,'AZ':0,'AR':0,'CA':0,'CO':0,'CT':0,'DE':0,'DC':0,'FL':0,
               'GA':0,'HI':0,'ID':0,'IL':0,'IN':0,'IA':0,'KS':0,'KY':0,'LA':0,'ME':0,
               'MD':0,'MA':0,'MI':0,'MN':0,'MS':0,'MO':0,'MT':0,'NE':0,'NV':0,'NH':0,
               'NJ':0,'NM':0,'NY':0,'NC':0,'ND':0,'OH':0,'OK':0,'OR':0,'PA':0,'RI':0,
               'SC':0,'SD':0,'TN':0,'TX':0,'UT':0,'VT':0,'VA':0,'WA':0,'WV':0,'WI':0,'WY':0}

for state in rest_dic.keys():
    start_count = 0
    for i in range(len(rest_df)):
        if rest_df.iloc[i, 12] == state:
            start_count += 1
    rest_dic[state] = start_count

fig = plt.figure(figsize = (15,15))
plt.bar(rest_dic.keys(), rest_dic.values())
plt.title('Total Store Numbers in All States', fontsize=30)
plt.ylabel('Store Number', fontsize=20)
plt.xlabel('State', fontsize=20)
plt.show()

rest_dic_no_zero = {}

for i in rest_dic.keys():
    if rest_dic[i] != 0:
        rest_dic_no_zero[i] = rest_dic[i]



if len(rest_dic_no_zero) <= 10:
    fig = plt.figure(figsize=(15, 15))
    plt.title('Total Store Numbers in Avaliable States', fontsize = 30)
    plt.bar(rest_dic_no_zero.keys(), rest_dic_no_zero.values())
    plt.ylabel('Store Number', fontsize=20)
    plt.xlabel('State', fontsize=20)
    plt.xticks(rotation=30, fontsize=20)
    plt.show()
else:
    fig = plt.figure(figsize=(15, 15))
    plt.title('Total Store Numbers in Avaliable States', fontsize = 30)
    plt.bar(rest_dic_no_zero.keys(), rest_dic_no_zero.values())
    plt.ylabel('Store Number', fontsize=20)
    plt.xlabel('State', fontsize=20)
    plt.xticks(rotation=30)
    plt.show()

total_numbers = 0
for i in rest_dic_no_zero.values():
    total_numbers += i

print("There have total " + total_numbers.__str__() + ' restaurants.')

input_state = input("Input the state you want to check: ").upper()

state_number = 0
for i in rest_dic.keys():
    if i == input_state:
        state_number = rest_dic[i]
if state_number == 0:
    print("Sorry! There has no restaurant in the state. You should not buy this gift card.")
else:
    print("There have " + state_number.__str__() + " in the state.")

city = []

for i in range(len(rest_df)):
    if rest_df.iloc[i, 12] == input_state:
        city.append(rest_df.iloc[i, 5])

# count each city's number
result = pd.value_counts(city)
result.index = result.index.str.upper()
print(result)

fig = plt.figure(figsize=(15, 15))
plt.plot(result)
plt.title('Store Numbers of Each City', fontsize = 25)
result.plot.bar()
plt.ylabel('Store Numbers', fontsize = 20)
plt.xlabel('City', fontsize = 20)
plt.xticks(rotation = 20)
plt.show()

input_city = input("Input the city you want to check: ").upper()

city_number = 0
for i,v in result.items():
    if i == input_city:
        print("There have " + v.__str__() + " in the city.")
        city_number = v
        break

if city_number == 0:
    print("There have no restaurant in your city. Do not buy the gift card.")

sys.exit()
