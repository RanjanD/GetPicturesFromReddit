using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditSharp;
using System.IO;
using System.Net;

namespace GetAww
{
    class WallpaperGetter
    {
        private string path, subRedditName;
        Reddit myReddit;
        WebClient client;
        DirectoryInfo wallpaperDirectory;
        private int successfulDownloadCount;

        public WallpaperGetter(string subRedditName)
        {
            path = @"C:\Wallpapers\";
            myReddit = new Reddit();
            client = new WebClient();
            successfulDownloadCount = 0;
            this.subRedditName = @"/r/"+subRedditName;
        }

        public void GetWallpapers()
        {
            var subReddit = myReddit.GetSubreddit(subRedditName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

            }
            wallpaperDirectory = new DirectoryInfo(path);
            foreach (FileInfo oldPicture in wallpaperDirectory.GetFiles())
            {
                oldPicture.Delete();
            }
            if(subReddit != null)
            {
                //try
                //{
                    var top30 = subReddit.Hot.Take(30);
                    foreach (var post in top30)
                    {
                        if (post.Url.ToString().EndsWith(".jpg"))
                        {
                            Console.WriteLine(post.Url.ToString());
                            try
                            {
                                client.DownloadFile(post.Url, path + post.Id + ".jpeg");
                                successfulDownloadCount++;
                                if (successfulDownloadCount == 10)
                                {
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Exception Caught.");
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                //}
                //catch(Exception e)
                //{
                //    Console.WriteLine("There is a connection problem.");
                //    Console.WriteLine(e.Message);
                //}
            }
            else
            {
                Console.WriteLine("The subreddit you requested for does not exist.");
            }
            //Console.WriteLine(subReddit.Id );
            Console.WriteLine("fin");
        }
    }
}
