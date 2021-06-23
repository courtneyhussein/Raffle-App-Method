using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            MultiLineAnimation();
            PrintGuestsName();
            PrintWinner();
            Console.ReadLine();



        }

        //Start writing your code here

        private static Dictionary<int, string> guests = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static int raffleNumber;
        private static Random _rdm = new Random();



        //Method to get user input
        private static string GetUserInput(string request)
        {
            Console.WriteLine(request);
            string input = Console.ReadLine();
            return input;
        }

        //Method to get user info.
        private static void GetUserInfo()
        {
            string otherGuest = "yes";
            string name;
            raffleNumber = 0;

            while (otherGuest == "yes")
            {
                
                //Validtate that user does not enter empty string.
                do
                {
                    name = GetUserInput("Please enter guest name: ");
                }
                while (name == "");

                //Generate a random raffle number for the guest (making sure no other guest already has that raffle number.)
                do
                {
                    raffleNumber = GenerateRandomNumber(min, max);
                }
                while (guests.ContainsKey(raffleNumber));
                
                //Add guest name and raffle number to dictionary.
                AddGuestsInRaffle(raffleNumber, name);

                //Ask if user would like to add another guest.
                otherGuest = GetUserInput("Would you like to add another guest?").ToLower();
            }
        }

        //Create method that generates a random number between min and max numbers.
        private static int GenerateRandomNumber(int min, int max)
        {
            return _rdm.Next(min, max);
        }

        //Create method that adds guest and raffle number to dictionary.
        private static void AddGuestsInRaffle(int raffleNumber, string guest)
        {
            guests.Add(raffleNumber, guest);
        }

        //Create method that prints guest names and raffle numbers.
        private static void PrintGuestsName()
        {
            foreach (var pair in guests)
            {
                Console.WriteLine($"Guest Name: {pair.Value} Raffle Number: {pair.Key}");
            }
        }

        //Create method to select random guest number.
        private static int GetRaffleNumber(Dictionary<int, string> people)
        {
            int index = GenerateRandomNumber(0, people.Count);
            return people.Keys.ElementAt(index);
        }

        //Create method that prints teh name of the winner and thier raffle number.
        private static void PrintWinner()
        {
            int winningNum = GetRaffleNumber(guests);
            Console.WriteLine($"\nThe Winner is: {guests[winningNum]} with the #{winningNum}");

        }
                

        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    }
}
