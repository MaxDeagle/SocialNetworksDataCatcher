using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Web;
using System.Text.RegularExpressions;

namespace VKForms
{
    class Instagram
    {
        public static Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
        public class UserInfo
        {
            public string user_name;
            public string full_name;
            public string biography;
            public int followers_count;
            public int following_count;
            public int total_likes_count;
            public int total_photos_count;
            public List<string> photos_codes;
            public Dictionary<string, int> dict;

            public UserInfo()
            {
                this.photos_codes = new List<string>();
                this.user_name = "";
                this.full_name = "";
                this.biography = "";
                this.followers_count = 0;
                this.following_count = 0;
                this.total_likes_count = 0;
                this.total_photos_count = 0;
                this.dict = new Dictionary<string, int>();
            }
        }

        public static UserInfo getInfo(string user_name)
        {

            UserInfo user = new UserInfo();

            user.user_name = user_name;
            string data = "";
            string lastItemId = "";
            dynamic json_object_to_handle;

            while (true)
            {
                if (lastItemId.Equals(""))
                {
                    var request = WebRequest.Create("https://www.instagram.com/" + user_name + "/media");
                    request.Proxy = null;
                    var response = request.GetResponse();
                    using (StreamReader sReader = new StreamReader(response.GetResponseStream(), encode))
                    {
                        data = sReader.ReadToEnd();
                    }
                    // Console.WriteLine(data);
                }
                else
                {
                    var request = WebRequest.Create("https://www.instagram.com/" + user_name + "/media?max_id=" + lastItemId);
                    request.Proxy = null;
                    var response = request.GetResponse();
                    using (StreamReader sReader = new StreamReader(response.GetResponseStream(), encode))
                    {
                        data = sReader.ReadToEnd();
                    }
                    //    Console.WriteLine(data);
                }

                json_object_to_handle = JObject.Parse(data);

                if (json_object_to_handle.items.Count == 0)
                    break;

                for (int i = 0; i < json_object_to_handle.items.Count; i++)
                {
                    user.photos_codes.Add(json_object_to_handle.items[i].GetValue("code").ToString());
                    user.total_photos_count++;
                    user.total_likes_count += Int32.Parse(json_object_to_handle.items[i].likes.GetValue("count").ToString());
                }
                lastItemId = json_object_to_handle.items[json_object_to_handle.items.Count - 1].GetValue("id");

                if (user.full_name.Equals(""))
                {
                    string data1;
                    var request = WebRequest.Create("https://www.instagram.com/" + user_name + "/?__a=1");
                    request.Proxy = null;
                    var response = request.GetResponse();
                    using (StreamReader sReader = new StreamReader(response.GetResponseStream(), encode))
                    {
                        data1 = sReader.ReadToEnd();
                    }
                    dynamic json_object_to_handle1 = JObject.Parse(data1);

                    Console.WriteLine(json_object_to_handle1.user.GetValue("username"));
                    user.user_name = json_object_to_handle1.user.GetValue("username");
                    user.full_name = json_object_to_handle1.user.GetValue("full_name");
                    user.biography = json_object_to_handle1.user.GetValue("biography");
                    user.followers_count = json_object_to_handle1.user.followed_by.GetValue("count");
                    user.following_count = json_object_to_handle1.user.follows.GetValue("count");
                }
                Thread.Sleep(2000);
                Console.WriteLine("Next step");
            }
            Console.WriteLine(user.full_name);
            Console.WriteLine(user.biography);



            for (int j = 0; j < user.photos_codes.Count; j++)
            {


                var request = WebRequest.Create("https://www.instagram.com/p/" + user.photos_codes[j] + "/?__a=1");
                request.Proxy = null;
                var response = request.GetResponse();
                using (StreamReader sReader = new StreamReader(response.GetResponseStream(), encode))
                {
                    data = sReader.ReadToEnd();
                }
                // Console.WriteLine(data);



                json_object_to_handle = JObject.Parse(data);
                string json = "";
                if (json_object_to_handle.graphql.shortcode_media.edge_media_to_caption.edges.Count != 0)
                {
                    json = json_object_to_handle.graphql.shortcode_media.edge_media_to_caption.edges[0].node.GetValue("text").ToString();
                    json = Regex.Replace(json, @"\\u([0-9A-Fa-f]{4})", m => "" + (char)Convert.ToInt32(m.Groups[1].Value, 16));

                    string[] words = json.Trim().Split(new Char[] { ' ', '\n', '\r', '.', ',', ':', '-', '[', ']', '\\', '/', 
                       '{', '}', '#', '@', '!', '?', '(', ')', '<', '>', '"', '+'}, StringSplitOptions.RemoveEmptyEntries);
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
                        if (user.dict.ContainsKey(words[k]))
                            user.dict[words[k]] += 1;
                        else
                            user.dict.Add(words[k], 1);

                    }

                }

                for (int i = 0; i < json_object_to_handle.graphql.shortcode_media.edge_media_to_comment.edges.Count; i++)
                {
                    json = json_object_to_handle.graphql.shortcode_media.edge_media_to_comment.edges[i].node.GetValue("text").ToString();
                    json = Regex.Replace(json, @"\\u([0-9A-Fa-f]{4})", m => "" + (char)Convert.ToInt32(m.Groups[1].Value, 16));

                    string[] words = json.Trim().Split(new Char[] { ' ', '\n', '\r', '.', ',', ':', '-', '[', ']', '\\', '/', 
                       '{', '}', '#', '@', '!', '?', '(', ')', '<', '>', '"', '+'}, StringSplitOptions.RemoveEmptyEntries);
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
                        if (user.dict.ContainsKey(words[k]))
                            user.dict[words[k]] += 1;
                        else
                            user.dict.Add(words[k], 1);

                    }


                }





                Thread.Sleep(2000);
                Console.WriteLine("Next step 2");
            }
            /*
            var wordsList = user.dict.ToList();
            wordsList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            foreach (var word in wordsList)
            {
               
                DataRow dr = dataSet1.Tables[0].NewRow();
                dr.BeginEdit();
                dr[0] = word.Key;
                dr[1] = word.Value;
                dr.EndEdit();
                dataSet1.Tables[0].Rows.Add(dr);
                 
                Console.WriteLine(word.Key + " " + word.Value);
            } */
            return user;


        }
    }
}
