# Name: Duo Bao
# Collaborator(s):

load("atheism.RData")

# 1
## These percentages are population parameters.

# 2
dat.us = subset(atheism, nationality == 'United States')
atheism.us = table(dat.us$year, dat.us$response)
atheism.us

# 3
prop.table(atheism.us[2, ])
## The proportion of respondents in 2012 who had "atheist" as their response is 0.0499.

# 4
atheism.us[2, ]
## The two values > 10, so the conditions are met.
prop.test(atheism.us[2, 1], n2012)$conf.int

# 5
prop.test(atheism.us[2, 1], n2012, p = 0.13)
## The p-value is 0.000, so the proportion of atheists in the US in 2012
## is significantly different from the global proportion in 2012, 13%.

# 6
atheism.us
## All cells >= 10, so the conditions are met.
prop.test(atheism.us[, 1], rowSums(atheism.us), alternative = 'less')
## The p-value is 0.000, so the proportion of atheists in the US in 2005
## was lower than the proportion in 2012.

# 7
n = 1000
p = seq(0, 1, 0.01)
se = sqrt(p * (1-p) / n)

# 8
plot(p, se, type = 'l')
## For the same confidence level, the larger standard errors will lead to the larger
## margins of error, so we can conclu de that the largest confidence interval at p = 0.5.

# 9
## 1.
dat.sp = subset(atheism, nationality == 'Spain')
atheism.sp = table(dat.sp$year, dat.sp$response)
## 2.
atheism.sp
## All cells > 10, so the conditions for inference are met.
prop.test(atheism.sp[, 1], rowSums(atheism.sp))
## The p-value is 0.4375, so there is no convincing evidence that
## Spain has seen a change in its atheism index between 2005 and 2012.

# 10.
## 1.
dat = subset(atheism, nationality %in% c('Brazil', 'Colombia') & year == 2012)
dat$nationality = as.character(dat$nationality)
tb = table(dat$nationality, dat$response)
## 2.
tb
## All cells > 10, so the conditions for inference are met.
## 3.
prop.test(atheism.sp[, 1], rowSums(atheism.sp), alternative = 'greater')
## The p-value is 0.2187, so there is no convincing evidence that
## the proportion of atheists in Colombia was higher than that in Brazil in 2012.