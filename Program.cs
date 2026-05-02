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
