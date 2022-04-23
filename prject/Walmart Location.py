import pandas as pd
import matplotlib.pyplot as plt
import sys
import numpy as np

data = pd.read_csv('Walmart Store Location.csv', dtype=object)

val = input("Enter your State(2 letters): ")
input_data = val.upper()

state_df = pd.DataFrame()
city = []

for i in range(len(data)):
    if data.iloc[i, 4] == input_data:
        city.append(data.iloc[i, 3])

if len(city) == 0:
    print("Wrong State Name!")
    sys.exit()

total_counts = len(city)
result = pd.value_counts(city)

result2 = result.head(10)

plt.plot(result2)
plt.title('Top 10 Citis of Store Numbers', fontsize = 25)
result2.plot.bar()
plt.ylabel('Store Numbers', fontsize = 20)
plt.xticks(rotation = 20)
plt.show()

fig = plt.figure(figsize = (3,5))
plt.title('Total Store Numbers in '+ input_data + ' : ' +total_counts.__str__())
plt.bar(input_data, total_counts)
plt.show()
print('Total Store Numbers in '+ input_data + ' : ' +total_counts.__str__())