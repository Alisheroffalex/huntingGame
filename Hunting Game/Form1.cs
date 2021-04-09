using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hunting_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PlayButtonClick(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            this.Hide();
            form2.Closed += (s, args) => this.Close();

            
            form2.initUserToGame(this.usernameTextBox.Text);
        }
    }
}
