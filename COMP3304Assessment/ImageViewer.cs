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
    // was public maybe fucked up
    partial class ImageViewer : Form
    {
        private Image _img;

        private int imgIndex = 0;

        private FilePathHandler _handler;


        public ImageViewer(FilePathHandler handler)
        {
            InitializeComponent();
            _handler = handler;
            displayImage();
        }

        // DisplayImage
        private void displayImage()
        {
            imageBox.Image = _handler.getImage(imgIndex);
        }
        

        // Load an Image
        private void loadImageButton_Click(object sender, EventArgs e)
        {

            // Open file explorer dialog and store the result in a DialogResult, call it 'result':
            DialogResult result = openFileDialog.ShowDialog();

            // Check if the result is OK
            if(result == DialogResult.OK)
            {
                // Store the name of the file that has been selected, call it 'fileName':
                string fileName = openFileDialog.FileName;
                _handler.add(fileName);
                imgIndex++;
                displayImage();
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            imgIndex++;
            displayImage();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            imgIndex--;
            displayImage();
        }
    }
}
