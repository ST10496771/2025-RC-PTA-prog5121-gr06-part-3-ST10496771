using System;
using System.Speech.Synthesis;       // Needed for playing greeting
using System.Threading;             // Needed for the typing delay effect

class CybersecurityBot
{
    static void Main(string[] args)
    {

        DisplayLogo();
        PlayVoiceGreeting();
        //Ask the user for their name and greet them
        string userName = GetUserName();
        DisplayWelcomeMessage(userName);
        //Start the chat loop
        StartChat(userName);
    }
    static void PlayVoiceGreeting()
    {
        SpeechSynthesizer speaker = new SpeechSynthesizer();
        speaker.Volume = 100;
        speaker.Rate = 0;

        speaker.Speak("Hello! Welcome to the Cybersecurity Awareness Bot. I am here to help you stay safe online. How can I help you?");
    }

    static void DisplayLogo()
    {
        Console.Clear(); // Clear the screen first

        PrintDivider();
        Console.WriteLine("                                                        ");
        Console.WriteLine("        ██████╗██╗   ██╗██████╗ ███████╗██████╗         ");
        Console.WriteLine("       ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗        ");
        Console.WriteLine("       ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝        ");
        Console.WriteLine("       ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗        ");
        Console.WriteLine("       ╚██████╗   ██║   ██████╔╝███████╗██║  ██║        ");
        Console.WriteLine("        ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝        ");
        Console.WriteLine("                                                        "); 
        SetColour(ConsoleColor.Cyan);
        Console.WriteLine("         /\\ CYBERSECURITY AWARENESS BOT   /\\       ");
        Console.WriteLine("        /  \\   Keeping you safe online   /  \\      ");
        Console.WriteLine("       /    \\ ========================= /    \\     ");
        Console.WriteLine("      / SAFE \\ [shield] [lock] [alert] / SAFE \\    ");
        Console.WriteLine("     /________\\_______________________/________\\   ");
        Console.WriteLine("                                                     ");
        PrintDivider();

        ResetColour();

        Console.WriteLine();
    }

    static string GetUserName()
    {
        SetColour(ConsoleColor.Green);
        Console.Write("  Please enter your name: ");
        ResetColour();

        string name = Console.ReadLine();

        // Input validation - keep asking until they enter something
        while (string.IsNullOrWhiteSpace(name))
        {
            SetColour(ConsoleColor.Red);
            Console.WriteLine("  Name cannot be empty. Please try again.");
            ResetColour();

            SetColour(ConsoleColor.Green);
            Console.Write("  Please enter your name: ");
            ResetColour();

            name = Console.ReadLine();
        }

        return name.Trim(); // Remove extra spaces from the name
    }

    static void DisplayWelcomeMessage(string userName)
    {
        Console.WriteLine();
        PrintDivider();

        SetColour(ConsoleColor.Magenta);
        Console.WriteLine($"  Welcome, {userName}! I'm your Cybersecurity Awareness Bot.");
        Console.WriteLine("  I'm here to help you stay safe online.");
        ResetColour();

        PrintDivider();
        Console.WriteLine();
    }

