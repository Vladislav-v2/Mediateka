namespace Mediateka
{
    partial class AddSound
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtArtist = new System.Windows.Forms.ComboBox();
            this.txtAvtor = new System.Windows.Forms.ComboBox();
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.txtLeng = new System.Windows.Forms.MaskedTextBox();
            this.soundID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(132, 58);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(141, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(132, 198);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtText.Size = new System.Drawing.Size(141, 102);
            this.txtText.TabIndex = 4;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(133, 139);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(141, 20);
            this.txtSize.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Виконавець";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Композиція";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Автор";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Тривалість";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Слова";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Обсяг файлу";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Дата створення";
            // 
            // button1
            // 
            this.button1.Image = global::Mediateka.Properties.Resources.tick_8026;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(132, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 30);
            this.button1.TabIndex = 14;
            this.button1.Text = "Додати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtArtist
            // 
            this.txtArtist.FormattingEnabled = true;
            this.txtArtist.Location = new System.Drawing.Point(132, 24);
            this.txtArtist.Name = "txtArtist";
            this.txtArtist.Size = new System.Drawing.Size(141, 21);
            this.txtArtist.TabIndex = 15;
            // 
            // txtAvtor
            // 
            this.txtAvtor.FormattingEnabled = true;
            this.txtAvtor.Location = new System.Drawing.Point(132, 85);
            this.txtAvtor.Name = "txtAvtor";
            this.txtAvtor.Size = new System.Drawing.Size(141, 21);
            this.txtAvtor.TabIndex = 16;
            // 
            // txtDate
            // 
            this.txtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDate.Location = new System.Drawing.Point(133, 172);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(141, 20);
            this.txtDate.TabIndex = 17;
            // 
            // txtLeng
            // 
            this.txtLeng.Location = new System.Drawing.Point(133, 113);
            this.txtLeng.Mask = "00:00";
            this.txtLeng.Name = "txtLeng";
            this.txtLeng.Size = new System.Drawing.Size(37, 20);
            this.txtLeng.TabIndex = 18;
            this.txtLeng.ValidatingType = typeof(System.DateTime);
            // 
            // soundID
            // 
            this.soundID.AutoSize = true;
            this.soundID.Location = new System.Drawing.Point(112, 27);
            this.soundID.Name = "soundID";
            this.soundID.Size = new System.Drawing.Size(0, 13);
            this.soundID.TabIndex = 19;
            // 
            // AddSound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 344);
            this.Controls.Add(this.soundID);
            this.Controls.Add(this.txtLeng);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtAvtor);
            this.Controls.Add(this.txtArtist);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddSound";
            this.Text = "Нова композиція";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.TextBox txtText;
        public System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.ComboBox txtArtist;
        public System.Windows.Forms.ComboBox txtAvtor;
        public System.Windows.Forms.DateTimePicker txtDate;
        public System.Windows.Forms.MaskedTextBox txtLeng;
        public System.Windows.Forms.Label soundID;
    }
}