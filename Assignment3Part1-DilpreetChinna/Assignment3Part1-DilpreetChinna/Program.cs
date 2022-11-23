using System;
using System.Linq;

namespace Assignment3Part1_DilpreetChinna
{
    internal class Program
    {
        static void Main(string[] args)
        {  /* Purpose:             
            * Inputs: string program, string playAgainCraps, string playAgainPig,double maount
            * Outputs: double amount (amount to be won/lost)             
            * Test Plan: Added screenshots
            * Written by: Dilpreet Chinna
            * Instructor Name : Carlos Estoy
            * Section No: E01
            * Last modified: 2022-11-20 */
            string program = "";
            string playAgainCraps = "", playAgainPig = "";

            do
            {
                Console.WriteLine("------------------");
                Console.WriteLine("CPSC1012 Casino");
                Console.WriteLine("------------------");
                Console.WriteLine("1. Play Craps");
                Console.WriteLine("2. Play Pig");
                Console.WriteLine("0. Exit Program");
                Console.WriteLine("------------------");
                Console.WriteLine("Enter you menu number choice");
                program = Console.ReadLine();

                if (program != "1" && program != "2" && program != "0")
                {                    
                    Console.WriteLine("{0} is not a valid menu choice. Try again", program);
                }
               
                if (program == "1")
                {
                    do
                    {
                        playCraps();
                        Console.WriteLine("Do you want to play again (y/n)");
                        playAgainCraps = Console.ReadLine();
                        if (playAgainCraps != "y" && playAgainCraps != "n")
                        {
                            Console.WriteLine("Error Input Value. y or n");
                        }
                    }
                    while (playAgainCraps != "n");                    
                }
                if (program == "2")
                {
                    do
                    {
                        PlayPig();
                        Console.WriteLine("Do you want to play again (y/n)");
                        playAgainPig = Console.ReadLine();
                        if (playAgainPig != "y" && playAgainPig != "n")
                        {
                            Console.WriteLine("Error Input Value. y or n");
                        }
                    }
                    while (playAgainPig != "n");
                    

                }
            }
            while (program != "0");
            Console.WriteLine("Good-bye and thanks for coming to the CPSC1012 Casino.");
        }
        public static void playCraps()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Play Craps");
            Console.WriteLine("------------------");

            Console.WriteLine("Enter amount to bet");
            double amount = double.Parse(Console.ReadLine());

            Random rnd = new Random();
            int num1 = rnd.Next(1, 7); //can be replaced with loop
            int num2 = rnd.Next(1, 7);
            int total = num1 + num2;
            int[] number = { 4, 5, 6, 8, 9, 10 };
            Console.WriteLine("You rolled {0} + {1} = {2}", num1, num2, total);

            if (total == 2 || total == 3 || total == 12)
            {
                Console.WriteLine("You lost $" + amount);
            }
            if (total == 7 || total == 11)
            {
                Console.WriteLine("You win $" + amount);
            }
            if (number.Contains(total))
            {
                Console.WriteLine("Point is {0}", total);
                int num3 = rnd.Next(1, 7); //can be replaced with loop
                int num4 = rnd.Next(1, 7);
                int total2 = num3 + num4;
                Console.WriteLine("You rolled {0} + {1} = {2}", num3, num4, total2);
                if (total2 == 7 || total2 == total)
                {
                    Console.WriteLine("You lost $" + amount);
                }
                else
                {
                    Console.WriteLine("You Win $" + amount);
                }
            }
        }
        public static void PlayPig()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Game of Pig");
            Console.WriteLine("------------------");

            Console.WriteLine("Enter the point total to play for:");
            double pigAmount = double.Parse(Console.ReadLine());
            char pointValue = ' ';
            int totalPoints = 0, computerTotalPoints = 0;

            Console.WriteLine("It's your turn");
            Random rnd = new Random();


            while (pointValue != 'h')
            {
                int number = rnd.Next(1, 7);
                if (number == 1)
                {
                    totalPoints = 0;
                    Console.WriteLine("You rolled a {0}", number);
                    Console.WriteLine("Your turn score is {0}", totalPoints);
                    pointValue = 'h';
                }
                else
                {
                    Console.WriteLine("Enter r to roll or h to hold");
                    pointValue = char.Parse(Console.ReadLine());

                    Console.WriteLine("You rolled a {0}", number);
                    totalPoints += number;
                }
            }

            Console.WriteLine("It's the computer's turn");

            bool computerHold = false;
            while (computerTotalPoints < 10 && computerHold != true)
            {
                int computerRandom = rnd.Next(2, 7);
                if (computerRandom == 1)
                {
                    Console.WriteLine("Computer rolled a {0}", computerRandom);
                    computerTotalPoints = 0;
                    Console.WriteLine("Your turn score is {0}", computerTotalPoints);
                    computerHold = true;

                }
                else
                {
                    Console.WriteLine("Computer rolled a {0}", computerRandom);
                    computerTotalPoints += computerRandom;
                    computerHold = false;                    
                }
            }

            if (computerHold == false)
            {
                Console.WriteLine("Computer Hold");
                Console.WriteLine("It's your turn");
                while (pointValue != 'h')
                {
                    int number = rnd.Next(1, 7);
                    if (number == 1)
                    {
                        totalPoints = 0;
                        Console.WriteLine("You rolled a {0}", number);
                        Console.WriteLine("Your turn score is {0}", totalPoints);
                        pointValue = 'h';
                    }
                    else
                    {
                        Console.WriteLine("Enter r to roll or h to hold");
                        pointValue = char.Parse(Console.ReadLine());

                        Console.WriteLine("You rolled a {0}", number);
                        totalPoints += number;
                    }
                }
            }

            Console.WriteLine("Your total point is {0}", totalPoints);
            Console.WriteLine("Computer total points {0}", computerTotalPoints);


            if (totalPoints > computerTotalPoints)
            {
                Console.WriteLine("You Win {0:C}", pigAmount);
            }
            else if (totalPoints < computerTotalPoints)
            {
                Console.WriteLine("You Lost {0:C}", pigAmount);
            }
            else
            {
                Console.WriteLine("Tie {0:C}", pigAmount);
            }
        }
    }
}
