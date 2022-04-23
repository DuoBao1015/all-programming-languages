# Name: Duo Bao
# Lab Assignment: 6
# Collaborator(s):

# part 1
suits = c('Spade', 'Heart', 'Diamond', 'Club')
ranks = c('Ace', '2', '3', '4', '5', '6', '7', '8', '9', '10', 'Jack', 'Queen', 'King')

cards = expand.grid(suit = suits, rank = ranks)

p_table = prop.table(table(cards$suit, cards$rank))
sum(p_table['Spade', ]) ## answer: 0.25
sum(p_table[, 'Ace'])   ## answer: 0.0769
p_table['Spade', 'Ace'] ## answer: 0.0192

n = nrow(cards)
set.seed(2)
ind = sample(n, 10)
cards[ind, ]
##      suit  rank
##21   Spade     6
##15 Diamond     4
##6    Heart     2
##50   Heart  King
##32    Club     8
##8     Club     2
##17   Spade     5
##29   Spade     8
##46   Heart Queen
##12    Club     3

cards_new = cards[-ind, ]
p_table_new = prop.table(table(cards_new$suit, cards_new$rank))
sum(p_table_new['Spade', ]) ## answer: 0.2381
sum(p_table_new[, 'Ace'])   ## answer: 0.0952
p_table_new['Spade', 'Ace'] ## answer: 0.0238
##They are not the same as in step 3 because this is a without replacement sample.


# part 2
res = expand.grid(roll1 = 1:6, roll2 = 1:6, roll3 = 1:6)

res$sum = rowSums(res)

barplot(prop.table(table(res$sum)))
##The most likely 2 outcomes are 10 and 11.

sum_of_three_dices = replicate(1000, sum(sample(1:6, 3, replace = TRUE)))
barplot(prop.table(table(sum_of_three_dices)))
##This is roughly the same as the result from step 8 (slight difference).

sum_of_top_three_dices = replicate(1000, sum(sort(sample(1:6, 5, replace = TRUE))[3:5]))
barplot(prop.table(table(sum_of_top_three_dices)))
##This is obviously different from the results from steps 8 and 9.

