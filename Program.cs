using System;

namespace PackageExpress

    class Program
  
        static void Main(string[] args)
  
            Display welcome message to the user
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

            Prompt user for the package weight
            Console.WriteLine("Please enter the package weight:");
            Convert user input (string) into an integer for calculations
            int weight = Convert.ToInt32(Console.ReadLine());

            Check if weight is greater than 50
            if (weight > 50)
            
                Display error message if weight exceeds 50
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                Exit the program
                return;

            Prompt user for the package width
            Console.WriteLine("Please enter the package width:");
            int width = Convert.ToInt32(Console.ReadLine());

            Prompt user for the package height
            Console.WriteLine("Please enter the package height:");
            int height = Convert.ToInt32(Console.ReadLine());

            Prompt user for the package length
            Console.WriteLine("Please enter the package length:");
            int length = Convert.ToInt32(Console.ReadLine());

            Check if total dimensions exceed 50
            if (width + height + length > 50)

                Display error message if dimensions are too large
                Console.WriteLine("Package too big to be shipped via Package Express.");
                Exit the program
                return;
                
            Multiply the three dimensions together
            int dimensionsProduct = width * height * length;

            Multiply the product of dimensions by the weight
            int volumeTimesWeight = dimensionsProduct * weight;

            Divide the outcome by 100 to calculate the shipping quote
            decimal quote = (decimal)volumeTimesWeight / 100;

            Display the quote to the user as a dollar amount (formatted to 2 decimal places)
            Console.WriteLine("Your estimated total for shipping this package is: $" + quote.ToString("0.00"));

            Thank the user
            Console.WriteLine("Thank you!");