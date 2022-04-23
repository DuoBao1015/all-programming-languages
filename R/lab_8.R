# Name: Duo Bao
# Lab Assignment: 8
# Collaborator(s):

#1
load("bdims.RData")
fdims <- subset(bdims, sex == 0, select=c(age, wgt, hgt))
fhgtmean <- mean(fdims$hgt)
hist(fdims$hgt, prob = TRUE, main="Female height histogram",
     xlab="Females heights in cm", ylim = c(0, 0.06))
abline(v = fhgtmean, col = "red")
# It appears that on average, men are taller than women, however, 
# the spread of their heights are about the same.

#2
x <- seq(min(fdims$hgt), max(fdims$hgt), 0.1)

#3
fhgtsd <- sd(fdims$hgt)
y <- dnorm(x = x, mean = fhgtmean, sd = fhgtsd)

#4
lines(x = x, y = y, col = "blue")
# According to the plot, the data appears to follow the normal distribution fairly well. 
# The observations fall pretty close to the ideal normal distribution lines.

#5
qqnorm(fdims$hgt)
qqline(fdims$hgt, col = 2)
# A large propotion of the points from sim_norm fall very close to the line. Compared to the real data.

#6
sim_norm <- rnorm(n = length(fdims$hgt), mean = fhgtmean, sd = fhgtsd)
qqnorm(sim_norm)
qqline(sim_norm, col = 2)
# the sim_norm points are closer to the line. However, 
# this is expected because it samples directly from a perfect normal distribution.

#7
qqnormsim(fdims$hgt)

#8
qqnorm(fdims$wgt)
qqline(fdims$wgt, col = 2)
qqnormsim(fdims$wgt)
qqnorm(fdims$age)
qqline(fdims$age, col = 2)
qqnormsim(fdims$age)
# According to the qq plot, female weights do not appear to be normal. The tails of the plot are not close to the line compared to a normal distribution. This indicates that there is some skewness present in the female weight distribution. 
# There is not enough evidence to conclude that female weight is normally distributed.

#9
1 - pnorm(182, mean = fhgtmean, sd = fhgtsd)
#[1] 0.004434387
mean(fdims$hgt > 182)

#10
qnorm(0.9, mean = fhgtmean, sd = fhgtsd)
quantile(fdims$hgt, 0.9)
