using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_Calculator
{
    public partial class Form1 : Form
    {
        int GridSize1 = 0;
        int GridSize2 = 0;
        int GridSize3 = 0;
        double gravv = 0;
        double gravv2 = 0;
        double ContainerItem = 0;
            
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRäknaUt_Click(object sender, EventArgs e)
        {
            int lc = int.Parse(tbxLargeContainer.Text);
            int sc = int.Parse(tbxSmallC.Text);
            int sw = int.Parse(tbxShipWeight.Text);

            if (GridSize1 == 1)
            {
                double totlc = (lc * 2449.6) + (lc * 421000 / (0.37));
                double totsc = (sc * 576.4) + (sc * (576.4) / (0.37));
                double newton = (sw + totlc + totsc) * 9.80;

                lblSvar.Text = (Math.Round(newton, 1)).ToString() + "N";
                lblLargeHydrogen.Text = ((int)(((newton) / 7200000) * 1.1)).ToString() + " st Big LG Hydrogen Thrusters";
                lblSmallHydrogen.Text = ((int)(((newton) / 1080000) * 1.02)).ToString() + " st Small LG Hydrogen Thrusters";

            }
            else
            {
                lblSvar.Text = sw.ToString();
                lblLargeHydrogen.Text = "";
                lblSmallHydrogen.Text = "";

            }






        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == "Large Grid")
            {
                GridSize1 = 1;
            }
            else
            {
                GridSize1 = 2; 
            }

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


            if (GridSize2 == 1)
            {
                int totsw = (int)((lc2 * 421000 / ContainerItem) + (sc2 * (15625) / ContainerItem) + sw2);
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
            else if (GridSize2 == 2)
            {
                int totsw2 = (int)((lc2 * 15625 / ContainerItem) + (sc2 * (125) / ContainerItem) + sw2);
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

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == "Large Grid")
            {
                GridSize2 = 1;

            }
            else
            {
                GridSize2 = 2;
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem == "Earth")
            {
                gravv = 1;
            }
            else if (listBox3.SelectedItem == "Moon")
            {
                gravv = 0.25;
            }
            else if (listBox3.SelectedItem == "Mars")
            {
                gravv = 0.9;
            }
            else if (listBox3.SelectedItem == "Titan")
            {
                gravv = 0.25;
            }
            else if (listBox3.SelectedItem == "Europa")
            {
                gravv = 0.25;
            }
            else
            {
                gravv = 1.1;
            }
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
           

            if (GridSize3 == 1)
            {
                double totN = ((BigHydrogenThruster * 7200000) + (SmallHydrogenThruster * 1080000) + (BigAtmosphericThruster * 6480000) + (SmallAtmosphericThruster * 648000) + (BigIonThruster * 4320000) + (SmallIonThruster * 345600));
                double acc = totN / ShipWeight;
                tbxAcceleration.Text = (Math.Round(acc, 1)).ToString() + " m/s";

                tbxTime.Text = (Math.Round((100 / acc), 1)).ToString() + " sekunds to reach 100 m/s";

                double line = 50 * (100 / acc);
                tbxSträcka.Text = (Math.Round(line, 1)).ToString() + " m";

            }
            else
            {
                tbxAcceleration.Text = " WTF?";
                tbxTime.Text = " WTF?";


            }



        }

        private void lblGridSize2_Click(object sender, EventArgs e)
        {

        }

        private void listBox5_Click(object sender, EventArgs e)
        {
            if (listBox5.SelectedItem == "Large Grid")
            {
                GridSize3 = 1;

            }
            else
            {
                GridSize3 = 2;
            }
        }

        private void listBox4_Click(object sender, EventArgs e)
        {
            if (listBox4.SelectedItem == "Earth")
            {
                gravv2 = 1;
            }
            else if (listBox3.SelectedItem == "Moon")
            {
                gravv2 = 0.25;
            }
            else if (listBox3.SelectedItem == "Mars")
            {
                gravv2 = 0.9;
            }
            else if (listBox3.SelectedItem == "Titan")
            {
                gravv2 = 0.25;
            }
            else if (listBox3.SelectedItem == "Europa")
            {
                gravv2 = 0.25;
            }
            else
            {
                gravv2 = 1.1;
            }
        }

        private void listBox6_Click(object sender, EventArgs e)
        {
           
            switch (listBox6.SelectedItem.ToString())
            {
                case "Display" :
                    ContainerItem = 0.75;
                    break;
                case "Ores and Stone":
                    ContainerItem = 0.37;
                    break;
                case "Steel Plate" :
                    ContainerItem = 0.15;
                    break;
                case "Computer":
                    ContainerItem = 5;
                    break;
                case "Construction Component/Gravity Component/ThrusterComponent":
                    ContainerItem = 0.25;
                    break;
                case "Metal Grid":
                    ContainerItem = 2.5;
                    break;
                case "Interior Plate":
                    ContainerItem = 5/3;
                    break;
                case "Iron Ingot":
                    ContainerItem = 0.13;
                    break;
                case "Silicon Wafer":
                    ContainerItem = 0.43;
                    break;
                case "Nickel Ingot/Cobalt Ingot":
                    ContainerItem = 0.11;
                    break;
                case "Magnesium Powder":
                    ContainerItem = 0.58;
                    break;
                case "Silver Ingot":
                    ContainerItem = 0.10;
                    break;
                case "Gold Ingot/Uranium Ingot":
                    ContainerItem = 0.052;
                    break;
                case "Platinum Ingot":
                    ContainerItem = 0.05;
                    break;
                case "Power Cell":
                    ContainerItem = 1.6;
                    break;
                case "Girder":
                    ContainerItem = 1/3;
                    break;
                case "Large Steel Tube":
                    ContainerItem = 1.52;
                    break;
                case "Small Steel Tube":
                    ContainerItem = 0.5;
                    break;
                case "Motor":
                    ContainerItem = 8/(0.024);
                    break;
                case "Detector Component":
                    ContainerItem = 1.2;
                    break;
                case "Radio-comm comp.":
                    ContainerItem = 8.75;
                    break;
                default:
                    ContainerItem = 8 / (15);
                    break;
            }




        }
    }
}
