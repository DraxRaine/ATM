using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName; 
        this.lastName = lastName;  
        this.balance = balance;
    }

    /* Get functions */
    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    /* Set functions */

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options ... ");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdrawl");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit?  ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit + currentUser.getBalance());
            Console.WriteLine("Thank you for your deposit. We will use it to invest and make more money off your labors so thanks again chump. Your new balance is: " + currentUser.getBalance());
        }

        void withdrawal(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdrawal:  ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //Check if the user has enough money 
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance:(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're good to go you simp! THANK YOU VERY MUCH! :)");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1", 1234, "John", "Grif", 150.31));
        cardHolders.Add(new cardHolder("2", 4321, "Ash", "Jones", 321.13));
        cardHolders.Add(new cardHolder("3", 9999, "Frida", "Dickerson", 105.59));
        cardHolders.Add(new cardHolder("4", 2468, "Muneeb", "Harding", 851.84));
        cardHolders.Add(new cardHolder("5", 4826, "Dawn", "Smith", 54.27));

        /* Prompt User */ 
        Console.WriteLine("Welcome to SIMP ATM fool.");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                /* Check against our LIST */
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again fool!"); }

            }
            catch { Console.WriteLine("Card not recognized. Please try again fool!");}
        }

        Console.WriteLine("Please enter your pin punk!");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                /* Check against our LIST */
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin, are you thief... You look like a thief, re-enter your pin... If you dare."); }

            }
            catch { Console.WriteLine("Incorrect pin, are you thief... You look like a thief, re-enter your pin... If you dare."); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :-)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { deposit(currentUser); }
            else if (option == 2) { withdrawal(currentUser);}
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0;  };

        }
        while (option != 4);
        Console.WriteLine("Thanks for wasting time but I guess it was alright since I have your money... ");

    }

}