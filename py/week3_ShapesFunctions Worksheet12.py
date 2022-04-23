import turtle
def dodecagon(turtle, length):
    angle = 360/12
    for i in range(12):
        turtle.forward(length) #Assuming the side of a pentagon is length units
        turtle.right(angle) #Turning the turtle by n degree
t = turtle.Turtle()
dodecagon(turtle, 50)