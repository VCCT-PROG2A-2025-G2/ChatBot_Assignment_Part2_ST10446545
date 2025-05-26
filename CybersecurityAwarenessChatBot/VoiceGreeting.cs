//*************************************************************
// Part1_POE_PROG6221_ST10446545
// ST10446545@vcconnect.edu.za
//*************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
//----------------------------------------------------------------------------------------------------------------------------------------
namespace CybersecurityAwarenessChatBot
{
    class VoiceGreeting  // This class handles playing a welcome audio greeting when the chatbot starts
    {
        public static void Play() // Static method to play the welcome audio file
        {
            try
            {
                SoundPlayer player = new SoundPlayer("Assets/welcome.wav"); // Create a new SoundPlayer object with the specified audio file path
                player.PlaySync();  // Play the audio file synchronously (execution will wait until the sound finishes playing)
            }
            catch (Exception ex)
            {
                // If an error occurs while trying to play the audio, display an error message in red
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[Error playing voice greeting: " + ex.Message + "]");
                Console.ResetColor(); // Reset the text color to default
            }
        }
    }
}
//--------------------------------------------------------------- End of File --------------------------------------------------------------------

// Reference List
// https://elevenlabs.io/app/speech-synthesis/text-to-speech (Ln21, Ai voice used for greeting located in the assets folder)
// https://chatgpt.com/share/680940a0-abf4-8008-84d8-1300e2d02e7d (Ln27, Asking chat how to change the text colour)