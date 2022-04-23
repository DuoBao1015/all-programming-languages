# Name: Duo Bao
# Lab Assignment: 14
# Collaborator(s):

load("mlb11.RData")

# 1
plot(runs ~ at_bats, mlb11)
## The scatterplot suggests that there a positive linear association between these variables.

# 2
cor(mlb11$runs, mlb11$at_bats)
## The correlation coefficient is 0.611, which means that 
## the strength of association between the two variables is moderate.

# 3
plot_ss(x = mlb11$at_bats, y = mlb11$runs)
## SSE = 125950.6
## The regression equation: runs = -2239.0381 + 0.5303at_bats

# 4
fit = lm(runs ~ at_bats, mlb11)
fit
## The OLS regression equation: runs = -2789.2429 + 0.6305at_bats
## Both intercept and slope of the two regression equations are different.

# 5
summary(fit)
## The R-squared is 0.3729, which means that
## 37.29% of the variability in runs is explained by at_bats.

# 6
par(mfrow = c(1, 2))
plot(fit, 1:2)
## The Residual vs Fitted plot shows that the assumption linearity and
## constant variability are met because the these points have no obvious pattern.
## The Normal Q-Q plot reveals that the nearly normal residuals
## assumption is met these points appear to follow a straight line.

# 7
fit_new = lm(runs ~ homeruns, mlb11)
fit_new
## The regression equation: runs = 415.239 + 1.835homeruns

# 8
summary(fit_new)
## The R-squared is 0.6266 > 0.3729, so the homeruns is  a better predictor of runs.
## The slope for at_bats is 0.6305, which means that
## the mean runs increases 0.6305 units as at_bats increases one-unit.
## The slope for homeruns is 1.835, which means that
## the mean runs increases 1.835 units as homeruns increases one-unit.

# 9
variables = c('hits', 'bat_avg', 'strikeouts', 'stolen_bases', 'wins')
Rsq = numeric(5)
for (i in 1:5) {
  Rsq[i] = summary(lm(mlb11$runs ~ mlb11[, variables[i]]))$r.sq
}
names(Rsq) = variables
Rsq
## The variable bat_avg is the best predictor of runs because it has the highest R-squared.

# 10
model = lm(runs ~ at_bats + hits + homeruns + bat_avg + strikeouts + stolen_bases + wins, mlb11)
summary(model)
## The R-squared is 0.9182, which means that
## 91.82% of the variability in runs is explained by multiple regression model.
## This is because the R-squared incereas as the number of predictors incereases.

