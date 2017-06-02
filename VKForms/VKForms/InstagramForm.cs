using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VKForms
{
    public partial class InstagramForm : Form
    {
        public InstagramForm()
        {
            InitializeComponent();
            button2.Enabled = false;
            button1.Enabled = false;
        }

        Instagram.UserInfo user;
        private void button1_Click(object sender, EventArgs e)
        {
            user = Instagram.getInfo(textBox1.Text);
            Dictionary<string, int> dict = user.dict;
            var wordsList = dict.ToList();
            wordsList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            foreach (var word in wordsList)
            {
                DataRow dr = dataSet1.Tables[0].NewRow();
                dr.BeginEdit();
                dr[0] = word.Key;
                dr[1] = word.Value;
                dr.EndEdit();
                dataSet1.Tables[0].Rows.Add(dr);
            }
            textBox2.Text = user.full_name;
            textBox3.Text = user.biography;
            textBox4.Text = user.followers_count.ToString();
            textBox5.Text = user.following_count.ToString();
            textBox6.Text = user.total_likes_count.ToString();
            textBox7.Text = user.total_photos_count.ToString();

            button2.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = textBox1.Text.Trim() != "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.ShowDialog();
            saveFileDialog1.DefaultExt = "csv";
            var myExport = new CsvExport();

            Dictionary<string, int> dict = user.dict;
            var wordsList = dict.ToList();
            wordsList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            myExport.AddRow();
            myExport["Слово"] = wordsList[0].Key;
            myExport["Количество"] = wordsList[0].Value;
            myExport["Полное имя"] = user.full_name;
            myExport["Описание"] = user.biography;
            myExport["Количество подписчиков"] = user.followers_count.ToString();
            myExport["Количество подписок"] = user.following_count.ToString();
            myExport["Общее количество лайков"] = user.total_likes_count.ToString();
            myExport["Общее количество фотографий"] = user.total_photos_count.ToString();
            for (int i = 1; i < wordsList.Count; i++)
            {               
                myExport["Слово"] = wordsList[i].Key;
                myExport["Количество"] = wordsList[i].Value;
                myExport.AddRow();
            }

          

            ///ASP.NET MVC action example

            myExport.ExportToFile(saveFileDialog1.FileName);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

       
    }
}
