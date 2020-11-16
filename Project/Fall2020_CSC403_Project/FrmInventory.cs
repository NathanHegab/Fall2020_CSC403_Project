using Fall2020_CSC403_Project.code;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
    public partial class FrmInventory : Form
    {
        public static FrmInventory instance = new FrmInventory();

        public FrmInventory()
        {
            InitializeComponent();
        }

        public static FrmInventory GetInstance()
        {
            return instance;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        // Form will now hide instead of closing when x is clicked.
        // Borrowed from Reggie's closing battle form feature (Thanks Reggie lol)
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.WindowsShutDown
              || e.CloseReason == CloseReason.ApplicationExitCall
              || e.CloseReason == CloseReason.FormOwnerClosing) return;


            e.Cancel = true;
            this.Hide();
        }
    }
}
