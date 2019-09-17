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
    public enum AlertType
    {
        success, error, warning, info
    }

    public partial class Alert : Form
    {
        private int interval = 0;

        public Alert(string message, AlertType type)
        {
            InitializeComponent();

            messageLabel.Text = message;

            switch (type)
            {
                case AlertType.success:
                    this.BackColor = Color.SeaGreen;
                    icon.Image = imageList1.Images[0];
                    break;
                case AlertType.info:
                    this.BackColor = Color.Silver;
                    icon.Image = imageList1.Images[1];
                    break;
                case AlertType.warning:
                    this.BackColor = Color.FromArgb(255, 128, 0);
                    icon.Image = imageList1.Images[2];
                    break;
                case AlertType.error:
                    this.BackColor = Color.Crimson;
                    icon.Image = imageList1.Images[3];
                    break;
            }
        }

        public static void AlertCreation(string message, AlertType type)
        {
            new Alert(message, type).Show();
        }

        private void Alert_Load(object sender, EventArgs e)
        {
            this.Top = -1 * (this.Height);
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 60;

            Show.Start();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close.Start();
        }

        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            Close.Start();
        }

        private void Show_Tick(object sender, EventArgs e)
        {
            if (this.Top < 60)
            {
                this.Top += interval; // drop alert
                interval += 2; // sppeed double
            }
            else
            {
                Show.Stop();
            }
        }

        private void Close_Tick(object sender, EventArgs e)
        {
            if(this.Opacity > 0)
            {
                this.Opacity -= 0.1;
            }
            else
            {
                this.Close();
            }
        }
    }
}
