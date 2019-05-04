using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public string Name { get; set; }

        public DateTime TaskDate { get; set; }

        public bool IsDone { get; set; }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Name = textBoxName.Text;
            TaskDate = dtpTaskDate.Value;
            IsDone = checkBox1.Checked;
        }
    }
}
