using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Program
    {
        static int rand = 0;
        static void Main(string[] args)
        {
            /*
             * Shaun Wehe
             * February 19, 2019
             * Project and Portfolio2
             * Exercise 5: Rock, Paper, Scissors, Lizard, Spock
             */

            string inputLine, playerChoice = "", computerChoice =  "", resultString = "";
            int gameCount, gamePlayerWins, gameTies, gameComputerWins, result;
            bool programRunning = true, selectionMade;

            while (programRunning)
            {
                gameCount = 0;
                gamePlayerWins = 0;
                gameTies = 0;
                gameComputerWins = 0;
                selectionMade = false;

                while (gameCount < 10)
                {
                    Console.Clear();
                    Console.WriteLine($"Game {gameCount+1}\n" +
                        "Which do you choose:\n" +
                        "1. Rock\n" +
                        "2. Paper\n" +
                        "3. Scissors\n" +
                        "4. Lizard\n" +
                        "5. Spock");
                    Console.Write("Selection: ");
                    inputLine = Console.ReadLine().ToLower();

                    switch (inputLine)
                    {
                        case "1":
                        case "rock":
                            playerChoice = "rock";
                            selectionMade = true;
                            break;
                        case "2":
                        case "paper":
                            playerChoice = "paper";
                            selectionMade = true;
                            break;
                        case "3":
                        case "scissors":
                            playerChoice = "scissors";
                            selectionMade = true;
                            break;
                        case "4":
                        case "lizard":
                            playerChoice = "lizard";
                            selectionMade = true;
                            break;
                        case "5":
                        case "spock":
                            playerChoice = "spock";
                            selectionMade = true;
                            break;
                        default:
                            Console.WriteLine("That is not a recognized input. Please try again.");
                            Utility.KeyToProceed();
                            break;
                    }

                    if (selectionMade)
                    {
                        computerChoice = DetermineComputerChoice();
                        result = DetermineResult(playerChoice, computerChoice);

                        switch (result)
                        {
                            case -1:
                                gameComputerWins += 1;
                                resultString = "Computer Wins!";
                                break;
                            case 0:
                                gameTies += 1;
                                resultString = "It's a Tie!";
                                break;
                            case 1:
                                gamePlayerWins += 1;
                                resultString = "Player Wins!";
                                break;
                            default:
                                //This should never be seen
                                Console.WriteLine("Result not recognized.");
                                Utility.KeyToProceed();
                                break;
                        }

                        Console.WriteLine($"Player chose {playerChoice}\n" +
                            $"Computer chose {computerChoice}\n" +
                            $"{resultString}");
                        Utility.KeyToProceed();
                        gameCount++;
                    }

                    if (gameCount >= 10)
                    {
                        Console.Clear();
                        Console.WriteLine($"Player Wins: {gamePlayerWins}\n" +
                            $"Player/Computer Ties: {gameTies}\n" +
                            $"Computer Wins: {gameComputerWins}\n");
                        Console.WriteLine("Would you like to play again?");
                        Console.Write("Y/N: ");
                        inputLine = Console.ReadLine().ToLower();
                        while (!(inputLine == "y" || inputLine == "n" || inputLine == "yes" || inputLine == "no"))
                        {
                            Console.WriteLine("That is not a recognized answer. Please enter either (y)es or (n)o.");
                            Console.Write("Y/N: ");
                            inputLine = Console.ReadLine().ToLower();
                        }

                        switch (inputLine)
                        {
                            case "y":
                            case "yes":
                                programRunning = true;
                                break;
                            case "n":
                            case "no":
                                programRunning = false;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        public static string DetermineComputerChoice()
        {
            rand++;
            Random random = new Random();
            int value = 0;
            string compChoice = "";
            for (int i = 0; i < rand; i++)
            {
                value = random.Next();
            }
            value = value % 5;
            switch (value)
            {
                case 0:
                    compChoice = "rock";
                    break;
                case 1:
                    compChoice = "paper";
                    break;
                case 2:
                    compChoice = "scissors";
                    break;
                case 3:
                    compChoice = "lizard";
                    break;
                case 4:
                    compChoice = "spock";
                    break;
                default:
                    compChoice = "rock";
                    break;
            }
            return compChoice;
        }

        public static int DetermineResult(string player, string computer)
        {
            int result = 0;
            switch (player)
            {
                case "rock":
                    switch (computer)
                    {
                        case "scissors":
                        case "lizard":
                            result = 1;
                            break;
                        case "paper":
                        case "spock":
                            result = -1;
                            break;
                        case "rock":
                            result = 0;
                            break;
                        default:
                            break;
                    }
                    break;
                case "paper":
                    switch (computer)
                    {
                        case "rock":
                        case "spock":
                            result = 1;
                            break;
                        case "scissors":
                        case "lizard":
                            result = -1;
                            break;
                        case "paper":
                            result = 0;
                            break;
                        default:
                            break;
                    }
                    break;
                case "scissors":
                    switch (computer)
                    {
                        case "paper":
                        case "lizard":
                            result = 1;
                            break;
                        case "rock":
                        case "spock":
                            result = -1;
                            break;
                        case "scissors":
                            result = 0;
                            break;
                        default:
                            break;
                    }
                    break;
                case "lizard":
                    switch (computer)
                    {
                        case "paper":
                        case "spock":
                            result = 1;
                            break;
                        case "scissors":
                        case "rock":
                            result = -1;
                            break;
                        case "lizard":
                            result = 0;
                            break;
                        default:
                            break;
                    }
                    break;
                case "spock":
                    switch (computer)
                    {
                        case "rock":
                        case "scissors":
                            result = 1;
                            break;
                        case "paper":
                        case "lizard":
                            result = -1;
                            break;
                        case "spock":
                            result = 0;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
