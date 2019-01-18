using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anket2
{
    public partial class Form1 : Form
    {
        Datebase datebase = new Datebase();
        public Form1()
        {
            InitializeComponent();
            listBox1.DataSource = datebase.GetPeopleList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Point pointtemp = buttonChange.Location;
            buttonChange.Location = buttonAdd.Location;
            buttonAdd.Location = pointtemp;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            Point pointtemp = buttonChange.Location;
            buttonChange.Location = buttonAdd.Location;
            buttonAdd.Location = pointtemp;
        }
    }
}
