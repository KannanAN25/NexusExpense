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
            double budget, balance;
            while (string.IsNullOrWhiteSpace(budgetInput) || !double.TryParse(budgetInput, out budget))
            {
                Console.Write("\nPlease enter a valid budget: ");
                budgetInput = Console.ReadLine();
            }
            budget = double.Parse(budgetInput);
            balance = budget;

            //getting the transactions based on category.
            double essentialExpense, personalExpense, miscExpense, transactionAmount;
            essentialExpense = personalExpense = miscExpense = transactionAmount = 0;
            string? AmountInput;
            int transactionCount = 0;
            Console.WriteLine("\nYou can start entering the expenses");
            int choice  = 0;
            do //get the transactions until user enters 4 which exits the program.
            {
                Console.WriteLine("\nExpenses are categorized into 3 groups - Press 1 for Essential, " +
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
                        Console.Write("Enter the amount for essential expense: ");
                        AmountInput = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(AmountInput) || !double.TryParse(AmountInput, out transactionAmount))
                        {
                            Console.Write("\nPlease enter a valid amount: ");
                            AmountInput = Console.ReadLine();
                        }
                        transactionAmount = double.Parse(AmountInput);
                        essentialExpense += transactionAmount;
                        balance -= transactionAmount;
                        break;
                    case 2:
                        Console.Write("Enter the amount for personal expense: ");
                        AmountInput = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(AmountInput) || !double.TryParse(AmountInput, out transactionAmount))
                        {
                            Console.Write("\nPlease enter a valid amount: ");
                            AmountInput = Console.ReadLine();
                        }
                        transactionAmount = double.Parse(AmountInput);
                        personalExpense += transactionAmount;
                        balance -= transactionAmount;
                        break;
                    case 3:
                        Console.Write("Enter the amount for miscellaneous expense: ");
                        AmountInput = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(AmountInput) || !double.TryParse(AmountInput, out transactionAmount))
                        {
                            Console.Write("\nPlease enter a valid amount: ");
                            AmountInput = Console.ReadLine();
                        }
                        transactionAmount = double.Parse(AmountInput);
                        miscExpense += transactionAmount;
                        balance -= transactionAmount;
                        break;
                    case 4:
                        Console.WriteLine($"\nFinal Report: \nBudget = {budget}\nAmount spent = {budget - balance}\n" +
                            $"Remaining balance = {balance}\n" +
                            $"Amount spent on category wise - Essential = {essentialExpense}, Personal = {personalExpense}, Miscellaneous = {miscExpense}");
                        Console.WriteLine($"Total number of transactions/Expense = {transactionCount}");

                        if (balance == budget)
                        {   
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("\nYou did not spend anything, good, but don't waste my potential, haha");
                            Console.ResetColor();
                        }
                        else if (balance >= 0.5 * budget)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nComments - Great financial management, you have spent less than 50% of budget :)");
                            Console.ResetColor();
                        }
                        else if (balance < 0.5 * budget && balance > 0.1 * budget)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine("\nComments - Good split of expenses, try to reduce it around 50%");
                            Console.ResetColor();
                        }
                        else if (balance < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nComments - Overspent, you will be broke :(");
                            Console.ResetColor();
                        }
                        break;
                }

                if (choice != 4)
                {
                    transactionCount++;
                    if (balance < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nBudget exceeded - Please spend wisely");
                        Console.ResetColor();
                    }
                    else if (balance == 0)
                    {
                        Console.WriteLine("\nBudget completed");
                    }

                    if (transactionAmount > 0.5 * budget)
                    {   
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Large purchase transaction, be very mindful about the spending");
                        Console.ResetColor();
                    }
                }

            } while (choice != 4);
            
        }
    }
}
