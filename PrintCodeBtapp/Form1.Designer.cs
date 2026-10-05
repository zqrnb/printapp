namespace PrintCodeBtapp
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            button2 = new Button();
            groupBox2 = new GroupBox();
            listBox1 = new ListBox();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            groupBox3 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(10, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(360, 350);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "基础信息";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(15, 210);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(330, 47);
            comboBox1.TabIndex = 10;
            comboBox1.Text = "选择模板";
            // 
            // button1
            // 
            button1.BackColor = Color.WhiteSmoke;
            button1.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(85, 280);
            button1.Name = "button1";
            button1.Size = new Size(190, 60);
            button1.TabIndex = 9;
            button1.Text = "手动打印";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(15, 90);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(330, 46);
            textBox1.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(15, 165);
            label2.Name = "label2";
            label2.Size = new Size(167, 40);
            label2.TabIndex = 3;
            label2.Text = "当前机型：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(15, 45);
            label1.Name = "label1";
            label1.Size = new Size(167, 40);
            label1.TabIndex = 2;
            label1.Text = "总成条码：";
            // 
            // button2
            // 
            button2.BackColor = Color.WhiteSmoke;
            button2.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(820, 30);
            button2.Name = "button2";
            button2.Size = new Size(130, 44);
            button2.TabIndex = 11;
            button2.Text = "清空日志";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(listBox1);
            groupBox2.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(10, 370);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(960, 280);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "系统日志";
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.IntegralHeight = false;
            listBox1.ItemHeight = 27;
            listBox1.Location = new Point(11, 30);
            listBox1.Name = "listBox1";
            listBox1.ScrollAlwaysVisible = true;
            listBox1.Size = new Size(800, 240);
            listBox1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(566, 305);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(pictureBox1);
            groupBox3.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox3.Location = new Point(380, 10);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(590, 350);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "预览信息";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 660);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = true;
            Name = "Form1";
            Text = "KUKA打印机程序";
            FormClosing += Form1_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label2;
        private Label label1;
        private Button button1;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private GroupBox groupBox3;
        private ListBox listBox1;
        private Button button2;
    }
}
