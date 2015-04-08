using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GetAww
{
    class Program
    {
        static void Main(string[] args)
        {
            //WebClient client = new WebClient();
            //client.DownloadFile(@"http://i.imgur.com/rt1xXSe.jpg", @"C:\Temp\test.jpeg");
            //client.DownloadFile(@"http://www.reddit.com/r/wallpapers/", @"C:\\Temp\tesePage.html");
            WallpaperGetter wallpaperGetter;
            try
            {
                wallpaperGetter = new WallpaperGetter("wallpapers");
                wallpaperGetter.GetWallpapers();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong!");
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
