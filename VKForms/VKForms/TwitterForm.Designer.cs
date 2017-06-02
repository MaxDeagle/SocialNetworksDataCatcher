namespace VKForms
{
    partial class TwitterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userInfoBox = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.urlBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.timezoneBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.screenNameBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.locationBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.friendsBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.followersBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.targetBox = new System.Windows.Forms.TextBox();
            this.createdBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.filterText = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.словоDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.количествоПовторенийDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.targetBoxWords = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.userInfoBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // userInfoBox
            // 
            this.userInfoBox.Controls.Add(this.button4);
            this.userInfoBox.Controls.Add(this.button1);
            this.userInfoBox.Controls.Add(this.descriptionBox);
            this.userInfoBox.Controls.Add(this.label10);
            this.userInfoBox.Controls.Add(this.urlBox);
            this.userInfoBox.Controls.Add(this.label9);
            this.userInfoBox.Controls.Add(this.timezoneBox);
            this.userInfoBox.Controls.Add(this.label8);
            this.userInfoBox.Controls.Add(this.statusBox);
            this.userInfoBox.Controls.Add(this.label7);
            this.userInfoBox.Controls.Add(this.screenNameBox);
            this.userInfoBox.Controls.Add(this.label6);
            this.userInfoBox.Controls.Add(this.locationBox);
            this.userInfoBox.Controls.Add(this.label5);
            this.userInfoBox.Controls.Add(this.friendsBox);
            this.userInfoBox.Controls.Add(this.label4);
            this.userInfoBox.Controls.Add(this.followersBox);
            this.userInfoBox.Controls.Add(this.label3);
            this.userInfoBox.Controls.Add(this.groupBox1);
            this.userInfoBox.Controls.Add(this.createdBox);
            this.userInfoBox.Controls.Add(this.label2);
            this.userInfoBox.Controls.Add(this.nameBox);
            this.userInfoBox.Controls.Add(this.label1);
            this.userInfoBox.Location = new System.Drawing.Point(12, 12);
            this.userInfoBox.Name = "userInfoBox";
            this.userInfoBox.Size = new System.Drawing.Size(297, 478);
            this.userInfoBox.TabIndex = 0;
            this.userInfoBox.TabStop = false;
            this.userInfoBox.Text = "Информация о пользователе";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 420);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(285, 23);
            this.button4.TabIndex = 22;
            this.button4.Text = "Экспорт в Excel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 449);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(282, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Найти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(6, 349);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.ReadOnly = true;
            this.descriptionBox.Size = new System.Drawing.Size(285, 59);
            this.descriptionBox.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 333);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Описание";
            // 
            // urlBox
            // 
            this.urlBox.Location = new System.Drawing.Point(32, 310);
            this.urlBox.Name = "urlBox";
            this.urlBox.ReadOnly = true;
            this.urlBox.Size = new System.Drawing.Size(259, 20);
            this.urlBox.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 313);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Url";
            // 
            // timezoneBox
            // 
            this.timezoneBox.Location = new System.Drawing.Point(90, 288);
            this.timezoneBox.Name = "timezoneBox";
            this.timezoneBox.ReadOnly = true;
            this.timezoneBox.Size = new System.Drawing.Size(201, 20);
            this.timezoneBox.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Часовой пояс";
            // 
            // statusBox
            // 
            this.statusBox.Location = new System.Drawing.Point(6, 225);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.ReadOnly = true;
            this.statusBox.Size = new System.Drawing.Size(285, 59);
            this.statusBox.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Статус";
            // 
            // screenNameBox
            // 
            this.screenNameBox.Location = new System.Drawing.Point(39, 186);
            this.screenNameBox.Name = "screenNameBox";
            this.screenNameBox.ReadOnly = true;
            this.screenNameBox.Size = new System.Drawing.Size(252, 20);
            this.screenNameBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Ник";
            // 
            // locationBox
            // 
            this.locationBox.Location = new System.Drawing.Point(107, 162);
            this.locationBox.Name = "locationBox";
            this.locationBox.ReadOnly = true;
            this.locationBox.Size = new System.Drawing.Size(184, 20);
            this.locationBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Местоположение";
            // 
            // friendsBox
            // 
            this.friendsBox.Location = new System.Drawing.Point(116, 139);
            this.friendsBox.Name = "friendsBox";
            this.friendsBox.ReadOnly = true;
            this.friendsBox.Size = new System.Drawing.Size(175, 20);
            this.friendsBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Количество друзей";
            // 
            // followersBox
            // 
            this.followersBox.Location = new System.Drawing.Point(146, 116);
            this.followersBox.Name = "followersBox";
            this.followersBox.ReadOnly = true;
            this.followersBox.Size = new System.Drawing.Size(145, 20);
            this.followersBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Количество подписчиков";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.targetBox);
            this.groupBox1.Location = new System.Drawing.Point(9, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 43);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Целевой пользователь";
            // 
            // targetBox
            // 
            this.targetBox.Location = new System.Drawing.Point(6, 17);
            this.targetBox.Name = "targetBox";
            this.targetBox.Size = new System.Drawing.Size(270, 20);
            this.targetBox.TabIndex = 0;
            this.targetBox.TextChanged += new System.EventHandler(this.targetBox_TextChanged);
            // 
            // createdBox
            // 
            this.createdBox.Location = new System.Drawing.Point(108, 91);
            this.createdBox.Name = "createdBox";
            this.createdBox.ReadOnly = true;
            this.createdBox.Size = new System.Drawing.Size(183, 20);
            this.createdBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Зарегистрирован";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(41, 62);
            this.nameBox.Name = "nameBox";
            this.nameBox.ReadOnly = true;
            this.nameBox.Size = new System.Drawing.Size(250, 20);
            this.nameBox.TabIndex = 1;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.filterText);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(315, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 478);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Словарь пользователя";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 420);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(289, 23);
            this.button5.TabIndex = 25;
            this.button5.Text = "Экспорт в Excel";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // filterText
            // 
            this.filterText.Location = new System.Drawing.Point(93, 387);
            this.filterText.Name = "filterText";
            this.filterText.Size = new System.Drawing.Size(195, 20);
            this.filterText.TabIndex = 24;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 385);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "Фильтр";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 449);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(289, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Найти";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.словоDataGridViewTextBoxColumn,
            this.количествоПовторенийDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "tableWords";
            this.dataGridView1.DataSource = this.dataSet1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(276, 311);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // словоDataGridViewTextBoxColumn
            // 
            this.словоDataGridViewTextBoxColumn.DataPropertyName = "Слово";
            this.словоDataGridViewTextBoxColumn.HeaderText = "Слово";
            this.словоDataGridViewTextBoxColumn.Name = "словоDataGridViewTextBoxColumn";
            this.словоDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // количествоПовторенийDataGridViewTextBoxColumn
            // 
            this.количествоПовторенийDataGridViewTextBoxColumn.DataPropertyName = "Количество повторений";
            this.количествоПовторенийDataGridViewTextBoxColumn.HeaderText = "Количество повторений";
            this.количествоПовторенийDataGridViewTextBoxColumn.Name = "количествоПовторенийDataGridViewTextBoxColumn";
            this.количествоПовторенийDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
            this.dataTable1.TableName = "tableWords";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "Слово";
            this.dataColumn1.ColumnName = "Слово";
            this.dataColumn1.ReadOnly = true;
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "Количество повторений";
            this.dataColumn2.ColumnName = "Количество повторений";
            this.dataColumn2.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.targetBoxWords);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(282, 43);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Целевой пользователь";
            // 
            // targetBoxWords
            // 
            this.targetBoxWords.Location = new System.Drawing.Point(6, 17);
            this.targetBoxWords.Name = "targetBoxWords";
            this.targetBoxWords.Size = new System.Drawing.Size(270, 20);
            this.targetBoxWords.TabIndex = 0;
            this.targetBoxWords.TextChanged += new System.EventHandler(this.targetBoxWords_TextChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            // 
            // TwitterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 502);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.userInfoBox);
            this.Name = "TwitterForm";
            this.Text = "Twitter";
            this.Load += new System.EventHandler(this.TwitterForm_Load);
            this.userInfoBox.ResumeLayout(false);
            this.userInfoBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox userInfoBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox timezoneBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox screenNameBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox locationBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox friendsBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox followersBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox targetBox;
        private System.Windows.Forms.TextBox createdBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox targetBoxWords;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn словоDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn количествоПовторенийDataGridViewTextBoxColumn;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox filterText;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}