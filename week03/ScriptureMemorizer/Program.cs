using System;

class Program
{
    static void Main(string[] args)
    {
        // Create the Reference and Scripture objects
        
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";
        Scripture scripture = new Scripture(reference, text);

        string userInput = "";

        // Main Game Loop
        
        while (userInput.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();

            // Display the current state (Reference + Words)
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");

            // Wait for user input
            userInput = Console.ReadLine();

            //Only hides words if the user hasn't chosen to quit
            if (userInput.ToLower() != "quit")
            {
                // 3 hides per turn
                scripture.HideRandomWords(3);
            }
        }

        //Final part: Show the fully hidden scripture one last time
        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nAll words are hidden. Well done!");
        }
    }
}