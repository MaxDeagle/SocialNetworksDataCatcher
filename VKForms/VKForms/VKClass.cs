using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace VKForms
{
    public class User
    {
        public int id;

        public int hidden;
        public string first_name;
        public string last_name;
        public string bdate;
        public List<string> career_ids;
        public int city_id;
        public int country_id;
        public int university_id;
        public int followers_count;
        public bool has_photo;
        public int political;
        public int people_main;
        public int life_main;
        public int smoking;
        public int alcohol;
        public int relation;
        public int sex;
        public string site;
        public List<string> top_five_subs;
        public int count_main_photos;
        public string domain;
        public int same_points;


        public User()
        {
            this.id = -1;
            this.hidden = -1;
            this.first_name = "";
            this.last_name = "";
            this.bdate = "";
            this.career_ids = new List<string>();
            this.city_id = -1;
            this.country_id = -1;
            this.university_id = -1;
            this.followers_count = -1;
            this.has_photo = false;
            this.political = -1;
            this.people_main = -1;
            this.life_main = -1;
            this.smoking = -1;
            this.alcohol = -1;
            this.relation = -1;
            this.sex = -1;
            this.site = "";
            this.top_five_subs = new List<string>();
            this.count_main_photos = -1;
            this.domain = "";
            this.same_points = 0;
        }
    }

    public class UserInfo
    {
        public int id;

        public int hidden;
        public string first_name;
        public string last_name;
        public string bdate;
        public string career;
        public string city;
        public string country;
        public string university;
        public string fac;
        public string edu_form;
        public int followers_count;
        public int political;
        public int people_main;
        public int life_main;
        public int smoking;
        public int alcohol;
        public int relation;
        public string rel_with;
        public int sex;
        public string site;
        public string domain;


        public UserInfo()
        {
            this.id = -1;
            this.hidden = -1;
            this.first_name = "";
            this.last_name = "";
            this.bdate = "";
            this.career = "";
            this.city = "";
            this.country = "";
            this.university = "";
            this.followers_count = -1;
            this.fac = "";
            this.edu_form = "";
            this.political = -1;
            this.people_main = -1;
            this.life_main = -1;
            this.smoking = -1;
            this.alcohol = -1;
            this.relation = -1;
            this.sex = -1;
            this.site = "";
            this.rel_with = "";


            this.domain = "";
    
        }
    }
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
    class VKClass
    {
        public static List <User> findSameAccs(string target, string pathToAccs, string pathToProxys)
        {

            String TARGET_ACC = target;
            //read acc_list
            List<String> ACC_LIST = new List<String>(System.IO.File.ReadAllLines(pathToAccs).Distinct().ToArray());
            //read proxy
            List<String> PROXY_LIST = new List<String>(System.IO.File.ReadAllLines(pathToProxys).Distinct().ToArray());

            //check proxys
            var threadsCheck = new List<Thread>();
            int proxy_iterator = 0;
            while (proxy_iterator < PROXY_LIST.Count)
            {
                string temp_proxy = PROXY_LIST[proxy_iterator];
                Thread proxy_check_thread = new Thread(() =>
                {
                    if (!Thread_function_check_proxy(temp_proxy))
                    {
                        PROXY_LIST.Remove(temp_proxy);
                        proxy_iterator--;
                    }
                });
                proxy_check_thread.Start();
                //Thread.Sleep(10);
                threadsCheck.Add(proxy_check_thread);

                proxy_iterator++;
            }

            foreach (var thread in threadsCheck)
                thread.Join();

            for (int i = 0; i < PROXY_LIST.Count; i++)
            {
                Console.WriteLine(PROXY_LIST[i]);
            }

            if (PROXY_LIST.Count >= ACC_LIST.Count) //if 1 proxy for 1 acc
            {

                PROXY_LIST.RemoveRange(0, PROXY_LIST.Count - ACC_LIST.Count);
            }

            int k = 0;
            List<List<String>> list_of_proxy = new List<List<String>>(); //each element contains users for current proxy

            for (int i = 0; i < PROXY_LIST.Count; i++)
            {
                list_of_proxy.Add(new List<String>());
            }
            for (int i = 0; i < ACC_LIST.Count; i++)
            {

                list_of_proxy[k].Add(ACC_LIST[i]);
                k++;
                if (k == PROXY_LIST.Count)
                    k = 0;


            }
            list_of_proxy[list_of_proxy.Count - 1].Add(TARGET_ACC); //add target user




            List<dynamic> json_objects_to_handle = new List<dynamic>();


            //Start collectioning data
            var threads = new List<Thread>();
            for (int thread_number = 0; thread_number < PROXY_LIST.Count; thread_number++)
            {
                List<String> temp_list = new List<String>();
                for (int i = 0; i < list_of_proxy[thread_number].Count; i++)
                    temp_list.Add(list_of_proxy[thread_number][i]);

                string temp_proxy = PROXY_LIST[thread_number];

                Thread proxy_thread = new Thread(() => { json_objects_to_handle.Add(JObject.Parse(Thread_function(temp_list, temp_proxy))); });

                proxy_thread.Name = "thread " + PROXY_LIST[0].ToString();
                proxy_thread.Start();
                //Thread.Sleep(10);
                threads.Add(proxy_thread);
            }
            //    Console.ReadKey();

            foreach (var thread in threads)
                thread.Join();


            List<User> users_with_data = new List<User>();
            User target_user = new User();
            int count_users = 0;

            //parsing data
            while (count_users <= ACC_LIST.Count)
                for (int i = 0; i < json_objects_to_handle.Count; i++)
                {
                    for (int j = 0; j < json_objects_to_handle[i].response.Count; j++)
                    {
                        User temp_user = new User();
                        Console.WriteLine(json_objects_to_handle[i].response[j].GetValue("id"));
                        temp_user.id = Int32.Parse(json_objects_to_handle[i].response[j].GetValue("id").ToString());
                        temp_user.first_name = json_objects_to_handle[i].response[j].GetValue("first_name");

                        if (json_objects_to_handle[i].response[j].Property("last_name") != null)
                            temp_user.last_name = json_objects_to_handle[i].response[j].GetValue("last_name");
                        if (json_objects_to_handle[i].response[j].Property("sex") != null)
                            temp_user.sex = Int32.Parse(json_objects_to_handle[i].response[j].GetValue("sex").ToString());
                        if (json_objects_to_handle[i].response[j].Property("bdate") != null)
                            temp_user.bdate = json_objects_to_handle[i].response[j].GetValue("bdate");
                        if (json_objects_to_handle[i].response[j].Property("city") != null)
                            temp_user.city_id = Int32.Parse(json_objects_to_handle[i].response[j].city.GetValue("id").ToString());
                        if (json_objects_to_handle[i].response[j].Property("country") != null)
                            temp_user.country_id = Int32.Parse(json_objects_to_handle[i].response[j].country.GetValue("id").ToString());
                        int has_photo = Int32.Parse(json_objects_to_handle[i].response[j].GetValue("has_photo").ToString());
                        temp_user.has_photo = (has_photo == 1);
                        if (json_objects_to_handle[i].response[j].Property("site") != null)
                            temp_user.site = json_objects_to_handle[i].response[j].GetValue("site");
                        if (json_objects_to_handle[i].response[j].Property("followers_count") != null)
                            temp_user.site = json_objects_to_handle[i].response[j].GetValue("followers_count");
                        if (json_objects_to_handle[i].response[j].Property("career") != null)
                            for (k = 0; k < json_objects_to_handle[i].response[j].career.Count; k++)
                            {
                                temp_user.career_ids.Add(json_objects_to_handle[i].response[j].career[k].GetValue("company").ToString());
                            }
                        if (json_objects_to_handle[i].response[j].Property("university") != null)
                            temp_user.university_id = Int32.Parse(json_objects_to_handle[i].response[j].GetValue("university").ToString());
                        if (json_objects_to_handle[i].response[j].Property("relation") != null)
                            temp_user.relation = Int32.Parse(json_objects_to_handle[i].response[j].GetValue("relation").ToString());
                        if (json_objects_to_handle[i].response[j].Property("personal") != null)
                        {
                            if (json_objects_to_handle[i].response[j].personal.Property("political") != null)
                                temp_user.political = Int32.Parse(json_objects_to_handle[i].response[j].personal.GetValue("political").ToString());
                            if (json_objects_to_handle[i].response[j].personal.Property("people_main") != null)
                                temp_user.people_main = Int32.Parse(json_objects_to_handle[i].response[j].personal.GetValue("people_main").ToString());
                            if (json_objects_to_handle[i].response[j].personal.Property("life_main") != null)
                                temp_user.life_main = Int32.Parse(json_objects_to_handle[i].response[j].personal.GetValue("life_main").ToString());
                            if (json_objects_to_handle[i].response[j].personal.Property("smoking") != null)
                                temp_user.smoking = Int32.Parse(json_objects_to_handle[i].response[j].personal.GetValue("smoking").ToString());
                            if (json_objects_to_handle[i].response[j].personal.Property("alcohol") != null)
                                temp_user.alcohol = Int32.Parse(json_objects_to_handle[i].response[j].personal.GetValue("alcohol").ToString());
                        }
                        if (json_objects_to_handle[i].response[j].Property("hidden") != null)
                            temp_user.hidden = Int32.Parse(json_objects_to_handle[i].response[j].GetValue("hidden").ToString());
                        if (json_objects_to_handle[i].response[j].Property("domain") != null)
                            temp_user.domain = json_objects_to_handle[i].response[j].GetValue("domain").ToString();

                        if (temp_user.domain == TARGET_ACC)
                            target_user = temp_user;
                        else
                            users_with_data.Add(temp_user);
                        count_users++;
                    }
                }

            for (int i = 0; i < users_with_data.Count; i++)
                Console.WriteLine("{0} {1}", users_with_data[i].first_name, users_with_data[i].last_name);
            Console.WriteLine("AND {0} {1}", target_user.first_name, target_user.last_name);
            //    Console.ReadKey();

            //getting top subs
            int proxy_number = 0;
            var threads_users = new List<Thread>();
            for (int i = 0; i < users_with_data.Count; i++)
            {
                User temp_user = users_with_data[i];

                string temp_proxy = PROXY_LIST[proxy_number];

                Thread user_thread = new Thread(() =>
                {
                    dynamic json_object_to_handle = JObject.Parse(Thread_function_get_subs(temp_user.id, temp_proxy));
                    //      Console.WriteLine(json_object_to_handle);
                    if (json_object_to_handle.response.Property("items") != null)
                        for (int j = 0; j < json_object_to_handle.response.items.Count; j++)
                        {
                            //          Console.WriteLine(json_object_to_handle.response.items[j].GetValue("id"));
                            temp_user.top_five_subs.Add(json_object_to_handle.response.items[j].GetValue("id").ToString());
                        }
                });

                user_thread.Name = "thread " + PROXY_LIST[0].ToString();
                user_thread.Start();

                users_with_data[i] = temp_user;
                //Thread.Sleep(10);
                threads_users.Add(user_thread);


                proxy_number++;
                if (proxy_number == PROXY_LIST.Count)
                    proxy_number = 0;

            }
            foreach (var thread in threads_users)
                thread.Join();

            dynamic json_object_to_handle_target = JObject.Parse(VKRequests.getTopUserSubs(target_user.id, PROXY_LIST[0]));
            //      Console.WriteLine(json_object_to_handle);
            if (json_object_to_handle_target.response.Property("items") != null)
                for (int j = 0; j < json_object_to_handle_target.response.items.Count; j++)
                {
                    //          Console.WriteLine(json_object_to_handle.response.items[j].GetValue("id"));
                    target_user.top_five_subs.Add(json_object_to_handle_target.response.items[j].GetValue("id").ToString());
                }



            //getting count of main photos
            proxy_number = 0;
            threads_users = new List<Thread>();
            for (int i = 0; i < users_with_data.Count; i++)
            {
                User temp_user = users_with_data[i];

                string temp_proxy = PROXY_LIST[proxy_number];

                Thread user_thread = new Thread(() =>
                {
                    dynamic json_object_to_handle = JObject.Parse(Thread_function_get_count_photos(temp_user.id, temp_proxy));
                    //   Console.WriteLine(json_object_to_handle);
                    if (json_object_to_handle.response.Property("items") != null)
                        for (int j = 0; j < json_object_to_handle.response.items.Count; j++)
                        {
                            if (json_object_to_handle.response.items[j].GetValue("id").ToString().Equals("-6"))
                                temp_user.count_main_photos = Int32.Parse(json_object_to_handle.response.items[j].GetValue("size").ToString());
                        }
                });

                user_thread.Name = "thread " + PROXY_LIST[0].ToString();
                user_thread.Start();

                users_with_data[i] = temp_user;
                //Thread.Sleep(10);
                threads_users.Add(user_thread);


                proxy_number++;
                if (proxy_number == PROXY_LIST.Count)
                    proxy_number = 0;

            }
            foreach (var thread in threads_users)
                thread.Join();

            json_object_to_handle_target = JObject.Parse(VKRequests.getCountPhotos(target_user.id, PROXY_LIST[0]));
            //      Console.WriteLine(json_object_to_handle);
            if (json_object_to_handle_target.response.Property("items") != null)
                for (int j = 0; j < json_object_to_handle_target.response.items.Count; j++)
                {
                    if (json_object_to_handle_target.response.items[j].GetValue("id").ToString().Equals("-6"))
                        target_user.count_main_photos = Int32.Parse(json_object_to_handle_target.response.items[j].GetValue("size").ToString());
                }

            for (int i = 0; i < users_with_data.Count; i++)
            {
                Console.WriteLine("{0} {1} {2}", users_with_data[i].first_name, users_with_data[i].last_name, users_with_data[i].count_main_photos);
                for (int j = 0; j < users_with_data[i].top_five_subs.Count; j++)
                    Console.WriteLine(users_with_data[i].top_five_subs[j]);
            }
            //  Console.ReadKey();
            Console.WriteLine("{0} {1} {2} {3}", target_user.first_name, target_user.last_name, target_user.count_main_photos, target_user.top_five_subs[0]);
            //  Console.ReadKey();


            for (int i = 0; i < users_with_data.Count; i++)
            {
                if (users_with_data[i].alcohol == target_user.alcohol && target_user.alcohol != new User().alcohol) users_with_data[i].same_points += 1;
                if (users_with_data[i].political == target_user.political && target_user.political != new User().political) users_with_data[i].same_points += 1;
                if (users_with_data[i].relation == target_user.relation && target_user.relation != new User().relation) users_with_data[i].same_points += 1;
                if (users_with_data[i].sex == target_user.sex && target_user.sex != new User().sex) users_with_data[i].same_points += 1;
                if (users_with_data[i].site.Equals(target_user.site)) users_with_data[i].same_points += 1;
                if (users_with_data[i].smoking == target_user.smoking && target_user.smoking != new User().smoking) users_with_data[i].same_points += 1;
                if (users_with_data[i].university_id == target_user.university_id && target_user.university_id != new User().university_id) users_with_data[i].same_points += 1;
                if (users_with_data[i].city_id == target_user.city_id && target_user.city_id != new User().city_id) users_with_data[i].same_points += 1;
                if ((users_with_data[i].count_main_photos > target_user.count_main_photos - 5) && users_with_data[i].count_main_photos < target_user.count_main_photos + 5) users_with_data[i].same_points += 1;
                if (users_with_data[i].country_id == target_user.country_id && target_user.country_id != new User().country_id) users_with_data[i].same_points += 1;
                if ((users_with_data[i].followers_count > target_user.followers_count - 100) && users_with_data[i].followers_count < target_user.followers_count + 100) users_with_data[i].same_points += 1;
                if (users_with_data[i].has_photo == target_user.has_photo) users_with_data[i].same_points += 1;
                if (users_with_data[i].life_main == target_user.life_main && target_user.life_main != new User().life_main) users_with_data[i].same_points += 1;
                if (users_with_data[i].people_main == target_user.people_main && target_user.people_main != new User().people_main) users_with_data[i].same_points += 1;

                var result = users_with_data[i].top_five_subs.Intersect(target_user.top_five_subs);
                foreach (string s in result)
                    users_with_data[i].same_points += 1;

                result = users_with_data[i].career_ids.Intersect(target_user.career_ids);
                foreach (string s in result)
                    users_with_data[i].same_points += 1;



            }

            users_with_data.Sort((x, y) =>
            y.same_points.CompareTo(x.same_points));

         
            for (int i = 0; i < users_with_data.Count; i++)
                Console.WriteLine("{0} {1}", users_with_data[i].first_name, users_with_data[i].last_name);

            users_with_data.Distinct();
            Console.WriteLine("Done");
            return users_with_data;
        }

        public static Dictionary<string, int> wallHandle(string target)
        {
      //      String target = "petuhov_max";
       //     String target_id = "36231991";
            string target_id = getUserInfo(target).id.ToString();
            List<String> PROXY_LIST = new List<String>(System.IO.File.ReadAllLines("C:/Users/Max/Documents/Visual Studio 2013/Projects/VKParallelCatcher/VKParallelCatcher/bin/Debug/proxylist.txt").Distinct().ToArray());

            //check proxys
            var threadsCheck = new List<Thread>();
            int proxy_iterator = 0;
            while (proxy_iterator < PROXY_LIST.Count)
            {
                string temp_proxy = PROXY_LIST[proxy_iterator];
                Thread proxy_check_thread = new Thread(() =>
                {
                    if (!Thread_function_check_proxy(temp_proxy))
                    {
                        PROXY_LIST.Remove(temp_proxy);
                        proxy_iterator--;
                    }
                });
                proxy_check_thread.Start();
                //Thread.Sleep(10);
                threadsCheck.Add(proxy_check_thread);

                proxy_iterator++;
            }

            foreach (var thread in threadsCheck)
                thread.Join();

            for (int i = 0; i < PROXY_LIST.Count; i++)
            {
                Console.WriteLine(PROXY_LIST[i]);
            }


            int size_of_wall = (JObject.Parse(VKRequests.getSizeOfWall(target)) as dynamic).response.GetValue("count");
            Console.WriteLine(size_of_wall);
          

            if (!(size_of_wall % 100 == 0))
                size_of_wall = size_of_wall / 100 + 1;
            else
                size_of_wall /= 100;


            if (PROXY_LIST.Count > size_of_wall) //1 proxy to 100 posts
            {

                PROXY_LIST.RemoveRange(0, PROXY_LIST.Count - size_of_wall);
            }


            //getting wall posts
            UserWordBook target_user = new UserWordBook();
            target_user.domain = target;
            int proxy_number = 0;
            int offset = 0;
            var threads_100_posts = new List<Thread>();
            List<String> posts = new List<String>(); //take comments from this
            List<Dictionary<string, int>> list_of_dict = new List<Dictionary<string, int>>();
            for (int i = 0; i < size_of_wall * 2; i++)
            {

                int temp_offset = offset;
                string temp_proxy = PROXY_LIST[proxy_number];
                string temp_target = target;
                Thread thread_for_100_posts = new Thread(() =>
                {

                    string res = Thread_function_get_wall(temp_proxy, temp_target, temp_offset);

                    dynamic json_object_to_handle = JObject.Parse(res);
                    //      Console.WriteLine(json_object_to_handle);
                    if (json_object_to_handle.response.Property("items") != null)
                    {
                        Dictionary<string, int> temp_dict = new Dictionary<string, int>();
                        for (int j = 0; j < json_object_to_handle.response.items.Count; j++)
                        {
                            Console.WriteLine(json_object_to_handle.response.items[j].GetValue("id").ToString());
                            if (json_object_to_handle.response.items[j].GetValue("from_id").ToString().Equals(target_id))
                            {
                                string text = json_object_to_handle.response.items[j].GetValue("text");
                                text = text.Trim();
                                string[] words = text.Split(new Char[] { ' ', '\n', '\r', '.', ',', ':', '-', '[', ']', '\\', '/', 
                                '{', '}', '#', '@', '!', '?', '(', ')', '<', '>', '"' }, StringSplitOptions.RemoveEmptyEntries);
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
                            if (json_object_to_handle.response.items[j].GetValue("from_id").ToString().Equals(target_id))
                            {
                                if (json_object_to_handle.response.items[j].Property("copy_history") != null)
                                {
                                    string text = json_object_to_handle.response.items[j].copy_history[0].GetValue("text");
                                    text = text.Trim();
                                    string[] words = text.Split(new Char[] { ' ', '\n', '\r', '.', ',', ':', '-', '[', ']', '\\', '/', 
                                '{', '}', '#', '@', '!', '?', '(', ')', '<', '>', '"' }, StringSplitOptions.RemoveEmptyEntries);
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
                            }
                            posts.Add(json_object_to_handle.response.items[j].GetValue("id").ToString());
                        }//Сохранить результат каждого потока в общий словарь. Далее комментарии
                        list_of_dict.Add(temp_dict);


                    }
                });




                thread_for_100_posts.Start();



                //Thread.Sleep(10);
                threads_100_posts.Add(thread_for_100_posts);


                proxy_number++;
                if (proxy_number == PROXY_LIST.Count)
                    proxy_number = 0;
                offset += 50;

            }
            foreach (var thread in threads_100_posts)
                thread.Join();

          /*  var myList = target_user.dict.ToList();
            myList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i].Value == 2)
                    Console.WriteLine(myList[i].Key + " " + myList[i].Value);

            }*/
            Console.WriteLine("Done");

            return target_user.dict;

            //https://api.vk.com/api.php?oauth=1&method=wall.getComments&owner_id=36231991&post_id=2273&v=5.63&access_token=cfeeb33ecfeeb33ecfeeb33e56cfbca48cccfeecfeeb33e96e5a5c0c7e391ada0523a8e
            /*
            dynamic json_object_to_handle_target = JObject.Parse(VKRequests.getTopUserSubs(target_user.id, PROXY_LIST[0]));
            //      Console.WriteLine(json_object_to_handle);
            if (json_object_to_handle_target.response.Property("items") != null)
                for (int j = 0; j < json_object_to_handle_target.response.items.Count; j++)
                {
                    //          Console.WriteLine(json_object_to_handle.response.items[j].GetValue("id"));
                    target_user.top_five_subs.Add(json_object_to_handle_target.response.items[j].GetValue("id").ToString());
                }
            */

        }



        static string Thread_function(List<String> piece_of_users_list, string proxy_string)
        {
            return VKRequests.getUsers(piece_of_users_list, proxy_string);
        }

        static bool Thread_function_check_proxy(string proxy_string)
        {
            return VKRequests.isProxyValid(proxy_string);
        }

        static string Thread_function_get_subs(int user_id, string proxy_string)
        {
            return VKRequests.getTopUserSubs(user_id, proxy_string);
        }

        static string Thread_function_get_count_photos(int user_id, string proxy_string)
        {
            return VKRequests.getCountPhotos(user_id, proxy_string);
        }

        static string Thread_function_get_wall(string proxy_string, string target_domain, int offset)
        {
            return VKRequests.getWall(proxy_string, target_domain, offset);
        }
        public static UserInfo getUserInfo(string user_domain)
        {
            dynamic json_objects_to_handle = JObject.Parse(VKRequests.getUserInfo(user_domain));
            Console.WriteLine(json_objects_to_handle);
            UserInfo temp_user = new UserInfo();
            Console.WriteLine(json_objects_to_handle.response[0].GetValue("id"));
            temp_user.id = Int32.Parse(json_objects_to_handle.response[0].GetValue("id").ToString());
            temp_user.first_name = json_objects_to_handle.response[0].GetValue("first_name");


            if (json_objects_to_handle.response[0].Property("last_name") != null)
                temp_user.last_name = json_objects_to_handle.response[0].GetValue("last_name");
            if (json_objects_to_handle.response[0].Property("sex") != null)
                temp_user.sex = Int32.Parse(json_objects_to_handle.response[0].GetValue("sex").ToString());
            if (json_objects_to_handle.response[0].Property("bdate") != null)
                temp_user.bdate = json_objects_to_handle.response[0].GetValue("bdate");
            if (json_objects_to_handle.response[0].Property("city") != null)
                temp_user.city = json_objects_to_handle.response[0].city.GetValue("title").ToString();
            if (json_objects_to_handle.response[0].Property("country") != null)
                temp_user.country = json_objects_to_handle.response[0].country.GetValue("title").ToString();
           
            if (json_objects_to_handle.response[0].Property("site") != null)
                temp_user.site = json_objects_to_handle.response[0].GetValue("site");
            if (json_objects_to_handle.response[0].Property("followers_count") != null)
                temp_user.followers_count = json_objects_to_handle.response[0].GetValue("followers_count");
            if (json_objects_to_handle.response[0].Property("career") != null)
                for (int k = 0; k < json_objects_to_handle.response[0].career.Count; k++)
                {
                    temp_user.career += json_objects_to_handle.response[0].career[k].GetValue("company").ToString();
                    temp_user.career += json_objects_to_handle.response[0].career[k].GetValue("position").ToString();
                    temp_user.career += "; ";
                }
            if (json_objects_to_handle.response[0].Property("university_name") != null)
                temp_user.university = json_objects_to_handle.response[0].GetValue("university_name").ToString();
            if (json_objects_to_handle.response[0].Property("faculty_name") != null)
                temp_user.fac = json_objects_to_handle.response[0].GetValue("faculty_name").ToString();
            if (json_objects_to_handle.response[0].Property("education_form") != null)
                temp_user.edu_form = json_objects_to_handle.response[0].GetValue("education_form").ToString();
            if (json_objects_to_handle.response[0].Property("relation") != null)
                temp_user.relation = Int32.Parse(json_objects_to_handle.response[0].GetValue("relation").ToString());
            if (json_objects_to_handle.response[0].Property("relation_partner") != null)
            {
                temp_user.rel_with += json_objects_to_handle.response[0].relation_partner.GetValue("first_name").ToString();
                temp_user.rel_with += " ";
                temp_user.rel_with += json_objects_to_handle.response[0].relation_partner.GetValue("last_name").ToString();
            }
            if (json_objects_to_handle.response[0].Property("personal") != null)
            {
                if (json_objects_to_handle.response[0].personal.Property("political") != null)
                    temp_user.political = Int32.Parse(json_objects_to_handle.response[0].personal.GetValue("political").ToString());
                if (json_objects_to_handle.response[0].personal.Property("people_main") != null)
                    temp_user.people_main = Int32.Parse(json_objects_to_handle.response[0].personal.GetValue("people_main").ToString());
                if (json_objects_to_handle.response[0].personal.Property("life_main") != null)
                    temp_user.life_main = Int32.Parse(json_objects_to_handle.response[0].personal.GetValue("life_main").ToString());
                if (json_objects_to_handle.response[0].personal.Property("smoking") != null)
                    temp_user.smoking = Int32.Parse(json_objects_to_handle.response[0].personal.GetValue("smoking").ToString());
                if (json_objects_to_handle.response[0].personal.Property("alcohol") != null)
                    temp_user.alcohol = Int32.Parse(json_objects_to_handle.response[0].personal.GetValue("alcohol").ToString());
            }
            if (json_objects_to_handle.response[0].Property("hidden") != null)
                temp_user.hidden = Int32.Parse(json_objects_to_handle.response[0].GetValue("hidden").ToString());
            if (json_objects_to_handle.response[0].Property("domain") != null)
                temp_user.domain = json_objects_to_handle.response[0].GetValue("domain").ToString();

  
            foreach(PropertyInfo prop in typeof(User).GetProperties())
            {
               Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(temp_user, null));
            }
            

            return temp_user;
        }
    }
}
