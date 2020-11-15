using Fall2020_CSC403_Project.code;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project {
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
    }
}