    static void StartChat(string userName)
    {
        SetColour(ConsoleColor.White);
        Console.WriteLine($" Hey! {userName}, Type a question to get started, or type 'exit' to quit.");
        Console.WriteLine("  (I can offer assistance with Cybersecurity related questions like 'what is phishing', 'password tips', etc.)");
        ResetColour();

        Console.WriteLine();

        // This loop keeps running until the user types "exit"
        while (true)
        {
            // Show the input prompt
            SetColour(ConsoleColor.Green);
            Console.Write($"  {userName}: ");
            ResetColour();

            string userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                ShowBotResponse("I didn't receive any input. Could you please type something?");
                continue; // Go back to the top of the loop
            }

            // Convert to lowercase so we can compare easily
            string input = userInput.ToLower().Trim();

            // Check if user wants to exit
            if (input == "exit" || input == "quit" || input == "bye")
            {
                ShowBotResponse($"Goodbye, {userName}! Stay safe online. See you next time!");
                break; // Exit the loop
            }

            string response = GetResponse(input, userName);
            ShowBotResponse(response);

            Console.WriteLine(); // Space between conversations
        }
    }
    static string GetResponse(string input, string userName)
    {
        // --- Greeting responses ---
        if (input.Contains("how are you"))
        {
            return $"I am great, thank you for asking, {userName}! and i am ready to help you stay cybersafe! How can I assist you with cybersecurity today?";
        }

        //Purpose
        if (input.Contains("purpose") || input.Contains("what do you do") || input.Contains("what are you") || input.Contains("how can you help"))
        {
            return "My purpose is to educate you about cybersecurity. I can answer questions " +
                   "about various topics on cyber security! Feel free to ask anything and i will answer the best i can";
        }

        if (input.Contains("what can i ask") || input.Contains("help") || input.Contains("topics"))
        {
            return "You can ask me about:\n" +
                   "  - Phishing\n" +
                   "  - Password safety\n" +
                   "  - Safe browsing\n" +
                   "  - Malware\n" +
                   "  - Social engineering\n" +
                   "  - Two-factor authentication (2FA)\n" +
                   "  - Or anything else Cyber security related\n" +
                   "  What would you like to know more about?";
        }

        //Cybersecurity Catchphrases
        if (input.Contains("phishing") || input.Contains("what is phishing?"))
        {
            return "Phishing is when criminals send fake emails or messages pretending to be " +
                   "a trusted company (like your bank) to steal your personal information. " +
                   "Always check the sender's email address and never click suspicious links!\n" +
                   "If you would like to know how to stay safe from phishing, I can give a few pointers";
        }

        if (input.Contains("how can i prevent phishing?") || input.Contains("prevent phishing?") || input.Contains("safe from phishing?"))
        {
            return "To avoid phishing, never click links or download attachments in unexpected emails or texts, " +
                "and verify suspicious requests directly through official websites or phone numbers. Key defenses " +
                "include enabling multi-factor authentication (MFA), keeping software updated, using strong, unique " +
                "passwords, and watching for spelling errors, generic greetings, and high-pressure threats";
        }

        if (input.Contains("viruses"))
        {
            return "A computer virus is malware that attaches itself to legitimate files and " +
                "spreads when those files are opened or shared. " +
                "It can corrupt data, slow down your device, or give hackers access to your system. " +
                "Keeping your antivirus updated is the best way to protect against viruses.!" +
                "If you would like to know how to stay safe from viruses, I can give a few pointers\n";
        }

        if (input.Contains("how can i prevent virus?") || input.Contains("prevent viruses?") || input.Contains("safe from viruses?"))
        {
            return "Prevent viruses and malicious code by using reputable antivirus software, keeping all software updated, " +
                "avoiding suspicious links/attachments, and practicing safe browsing habits. Key actions include using strong, " +
                "unique passwords with multi-factor authentication (MFA), enabling firewalls, and backing up data regularly to " +
                "prevent ransomware losses.";
        }

        if (input.Contains("ransomware"))
        {
            return "Ransomware is a type of malware that locks or encrypts your files and demands a payment to restore access. " +
                "It often spreads through malicious email attachments or infected downloads. " +
                "Regularly backing up your data is the best defence against ransomware attacks!\n" +
                "I can give a few tips on how to protect yourself from ransomware";
        }

        if (input.Contains("prevent ransomware") || input.Contains("protect from ransomware"))
        {
            return "Preventing ransomware requires a layered defense: regularly back up data (ideally offline), " +
                "keep software patched, use reputable security software, and educate users against phishing, " +
                "which is a primary infection vector. Enable multi-factor authentication (MFA) and restrict " +
                "user permissions to prevent widespread infections";

            if (input.Contains("spyware"))
        {
            return "Spyware secretly installs itself on your device and monitors your activity without your knowledge. " +
                "It can record your keystrokes, browsing habits, and even your passwords. " +
                "Running regular antivirus scans can help detect and remove spyware from your device.!";
        }

        if (input.Contains("Adware"))
        {
            return "Adware is software that automatically displays unwanted advertisements on your device, often as pop-ups. " +
                "While not always harmful, it can slow your device down and sometimes lead to more dangerous malware. " +
                "You can remove adware using an antivirus or anti-malware tool.!";
        }

        if (input.Contains("Trojan"))
        {
            return "A Trojan is malware that disguises itself as a harmless or useful program to trick you into installing it. " +
                "Once installed, it can give hackers remote access to your device or steal your data. " +
                "Never download software from untrusted websites or unofficial sources.!";
        }

        if (input.Contains("worm"))
        {
            return "A worm is malware that spreads automatically across networks without needing any human interaction. " +
                "Unlike viruses, it does not need to attach to a file — it travels on its own. " +
                "Worms can cause massive damage by consuming network bandwidth and dropping other malware.!";
        }

        if (input.Contains("Firewall"))
        {
            return "A firewall is a security system that monitors and controls the traffic coming in and " +
                "going out of your network. It acts as a barrier between your device and potential threats from the internet." +
                " Most operating systems come with a built-in firewall that should always be kept on.!";
        }

        if (input.Contains("Virtual Private Network") || input.Contains("VPN"))
        {
            return "A firewall is a security system that monitors and controls the traffic coming in and " +
                "going out of your network. It acts as a barrier between your device and potential threats from the internet." +
                " Most operating systems come with a built-in firewall that should always be kept on.!";
        }

        if (input.Contains("password"))
        {
            return "Password Safety Tips:\n" +
                   "  - Use at least 12 characters\n" +
                   "  - Mix uppercase, lowercase, numbers, and symbols\n" +
                   "  - Never reuse the same password on different sites\n" +
                   "  - Use a password manager to keep them safe";
        }

        if (input.Contains("browsing") || input.Contains("safe browsing") || input.Contains("internet"))
        {
            return "Safe Browsing Tips:\n" +
                   "  - Only visit websites that start with HTTPS (the padlock icon)\n" +
                   "  - Avoid clicking on pop-up ads\n" +
                   "  - Keep your browser updated\n" +
                   "  - Use a VPN on public Wi-Fi";
        }

        if (input.Contains("malware") || input.Contains("virus"))
        {
            return "Malware is harmful software that can damage your computer or steal data. " +
                   "Protect yourself by installing a trusted antivirus program, " +
                   "keeping your system updated, and never downloading files from unknown sources.";
        }

        if (input.Contains("social engineering"))
        {
            return "Social engineering is when hackers trick people (not computers) into giving " +
                   "away information. They may pretend to be IT support, a friend, or a manager. " +
                   "Always verify who you are speaking to before sharing any information!";
        }

        if (input.Contains("2fa") || input.Contains("two factor") || input.Contains("two-factor"))
        {
            return "Two-Factor Authentication (2FA) adds an extra layer of security. " +
                   "Even if someone knows your password, they cannot log in without " +
                   "the second step (like a code sent to your phone). Always enable 2FA!";
        }

        if (input.Contains("2fa") || input.Contains("two factor") || input.Contains("two-factor"))
        {
            return "Two-Factor Authentication (2FA) adds an extra layer of security. " +
                   "Even if someone knows your password, they cannot log in without " +
                   "the second step (like a code sent to your phone). Always enable 2FA!";
        }

        //Default response for unrecognised input
        return "I didn't quite understand that. Could you rephrase? " +
               "Try asking about: phishing, passwords, safe browsing, malware, or 2FA.";
    }

    static void ShowBotResponse(string message)
    {
        Console.WriteLine();
        SetColour(ConsoleColor.Cyan);
        Console.Write("  Bot: ");
        ResetColour();

        SetColour(ConsoleColor.White);
        TypeText("  " + message); // TypeText gives a typing effect
        ResetColour();
    }

    static void PrintDivider()
    {
        SetColour(ConsoleColor.DarkCyan);
        Console.WriteLine("  ============================================================");
        ResetColour();
    }

    static void SetColour(ConsoleColor colour)
    {
        Console.ForegroundColor = colour;
    }

    static void ResetColour()
    {
        Console.ResetColor();
    }

    static void TypeText(string message)
    {
        foreach (char letter in message)
        {
            Console.Write(letter);
            Thread.Sleep(18); // Wait 18 milliseconds between each letter
        }
        Console.WriteLine(); // Move to the next line when done
    }
}