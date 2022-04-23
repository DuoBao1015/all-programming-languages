# Name: Duo Bao
# Lab Assignment: 9
# Collaborator(s):

load("ames.RData")

#1
#MEan of the variable Gr.Liv.Area
mean(ames$Gr.Liv.Area)
## answer: 1499.69

#2
#MEan of the sample of 50 for variable variable Gr.Liv.Area
ames.gr.liv.area.sample<-sample(ames$Gr.Liv.Area,50, replace = FALSE)
mean(ames$Gr.Liv.Area[ames.gr.liv.area.sample])
## answer: 1479.88

#3
# Plot set plotting space
par(mfrow=c(2,1))
area.xlim = range(ames$Gr.Liv.Area)

#4
#Plot histogram for variable Gr.Liv.Area
hist(ames$Gr.Liv.Area, xlim=area.xlim, main = "Histogram for Living Area")
abline(v=mean(ames$Gr.Liv.Area),col="red", lwd="4")

#5
#Plot histogram for sample of 50 for variable variable Gr.Liv.Area
hist(ames$Gr.Liv.Area[ames.gr.liv.area.sample], xlim=area.xlim, main = "Histogram for Living Area (Sample of 50)")
abline(v=mean(ames$Gr.Liv.Area[ames.gr.liv.area.sample]),col="red", lwd="4")

#6
replicate(5000,mean(ames$Gr.Liv.Area[sample(ames$Gr.Liv.Area,10)]))

#7
#The shape of the histogram is that of a normal distribution
area.means.10<-replicate(5000,mean(ames$Gr.Liv.Area[sample(ames$Gr.Liv.Area,10)]))
hist(area.means.10)

#8
sample_means50 = do(5000) * mean(sample(area, 50))

#9
sample_means50 = rep(NA, 5000)

sample_means50[1] = mean(sample(area, 50))
sample_means50[2] = mean(sample(area, 50))
sample_means50[3] = mean(sample(area, 50))
sample_means50[4] = mean(sample(area, 50))

#10
sample_means1 <- rep(NA, 5000)
sample_means2930 <- rep(NA, 5000)

for(i in 1:5000){
  samp <- sample(area, size = 1, replace = TRUE)
  sample_means10[i] <- mean(samp)
  samp <- sample(area, size = 2930, replace = TRUE)
  sample_means100[i] <- mean(samp)
}

