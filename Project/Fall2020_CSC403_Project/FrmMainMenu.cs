using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string inventoryText;
            string equipText;
            string openInventoryText;
            if (btnChangeLan.Text == "Switch to Spanish")
            {
                inventoryText = "INVENTORY";
                equipText = "Equip";
                openInventoryText = "Press 'N' key to open inventory";
            }
            else
            {
                inventoryText = "INVENTORIO";
                equipText = "Equipar";
                openInventoryText = "Presiona 'N' para abrir tu inventorio";
            }
            FrmLevel formLevel = new FrmLevel(inventoryText, equipText, openInventoryText);
            formLevel.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangeLan_Click(object sender, EventArgs e)
        {
            if (btnChangeLan.Text == "Switch to Spanish")
            {
                btnChangeLan.Text = "Cambiar a Ingles";
                btnExit.Text = "Salir";
                btnStart.Text = "Iniciar";
                lblTitle.Text = "La Venganza de Kool Aid Main";    
            }
            else
            {
                btnChangeLan.Text = "Switch to Spanish";
                btnExit.Text = "Exit";
                btnStart.Text = "Start";
                lblTitle.Text = "The Revenge of the Kool Aid Main";
            }
        }
    }
}
