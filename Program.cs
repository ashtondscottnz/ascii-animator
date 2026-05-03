// MIT License

// Copyright(c) 2026 Ashton Scott

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace ascii_animator
{
    internal class Program
    {
        private const string PathAssets = "C:\\Users\\Ashton Scott\\Visual Studio\\source\\repos\\ascii-animator\\assets";
        private const string PathConfig = "C:\\Users\\Ashton Scott\\Visual Studio\\source\\repos\\ascii-animator\\config";
        private const string PathAnimations = "C:\\Users\\Ashton Scott\\Visual Studio\\source\\repos\\ascii-animator\\animations";

        static void DisplayMenu()
        {
            PlayMenuSplash();

            try
            {
                StreamReader sr = new StreamReader($"{PathAssets}\\main-menu.txt");
                string menu = sr.ReadToEnd();
                sr.Close();

                Console.Write(menu);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: main-menu.txt in \\assets could not be found, does the file exist and are your paths set correctly?\n");
                Console.WriteLine($"Assets Path: {PathAssets}\nConfig Path: {PathConfig}");
                Console.WriteLine("\nTip: You are still able to use the program, just be sure you know what your doing!");
            }
        }

        static void PlayMenuSplash()
        {

        }

        static void CreateAnimation(string animationName, string creatorName, int frameCount, double frameRate, bool loopAnimation)
        {
            Directory.CreateDirectory($"{PathAnimations}\\{animationName}");

            using (StreamWriter sw = new StreamWriter($"{PathAnimations}\\{animationName}\\000_metadata.txt"))
            {
                sw.WriteLine($"ANIMATION: {animationName}");
                sw.WriteLine($"CREATOR: {creatorName}");
                sw.WriteLine($"DATE: {DateTime.Now}");
                sw.WriteLine($"FRAME_RATE: {frameRate}");
                sw.WriteLine($"LOOP: {loopAnimation}");
            }

            for (int i = 0; i < frameCount; i++)
            {
                File.Create($"{PathAnimations}\\{animationName}\\{(i + 1):D3}_frame.txt");
            }

            Console.Clear();
            Console.WriteLine($"Created '{animationName}' at {PathAnimations}\\{animationName}");
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            bool exitProgram = false;

            do
            {
                Console.Clear();
                DisplayMenu();

                Console.Write("\n> ");
                string userInput = Console.ReadLine();
                switch (userInput.ToLower())
                {
                    case "1": // Demo
                    case "demo":
                        break;

                    case "2": // Load/Play
                    case "play":
                    case "load":
                        break;

                    case "3": // Create
                    case "create":
                        while (true) // Prompt user if they would like to create a new animation
                        {
                            Console.Write("\nCreate a new animation (y/n)? ");
                            userInput = Console.ReadLine();

                            if (userInput == "y" || userInput == "yes")
                            {
                                Console.Clear();

                                Console.Write("Animation name: ");
                                string animationName = Console.ReadLine();

                                Console.Write("Creator name: ");
                                string creatorName = Console.ReadLine();

                                Console.Write("Frame count: ");
                                int frameCount = Convert.ToInt16(Console.ReadLine());

                                Console.Write("Frame rate (fps): ");
                                double frameRate = Convert.ToDouble(Console.ReadLine());

                                bool loopAnimation;
                                while (true)
                                {
                                    Console.Write("\nDoes your animation loop (y/n)? ");
                                    userInput = Console.ReadLine();

                                    if (userInput == "y" || userInput == "yes")
                                    {
                                        loopAnimation = true;
                                        break;
                                    }

                                    if (userInput == "n" || userInput == "no")
                                    {
                                        loopAnimation = false;
                                        break;
                                    }
                                    Console.Write("Invalid Input!");
                                    Thread.Sleep(1000);
                                }
                                CreateAnimation(animationName, creatorName, frameCount, frameRate, loopAnimation);
                                break;
                            }

                            if (userInput == "n" || userInput == "no")
                            {
                                break;
                            }

                            Console.Write("Invalid Input!");
                            Thread.Sleep(1000);
                        }
                        break;

                    case "4": // Settings
                    case "settings":
                        break;

                    case "5": // Help
                    case "help":
                        break;

                    case "exit": // Exit
                    case "q":
                        exitProgram = true;
                        break;

                    default: // Invalid input
                        Console.Write("Invalid input!");
                        Thread.Sleep(1000);
                        break;
                }

            } while (!exitProgram);
        }
    }
}
