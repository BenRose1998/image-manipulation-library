﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP3304Assessment
{
    class Controller
    {
        private IModel _model;

        private IList<string> pathfilenames;

        private IList<string> keys;

        public Controller()
        {
            keys = new List<string>();

            pathfilenames = new List<string>();
            
            pathfilenames.Add("../../assets/JavaFish.png");

            _model = new Model();

            keys = _model.load(pathfilenames);

            Image img = _model.getImage(keys[0], 0, 0);

            Application.Run(new Form1(img));
        }
    }
}