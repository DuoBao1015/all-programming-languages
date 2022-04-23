import turtle
def nonagon(turtle, length):
    angle = 360/9
    for i in range(9):
        turtle.forward(length) #Assuming the side of a pentagon is length units
        turtle.right(angle) #Turning the turtle by n degree
turtle = turtle.Turtle()
nonagon(turtle, 50)
