﻿using OpenCV_Vision_Pro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV___Vision_Pro
{
    public partial class ToolWindow : Form
    {
        DisplayControl m_displayControl;
        public ToolWindow()
        {
            InitializeComponent();
            m_displayControl = new DisplayControl();
            m_displayControl.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(m_displayControl);
        }
    }
}
