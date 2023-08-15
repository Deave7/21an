namespace _21an
{
    internal class Program
    {
       static void DiceSimulator() //P1.2
        {
            Random random = new Random();

            Console.WriteLine("Welcome to the DICE SIMULATOR!");
            Console.WriteLine("------------------------------");

            Console.WriteLine("\n Please choose how many dice you would like to throw and how many sides the dice should have: ");
            Console.Write("How many dice would you like to throw? ");
            int numberOfDice = Convert.ToInt32(Console.ReadLine());

            Console.Write("How many sides should the dice have? ");
            int sidesOfDice = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numberOfDice; i++)
            {
                int diceRoll = random.Next(1, sidesOfDice + 1);
                Console.WriteLine($"Roll number: {i + 1}");
                Console.WriteLine($"You rolled: {diceRoll}");
            }
            
        }
        
        static void WheelOfFortune() //P1.1
        {

            Console.WriteLine("Welcome to the amazing WHEEL OF FORTUNE!");
            Console.Write("Please pick a number between 1 and 10: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Random random = new Random();

            int roll = random.Next(1, 11);

            if (choice == roll)
            {
                Console.WriteLine($"You guessed {choice} which was the number that the wheel landed on! :)");
            }
            else
            {
                Console.WriteLine($"You guessed {choice} which wasn't the number the wheel landed on :(");
                Console.WriteLine($"The wheel landed on {roll}");
            }
        }

        static void BlackJack()
        {
            string lastWinner = "";
            Random random = new Random();
            
            Console.WriteLine("Welcome to BLACKJACK!");
            Console.WriteLine("---------------------");

            
            
            while (true)
            {
                Console.WriteLine("\nPlease pick a option from the menu: ");
                Console.WriteLine("1. Play Blackjack");
                Console.WriteLine("2. Show the last winner");
                Console.WriteLine("3. Show the rules");
                Console.WriteLine("4. Quit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        int userPoints = 0;
                        int dealerPoints = 0;

                        int userCard1 = random.Next(2, 11);
                        int userCard2 = random.Next(2, 11);
                        
                        Console.WriteLine($"Player card 1: {userCard1}");
                        Console.WriteLine($"Player card 2: {userCard2}");

                        userPoints += userCard1 + userCard2;

                        Console.WriteLine($"Your point total is: {userPoints}");

                        int dealerCard1 = random.Next(2, 11);
                        int dealerCard2 = random.Next(2, 11);

                        Console.WriteLine($"Dealer card 1: {dealerCard1}");
                        Console.WriteLine($"Dealer card 2: {dealerCard2}");

                        dealerPoints += dealerCard1 + dealerCard2;

                        Console.WriteLine($"The dealers point total is: {dealerPoints}");

                        Console.WriteLine("Choose [P]ull card or [S]tay");
                        string pullOrStay = Console.ReadLine();

                        while (pullOrStay.ToUpper() == "P")
                        {
                            int userCard3 = random.Next(2, 11);
                            userPoints += userCard3;

                            Console.WriteLine($"You pulled a {userCard3}, your new point total is: {userPoints}");

                            if (userPoints > 21)
                            {
                                Console.WriteLine("You went B-U-S-T! Dealer wins");
                                lastWinner = "Dealer";
                                pullOrStay = " ";
                                break;

                            }
                            else
                            {
                                Console.WriteLine("Choose [P]ull card or [S]tay");
                                pullOrStay = Console.ReadLine();
                            }

                        }

                        while (pullOrStay.ToUpper() == "S")
                        {
                            if (dealerPoints < userPoints && dealerPoints <= 21)
                            {
                                int dealerCard3 = random.Next(2, 11);
                                dealerPoints += dealerCard3;

                                Console.WriteLine($"The dealer pulled a {dealerCard3} and their new point total is: {dealerPoints}");

                                if (dealerPoints >= 22)
                                {
                                    Console.WriteLine("The dealer went B-U-S-T! You win!");
                                    lastWinner = "Player";
                                    break;
                                }
                                else if (dealerPoints > userPoints && dealerPoints >= 21)
                                {
                                    Console.WriteLine("The dealer got more points than you without going B-U-S-T! Dealer wins");
                                    lastWinner = "Dealer";
                                    break;
                                }
                            }
                            else if (userPoints == dealerPoints)
                            {
                                int dealerCard3 = random.Next(2, 11);
                                dealerPoints += dealerCard3;

                                Console.WriteLine($"The dealer pulled a {dealerCard3} and their new point total is: {dealerPoints}");
                            }
                            else
                            {
                                Console.WriteLine("The dealer got more points than you without going B-U-S-T! Dealer wins");
                                lastWinner = "Dealer";
                                break;
                            }
                        }
                        break;

                    case 2:
                        Console.WriteLine($"The last round was won by: {lastWinner}");
                        break;

                    case 3:
                        Console.WriteLine("R U L E S:");
                        Console.WriteLine("Blackjack hands are scored by their point total.");
                        Console.WriteLine("The hand with the highest points wins as long as it doesn't exceed 21.");
                        Console.WriteLine("A hand with a point total over 21 is called a \"bust\"");
                        Console.WriteLine("Cards 2 through 10 are worth their face value and face cards (jack, queen and king) are worth 10");
                        Console.WriteLine("An ace's value is 11 unless this would cause the player to bust, in which case it is worth 1.");
                        Console.WriteLine("Every player including the dealer is dealt two cards at the start of each round");
                        Console.WriteLine("The player may choose to pull more cards until they are satisfied or go over 21");
                        Console.WriteLine("The dealer will then pull cards until they have more points than the player or goes over 21");
                        break;

                    case 4:
                        Console.WriteLine("The program is shutting down, thanks for playing and see you next time!");
                        return;

                    default:
                        Console.WriteLine("Your input was invalid");
                        break;
                }

            }

           


        }

        static void Main(string[] args)
        {
            BlackJack();
        }
    }
}