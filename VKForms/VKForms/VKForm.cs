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
    public partial class VKForm : Form
    {
        List<User> result;
        Dictionary<string, int> dict;
        public VKForm()
        {
            InitializeComponent();
            button3.Enabled = domainBox.Text.Trim() != "";
            button6.Enabled = targetBoxWords.Text.Trim() != "";
            button5.Enabled = false;
            button8.Enabled = false;
            button7.Enabled = false;
            findSameAccs.Enabled = (textBoxTarget.Text.Trim() != "" && pathToAccs.Text.Trim() != "");
        }

        private void VKForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            findSameAccs.Enabled = (textBoxTarget.Text.Trim() != "" && pathToAccs.Text.Trim() != "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            pathToAccs.Text = openFileDialog1.FileName;
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            pathToProxys.Text = openFileDialog2.FileName;
        }

        private void findSameAccs_Click(object sender, EventArgs e)
        {
           result = VKClass.findSameAccs(textBoxTarget.Text, pathToAccs.Text, pathToProxys.Text);
        //   dataSet1.Tables[0].Columns[0] = result
           foreach (User item in result)
           {
               DataRow dr = dataSet1.Tables[0].NewRow();
               dr.BeginEdit();
               dr[0] = item.first_name + " " + item.last_name;
               dr[1] = item.id;
            dr.EndEdit();
            dataSet1.Tables[0].Rows.Add(dr);
        }
           dataGridView1.DataSource = (new DataView(dataSet1.Tables[0])).ToTable(true, "Пользователь", "ID");
           button7.Enabled = true;
      //  return dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            VKClass.getUserInfo("petuhov_max");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            UserInfo user = VKClass.getUserInfo(domainBox.Text);
            IDBox.Text = user.id.ToString();
            if (user.sex == 1)
                SexBox.Text = "Женский";
            else if (user.sex == 2)
                SexBox.Text = "Мужской";
            else
                SexBox.Text = "Нет данных";
            NameBox.Text = user.first_name + " " + user.last_name;
            if (!user.country.Equals(""))
                CountryBox.Text = user.country;
            else
                CountryBox.Text = "Нет данных";
            if (!user.city.Equals(""))
                CityBox.Text = user.city;
            else
                CityBox.Text = "Нет данных";
            if (!user.bdate.Equals(""))
                DateBox.Text = user.bdate;
            else
                DateBox.Text = "Нет данных";
            if (!user.site.Equals(""))
                SiteBox.Text = user.site;
            else
                SiteBox.Text = "Нет данных";

            FollBox.Text = user.followers_count == -1 ? "Нет данных" : user.followers_count.ToString();
            CareerBox.Text = user.career.Equals("") ? "Нет данных" : user.career;
            UnivBox.Text = user.university.Equals("") ? "Нет данных" : user.university;
            FacBox.Text = user.fac.Equals("") ? "Нет данных" : user.fac;
            FormBox.Text = user.edu_form.Equals("") ? "Нет данных" : user.edu_form;
            if (user.rel_with.Equals(""))
                switch (user.relation)
                {
                    case 1:
                        RelBox.Text = user.sex == 1 ? "не замужем" : "не женат";
                        break;
                    case 2:
                        RelBox.Text = user.sex == 1 ? "есть друг" : "есть подруга";
                        break;
                    case 3:
                        RelBox.Text = user.sex == 1 ? "помолвлена" : "помолвлен";
                        break;
                    case 4:
                        RelBox.Text = user.sex == 1 ? "замужем" : "женат";
                        break;
                    case 5:
                        RelBox.Text = "все сложно";
                        break;
                    case 6:
                        RelBox.Text = "в активном поиске";
                        break;
                    case 7:
                        RelBox.Text = user.sex == 1 ? "влюблена" : "влюблен";
                        break;
                    case 8:
                        RelBox.Text = "в гражданском браке";
                        break;

                }
            else
                RelBox.Text = "с" + " " + user.rel_with;
            if (user.relation == -1)
                RelBox.Text = "Нет данных";
            if (user.life_main != -1)
                switch (user.life_main)
                {
                    case 1:
                        LifeBox.Text = "семья и дети";
                        break;
                    case 2:
                        LifeBox.Text = "карьера и деньги";
                        break;
                    case 3:
                        LifeBox.Text = "развлечения и отдых";
                        break;
                    case 4:
                        LifeBox.Text = "наука и исследования";
                        break;
                    case 5:
                        LifeBox.Text = "совершенствование мира";
                        break;
                    case 6:
                        LifeBox.Text = "саморазвитие";
                        break;
                    case 7:
                        LifeBox.Text = "красота и искусство";
                        break;
                    case 8:
                        LifeBox.Text = "слава и влияние";
                        break;
                }
            else
                LifeBox.Text = "Нет данных";


            if (user.people_main != -1)
                switch (user.people_main)
                {
                    case 1:
                        PeopBox.Text = "ум и креативность";
                        break;
                    case 2:
                        PeopBox.Text = "доброта и честность";
                        break;
                    case 3:
                        PeopBox.Text = "красота и здоровье";
                        break;
                    case 4:
                        PeopBox.Text = "власть и богатство";
                        break;
                    case 5:
                        PeopBox.Text = "смелость и упорство";
                        break;
                    case 6:
                        PeopBox.Text = "юмор и жизнелюбие";
                        break;
                }
            else
                PeopBox.Text = "Нет данных";

            if (user.alcohol != -1)
                switch (user.alcohol)
                {
                    case 1:
                        AlcBox.Text = "резко негативное";
                        break;
                    case 2:
                        AlcBox.Text = "негативное";
                        break;
                    case 3:
                        AlcBox.Text = "компромиссное";
                        break;
                    case 4:
                        AlcBox.Text = "нейтральное";
                        break;
                    case 5:
                        AlcBox.Text = "положительное";
                        break;
                }
            else
                AlcBox.Text = "Нет данных";

            if (user.smoking != -1)
                switch (user.smoking)
                {
                    case 1:
                        SmokeBox.Text = "резко негативное";
                        break;
                    case 2:
                        SmokeBox.Text = "негативное";
                        break;
                    case 3:
                        SmokeBox.Text = "компромиссное";
                        break;
                    case 4:
                        SmokeBox.Text = "нейтральное";
                        break;
                    case 5:
                        SmokeBox.Text = "положительное";
                        break;
                }
            else
                SmokeBox.Text = "Нет данных";
            button8.Enabled = true;

       

        }

        private void domainBox_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = domainBox.Text.Trim() != "";
        }

        private void pathToAccs_TextChanged(object sender, EventArgs e)
        {
            findSameAccs.Enabled = (textBoxTarget.Text.Trim() != "" && pathToAccs.Text.Trim() != "");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dict = VKClass.wallHandle(targetBoxWords.Text);
            var wordsList = dict.ToList();
            wordsList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            foreach (var word in wordsList)
            {
                DataRow dr = dataSet2.Tables[0].NewRow();
                dr.BeginEdit();
                dr[0] = word.Key;
                dr[1] = word.Value;
                dr.EndEdit();
                dataSet2.Tables[0].Rows.Add(dr);
            }
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable contacts = dataSet2.Tables["tableWords"];

            EnumerableRowCollection<DataRow> query = from contact in contacts.AsEnumerable()
                                                     where contact.Field<string>("Слово").ToLower().Contains(filterText.Text.ToLower())
                                                     select contact;

            DataView view = query.AsDataView();

            dataGridView2.DataSource = view;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openFileDialog3.ShowDialog();
        }

        private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
        {
            textBox1.Text = openFileDialog3.FileName;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.ShowDialog();
            saveFileDialog1.DefaultExt = "csv";
            var myExport = new CsvExport();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            
          
            foreach (User item in result)
            {
                try
                {
                    dict.Add(item.first_name + " " + item.last_name, item.id);
                    myExport.AddRow();
                    myExport["Имя"] = item.first_name + " " + item.last_name;
                    myExport["ID"] = item.id;
                }
                catch (ArgumentException)
                {
                    //do nothing
                }
            }

            ///ASP.NET MVC action example

            myExport.ExportToFile(saveFileDialog1.FileName);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.ShowDialog();
            saveFileDialog1.DefaultExt = "csv";
            var myExport = new CsvExport();

            var wordsList = dict.ToList();
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

        private void button8_Click(object sender, EventArgs e)
        {
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CreatePrompt = true;
            saveFileDialog1.ShowDialog();
            saveFileDialog1.DefaultExt = "csv";
            var myExport = new CsvExport();
     

                try
                {

                    myExport.AddRow();
                    myExport["ID"] = IDBox.Text;
                    myExport["Пол"] = SexBox.Text;
                    myExport["Имя"] = NameBox.Text;
                    myExport["Страна"] = CountryBox.Text;
                    myExport["Город"] = CityBox.Text;
                    myExport["Дата рождения"] = DateBox.Text;
                    myExport["Сайт"] = SiteBox.Text;
                    myExport["Количество подписчиков"] = FollBox.Text;
                    myExport["Карьера"] = CareerBox.Text;
                    myExport["Университет"] = UnivBox.Text;
                    myExport["Факультет"] = FacBox.Text;
                    myExport["Форма обучения"] = FormBox.Text;
                    myExport["Состоит в отношениях"] = RelBox.Text;
                    myExport["Главное в людях"] = PeopBox.Text;
                    myExport["Главное в жизни"] = LifeBox.Text;
                    myExport["Отношение к курению"] = SmokeBox.Text;
                    myExport["Отношение к алкоголю"] = AlcBox.Text;
                }
                catch (ArgumentException)
                {
                    //do nothing
                }
                myExport.ExportToFile(saveFileDialog1.FileName);
        }

        private void IDBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void targetBoxWords_TextChanged(object sender, EventArgs e)
        {
            button6.Enabled = targetBoxWords.Text.Trim() != "";
        }
    }
}
