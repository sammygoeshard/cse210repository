using System;

class Program
{
    static void Main(string[] args)
    {

        string descriptionB = "This activity will help you lower your stress levels through deep, rhythmic breathing.\nLet go of the tension in your body and follow the timed cues closely.";
        string descriptionR = "This activity will help you reflect on times in your life when you have shown strength and resilience.\nThis will help you recognize the power you have and how you can use it in other aspects of your life.";
        string descriptionL = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        ActivityLog log = new ActivityLog();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. View activity log");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine().Trim();

            if (choice == "1")
            {
                BreathingActivity act = new BreathingActivity("Breathing Activity", descriptionB, 0);
                act.Run();
                log.Record("Breathing");
            }
            else if (choice == "2")
            {
                ReflectingActivity act = new ReflectingActivity("Reflection Activity", descriptionR, 0);
                act.Run();
                log.Record("Reflection");
            }
            else if (choice == "3")
            {
                ListingActivity act = new ListingActivity("Listing Activity", descriptionL, 0, 0);
                act.Run();
                log.Record("Listing");
            }
            else if (choice == "4")
            {
                Console.Clear();
                log.Display();
                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
            }
            else if (choice == "5")
            {
                Console.WriteLine("\nThank you for using the mindfulness program.");
                return;
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Press Enter and try again...");
                Console.ReadLine();
            }
        }
    }
}
