namespace ascii_animator
{
    internal class Program
    {
        private const string Path_Assets = "C:\\Users\\Ashton Scott\\Visual Studio\\source\\repos\\ascii-animator\\assets";
        private const string Path_Config = "C:\\Users\\Ashton Scott\\Visual Studio\\source\\repos\\ascii-animator\\config";

        static void DisplayMenu()
        {
            PlayMenuSplash();

            StreamReader sr = new StreamReader($"{Path_Assets}\\main-menu.txt");
            string menu = sr.ReadToEnd();
            sr.Close();

            Console.Write(menu);
        }

        static void PlayMenuSplash()
        {

        }

        static void Main(string[] args)
        {
            
            bool exitCondition = false;

            do
            {
                Console.Clear();
                DisplayMenu();

                Console.Write("\n> ");
                string userInput = Convert.ToString(Console.ReadLine());
                switch (userInput.ToLower())
                {
                    case "1": // Demo
                    case "demo":
                        Console.WriteLine("Demo");
                        Thread.Sleep(1000);
                        break;
                    case "2": // Load/Play
                    case "play":
                    case "load":
                        Console.WriteLine("Load/Play");
                        Thread.Sleep(1000);
                        break;
                    case "3": // Create
                    case "create":
                        Console.WriteLine("Create");
                        Thread.Sleep(1000);
                        break;
                    case "4": // Settings
                    case "settings":
                        Console.WriteLine("Settings");
                        Thread.Sleep(1000);
                        break;
                    case "5": // Help
                    case "help":
                        Console.WriteLine("Help");
                        Thread.Sleep(1000);
                        break;
                    case "exit": // Exit
                    case "q":
                        exitCondition = true;
                        break;
                    default: // Invalid input
                        Console.Write("Invalid input!");
                        Thread.Sleep(1000);
                        break;
                }

            } while (!exitCondition);
        }
    }
}
