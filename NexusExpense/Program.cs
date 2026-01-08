namespace NexusExpense
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Nexus Expense - CLI \nA console app for managing transactions and budget health");
            //Getting the monthly budget from the user.
            Console.Write("Enter your monthly budget: ");
            string? budgetInput = Console.ReadLine();
            double budget;
            while (string.IsNullOrWhiteSpace(budgetInput) || !double.TryParse(budgetInput, out budget))
            {
                Console.Write("\nPlease enter a valid budget: ");
                budgetInput = Console.ReadLine();
            }
            budget = double.Parse(budgetInput);

            //getting the transactions based on category.
            Console.WriteLine("You can start entering the expenses");
            int choice  = 0;
            while (choice != 4) //get the transactions until user enters 4 which exits the program.
            {
                Console.WriteLine("These are categorized into 3 groups - Press 1 for Essential, " +
                    "Press 2 for Personal, Press 3 for Miscellaneous " +
                    "\nand Press 4 to exit the program");
                string? choiceInput = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(choiceInput) 
                    || !int.TryParse(choiceInput, out choice) 
                    || int.Parse(choiceInput) < 0 
                    || int.Parse(choiceInput) > 4)
                {
                    Console.Write("\nPlease enter a valid choice (1-4): ");
                    choiceInput = Console.ReadLine();
                }
                choice = int.Parse(choiceInput);

                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
            }
            
        }
    }
}
