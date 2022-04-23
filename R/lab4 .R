# Name: Duo Bao
# Lab Assignment Lb4
library(openintro)
head(heartTr)

# 1
boxplot(heartTr$survtime)
## There are 10 outliers.

# 2
boxplot(log(heartTr$survtime))
## There are no outliers.

# 3
## Because the log-transform reduces the dispersion of data.
## The transformed data is better since it does not have outlier.

# 4
table(heartTr$survived, heartTr$transplant)
## There are 4 participants in the control group survived.

# 5
prop.table(table(heartTr$survived, heartTr$transplant), 2)
## The treatment patients is more likely to survive.

# 6
prop.table(table(heartTr$survived, heartTr$transplant), 1)
## This means that the treatment group has a higher
## proportion of alive and death than control group.
## Theese proportions add to 1 by row, but the previous step add to 1 by column.

# 7
barplot(table(heartTr$survived, heartTr$acceptyear))
## The number of death decreases as year incereases.

# 8
barplot(table(heartTr$survived, heartTr$acceptyear), legend.text = TRUE)

# 9
tb = prop.table(table(heartTr$transplant, heartTr$acceptyear), 2)
barplot(tb, legend.text = TRUE)
## The proporion of treatment increases as year incereases.

# 10
tb = prop.table(table(heartTr$acceptyear, heartTr$transplant), 2)
mosaicplot(tb, main = '')
## We can see the years 67 nad 74 have very small proportions (widths) in the data.

