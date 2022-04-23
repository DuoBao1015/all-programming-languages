# Name: Duo Bao
# Collaborator(s):

download.file("http://www.openintro.org/stat/data/nc.RData", destfile = "nc.RData")
load("nc.RData")
nc <- na.omit(nc)

# 1
##The null hypothesis is that the average number of weeks for children in North Carolina is 40.
##The alternative hypothesis is the average number of weeks for children in North Carolina is not 40.

# 2
hist(nc$weeks)
##No, the data is skewed to left. 
##The normality assumption is not necessary because the CLT can be applied with a large samle (n = 800).

# 3
xbar = mean(nc$weeks); xbar
se = sd(nc$weeks) / sqrt(nrow(nc)); se

## 4
cl = 0.99
crit = qnorm((1+cl)/2); crit

# 5
xbar + c(-1, 1) * crit * se
##The null hypothesis does not lie within the confidence interval.

# 6
zstat = (xbar-40) / se; zstat
##This is a two-sided test because the sign of the laternative hypothesis is "not equal".
pvalue = 2*pnorm(zstat); pvalue
##The p-value is approximately 0, so we can reject the null hypothesis,
##and conclude that the average number of weeks for children in North Carolina is not 40

# 7.
RR = 40 - qnorm(0.975) * se; RR

# 8
pnorm(RR, 39+6/7, se)
##No, I am not satisfied with this level of power because it is relatively low.

# 9
pnorm(RR, 39, se)
##Yes, I am satisfied with this level of power because it is the highest level.