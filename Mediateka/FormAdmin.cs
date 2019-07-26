using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;


namespace Mediateka
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();

            db = new MediatekaEntities3();
            refresKomp();
            refresAvtors();
            refresGenre();
            refresArtists();
            refresCountry();
            comboBox1.SelectedIndex = 0;
            comboAvtorsBox.SelectedIndex = 0;
            SearchBox.SelectedIndex = 0;
            comboSearchArtist.SelectedIndex = 0;
            comboCountry.SelectedIndex = 0;
        }
        MediatekaEntities3 db;

        private void userForm()
        {
            dataGridKompoz.ContextMenuStrip = null;
            dataGridArtists.ContextMenuStrip = null;
            dataGridAvtors.ContextMenuStrip = null;
            dataGridGenre.ContextMenuStrip = null;
            dataGridCountry.ContextMenuStrip = null;

            Addbtn.Visible = false;
            RenameBtn.Visible = false;
            Delbtn.Visible = false;

            addArtistBtb.Visible = false;
            redArtistBtn.Visible = false;
            delArtistBtn.Visible = false;

            addBtnAvror.Visible = false;
            renBtnAvtor.Visible = false;
            delBtnAvtor.Visible = false;

            AddGenreBtn.Visible = false;
            RenGenreBtn.Visible = false;
            DelGenreBtn.Visible = false;

            AddCountryBtn.Visible = false;
            RedCountryBtn.Visible = false;
            DelCountryBtn.Visible = false;
        }

        private List<ListKomp> zaproskmp;

        private void refresKomp()
        {
            zaproskmp = db.Виконавці.Join(db.Композиції, v => v.id, vk => vk.id_Виконавець,
            (v, vk) => new { v, vk }).
            Join(db.Автори, avk => avk.vk.id_Автор,
            a => a.id, (avk, a) => new { avk, a }).
            AsEnumerable().Select(x => new ListKomp
            (x.avk.vk.id, x.avk.v.Виконавець, x.avk.vk.Композиція,
            x.a.Автор, x.avk.vk.Тривалість, x.avk.vk.Слова,
            x.avk.vk.Обсяг_файлу_мб_, x.avk.vk.Дата_створення)).ToList();
            dataGridKompoz.DataSource = zaproskmp;
            if (dataGridKompoz.RowCount != 0) notKompoztxt.Visible = false;
            else
                notKompoztxt.Visible = true;
            CountMusic.Text = " Кількість записів: " + dataGridKompoz.RowCount;
        }

        private void refresGenre()
        {
            db.Музичні_жанри.Load();
            dataGridGenre.DataSource = db.Музичні_жанри.ToList();
            if (dataGridGenre.RowCount == 0) notGenretxt.Visible = true;
            else notGenretxt.Visible = false;
            CountGenre.Text = " Кількість записів: " + dataGridGenre.RowCount;
        }

        private void refresCountry()
        {
            db.Країни.Load();
            dataGridCountry.DataSource = db.Країни.ToList();
            if (dataGridCountry.RowCount == 0) notCountryTxt.Visible = true;
            else notCountryTxt.Visible = false;
            CountCountry.Text = " Кількість записів: " + dataGridCountry.RowCount;
        }

        public void refresArtists()
        {
            refsart = db.Музичні_жанри.Join(db.Виконавці, c => c.id, cv => cv.id_музичний_жанр,
             (c, cv) => new { c, cv }).Join(db.Країни, x => x.cv.id_Країна, xc => xc.id, (x, xc) => new { x, xc }).
             AsEnumerable().Select(q => new ListArtist(
             q.x.cv.id, q.x.cv.Виконавець, q.x.cv.Дата_народження, q.xc.Країна, q.x.c.Музичні_жанри1)).ToList();

            dataGridArtists.DataSource = refsart;
            CountArtist.Text = " Кількість записів: " + dataGridArtists.RowCount;
        }

        private void refresAvtors()
        {
            db.Автори.Load();
            dataGridAvtors.DataSource = db.Автори.Local.ToBindingList();
            if (dataGridAvtors.RowCount == 0) notAvtorstxt.Visible = true;
            notAvtorstxt.Visible = false;
            CountAvtors.Text = " Кількість записів: " + dataGridAvtors.RowCount;
        }

        private List<ListArtist> refsart;

        private void FormAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bol) Application.Exit();
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            AddSound newSound = new AddSound();
            newSound.Text = "Нова композиція";
            newSound.button1.Text = "Додати";
            List<Виконавці> sounds = db.Виконавці.ToList();
            newSound.txtArtist.DataSource = sounds;
            newSound.txtArtist.ValueMember = "id";
            newSound.txtArtist.DisplayMember = "Виконавець";

            List<Автори> avtor = db.Автори.ToList();
            newSound.txtAvtor.DataSource = avtor;
            newSound.txtAvtor.ValueMember = "id";
            newSound.txtAvtor.DisplayMember = "Автор";

            DialogResult result = newSound.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Композиції lst = new Композиції();

            lst.Виконавці = (Виконавці)newSound.txtArtist.SelectedItem;
            lst.Автори = (Автори)newSound.txtAvtor.SelectedItem;
            lst.Композиція = newSound.txtName.Text;
            lst.Обсяг_файлу_мб_ = float.Parse(newSound.txtSize.Text);
            lst.Тривалість = TimeSpan.Parse(newSound.txtLeng.Text);
            lst.Слова = newSound.txtText.Text;
            lst.Дата_створення = newSound.txtDate.Value.Date;
            db.Композиції.Add(lst);
            db.SaveChanges();
            refresKomp();
        }

        private void RenameBtn_Click(object sender, EventArgs e)
        {
            if (dataGridKompoz.SelectedRows.Count > 0)
            {
                int index = dataGridKompoz.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridKompoz[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Композиції lst = db.Композиції.Find(id);
                AddSound renSound = new AddSound();
                renSound.Text = "Редагування композиції";
                renSound.button1.Text = "Редагувати";
                List<Виконавці> sounds = db.Виконавці.ToList();
                renSound.txtArtist.DataSource = sounds;
                renSound.txtArtist.ValueMember = "id";
                renSound.txtArtist.DisplayMember = "Виконавець";
                renSound.soundID.Text = lst.id.ToString();

                List<Автори> avtor = db.Автори.ToList();
                renSound.txtAvtor.DataSource = avtor;
                renSound.txtAvtor.ValueMember = "id";
                renSound.txtAvtor.DisplayMember = "Автор";

                renSound.txtName.Text = lst.Композиція.ToString();
                renSound.txtArtist.SelectedValue = lst.id_Виконавець;
                renSound.txtAvtor.SelectedValue = lst.id_Автор;
                renSound.txtName.Text = lst.Композиція;
                renSound.txtLeng.Text = lst.Тривалість.ToString();
                renSound.txtSize.Text = lst.Обсяг_файлу_мб_.ToString();
                renSound.txtText.Text = lst.Слова;
                renSound.txtDate.Text = lst.Дата_створення.ToString();


                DialogResult result = renSound.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                lst.Виконавці = (Виконавці)renSound.txtArtist.SelectedItem;
                lst.Автори = (Автори)renSound.txtAvtor.SelectedItem;
                lst.Композиція = renSound.txtName.Text;
                lst.Обсяг_файлу_мб_ = float.Parse(renSound.txtSize.Text);
                lst.Тривалість = TimeSpan.Parse(renSound.txtLeng.Text);
                lst.Слова = renSound.txtText.Text;
                lst.Дата_створення = renSound.txtDate.Value.Date;
                db.Entry(lst).State = EntityState.Modified;
                db.SaveChanges();
                refresKomp();
            }
        }

        private void додатиКомпозиціюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Addbtn_Click(this, null);
        }

        private void редагуватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameBtn_Click(this, null);
        }

        private void видалитиКомпозиціюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delbtn_Click(this, null);
        }

        private void Delbtn_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Дійсно хочете видалити?", null, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int index = dataGridKompoz.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridKompoz[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Композиції lst = db.Композиції.Find(id);
                db.Композиції.Remove(lst);
                db.SaveChanges();
                refresKomp();
            }
        }

        private void Searchbtn_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                switch (SearchBox.SelectedIndex)
                {
                    case 0:
                        dataGridKompoz.DataSource = zaproskmp.Where
                        (p => p.id.ToString() == txtSearch.Text.ToString()).ToList(); break;
                    case 1:
                        dataGridKompoz.DataSource = zaproskmp.Where
                        (p => p.Виконавець.ToString().Contains(txtSearch.Text.ToString())).ToList(); break;
                    case 2:
                        dataGridKompoz.DataSource = zaproskmp.Where
                        (p => p.Композиція.ToString().Contains(txtSearch.Text.ToString())).ToList(); break;
                    case 3:
                        dataGridKompoz.DataSource = zaproskmp.Where
                        (p => p.Автор.ToString().Contains(txtSearch.Text.ToString())).ToList(); break;
                    case 4:
                        {
                            if (maskedTextBox1.Text.Trim() != "" && maskedTextBox2.Text.Trim() != "")
                                searchKompozLength(maskedTextBox1.Text,
                                  maskedTextBox2.Text); break;
                        }
                    case 5:
                        dataGridKompoz.DataSource = zaproskmp.Where
                        (p => p.Слова.ToString().Contains(txtSearch.Text.ToString())).ToList(); break;
                    case 6:
                        searchKompozSize(txtSearch.Text, txtSearch2.Text); break;
                    case 7:
                        searchKompozDate(dateTimePicker1, dateTimePicker2); break;
                }
            }
            else
                dataGridKompoz.DataSource = zaproskmp;
            dataGridKompoz.Update();
            if (dataGridKompoz.RowCount == 0) notKompoztxt.Visible = true;
            else
                notKompoztxt.Visible = false;
            CountMusic.Text = " Кількість записів: " + dataGridKompoz.RowCount;
        }

        private void addBtnAvror_Click(object sender, EventArgs e)
        {
            AddNewAvtor newAvt = new AddNewAvtor();
            newAvt.Text = "Новий автор";
            newAvt.AddBtn.Text = "     Додати";

            DialogResult result = newAvt.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Автори lst = new Автори();

            lst.Автор = newAvt.textBox1.Text;
            db.Автори.Add(lst);
            db.SaveChanges();
            refresAvtors();
        }

        private void renBtnAvtor_Click(object sender, EventArgs e)
        {
            if (dataGridAvtors.SelectedRows.Count > 0)
            {
                int index = dataGridAvtors.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridAvtors[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Автори lst = db.Автори.Find(id);
                AddNewAvtor newAvt = new AddNewAvtor();
                newAvt.Text = "Редагувати автора";
                newAvt.AddBtn.Text = "     Редагувати";
                newAvt.textBox1.Text = lst.Автор;
                newAvt.idAvtor.Text = lst.id.ToString();

                DialogResult result = newAvt.ShowDialog(this);


                if (result == DialogResult.Cancel)
                    return;

                lst.Автор = newAvt.textBox1.Text;

                db.Entry(lst).State = EntityState.Modified;
                db.SaveChanges();
                refresAvtors();
            }
        }

        private void delBtnAvtor_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Дійсно хочете видалити?", null, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int index = dataGridAvtors.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridAvtors[0, index].Value.ToString(), out id);
                if (converted == false)
                return;

                Автори lst = db.Автори.Find(id);
                db.Автори.Remove(lst);
                db.SaveChanges();
                refresAvtors();
            }
        }

        private void AddGenreBtn_Click(object sender, EventArgs e)
        {
            AddNewGenre newGenre = new AddNewGenre();
            newGenre.Text = "Новий жанр";
            newGenre.AddBtn.Text = "     Додати";

            DialogResult result = newGenre.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Музичні_жанри lst = new Музичні_жанри();

            lst.Музичні_жанри1 = newGenre.textBox1.Text;
            db.Музичні_жанри.Add(lst);
            db.SaveChanges();
            refresGenre();
        }

        private void RenGenreBtn_Click(object sender, EventArgs e)
        {           
                int index = dataGridGenre.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridGenre[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Музичні_жанри lst = db.Музичні_жанри.Find(id);
                AddNewGenre newGenre = new AddNewGenre();
                newGenre.Text = "Редагувати жанр";
                newGenre.AddBtn.Text = "     Редагувати";
                newGenre.textBox1.Text = lst.Музичні_жанри1;
                newGenre.idGenre.Text = lst.id.ToString();

                DialogResult result = newGenre.ShowDialog(this);


                if (result == DialogResult.Cancel)
                    return;

                lst.Музичні_жанри1 = newGenre.textBox1.Text;

                db.Entry(lst).State = EntityState.Modified;
                db.SaveChanges();
                refresGenre();           
        }

        private void DelGenreBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Дійсно хочете видалити?", null, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            { 
                int index = dataGridGenre.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridGenre[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Музичні_жанри lst = db.Музичні_жанри.Find(id);
                db.Музичні_жанри.Remove(lst);
                db.SaveChanges();
                refresAvtors();  
                    
            }     
        }

        private void searchGenre_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Trim() != "")
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        {
                            dataGridGenre.DataSource = db.Музичні_жанри.Where
                                (p => p.id.ToString() == textBox1.Text.ToString()).ToList();
                            break;
                        }
                    case 1:
                        {
                            dataGridGenre.DataSource = db.Музичні_жанри.Where
                                (p => p.Музичні_жанри1.ToString() == textBox1.Text.ToString()).ToList();
                            break;
                        }
                }
            }
            else refresGenre();
            dataGridGenre.Update();
            if (dataGridGenre.RowCount == 0) notGenretxt.Visible = true;
            else notGenretxt.Visible = false;

            CountGenre.Text = " Кількість записів: " + dataGridGenre.RowCount;
        }

        private void searchKompozLength(string stime1, string stime2)
        {

            TimeSpan time1, time2;
            try
            {

                time1 = TimeSpan.Parse(stime1);
                time2 = TimeSpan.Parse(stime2);

            }
            catch (System.FormatException)
            {
                MessageBox.Show("Невірна тривалісь копмозиції", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (System.OverflowException)
            {
                MessageBox.Show("Невірна тривалісь копмозиції", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (time1 < time2)
                dataGridKompoz.DataSource = zaproskmp.Where
                                 (p => p.Тривалість > time1 && p.Тривалість < time2).ToList();
            else dataGridKompoz.DataSource = zaproskmp.Where
                             (p => p.Тривалість > time2 && p.Тривалість < time1).ToList();
        }

        private void searchKompozDate(DateTimePicker date1, DateTimePicker date2)
        {
            if (date1.Value < date2.Value)
                dataGridKompoz.DataSource = zaproskmp.Where
                                 (p => p.Дата_створення > date1.Value && p.Дата_створення < date2.Value).ToList();
            else dataGridKompoz.DataSource = zaproskmp.Where
                             (p => p.Дата_створення > date2.Value && p.Дата_створення < date1.Value).ToList();
        }

        private void searchKompozSize(string sizef1, string sizef2)
        {
            float size1, size2;
            try
            {
                size1 = float.Parse(sizef1);
                size2 = float.Parse(sizef2);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Невірний обсяг файлів", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (size1 < size2)
                dataGridKompoz.DataSource = zaproskmp.Where
                                 (p => p.Обсяг_файлу > size1 && p.Обсяг_файлу < size2).ToList();
            else dataGridKompoz.DataSource = zaproskmp.Where
                             (p => p.Обсяг_файлу > size2 && p.Обсяг_файлу < size1).ToList();

        }

        private void searchAvtorsbtn_Click(object sender, EventArgs e)
        {
            if (searchAvttxt.Text.Trim() != "")
            {
                switch (comboAvtorsBox.SelectedIndex)
                {
                    case 0:
                        {
                            dataGridAvtors.DataSource = db.Автори.Where
                                (p => p.id.ToString() == searchAvttxt.Text.ToString()).ToList();
                            break;
                        }
                    case 1:
                        {
                            dataGridAvtors.DataSource = db.Автори.Where
                                (p => p.Автор.ToString().Contains(searchAvttxt.Text.ToString())).ToList();
                            break;
                        }
                }
            }
            else refresAvtors();
            dataGridAvtors.Update();
            if (dataGridAvtors.RowCount == 0) notAvtorstxt.Visible = true;
            else notAvtorstxt.Visible = false;

            CountAvtors.Text = " Кількість записів: " + dataGridAvtors.RowCount;
        }

        private void SearchBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SearchBox.SelectedIndex == 4)
            {
                txtSearch.Text = "1";
                maskedTextBox1.Visible = true;
                maskedTextBox2.Visible = true;
            }
            else
            {
                txtSearch.Text = "";
                maskedTextBox1.Visible = false;
                maskedTextBox2.Visible = false;
            }
            if (SearchBox.SelectedIndex == 7)
            {
                txtSearch.Text = "1";
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
            }
            else
            {
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
            }
            if (SearchBox.SelectedIndex == 6)
            {
                txtSearch.Text = "";
                txtSearch2.Visible = true;
            }
            else
            {
                txtSearch2.Visible = false;
            }

        }

        private void searchKArtistDate(DateTimePicker date1, DateTimePicker date2)
        {
            if (date1.Value < date2.Value)
                dataGridArtists.DataSource = refsart.Where
                                 (p => p.Дата_народження > date1.Value && p.Дата_народження < date2.Value).ToList();
            else dataGridArtists.DataSource = refsart.Where
                             (p => p.Дата_народження > date2.Value && p.Дата_народження < date1.Value).ToList();
        }

        private void searchArtistBtn_Click(object sender, EventArgs e)
        {
            if (searchArtistTxt.Text != "")
            {
                switch (comboSearchArtist.SelectedIndex)
                {
                    case 0:
                        dataGridArtists.DataSource = refsart.Where
                    (p => p.id.ToString() == searchArtistTxt.Text.ToString()).ToList(); break;
                    case 1:
                        dataGridArtists.DataSource = refsart.Where
                            (p => p.Виконавець.Contains(searchArtistTxt.Text)).ToList(); break;
                    case 2:
                        dataGridArtists.DataSource = refsart.Where
                         (p => p.id_музичний_жанр.ToLower() == searchArtistTxt.Text.ToLower()).ToList(); break;
                    case 3:
                        searchKArtistDate(dateSearch1, dateSearch2); break;
                    case 4:
                        dataGridArtists.DataSource = refsart.Where
                            (p => p.Країна == searchArtistTxt.Text).ToList(); break;
                }
            }
            else
                dataGridArtists.DataSource = refsart;
            dataGridArtists.Update();
            if (dataGridArtists.RowCount == 0) notArtisttxt.Visible = true;
            else
                notArtisttxt.Visible = false;
            CountArtist.Text = " Кількість записів: " + dataGridArtists.RowCount;
        }

        private void comboSearchArtist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSearchArtist.SelectedIndex == 3)
            {
                searchArtistTxt.Text = "1";
                dateSearch1.Visible = true;
                dateSearch2.Visible = true;
            }
            else
            {
                dateSearch1.Visible = false;
                dateSearch2.Visible = false;
            }
        }

        private void addArtistBtb_Click(object sender, EventArgs e)
        {
            NewArtistForm newArt = new NewArtistForm();
            newArt.Text = "Новий виконавець";
            newArt.addArtist.Text = "Додати";

            List<Країни> country = db.Країни.ToList();
            newArt.comboCountry.DataSource = country;
            newArt.comboCountry.ValueMember = "id";
            newArt.comboCountry.DisplayMember = "Країна";

            List<Музичні_жанри> genre = db.Музичні_жанри.ToList();
            newArt.comboGenre.DataSource = genre;
            newArt.comboGenre.ValueMember = "id";
            newArt.comboGenre.DisplayMember = "Музичні_жанри1";

            DialogResult result = newArt.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            Виконавці lst = new Виконавці();
            lst.Виконавець = newArt.textBox1.Text;
            lst.Країни = (Країни)newArt.comboCountry.SelectedItem;
            lst.Музичні_жанри = (Музичні_жанри)newArt.comboGenre.SelectedItem;
            lst.Дата_народження = newArt.dateBirthday.Value.Date;

            db.Виконавці.Add(lst);
            db.SaveChanges();
            refresArtists();
        }

        private void redArtistBtn_Click(object sender, EventArgs e)
        {
            if (dataGridArtists.SelectedRows.Count > 0)
            {
                int index = dataGridArtists.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridArtists[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Виконавці lst = db.Виконавці.Find(id);
                NewArtistForm newArt = new NewArtistForm();
                newArt.Text = "Редагувати виконавця";
                newArt.addArtist.Text = "     Редагувати";

                List<Країни> country = db.Країни.ToList();
                newArt.comboCountry.DataSource = country;
                newArt.comboCountry.ValueMember = "id";
                newArt.comboCountry.DisplayMember = "Країна";

                List<Музичні_жанри> genre = db.Музичні_жанри.ToList();
                newArt.comboGenre.DataSource = genre;
                newArt.comboGenre.ValueMember = "id";
                newArt.comboGenre.DisplayMember = "Музичні_жанри1";

                newArt.textBox1.Text = lst.Виконавець;
                newArt.dateBirthday.Value = lst.Дата_народження.Value;
                newArt.comboCountry.SelectedValue = lst.id_Країна;
                newArt.comboGenre.SelectedValue = lst.id_музичний_жанр;
                newArt.idArtist.Text = lst.id.ToString();


                DialogResult result = newArt.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                lst.Виконавець = newArt.textBox1.Text;
                lst.Країни = (Країни)newArt.comboCountry.SelectedItem;
                lst.Музичні_жанри = (Музичні_жанри)newArt.comboGenre.SelectedItem;
                lst.Дата_народження = newArt.dateBirthday.Value.Date;

                db.Entry(lst).State = EntityState.Modified;
                db.SaveChanges();
                refresArtists();
            }
        }

        private void delArtistBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Дійсно хочете видалити?", null, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int index = dataGridArtists.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridArtists[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Виконавці lst = db.Виконавці.Find(id);
                db.Виконавці.Remove(lst);
                db.SaveChanges();
                refresArtists();
            }
        }

        private void оновитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refresKomp();
        }

        private void searchCountryBtn_Click(object sender, EventArgs e)
        {
            if (searchCountryTxt.Text.Trim() != "")
            {
                switch (comboCountry.SelectedIndex)
                {
                    case 0:
                        {
                            dataGridCountry.DataSource = db.Країни.Where
                                (p => p.id.ToString() == searchCountryTxt.Text.ToString()).ToList();
                            break;
                        }
                    case 1:
                        {
                            dataGridCountry.DataSource = db.Країни.Where
                                (p => p.Країна.ToString() == searchCountryTxt.Text.ToString()).ToList();
                            break;
                        }
                }
            }
            else refresCountry();
            dataGridCountry.Update();
            if (dataGridCountry.RowCount == 0) notCountryTxt.Visible = true;
            else notCountryTxt.Visible = false;

            CountCountry.Text = " Кількість записів: " + dataGridCountry.RowCount;
        }

        private void AddCountryBtn_Click(object sender, EventArgs e)
        {
            AddNewCountry newCountry = new AddNewCountry();
            newCountry.Text = "Новий країна";
            newCountry.button1.Text = "     Додати";

            DialogResult result = newCountry.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Країни lst = new Країни();

            lst.Країна = newCountry.textBox1.Text;
            db.Країни.Add(lst);
            db.SaveChanges();
            refresCountry();
        }

        private void RedCountryBtn_Click(object sender, EventArgs e)
        {
            int index = dataGridCountry.SelectedRows[0].Index;
            int id = 0;
            bool converted = Int32.TryParse(dataGridCountry[0, index].Value.ToString(), out id);
            if (converted == false)
                return;
            Країни lst = db.Країни.Find(id);
            AddNewCountry newCountry = new AddNewCountry();
            newCountry.Text = "Редагувати Країну";
            newCountry.button1.Text = "     Редагувати";
            newCountry.textBox1.Text = lst.Країна;
            newCountry.idCountry.Text = lst.id.ToString();

            DialogResult result = newCountry.ShowDialog(this);


            if (result == DialogResult.Cancel)
                return;

            lst.Країна = newCountry.textBox1.Text;

            db.Entry(lst).State = EntityState.Modified;
            db.SaveChanges();
            refresCountry();
        }

        private void DelCountryBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Дійсно хочете видалити?", null, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int index = dataGridCountry.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridCountry[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Країни lst = db.Країни.Find(id);
                db.Країни.Remove(lst);
                db.SaveChanges();
                refresCountry();
            }
        }

        bool bol = true;

        private void ClosedAccaunt_Click(object sender, EventArgs e)
        {
            Form1 logInOut = new Form1();
            logInOut.Show();
            bol = false;
            this.Close();
        }

        private void додатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addArtistBtb_Click(this, null);
        }

        private void редагуватиToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            RenGenreBtn_Click(this,null);
        }

        private void видалитиToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            delArtistBtn_Click(this, null);
        }

        private void оновитиToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            refresArtists();
        }

        private void додатиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddCountryBtn_Click(this,null);
        }

        private void редагуватиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            redArtistBtn_Click(this, null);
        }

        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delArtistBtn_Click(this, null);
        }

        private void оновитиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            refresArtists();
        }

        private void редагуватиToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RedCountryBtn_Click(this, null);
        }

        private void видалитиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DelCountryBtn_Click(this, null);
        }

        private void оновитиToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            refresCountry();
        }

        private void додатиToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            addBtnAvror_Click(this, null);
        }

        private void редагуватиToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            renBtnAvtor_Click(this, null);
        }

        private void видалитиToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            delBtnAvtor_Click(this, null);
        }

        private void оновитиToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            refresAvtors();
        }

        private void додатиToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddGenreBtn_Click(this, null);
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            if (login.Text != "Привіт, admin") userForm();
        }
    }
}