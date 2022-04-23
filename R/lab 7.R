# Name: Duo Bao
# Lab Assignment: 7
# Collaborator(s):

#1
die_roll <- c(1,2,3,4,5,6)
winnings <- c(100, 0, 0, 0, 50, 0)
prob_rol <- c(rep(1/6, 6))
prob_df <- data.frame(Event=die_roll, Prob=prob_rol, Score=winnings)
prob_df
# first set the roll and find the win set, rolling number 1 through to 6.

#2
roll_ten_thousand <- replicate(10000, {s=sample(1:6, size=1, replace=TRUE); score=prob_df[s,'Score']})
roll_ten_thousand
hist(roll_ten_thousand, ylim=c(0,8000))
# The resulting distribution of the histogram tells us that the score of 0 is most.
# The possible scores are 0, 50, 100. 
# The score of 0 occurs most frequently over 6000 times in the 10000 sample size, 
# whereas the scores of 50 and 100 occur about equally around 2000 times in the 10000 sample size.

#3
sample_mean <- mean(roll_ten_thousand)
sample_mean 
# 24.56
weighted_mean_randvar <- weighted.mean(die_roll, winnings)
weighted_mean_randvar 
# 2.333333
# The sample mean is significantly different than the expected value. 
# because the sample mean considers each data point as contributing equally to final mean, 
# whereas the expected value considers some data points carry more,
# proportionally of other data points indicating they are more likely to occur.

#4
sample_sd <- sd(roll_ten_thousand)
sample_sd 
# 38.16349
#

#5
die_roll <- c(1,2,3,4,5,6)
winnings <- c(100, 0, 0, 0, 50, 0)
prob_rol <- c(1/10, 1/10, 1/10, 1/10, 1/2, 1/10)
prob_df2 <- data.frame(Event=die_roll, Prob=prob_rol, Score=winnings)
prob_df2

#6
roll_ten_thousand <- sample(prob_df2$Score, 10000, TRUE, prob_df2$Prob)
roll_ten_thousand
hist(roll_ten_thousand, ylim=c(0,8000))

#8
score <- replicate(10000, {
   s1 <- sample(prob_df1$Score, 1, p = prob_df1$Prob)
   s2 <- sample(prob_df2$Score, 1, p = prob_df2$Prob)
   s1 + s2
})
hist(score)

#9
mean(score)

weighted.mean(prob_df1$Score, prob_df1$Prob) + weighted.mean(prob_df2$Score, prob_df2$Prob)