using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP3304Assessment
{
    public partial class Form1 : Form
    {
        private Image _img;

        public Form1(Image img)
        {

            InitializeComponent();
            _img = img;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = _img;
        }
    }
}
