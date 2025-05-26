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
    class Program
    {
        static void Main(string[] args)
        {
            // Play a voice greeting to welcome the user
            VoiceGreeting.Play();

            // Display ASCII art banner to visually introduce the chatbot
            AsciiArt.Display();

            // Create an instance of the chatbot
            Chatbot chatbot = new Chatbot();

            // Start the chatbot interaction 
            chatbot.Start();
        }
    }
}
//--------------------------------------------------------------- End of File --------------------------------------------------------------------