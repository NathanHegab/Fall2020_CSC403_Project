using Fall2020_CSC403_Project.code;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project {
    public partial class FrmInventory : Form {
        public static FrmInventory instance = new FrmInventory();
        private static Sword[] inventory = new Sword[3];
        private Player player;

        public FrmInventory() {
            InitializeComponent();
            player = Game.player;
        }

        public static FrmInventory GetInstance() {
            return instance;
        }

        public void PutItemInInventory(Sword sword) {
            int indexAddedTo = 0;
            // looks for the next available spot to put sword in inventory
            for (int i = 0; i < inventory.Length; i++) {
                if (inventory[i] is Sword) {
                    continue;
                }
                else {
                    inventory[i] = sword;
                    indexAddedTo = i;
                    break;
                }
            }
            if (indexAddedTo == 0) {
                instance.itemDescription1.Text = sword.swordDescription;
                instance.inventorySpace1.Image = sword.swordPicture;
            }
            else if (indexAddedTo == 1) {
                instance.itemDescription2.Text = sword.swordDescription;
                instance.inventorySpace2.Image = sword.swordPicture;
            }
            else {
                instance.itemDescription3.Text = sword.swordDescription;
                instance.inventorySpace3.Image = sword.swordPicture;
            }
        }

        // equips the sword to player when button is pressed
        private void button1_Click(object sender, EventArgs e) {
            if(inventory[0] is Sword) {
                player.equipWeapon(inventory[0]);
            }
        }
        private void button2_Click(object sender, EventArgs e) {
            if (inventory[1] is Sword) {
                player.equipWeapon(inventory[1]);
            }
        }
        private void button3_Click(object sender, EventArgs e) {
            if (inventory[2] is Sword) {
                player.equipWeapon(inventory[2]);
            }
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
