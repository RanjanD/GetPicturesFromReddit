using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditSharp;
using System.Net;
using System.IO;


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
            Reddit myReddit = new Reddit();
            RedditSharp.Things.Subreddit subReddit = null;
            do
            {
                try
                {
                    subReddit = Driver.GetSubredditName(myReddit);
                }
                catch(FileNotFoundException ex)
                {
                    Console.WriteLine("The requested subreddit was not found!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }while(subReddit == null);

            try
            {
                wallpaperGetter = new WallpaperGetter(myReddit, subReddit);
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
