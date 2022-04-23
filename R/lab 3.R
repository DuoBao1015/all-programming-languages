# Name: Duo Bao
# Lab Assignment Lb3

source("http://www.openintro.org/stat/data/cdc.R")
#1
plot(cdc$weight ~ cdc$wtdesire)
# The  slope are above 1, that mean people want to lose weight.

#2
wdiff <- cdc$wtdesire - cdc$weight
# wdiff is discrete and numerical.
# If an observation has wdiff of 0, that mean people are happy about
# their weight now. if wdiff is positive that mean they want add weight
# if wdiff is negative that mean people want loss some weight.

#3
boxplot(wdiff)
summary(wdiff)
#The center of the wdiff is 0,and I use boslot for find center from
# graph and use summary to find median,becouse it give number and graph.

#4
hist(wdiff, breaks = 40)
plot(wdiff)
# The Wdiff histogram is unimodal with a left skew,
# The spread is between 0 and -21 pounds.histogram can help find
# bar graph and plot help find most range, summary give the number 
# of iqr spread.

#5
# The center tell people are want to lose around 10 to 15 pounds,
# the shape tell there are some people want lose weight, 
# but a few people who want to gain weight.
# the spread  tell most  people want to lose weight, but there are some
# outline.

#6
genwdiff <- data.frame(wdiff, cdc$gender)
summary(subset(genwdiff, cdc.gender == "m"))
summary(subset(genwdiff, cdc.gender == "f"))
# The median of women was -10, men is -5, so there are more women want
# lose weight, but there are more men who want add weight than women.

#8
mean(cdc$weight)
sd(cdc$weight)
mean(cdc$weight)-sd(cdc$weight)
# (1)[1] 129.602
mean(cdc$weight)+sd(cdc$weight)
# (2)[1] 209.7639
mean(cdc$weight)-(sd(cdc$weight)+sd(cdc$weight))
# (3)[1] 89.52101
mean(cdc$weight)+(sd(cdc$weight)+sd(cdc$weight))
# (4)[1] 249.8449

#9
avgwt <- mean(cdc$weight)
sdwt <- sd(cdc$weight)
instdev <- subset(cdc, weight < (avgwt + sdwt) & weight > (avgwt - sdwt))
dim(instdev)[1]/dim(cdc)[1]
#[1] 0.7076,proportion of the observations are within 1 standard deviation of the mean = 0.7076.
avgwt <- mean(cdc$weight)
sdwt <- sd(cdc$weight)
instdev <- subset(cdc, weight < (avgwt + sdwt) & weight > (avgwt - sdwt))
dim(instdev)[2]/dim(cdc)[2]
#[1] 1,proportion of the observations are within 1 standard deviation of the mean = 1.

#10
avght <- mean(cdc$height)
sdht <- sd(cdc$height)
instdev <- subset(cdc, height < (avght + sdht) & height > (avght - sdht))
dim(instdev)[1]/dim(cdc)[1]
# [1] 0.62125,proportion within one standard deviation of the mean = 0.62125.
avght <- mean(cdc$height)
sdht <- sd(cdc$height)
instdev <- subset(cdc, height < (avght + sdht) & height > (avght - sdht))
dim(instdev)[2]/dim(cdc)[2]
# [1] 1,proportion within one standard deviation of the mean = 1.