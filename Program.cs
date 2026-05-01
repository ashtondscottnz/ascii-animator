namespace ascii_animator
{
    internal class Program
    {
        private const string Path_Assets = "C:\\Users\\Ashton Scott\\Visual Studio\\source\\repos\\ascii-animator\\assets";
        private const string Path_Config = "C:\\Users\\Ashton Scott\\Visual Studio\\source\\repos\\ascii-animator\\config";

        static void DisplayMenu()
        {
            LoadMenuSplash();

            StreamReader sr = new StreamReader($"{Path_Assets}\\main-menu.txt");
            string menu = sr.ReadToEnd();
            sr.Close();

            Console.Write(menu);
        }

        static void LoadMenuSplash()
        {

        }

        static void Main(string[] args)
        {
            DisplayMenu();
        }
    }
}
