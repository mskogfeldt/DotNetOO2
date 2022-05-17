using DotNetOO2;
using System;
using System.Collections.Generic;

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

bool keepOn = true;
int currentPartysHeadCount = 0;
int currentPartysTotalCost = 0;

List<int> agesOfCustomers = new List<int>() { };
InputState currentInputState = InputState.MainMenu;

ProgramLoop();




void ProgramLoop()
{
    while (keepOn) BookingSystem();
}

void BookingSystem()
{
    switch (currentInputState)
    {
        case InputState.MainMenu:

            Console.WriteLine("Press 0 to close This app: ");
            Console.WriteLine("Press 1 to buy tickets: We also provide a service that calculates the total cost ");
            Console.WriteLine("Press 2 to get to write a bunch of words and if it is at least three words we will print the third one! ");
            Console.WriteLine("Press 3 to print a word of your choise 10 times");



            string userInput = Console.ReadLine();

            if (userInput == "0")
            {
                currentInputState = InputState.QuitApp;
            }
            else if (userInput == "1")
            {
                Console.WriteLine("Buy Ticket!");
                currentInputState = InputState.InputNumberOfCustomers;
            }
            else if (userInput == "2")
            {
                Console.WriteLine("TextThing");
                currentInputState = InputState.CutingEdgeCinemaAppFunction;
            }
            else if (userInput == "3")
            {
                Console.WriteLine("Ten prints");
                Console.WriteLine("Enter the word");
                string input = UserInput();
                TenTypes(input);
            }
            else Console.WriteLine("Wrong input. Please follow instructions");


            break;

        case InputState.QuitApp:

            Console.WriteLine("Thanks come again");
            keepOn = false;

            break;

        case InputState.InputNumberOfCustomers:

            SelectNumberOfTickets();

            break;

        case InputState.BuyTickets:
            BuyTicket();
            break;

        case InputState.CutingEdgeCinemaAppFunction:

            TextThingy();
            break;

    }
}

void BuyTicket()
{

    if (currentPartysHeadCount > 0)
    {
        Console.WriteLine("Enter age of this ticketholder");
        Console.WriteLine("Enter 0 to go to main menu");
        string age = UserInput();
        if (age != "0" && CheckUserInput(age))
        {
            currentPartysTotalCost += CostOfTicket(Int32.Parse(age));
            Console.WriteLine("Cost so far: " + currentPartysTotalCost);
            currentPartysHeadCount--;
            if (currentPartysHeadCount == 0)
            {
                Console.WriteLine("Thanks for your order, enjoy the movie!");
                currentInputState = InputState.MainMenu;
                currentPartysTotalCost = 0;
            }

        }
        else if (age == "0")
        {
            Console.WriteLine("Order Canselled!");
            currentInputState = InputState.MainMenu;
            currentPartysHeadCount = 0;
            currentPartysTotalCost = 0;
        }
        else Console.WriteLine("Wrong Input, please write only numbers");
    }
}

void SelectNumberOfTickets()
{
    Console.WriteLine("Enter number of tickets you wish to buy");
    Console.WriteLine("Press 0 to get to main menu");
    string tickets = UserInput();
    if (tickets != "0" && CheckUserInput(tickets))
    {
        currentPartysHeadCount = Int32.Parse(tickets);
        currentInputState = InputState.BuyTickets;

    }
    else if (tickets == "0")
    {
        currentInputState = InputState.MainMenu;
    }
    else
    {
        Console.WriteLine("Wrong Input, please write only numbers");

    }

}

int CostOfTicket(int age)
{
    if (age < 18) return 80;
    else if (age > 64) return 90;
    else return 120;
}

string UserInput()
{
    return Console.ReadLine();
}

bool CheckUserInput(string userInput)
{
    int inputValue;
    if (int.TryParse(userInput, out inputValue)) return true;
    else return false;
}

string[] SplitText(string text)
{
    
    string[] splitedString = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    //return splitedString.Select(s => s.Trim()).ToArray();
    return splitedString;

}

void TextThingy()
{
    Console.WriteLine("Enter your text and if its three words or more we will return the third word");
    Console.WriteLine("Then you will go to main menu");
    string text = UserInput();
    string[] splitedString = SplitText(text);
    if (splitedString.Length > 2) Console.WriteLine("Third word was: " + splitedString[2]);
    else Console.WriteLine("To few words for uss to print the third one");

    currentInputState = InputState.MainMenu;
}

void TenTypes(string input)
{
    for (int i = 0; i < 10; i++)
    {
        Console.Write((i+1) + "." + input + " ");
    }
}


