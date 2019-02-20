using System;

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

            string inputLine, playerChoice = "", computerChoice =  "", resultString = "", resultAction = "";
            int gameCount, gamePlayerWins, gameTies, gameComputerWins, result;
            bool programRunning = true, selectionMade;

            //Loop until selection is made to stop looping
            while (programRunning)
            {
                //Reset all values to start loop
                gameCount = 0;
                gamePlayerWins = 0;
                gameTies = 0;
                gameComputerWins = 0;
                selectionMade = false;

                //Loop for 10 games
                while (gameCount < 10)
                {
                    //Clear screen and display menu asking for user input
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

                    //Standardize player input for use later
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

                    //Only runs if a selection was made, ensuring that games are not added when invalid input is recieved
                    if (selectionMade)
                    {
                        //Calls to methods to get computer choice and the result of the match
                        computerChoice = DetermineComputerChoice();
                        result = DetermineResult(playerChoice, computerChoice);

                        //Despending on result value, increment appropriate variable and set resultString variable to display result to user
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

                        if (result != 0)
                        {
                            if (result == 1) { resultAction = DetermineAction(playerChoice, computerChoice); }
                            if (result == -1) { resultAction = DetermineAction(computerChoice, playerChoice); }
                        }

                        //Tell user the choice they made and the computer was determined to have made, then display resultString to inform user of result
                        Console.WriteLine($"\nPlayer chose {playerChoice.ToUpper()}\n" +
                            $"Computer chose {computerChoice.ToUpper()}\n");
                        if (result != 0)
                        {
                            if (result == 1) { Console.WriteLine($"{playerChoice.ToUpper()} {resultAction} {computerChoice.ToUpper()}"); }
                            if (result == -1) { Console.WriteLine($"{computerChoice.ToUpper()} {resultAction} {playerChoice.ToUpper()}"); }
                        }
                        Console.WriteLine(resultString);
                        Utility.KeyToProceed();

                        //Increment game count to indicate game was successfully completed
                        gameCount++;
                    }

                    //Once game count is 10, display wins, losses, and ties and ask user if they want to play again
                    if (gameCount >= 10)
                    {
                        Console.Clear();
                        Console.WriteLine($"Player Wins: {gamePlayerWins}\n" +
                            $"Player/Computer Ties: {gameTies}\n" +
                            $"Computer Wins: {gameComputerWins}\n");
                        Console.WriteLine("Would you like to play again?");
                        Console.Write("Y/N: ");
                        inputLine = Console.ReadLine().ToLower();

                        //Ensures valid input from user
                        while (!(inputLine == "y" || inputLine == "n" || inputLine == "yes" || inputLine == "no"))
                        {
                            Console.WriteLine("That is not a recognized answer. Please enter either (y)es or (n)o.");
                            Console.Write("Y/N: ");
                            inputLine = Console.ReadLine().ToLower();
                        }

                        //Set programRunning variable based on user input
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
            //Creates random variable and increments static rand variable
            rand++;
            Random random = new Random();
            int value = 0;
            string compChoice = "";

            //Ensures unique random number each time method is called
            for (int i = 0; i < rand; i++)
            {
                value = random.Next();
            }

            //Mod 5 allows only 5 results to be possible, regardless of random integer chosen
            value = value % 5;

            //Determine return value based on mod 5 value
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
            //This takes in the choices of the player and computer and returns integer indicating result
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

        public static string DetermineAction(string winner, string loser)
        {
            string action = "";
            switch (winner)
            {
                case "rock":
                    action = "crushes";
                    break;
                case "scissors":
                    if (loser == "lizard") { action = "decapitates"; }
                    if (loser == "paper") { action = "cuts"; }
                    break;
                case "paper":
                    if (loser == "spock") { action = "disproves"; }
                    if (loser == "rock") { action = "covers"; }
                    break;
                case "lizard":
                    if (loser == "spock") { action = "poisons"; }
                    if (loser == "paper") { action = "eats"; }
                    break;
                case "spock":
                    if (loser == "rock") { action = "vaporizes"; }
                    if (loser == "scissors") { action = "smashes"; }
                    break;
                default:
                    action = "defeats";
                    break;
            }
            return action;
        }
    }
}
