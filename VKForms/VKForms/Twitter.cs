using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToTwitter;

namespace VKForms
{
    class Twitter
    {

        public class UserWordBook
        {
            public string domain;
            public Dictionary<string, int> dict;


            public UserWordBook()
            {
                this.domain = "";
                this.dict = new Dictionary<string, int>();

            }
        }

        public static async Task<Dictionary<string, int>> getTweetsWords(string screen_name)
        {
            var auth =
           new SingleUserAuthorizer
           {
               CredentialStore = new
              SingleUserInMemoryCredentialStore
               {
                   ConsumerKey = "D5ljVdl67GunolnIYAQCzp860",
                   ConsumerSecret = "W3cUJ8f6MppIteYhUiJ3DJdrnIUV2SCpNgf5wAuewa6hQvicgp",
                   AccessToken = "3018013301-ADGoe8wVMittOWb66T3KZdhyYgvEASo3G49xg6z",
                   AccessTokenSecret = "jRg8tvJqYh45Bcn1jVmnZ0hJvihMLwkJ1gM5liIgfh734"
               }
           };

            await auth.AuthorizeAsync();

            var twitterCtx = new TwitterContext(auth);

            var tweets =
               await
               (from tweet in twitterCtx.Status
                where tweet.Type == StatusType.User &&
                      tweet.ScreenName == screen_name &&
                      tweet.Count == 200
                select tweet)
               .ToListAsync();

            for (int i = 0; i < 14; i++)
            {
                var temp_tweets =
                    await
                   (from tweet in twitterCtx.Status
                    where tweet.Type == StatusType.User &&
                          tweet.ScreenName == screen_name &&
                          tweet.Count == 200 &&
                          tweet.MaxID == tweets[tweets.Count - 1].ID
                    select tweet)
                   .ToListAsync();
                tweets.AddRange(temp_tweets);
            }

            foreach (var tweet in tweets)
            {
                Console.WriteLine(tweet.Text);
            }
            Console.WriteLine(tweets.Count);
            UserWordBook target_user = new UserWordBook();

            foreach (var tweet in tweets)
            {
                string[] words = tweet.Text.Trim().Split(new Char[] { ' ', '\n', '\r', '.', ',', ':', '-', '[', ']', '\\', '/', 
                       '{', '}', '#', '@', '!', '?', '(', ')', '<', '>', '"'}, StringSplitOptions.RemoveEmptyEntries);
                for (int k = 0; k < words.Length; k++)
                {
                    words[k].Replace(">", "");
                    words[k].Replace("<", "");
                    words[k].Replace(")", "");
                    words[k].Replace("[", "");
                    words[k].Replace("]", "");
                    words[k].Replace("(", "");
                    words[k].Replace("{", "");
                    words[k].Replace("}", "");
                    if (target_user.dict.ContainsKey(words[k]))
                        target_user.dict[words[k]] += 1;
                    else
                        target_user.dict.Add(words[k], 1);

                }
            }

       
            Console.WriteLine("Done");
            return target_user.dict;



        }

        public static async Task<string []> getUserInfo(string screen_name)
        {
            Console.WriteLine("go");
            var auth =
           new SingleUserAuthorizer
           {
               CredentialStore = new
              SingleUserInMemoryCredentialStore
               {
                   ConsumerKey = "D5ljVdl67GunolnIYAQCzp860",
                   ConsumerSecret = "W3cUJ8f6MppIteYhUiJ3DJdrnIUV2SCpNgf5wAuewa6hQvicgp",
                   AccessToken = "3018013301-ADGoe8wVMittOWb66T3KZdhyYgvEASo3G49xg6z",
                   AccessTokenSecret = "jRg8tvJqYh45Bcn1jVmnZ0hJvihMLwkJ1gM5liIgfh734"
               }
           };

            await auth.AuthorizeAsync();
            Console.WriteLine("go1");
            var twitterCtx = new TwitterContext(auth);

            var userResponse =
                await
                (from user in twitterCtx.User
                 where user.Type == UserType.Lookup &&
                       user.ScreenNameList == screen_name
                 select user)
                .ToListAsync();
            Console.WriteLine("go2");
            string [] result =  new string [10];
            if (userResponse != null)
               foreach(var user in userResponse)
               {
                   result = new string[] { user.Name,
                   user.CreatedAt.ToString(),
                   user.FollowersCount.ToString(),
                   user.FriendsCount.ToString(),
                   user.Location,
                   user.ScreenNameList,
                   user.Status.Text,
                   user.TimeZone,
                   user.Url,
                   user.Description
                   };
               }
            Console.WriteLine("finished");
            return result;
        }

    }
}
