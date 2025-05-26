//*************************************************************
// Part1_POE_PROG6221_ST10446545
// ST10446545@vcconnect.edu.za
//*************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------------------------------------------------------------------------------------------------------------------
namespace CybersecurityAwarenessChatBot
{
    class Chatbot
    {
        private string userName; // Variable storing the user's name

        public void Start() // Entry point to start the chatbot
        {
            WelcomeUser(); // Greets the user
            AskUserQuestions(); // Beginning the main question loop
        }
        //----------------------------------------------------------------------------------------------------------------------------------------

        private void WelcomeUser() // Greets the user and collects their name
        {
            Console.Write("\nPlease enter your name: ");
            userName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userName)) // Checks if the name is empty or contains only whitespace
            {
                Console.WriteLine("\nI didn’t catch your name, but welcome anyway!");
                userName = "User"; // Sets a default name if none was provided
            }
            else
            {
                Console.WriteLine($"\nWelcome, {userName}! Let's learn how to stay safe online.\n");
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------

        private void AskUserQuestions() // Main loop that interacts with the user and processes questions
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed; // Display prompt in dark red color for clarity
                Console.Write("Ask me something (type 'help', 'commands' or 'exit' to quit): ");
                Console.ResetColor();

                string question = Console.ReadLine().ToLower(); // Read and process the user's input

                if (string.IsNullOrWhiteSpace(question)) // If the user entered an empty input, ask them to rephrase
                {
                    Console.WriteLine("\nI didn’t quite understand that. Could you rephrase?\n");
                    continue; // Skip rest of the loop and prompt again
                }

                if (question == "exit") // Exit condition
                {
                    Console.WriteLine("\nThank you for chatting! Stay safe online!");
                    break;
                }

                ResponseHandler.Respond(question); // Handle the response using the ResponseHandler class
                Console.WriteLine();
            }
        }
    }
}
//--------------------------------------------------------------- End of File --------------------------------------------------------------------