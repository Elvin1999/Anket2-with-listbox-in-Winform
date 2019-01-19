using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anket2
{
    public partial class Form1 : Form
    {
        Datebase datebase = new Datebase();
        Person person = new Person();
        public Form1()
        {
            InitializeComponent();
            listBPerson.DisplayMember = "Name";
            //listBPerson.DataSource = datebase.GetPeopleList(); with problem
            listBPerson.Items.AddRange(datebase.GetPeopleList().ToArray());
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Point pointtemp = buttonChange.Location;
            buttonChange.Location = buttonAdd.Location;
            buttonAdd.Location = pointtemp;
            person.Name = textBoxName.Text;
            person.Surname = textBoxSurname.Text;
            person.Email = textBoxEmail.Text;
            person.Phonenumber = maskedTbPhone.Text;
            person.Birthdate = DateTime.Parse(maskedTbBirthDate.Text);
            //listBPerson.DataSource = datebase.GetPeopleList();
            datebase.Add(person);
            listBPerson.Items.Add(person);
            //listBPerson.DataSource = datebase.GetPeopleList();            
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            Point pointtemp = buttonChange.Location;
            buttonChange.Location = buttonAdd.Location;
            buttonAdd.Location = pointtemp;
            textBoxName.Enabled = true;
            textBoxSurname.Enabled = true;
            textBoxEmail.Enabled = true;
            maskedTbPhone.Enabled = true;
            maskedTbBirthDate.Enabled = true;
            foreach (var item in this.Controls)
            {
                if (item is TextBox tb)
                {
                    tb.ForeColor = Color.Black;
                }
                if (item is MaskedTextBox masked)
                {
                    masked.ForeColor = Color.Black;
                }
            }
            if (textBFilename.Text == "Filename")
            {
                textBFilename.ForeColor = Color.Gray;
            }
        }
        public bool CheckAccessToProgram { get; set; }
        private void listBPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckAccessToProgram)
            {
                Person person = listBPerson.SelectedItem as Person;
                textBoxName.Text = person.Name;
                textBoxSurname.Text = person.Surname;
                textBoxEmail.Text = person.Email;
                maskedTbPhone.Text = person.Phonenumber;
                maskedTbBirthDate.Text = person.Birthdate.ToShortDateString();
                textBoxName.Enabled = false;
                textBoxSurname.Enabled = false;
                textBoxEmail.Enabled = false;
                maskedTbPhone.Enabled = false;
                maskedTbBirthDate.Enabled = false;
                CheckAccessToProgram = false;
            }
            CheckAccessToProgram = true;
        }
        public string Filename { get; set; }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            Filename = textBFilename.Text;
            if (File.Exists(Filename))
            {
                string result = File.ReadAllText(Filename);
                var db = JsonConvert.DeserializeObject<Datebase>(result);
                listBPerson.Items.Clear();
                listBPerson.Items.AddRange(db.GetPeopleList().ToArray());
            }
            else
            {
                MessageBox.Show($"{Filename} this file does not exist");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Filename = textBFilename.Text;
            var result = JsonConvert.SerializeObject(datebase);
            File.WriteAllText(Filename + ".json", result);
        }
    }
}
