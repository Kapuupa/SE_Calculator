using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Räknare
{
    public partial class Form1 : Form
    {
        int GridSizeS = 0;
        int GridSize222222 = 0;
        double gravv = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == "Large Grid")
            {
                GridSizeS= 1;    

            }
            else
            {
                GridSizeS= 2;
            }


        }

        private void listBox2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == "Large Grid")
            {
                GridSize222222 = 1;

            }
            else
            {
                GridSize222222 = 2;
            }
        }

        private void listBox3_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem == "Earth")
            {
                grav = 1;
            }
            else if (listBox3.SelectedItem == "Moon")
            {
                grav = 0.25;
            }
            else if (listBox3.SelectedItem == "Mars")
            {
                grav = 0.9;
            }
            else if (listBox3.SelectedItem == "Titan")
            {
                grav = 0.25;
            }
            else if (listBox3.SelectedItem == "Europa")
            {
                grav = 0.25;
            }
            else
            {
                grav = 1.1;
            }
        }

        private void btnRäknaUt_Click(object sender, EventArgs e)
        {

        }
    }

    private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnRäknaUt_Click(object sender, EventArgs e)
        {
            double lc = double.Parse(tbxLargeContainer.Text);
            double sc = double.Parse(tbxSmallc.Text);
            double sw = double.Parse(tbxShipWeight.Text);
           
            
            if (GridSizeS == 1)
            {
                double totlc = (lc * 2449.6) + (lc * 421000 / (0.37));
                double totsc = (sc * 576.4) + (sc * (576.4) / (0.37));
                double newton = (sw + totlc + totsc) * 9.80;
                
                lblSvar.Text = (Math.Round(newton, 1)).ToString() + "N";
                lblLargeHydrogen.Text =((int)(((newton) / 7200000) * 1.1)).ToString() + " st Big LG Hydrogen Thrusters";
                lblSmallHydrogen.Text = ((int)(((newton) / 1080000) * 1.02)).ToString() + " st Small LG Hydrogen Thrusters";

            }
            else
            { 
                lblSvar.Text = sw.ToString();
                lblLargeHydrogen.Text = "";
                lblSmallHydrogen.Text = "";
            
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnRäkna_Click(object sender, EventArgs e)
        {
            double lc2 = double.Parse(tbxLargeContainer2.Text);
            int sc2 = int.Parse(tbxSmallContainer2.Text);
            int sw2 = int.Parse(tbxShipWeight2.Text);
            int bht2 = int.Parse(tbxHydrogenThrusterBig.Text);
            int sht2 = int.Parse(tbxHydrogenThrusterSmall.Text);
            int bat2 = int.Parse(tbxAtmosphericThrusterBig.Text);
            int sat2 = int.Parse(tbxAtmosphericThrusterSmall.Text);
            int bit2 = int.Parse(tbxIonThrusterBig.Text);
            int sit2 = int.Parse(tbxIonThrusterSmall.Text);
            

            if (GridSize222222 == 1)
            {
                int totsw = (int)((lc2 * 421000 / (0.37)) + (sc2 * (15625) / (0.37)) + sw2) ;
                tbxSvar.Text = totsw.ToString() + " kg";

                //+ (bht2 * 6940) + (sht2 * 1420) + (bat2 * 32970) + (sat2 * 4000) + (bit2 * 43200) + (sit2 * 4380));

                double totst = ((bht2 * 7200000) + (sht2 * 1080000) + (bat2 * 6480000) + (sat2 * 648000) + (bit2 * 4320000) + (sit2 * 345600)) / gravv;
                double res = totsw / totst;
                tbxSvar2.Text = res.ToString();

                double maxlift = ((bht2 * 734694) + (sht2 * 110204) + (bat2 * 661224) + (sat2 * 66122) + (bit2 * 88163) + (sit2 * 7053)) / gravv;
                tbxSvar3.Text = maxlift.ToString() + " kg";

                double liftcompare = maxlift / totsw;
                tbxSvar4.Text = liftcompare.ToString();


            }
            else if (GridSize222222 == 2)
            {
                int totsw2 = (int)((lc2 * 15625 / (0.37)) + (sc2 * (125) / (0.37)) + sw2);
                tbxSvar.Text = totsw2.ToString() + " kg";

                //+ (bht2 * 6940) + (sht2 * 1420) + (bat2 * 32970) + (sat2 * 4000) + (bit2 * 43200) + (sit2 * 4380));

                double totst2 = ((bht2 * 480000) + (sht2 * 98400) + (bat2 * 576000) + (sat2 * 96000) + (bit2 * 172800) + (sit2 * 14400)) / gravv;
                double res2 = totsw2 / totst2;
                tbxSvar2.Text = res2.ToString();

                double maxlift2 = ((bht2 * 48980) + (sht2 * 10041) + (bat2 * 58776) + (sat2 * 9796) + (bit2 * 3527) + (sit2 * 294)) / gravv;
                tbxSvar3.Text = maxlift2.ToString() + " kg";

                double liftcompare2 = maxlift2 / totsw2;
                tbxSvar4.Text = liftcompare2.ToString();

            }
            else
            {
                tbxSvar.Text = " WTF did you do wrong?";
                tbxSvar2.Text = " WTF did you do wrong?";
                tbxSvar3.Text = " WTF did you do wrong?";
                tbxSvar4.Text = " WTF did you do wrong?";
            }


        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnSpeed_Click(object sender, EventArgs e)
        {
            int ShipWeight = int.Parse(tbxShipWeight3.Text);
            int BigHydrogenThruster = int.Parse(tbxBHT.Text);
            int SmallHydrogenThruster = int.Parse(tbxSHT.Text);
            int BigAtmosphericThruster = int.Parse(tbxBAT.Text);
            int SmallAtmosphericThruster = int.Parse(tbxSAT.Text);
            int BigIonThruster = int.Parse(tbxBIT.Text);
            int SmallIonThruster = int.Parse(tbxSIT.Text);
            int Grav = int.Parse(tbxGrav.Text);
            int GridSize = int.Parse(tbxGS.Text);

            if ( GridSize == 1)
            {
                double totN = ((BigHydrogenThruster * 7200000) + (SmallHydrogenThruster * 1080000) + (BigAtmosphericThruster * 6480000) + (SmallAtmosphericThruster * 648000) + (BigIonThruster * 4320000) + (SmallIonThruster * 345600)) ;
                double acc = totN / ShipWeight;
                tbxAcceleration.Text = (Math.Round(acc, 1)).ToString() + " m/s";

                tbxTime.Text = (Math.Round((100 / acc), 1)).ToString() + " sekunds to reach 100 m/s";
            }
            else 
            {
                tbxAcceleration.Text = " WTF?";
            
            
            
            }



        }

}
