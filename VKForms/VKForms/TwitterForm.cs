using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKForms
{
    public partial class TwitterForm : Form
    {
        Dictionary<string, int> result;
        public TwitterForm()
        {
            
            InitializeComponent();
            button1.Enabled = targetBox.Text.Trim() != "";
            button2.Enabled = targetBoxWords.Text.Trim() != "";
            button4.Enabled = nameBox.Text.Trim() != "";
            button5.Enabled = dataSet1.Tables["tableWords"].Rows.Count != 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
           // string result = Twitter.getUserInfo(targetBox.Text).Result;
           
            Task<string []> task = Task.Run(() => Twitter.getUserInfo(targetBox.Text));
            string[] result = await task;
            Console.WriteLine(result[6]);
            nameBox.Text = result[0];
            createdBox.Text = result[1];
            followersBox.Text = result[2];
            friendsBox.Text = result[3];
            locationBox.Text = result[4];
            screenNameBox.Text = result[5];
            statusBox.Text = result[6];
            timezoneBox.Text = result[7];
            urlBox.Text = result[8];
            descriptionBox.Text = result[9];
        }

        private void targetBox_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = targetBox.Text.Trim() != "";
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Task<Dictionary<string,int>> task = Task.Run(() => Twitter.getTweetsWords(targetBoxWords.Text));
            result = await task;
            //   dataSet1.Tables[0].Columns[0] = result
            var wordsList = result.ToList();
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
            button5.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
      

            DataTable contacts = dataSet1.Tables["tableWords"];

            EnumerableRowCollection<DataRow> query = from contact in contacts.AsEnumerable()
                                                     where contact.Field<string>("Слово").ToLower().Contains(filterText.Text.ToLower())
                                                     select contact;

            DataView view = query.AsDataView();

            dataGridView1.DataSource = view;


        }

        private void targetBoxWords_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = targetBoxWords.Text.Trim() != "";
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            button4.Enabled = nameBox.Text.Trim() != "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TwitterForm_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.ShowDialog();
            saveFileDialog1.DefaultExt = "csv";
            var myExport = new CsvExport();

            var wordsList = result.ToList();
            wordsList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            foreach (var word in wordsList)
            {
                myExport.AddRow();
                myExport["Слово"] = word.Key;
                myExport["Количество повторений"] = word.Value;
            }


            ///ASP.NET MVC action example

            myExport.ExportToFile(saveFileDialog1.FileName);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.ShowDialog();
            saveFileDialog1.DefaultExt = "csv";
            var myExport = new CsvExport();

            
      

                myExport.AddRow();
                myExport["Имя"] = nameBox.Text;
                myExport["Зарегистрирован"] = createdBox.Text;
                myExport["Количество подписчиков"] = followersBox.Text;
                myExport["Количество друзей"] = friendsBox.Text;
                myExport["Местоположение"] = locationBox.Text;
                myExport["Ник"] = screenNameBox.Text;
                myExport["Статус"] = statusBox.Text;
                myExport["Часовой пояс"] = timezoneBox.Text;
                myExport["Сайт"] = urlBox.Text;
                myExport["Описание"] = descriptionBox.Text;

            


            ///ASP.NET MVC action example

            myExport.ExportToFile(saveFileDialog1.FileName);
        }
    }
}
