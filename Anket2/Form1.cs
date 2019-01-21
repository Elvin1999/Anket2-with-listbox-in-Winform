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
            listBPerson.Items.AddRange(datebase.GetPeopleList().ToArray());
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            person = new Person();
            listBPerson.Items.Clear();
            Point pointtemp = buttonChange.Location;
            buttonChange.Location = buttonAdd.Location;
            buttonAdd.Location = pointtemp;
            person.Name = textBoxName.Text;
            person.Surname = textBoxSurname.Text;
            person.Email = textBoxEmail.Text;
            person.Phonenumber = maskedTbPhone.Text;
            person.Birthdate = dateTimePicker1.Value;//hiding problem
            datebase.Add(datebase.GetPerson(person));
             listBPerson.DisplayMember = "Name";
            listBPerson.Items.AddRange(datebase.GetPeopleList().ToArray());
        }
        private void buttonChange_Click(object sender, EventArgs e)
        {
            Point pointtemp = buttonChange.Location;
            buttonChange.Location = buttonAdd.Location;
            buttonAdd.Location = pointtemp;
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
            var itemp = listBPerson.SelectedItem as Person;
            datebase.Remove(itemp);
            listBPerson.Items.Clear();
            listBPerson.DisplayMember = "Name";
            listBPerson.Items.AddRange(datebase.GetPeopleList().ToArray());
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
                dateTimePicker1.Value = person.Birthdate;
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
                var list = JsonConvert.DeserializeObject<List<Person>>(result);
                datebase.SetList(list);
                listBPerson.DataSource = datebase.GetPeopleList();
            }
            else
            {
                MessageBox.Show($"{Filename} this file does not exist");
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            Filename = textBFilename.Text;
            var result = JsonConvert.SerializeObject(datebase.GetPeopleList());
            File.WriteAllText(Filename, result);
        }
        private void textBoxName_Enter(object sender, EventArgs e)
        {
            if (textBoxName.Text == "Name")
            {
                textBoxName.Text = String.Empty;
            }
            else
            {
                textBoxName.ForeColor = Color.Black;
            }
        }
        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (textBoxName.Text == String.Empty)
            {
                textBoxName.Text = "Name";
            }
            else
            {
                textBoxName.ForeColor = Color.Black;
            }
        }
        private void textBoxSurname_Enter(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == "Surname")
            {
                textBoxSurname.Text = String.Empty;
            }
            else
            {
                textBoxSurname.ForeColor = Color.Black;
            }
        }
        private void textBoxSurname_Leave(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == String.Empty)
            {
                textBoxSurname.Text = "Surname";
            }
            else
            {
                textBoxSurname.ForeColor = Color.Black;
            }
        }
        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "email@example.com")
            {
                textBoxEmail.Text = String.Empty;
            }
            else
            {
                textBoxEmail.ForeColor = Color.Black;
            }
        }
        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == String.Empty)
            {
                textBoxEmail.Text = "email@example.com";
            }
            else
            {
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        private void textBFilename_Enter(object sender, EventArgs e)
        {
            if (textBFilename.Text == "Filename")
            {
                textBFilename.Text = String.Empty;
            }
            else
            {
                textBFilename.ForeColor = Color.Black;
            }
        }

        private void textBFilename_Leave(object sender, EventArgs e)
        {
            if (textBFilename.Text == String.Empty)
            {
                textBFilename.Text = "Filename";
            }
            else
            {
                textBFilename.ForeColor = Color.Black;
            }
        }
    }
}
