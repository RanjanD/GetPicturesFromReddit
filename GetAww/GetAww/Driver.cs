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
    internal static class Driver
    {
        internal static RedditSharp.Things.Subreddit GetSubredditName(Reddit reddit)
        {
            string subRedditName;
            RedditSharp.Things.Subreddit subReddit;
            Console.WriteLine("Please enter the name of the subrddit from which you want pictures:");
            subRedditName = Console.ReadLine();
            try
            {
                subReddit = reddit.GetSubreddit(@"/r/" + subRedditName);
                return subReddit;
            }
            catch(FileNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
