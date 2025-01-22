namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            tabPage2 = new TabPage();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            textBox3 = new TextBox();
            button2 = new Button();
            tabPage3 = new TabPage();
            button4 = new Button();
            button3 = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(1, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(803, 452);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(795, 419);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Навчання";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(193, 157);
            label2.Name = "label2";
            label2.Size = new Size(177, 20);
            label2.TabIndex = 4;
            label2.Text = "Введіть парольне слово";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(193, 92);
            label1.Name = "label1";
            label1.Size = new Size(166, 20);
            label1.TabIndex = 3;
            label1.Text = "Введіть шлях до файлу";
            // 
            // button1
            // 
            button1.Location = new Point(392, 211);
            button1.Name = "button1";
            button1.Size = new Size(124, 34);
            button1.TabIndex = 2;
            button1.Text = "Навчити";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(391, 150);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(392, 85);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(radioButton2);
            tabPage2.Controls.Add(radioButton1);
            tabPage2.Controls.Add(textBox3);
            tabPage2.Controls.Add(button2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(795, 419);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Підбір алгоритму";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(221, 162);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(229, 24);
            radioButton2.TabIndex = 3;
            radioButton2.TabStop = true;
            radioButton2.Text = "Мінімальний час виконання";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(221, 132);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(290, 24);
            radioButton1.TabIndex = 2;
            radioButton1.TabStop = true;
            radioButton1.Text = "Максимальний коефіціент стиснення";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(221, 77);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(290, 27);
            textBox3.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(221, 206);
            button2.Name = "button2";
            button2.Size = new Size(290, 34);
            button2.TabIndex = 0;
            button2.Text = "Підібрати";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(button4);
            tabPage3.Controls.Add(button3);
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(label5);
            tabPage3.Controls.Add(label4);
            tabPage3.Controls.Add(label3);
            tabPage3.Controls.Add(comboBox2);
            tabPage3.Controls.Add(comboBox1);
            tabPage3.Controls.Add(checkBox4);
            tabPage3.Controls.Add(checkBox3);
            tabPage3.Controls.Add(checkBox2);
            tabPage3.Controls.Add(checkBox1);
            tabPage3.Controls.Add(textBox5);
            tabPage3.Controls.Add(textBox4);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(795, 419);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Шифрування/архівування";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(499, 33);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 15;
            button4.Text = "Змінити порядок";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(341, 315);
            button3.Name = "button3";
            button3.Size = new Size(176, 36);
            button3.TabIndex = 14;
            button3.Text = "Зберегти";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(643, 37);
            label6.Name = "label6";
            label6.Size = new Size(17, 20);
            label6.TabIndex = 13;
            label6.Text = "2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(403, 37);
            label5.Name = "label5";
            label5.Size = new Size(17, 20);
            label5.TabIndex = 12;
            label5.Text = "1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 133);
            label4.Name = "label4";
            label4.Size = new Size(177, 20);
            label4.TabIndex = 11;
            label4.Text = "Введіть парольне слово";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 64);
            label3.Name = "label3";
            label3.Size = new Size(166, 20);
            label3.TabIndex = 10;
            label3.Text = "Введіть шлях до файлу";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Deflate", "LZ77", "Bzip2", "LZMA", "PPM" });
            comboBox2.Location = new Point(606, 189);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 9;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "AES", "DES", "3DES", "Blowfish", "RC4" });
            comboBox1.Location = new Point(374, 189);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 8;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(606, 136);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(140, 24);
            checkBox4.TabIndex = 5;
            checkBox4.Text = "Розархівування";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(606, 77);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(118, 24);
            checkBox3.TabIndex = 4;
            checkBox3.Text = "Архівування";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(373, 136);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(144, 24);
            checkBox2.TabIndex = 3;
            checkBox2.Text = "Розшифрування";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(374, 77);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(122, 24);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Шифрування";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(233, 126);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 1;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(233, 61);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Button button1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private TextBox textBox3;
        private Button button2;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private TextBox textBox5;
        private TextBox textBox4;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button button4;
        private Button button3;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
    }
}
