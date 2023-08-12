using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace screen_shoot_app
{
    public partial class message : Form
    {
        public message()
        {
            InitializeComponent();
        }

        private void tamam_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm= new Form1();
            frm.Show();
        }
    }
}
