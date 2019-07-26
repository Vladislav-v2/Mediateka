namespace Mediateka
{
    partial class NewArtistForm
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
            this.addArtist = new System.Windows.Forms.Button();
            this.comboCountry = new System.Windows.Forms.ComboBox();
            this.comboGenre = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateBirthday = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.idArtist = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addArtist
            // 
            this.addArtist.Image = global::Mediateka.Properties.Resources.tick_8026;
            this.addArtist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addArtist.Location = new System.Drawing.Point(52, 199);
            this.addArtist.Name = "addArtist";
            this.addArtist.Size = new System.Drawing.Size(88, 24);
            this.addArtist.TabIndex = 0;
            this.addArtist.Text = "      Додати";
            this.addArtist.UseVisualStyleBackColor = true;
            this.addArtist.Click += new System.EventHandler(this.addArtist_Click);
            // 
            // comboCountry
            // 
            this.comboCountry.FormattingEnabled = true;
            this.comboCountry.Items.AddRange(new object[] {
            ""});
            this.comboCountry.Location = new System.Drawing.Point(40, 124);
            this.comboCountry.Name = "comboCountry";
            this.comboCountry.Size = new System.Drawing.Size(125, 21);
            this.comboCountry.TabIndex = 1;
            // 
            // comboGenre
            // 
            this.comboGenre.FormattingEnabled = true;
            this.comboGenre.Location = new System.Drawing.Point(40, 164);
            this.comboGenre.Name = "comboGenre";
            this.comboGenre.Size = new System.Drawing.Size(125, 21);
            this.comboGenre.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 20);
            this.textBox1.TabIndex = 3;
            // 
            // dateBirthday
            // 
            this.dateBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBirthday.Location = new System.Drawing.Point(40, 73);
            this.dateBirthday.Name = "dateBirthday";
            this.dateBirthday.Size = new System.Drawing.Size(125, 20);
            this.dateBirthday.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ім\'я виконавця";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Дата народження";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Країна народження";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Музичний жанр";
            // 
            // idArtist
            // 
            this.idArtist.AutoSize = true;
            this.idArtist.Enabled = false;
            this.idArtist.Location = new System.Drawing.Point(12, 31);
            this.idArtist.Name = "idArtist";
            this.idArtist.Size = new System.Drawing.Size(0, 13);
            this.idArtist.TabIndex = 9;
            // 
            // NewArtistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 235);
            this.Controls.Add(this.idArtist);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateBirthday);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboGenre);
            this.Controls.Add(this.comboCountry);
            this.Controls.Add(this.addArtist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "NewArtistForm";
            this.Text = "Новий виконавець";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button addArtist;
        public System.Windows.Forms.ComboBox comboCountry;
        public System.Windows.Forms.ComboBox comboGenre;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.DateTimePicker dateBirthday;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label idArtist;
    }
}