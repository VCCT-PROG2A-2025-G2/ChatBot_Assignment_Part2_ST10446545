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
    class ResponseHandler
    {
        //Random number generator for selecting random responses
        static Random rand = new Random();

        //Stores the user's most recent topic
        static string lastTopic = "";

        //Indicates whether the bot is waiting for a follow-up question
        static bool waitingForFollowUp = false;

        //Dictionary to remember user's favorite topics
        static Dictionary<string, string> userMemory = new Dictionary<string, string>();

        //Tracks the index of last used response for each topic to avoid repetition
        static Dictionary<string, int> lastIndexUsed = new Dictionary<string, int>();

        public static void Respond(string question)
        {
            try
            {
                string q = question.ToLower().Trim();
                if (string.IsNullOrWhiteSpace(q))
                {
                    Console.WriteLine("Please type something so I can help.");
                    return;
                }
                //----------------------------------------------------------------------------------------------------------------------------------------
                //Sentiment Detection
                if (q.Contains("worried") || q.Contains("concerned"))
                {
                    Console.WriteLine("It's completely understandable to feel that way. Cybersecurity can be tricky, but I'm here to help.");
                    return;
                }
                if (q.Contains("confused") || q.Contains("don’t get it") || q.Contains("unclear"))
                {
                    Console.WriteLine("No worries — let's break it down. Which part can I explain better?");
                    return;
                }
                if (q.Contains("frustrated") || q.Contains("frustrating") || q.Contains("annoyed"))
                {
                    Console.WriteLine("I'm here to help — take your time, and we’ll figure this out together.");
                    return;
                }
                //----------------------------------------------------------------------------------------------------------------------------------------
                //User Memory Storage
                if (q.StartsWith("my favorite topic is ") || q.StartsWith("i care about "))
                {
                    string topic = q.Replace("my favorite topic is ", "").Replace("i care about ", "").Trim();
                    userMemory["favoriteTopic"] = topic;
                    Console.WriteLine($"Got it! I'll remember that you're interested in {topic}.");
                    return;
                }
                //----------------------------------------------------------------------------------------------------------------------------------------
                //Memory Recall
                if (q.Contains("what did i say") || q.Contains("remember my topic") || q.Contains("favorite topic"))
                {
                    if (userMemory.ContainsKey("favoriteTopic"))
                    {
                        Console.WriteLine($"You mentioned you're interested in {userMemory["favoriteTopic"]}. Would you like to hear more about that?");
                        waitingForFollowUp = true;
                    }
                    else
                    {
                        Console.WriteLine("You haven’t told me your favorite topic yet. You can say: My favorite topic is privacy.");
                    }
                    return;
                }
                //----------------------------------------------------------------------------------------------------------------------------------------
                //Knowledge Base: Keyword Responses
                Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>()
                {
                    { "how are you", new List<string> { "As your personal security assistant I'm running smoothly. Thanks!" } },

                    { "purpose", new List<string> { "I'm here to assist you in staying safe online by educating you about cybersecurity." } },

                    { "ask", new List<string> { "You can ask about password safety, phishing, or safe browsing." } },

                    { "help", new List<string> { "You can ask me about online safety, like phishing, scams, and password tips. Try asking something like: What is phishing?" } },

                    { "phishing", new List<string> {
                        "Phishing is when scammers trick you into giving personal info through fake emails or sites.",
                        "Watch out for emails that urge you to click links or download files — they may be phishing.",
                        "Phishing often disguises itself as messages from trusted sources like banks or companies."
                    }},
                    { "password", new List<string> {
                        "Use long, unique passwords for each account. Avoid reusing them.",
                        "Include uppercase, lowercase, numbers, and symbols in your password.",
                        "Avoid using names, birthdays, or common words in passwords."
                    }},
                    { "browse", new List<string> {
                        "Use HTTPS websites and don’t click unknown links.",
                        "Install an antivirus and keep your browser updated.",
                        "Avoid entering private info on sites without secure connections."
                    }},
                    { "privacy", new List<string> {
                        "Use privacy settings and limit what you share online. Avoid using public Wi-Fi for sensitive tasks.",
                        "Review app permissions and disable access to personal info unless necessary.",
                        "Be cautious when sharing photos or location data online."
                    }},
                    { "scam", new List<string> {
                        "Scams can come in emails, SMS, or calls. Be cautious of anything that feels suspicious.",
                        "Never share OTPs, banking info, or passwords with unknown callers.",
                        "If it sounds too good to be true, it probably is. Research before clicking or buying."
                    }}
                };
                //----------------------------------------------------------------------------------------------------------------------------------------
                //Follow-Up Response Confirmation
                if (waitingForFollowUp && (q.Contains("yes") || q.Contains("sure") || q.Contains("tell me more") || q.Contains("what else")))
                {
                    waitingForFollowUp = false;

                    if (userMemory.ContainsKey("favoriteTopic"))
                    {
                        string topic = userMemory["favoriteTopic"];
                        if (keywordResponses.ContainsKey(topic))
                        {
                            var responses = keywordResponses[topic];

                            if (!lastIndexUsed.ContainsKey(topic))
                                lastIndexUsed[topic] = -1;

                            lastIndexUsed[topic] = (lastIndexUsed[topic] + 1) % responses.Count;
                            Console.WriteLine(responses[lastIndexUsed[topic]]);
                        }
                        else
                        {
                            Console.WriteLine($"Sorry, I don't have more tips for {topic} yet.");
                        }
                    }
                    return;
                }
                //----------------------------------------------------------------------------------------------------------------------------------------
                //Keyword Matching
                foreach (var entry in keywordResponses)
                {
                    if (q.Contains(entry.Key))
                    {
                        lastTopic = entry.Key;
                        var responses = entry.Value;

                        if (!lastIndexUsed.ContainsKey(entry.Key))
                            lastIndexUsed[entry.Key] = -1;

                        lastIndexUsed[entry.Key] = (lastIndexUsed[entry.Key] + 1) % responses.Count;
                        Console.WriteLine(responses[lastIndexUsed[entry.Key]]);
                        return;
                    }
                }
                //----------------------------------------------------------------------------------------------------------------------------------------
                //Command Listing
                if (q.Contains("commands") || q.Contains("list") || q.Contains("options") || q.Contains("help"))
                {
                    ListCommands();
                    return;
                }
                //----------------------------------------------------------------------------------------------------------------------------------------
                //Fallback
                Console.WriteLine("Hmm, I'm not sure how to answer that. Try asking something else."); //Default response when input doesn't match any known pattern
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ResetColor();
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------
        public static void ListCommands() //List out available commands to guide the user
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nHey there, here are some things you can ask me:");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("1. How are you?");
            Console.WriteLine("2. What's your purpose?");
            Console.WriteLine("3. What can I ask you about?");
            Console.WriteLine("4. Tell me about password safety");
            Console.WriteLine("5. What is phishing?");
            Console.WriteLine("6. How do I browse safely?");
            Console.WriteLine("7. What is Privacy?");
            Console.WriteLine("8. What is a Scam?");
            Console.WriteLine("9. Help?");
            Console.WriteLine("----------------------------------------------");
            Console.ResetColor();
        }
    }
}
//--------------------------------------------------------------- End of File --------------------------------------------------------------------

// Reference List
//https://chatgpt.com/share/6830a93e-e298-8008-8587-e7e327ba2a23 (Ln75, asked chat how to use a dictionary list with keywordResponses)