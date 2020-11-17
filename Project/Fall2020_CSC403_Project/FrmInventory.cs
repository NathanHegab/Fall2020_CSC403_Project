using Fall2020_CSC403_Project.code;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project {
    public partial class FrmInventory : Form {
        public static FrmInventory instance = new FrmInventory();
        private static Sword[] inventory = new Sword[3];

        public FrmInventory() {
            InitializeComponent();
        }

        public static FrmInventory GetInstance() {
            return instance;
        }

        public void PutItemInInventory(Sword sword) {
            // looks for the next available spot to put sword in inventory
            for (int i = 0; i < inventory.Length; i++) {
                if (inventory[i] != sword) {
                    inventory[i] = sword;
                }
            }

            instance.itemDescription1.Text = sword.swordDescription;
            instance.inventorySpace1.Image = sword.swordPicture;
        }

        private void button1_Click(object sender, EventArgs e) {

        }

        // Form will now hide instead of closing when x is clicked.
        // Borrowed from Reggie's closing battle form feature (Thanks Reggie lol)
        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.WindowsShutDown
              || e.CloseReason == CloseReason.ApplicationExitCall
              || e.CloseReason == CloseReason.FormOwnerClosing) return;


            e.Cancel = true;
            this.Hide();
        }
    }
}
