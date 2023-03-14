using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RäknareV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRäkna_Click(object sender, EventArgs e)
        {
            int lc2 = int.Parse(tbxLargeContainer.Text);
            int sc2 = int.Parse(tbxSmallContainer.Text);
            int gs2 = int.Parse(tbxGridSize.Text);
            int sw2 = int.Parse(tbxShipWeight.Text);
            int bht2 = int.Parse(tbxHydrogenThrusterBig.Text);
            int sht2 = int.Parse(tbxHydrogenThrusterSmall.Text);
            int bat2 = int.Parse(tbxAtmosphericThrusterBig.Text);
            int sat2 = int.Parse(tbxAtmosphericThrusterSmall.Text);
            int bit2 = int.Parse(tbxIonThrusterBig.Text);
            int sit2 = int.Parse(tbxIonThrusterSmall.Text);
        }
    }
}
