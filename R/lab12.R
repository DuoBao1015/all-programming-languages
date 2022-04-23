# Name: Duo Bao
# Lab Assignment: 12
# Collaborator(s):

load('nc.RData')

# 1
by(nc$weight, nc$habit, mean)

# 2
by(nc$weight, nc$habit, length)
par(mfrow = c(1, 2))
qqnorm(nc$weight[nc$habit == 'nonsmoker'], main = 'Non-smoker')
qqline(nc$weight[nc$habit == 'nonsmoker'], col = 2, lwd = 2)
qqnorm(nc$weight[nc$habit == 'smoker'], main = 'Smoker')
qqline(nc$weight[nc$habit == 'smoker'], col = 4, lwd = 2)
## The normal Q-Q plots reveal that the normal assumptions for both populations
## are not met, but both sample size are sufficient large, then we can apply CLT.

# 3
## H0: mu1 = mu2,
## the average weights of babies born to smoking and non-smoking mothers are equal.
## H1: mu1 <> mu2
## the average weights of babies born to smoking and non-smoking mothers are different.

# 4
t.test(weight ~ habit, nc)
## The p-value is 0.019, which is relatively small, so there is significant
## difference between the weights of smokers' children and nonsmokers' children.

# 5
## The 95% CI is (0.052, 0.580), which does not include 0.8, so I
## will be surprised if the true difference in means was 0.8 pounds.

# 6
t.test(nc$weeks)
## The 95% CI is (38.153, 38.517), which includes 38.5, so I will not
## be surprised if the true average length of pregnancies was 38.5 weeks.

# 7
t.test(nc$weeks, conf.level = 0.9)
## The 95% CI is (38.152, 38.487), which does not include 38.5, so I will
## be surprised if the true average length of pregnancies was 38.5 weeks.
## The difference is because that the 90% CI is narrower than the 95% CI
## and the 95% CI includes 38.5 but the 90% CI does not include 38.5.

# 8
t.test(nc$gained ~ nc$mature)
## The p-value is 0.170, which is relatively large, so we can conclude that 
## the average weight gained  by younger mothers is equal to that by mature mothers.

# 9
boxplot(nc$mage ~ nc$mature)
by(nc$mage, nc$mature, summary)
## Based on the side-by-side boxplot and the summary output, we can use
## the 34.5 years old as the age cutoff for younger and mature mothers.

# 10
## Variables: weight and gender
## H0: mu1 = mu2, the average weights of babies between female and male babies are equal.
## H1: mu1 < mu2, the average weights of female babies are less than that of male babies.
by(nc$weight, nc$gender, length)
par(mfrow = c(1, 2))
qqnorm(nc$weight[nc$gender == 'male'], main = 'Male')
qqline(nc$weight[nc$gender == 'male'], col = 2, lwd = 2)
qqnorm(nc$weight[nc$gender == 'female'], main = 'Female')
qqline(nc$weight[nc$gender == 'female'], col = 2, lwd = 4)
## The normal Q-Q plots reveal that the normal assumptions for both populations
## are not met, but both sample size are sufficient large, then we can apply CLT.
t.test(nc$weight ~ nc$gender, alternative = 'less')
## The p-value is approxiamtely 0.000, so we can reject H0, and conclude
## that the average weights of female babies are less than that of male babies.

