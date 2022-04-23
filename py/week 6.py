#1
def number(count):
    if count >= 1 and count <=10:
    print('True')
number(count)

#2
if name == "Snoopy":
    # when input name is snoopy run function below.
    if color == "white":
        # when name is snoopy and color is white print below.
        print("Yep, Snoopy")
    else:
        # if color is not white print below.
        print("Nope, imposter")

#3
def variable(result):
    if result == 100:
        print('answer 1')
    else:
        print('answer 2')
variable(result)

#4
def gradepoint(score):
    if score >= 90:
        print('gradepoint: 4')
    elif score >=80 and score<90:
        print('gradepoint: 3')
    elif score >=70 and score<80:
        print('gradepoint: 2')
    elif score >=60 and score<70:
        print('gradepoint: 1')
    else:
        print('gradepoint: 0')
gradepoint(score)

#5
def oranges(pounds,order):
    if pounds >=100:
        pound = float(0.32*pounds)
        orders = float(1.50*order)
        a = print(pound+orders)
    else:
        pound = float(0.32*pounds)
        orders = float(7.50*order)
        b = print(pound+orders)
oranges(pounds,order)

#6
n1 = int(input('plase enter number 1:'))
n2 = int(input('plase enter number 2:'))
n3 = int(input('plase enter number 3:'))
list = [n1,n2,n3]
print(max(list))

#7
def wage(pay_rate, hours):
    salary = psy_rate * hours
    if hours > 40:
        overtime = 40 - hours
        salary += 0.5 * overtime
    return salary

#8
# Price is: $ 1.4