using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_TFS_ServerOperation
{
    public partial class CustomMessageBox : Form
    {
        public bool returnValue = false;
        private string message;

        public CustomMessageBox(string message)
        {
            this.message = message;
            InitializeComponent();

            MessageBoxQueestion.Text = message;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DeleteYesButton_Click(object sender, EventArgs e)
        {
            returnValue = true;
            Close();
        }

        private void DeleteNoButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
