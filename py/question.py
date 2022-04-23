from tkinter import *
from tkinter import messagebox

def sel():
   selection = "You selected the option " + str(var.get())
   label.config(text = selection)

root = Tk()
root.title('Tkinter Window - Center')
root.geometry("1000x600")
root.eval('tk::PlaceWindow . center')
var = IntVar()
R1 = Radiobutton(root, text="The consumer is a college student who wants to buy gifts for her roommate. \n"
                            "The consumer has limited financial ability and has a budget of 200 US dollars. \n"
                            "There are two roommates in her. Both roommates are women. Both roommates like cosmetics.\n "
                            "One of them likes food and the other likes to play games. Both are college classmates of consumers,\n "
                            "one is art major and the other is business. \n"
                            "Consumers will use the gift card program to find a suitable gift card choice.",
                 font=("Arial", 20), variable=var, value=1,
                  command=sel)
R1.pack( anchor = W )
R1.pack(ipadx=20, ipady=30)



def msg1():
    messagebox.askyesno('Yes|No', 'You want to buy the gift card for yourself?')
    messagebox.askyesno('Yes|No', 'Are you also want buy gift card for others?')
    messagebox.askyesno('Yes|No', 'The user gender for use this gift card is a female.')
    messagebox.askyesno('Yes|No', 'The user gender for use this gift card is a male.')
    messagebox.askyesno('Yes|No', 'The user who uses this gift card is over 18 years old.')
    messagebox.askyesno('Yes|No', 'Consumers are most interested in electronic products.')
    messagebox.askyesno('Yes|No', 'Consumers are most interested in cosmetics.')
    messagebox.askyesno('Yes|No', 'Consumers are most interested in toys and models.')
    messagebox.askyesno('Yes|No', 'The person you want to give the gift card to is currently a student.')
    messagebox.askyesno('Yes|No', 'Consumers like good food.')
    messagebox.askyesno('Yes|No', 'The gift card you want to buy can be turned into a collectible product.')
    messagebox.askyesno('Yes|No', 'The gift card you want to buy can be used at any time in your daily life.')
    messagebox.showinfo("showinfo", "This information is only a reference based on the data, and the user has already understood the content.")
    messagebox.askretrycancel("askretrycancel", "I need to re-reference options to help me make better choices.")
    messagebox.showinfo("showinfo", "According to a market survey from 2021, women’s purchase decisions on cosmetics are about 86%. "
                                    "Therefore, it is a good choice to send out cosmetic-related gift cards for women, such as Sephora's gift cards. "
                                    "48% of women are deciding on consumer electronics products, although the second gift card you choose shows that users are suitable for BestBuy. "
                                    "However, given that the user is a female, sitting and playing games for a long time will affect the skin, so it is recommended that you buy a Starbucks gift card, "
                                    "because the user is a student, so according to the survey, about 87% of the students would be better than the next day if they played the game "
                                    "the night before Students who play games reduce their concentration by 25%, and irregular lifestyles affect the quality of their skin. According to your record, "
                                    "both shopping cards are accepted by women, so cosmetics are the first choice, followed by Starbucks gift cards.")



Button(root, text='Click Me', command=msg1,width=20, height=10,background="white").pack(pady=100)
label = Label(root)
label.pack()
root.mainloop()