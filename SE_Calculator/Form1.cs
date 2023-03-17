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
        int gs2 = 0;
        int GridSize3 = 0;
        double gravv = 0;
        double gravv2 = 0;
        double ContainerItem = 0;
        int GridSize4 = 0;
            
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
            else if (GridSize1 == 2)
            {
                double totlc2 = (lc * 260.2) + (lc * 15625 / (0.37));
                double totsc2 = (sc * (73.4)) + (sc * (125) / (0.37));
                double newton2 = (sw + totlc2 + totsc2) * 9.80;

                lblSvar.Text = (Math.Round(newton2, 1)).ToString() + "N";
                lblLargeHydrogen.Text = ((int)(((newton2) / 480000) * 1.1)).ToString() + " st Big SG Hydrogen Thrusters";
                lblSmallHydrogen.Text = ((int)(((newton2) / 98400) * 1.02)).ToString() + " st Small SG Hydrogen Thrusters";

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


            if (gs2 == 1)
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
            else if (gs2 == 2)
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
          
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
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
                tbxSträcka.Text = " WTF?";

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
            else if (listBox4.SelectedItem == "Moon")
            {
                gravv2 = 0.25;
            }
            else if (listBox4.SelectedItem == "Mars")
            {
                gravv2 = 0.9;
            }
            else if (listBox4.SelectedItem == "Titan")
            {
                gravv2 = 0.25;
            }
            else if (listBox4.SelectedItem == "Europa")
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
           
           




        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox4.SelectedItem.ToString())
            {
                case "Display":
                    ContainerItem = 0.75;
                    break;
                case "Ores and Stone":
                    ContainerItem = 0.37;
                    break;
                case "Steel Plate":
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
                    ContainerItem = 5 / 3;
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
                    ContainerItem = 1 / 3;
                    break;
                case "Large Steel Tube":
                    ContainerItem = 1.52;
                    break;
                case "Small Steel Tube":
                    ContainerItem = 0.5;
                    break;
                case "Motor":
                    ContainerItem = 8 / (0.024);
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

        public void comboBox2_Click(object sender, EventArgs e)
        {
           if (comboBox2.SelectedItem == "Large Grid")
            {
                gs2 = 1;
            }
            else
            {
                gs2 = 2;
            }
           
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == "Earth")
            {
                gravv = 1;
            }
            else if (comboBox3.SelectedItem == "Moon")
            {
                gravv = 0.25;
            }
            else if (comboBox3.SelectedItem == "Mars")
            {
                gravv = 0.9;
            }
            else if (comboBox3.SelectedItem == "Titan")
            {
                gravv = 0.25;
            }
            else if (comboBox3.SelectedItem == "Europa")
            {
                gravv = 0.25;
            }
            else
            {
                gravv = 1.1;
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Large Grid")
            {
                GridSize1 = 1;
            }
            else
            {
                GridSize1 = 2;
            }
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox40_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void lblOxygenTank_Click(object sender, EventArgs e)
        {

        }

        private void btnResource_Click(object sender, EventArgs e)
        {
            int lcc = int.Parse(tbxLargeCargo.Text);
            int mcc = int.Parse(tbxMediumCargo.Text);
            int scc = int.Parse(tbxSmallCargo.Text);
            int hab = int.Parse(tbxHeavyArmorBlock.Text);
            int lab = int.Parse(tbxLightArmorBlock.Text);
            int cock = int.Parse(tbxCockpit.Text);
            int battery = int.Parse(tbxBattery.Text);
            int lhtank = int.Parse(tbxLargeHydroTank.Text);
            int shtank = int.Parse(tbxSmallHydroTank.Text);
            int gyro = int.Parse(tbxGyroscope.Text);
            int lhthrust = int.Parse(tbxLargeHydroThruster.Text);
            int shthrust = int.Parse(tbxHydroThruster.Text);
            int ann = int.Parse(tbxAntenna.Text);
            int beacon = int.Parse(tbxBeacon.Text);
            int oredet = int.Parse(tbxOreDetector.Text);
            int drill = int.Parse(tbxDrill.Text);
            int spot = int.Parse(tbxSpotlight.Text);
            int airvent = int.Parse(tbxAirVent.Text);
            int o2h2 = int.Parse(tbxO2H2gen.Text);
            int h2eng = int.Parse(tbxHydroEngine.Text);
            int o2farm = int.Parse(tbxOxygenFarm.Text);
            int o2tank = int.Parse(tbxOxygenTank.Text);
            int largeiont = int.Parse(tbxLargeIonThruster.Text);
            int iont = int.Parse(tbxIonThruster.Text);
            int largeatmot = int.Parse(tbxLargeAtmosphericThruster.Text);
            int atmot = int.Parse(tbxAtmosphericThruster.Text);

            
                
            if (GridSize4 == 1)
            {
                double irontot = (lcc * 3053) + (scc * 770) + (hab * 3150) + (lab * 525) + (cock * 383) + (battery * 2792.5) + (lhtank * 8984) + (shtank * 3584) + (gyro * 13802.5) + (largeatmot * 30240) + (atmot * 4415) + (ann * 3904) + (lhthrust * 9150) + (shthrust * 1845) + (beacon * 3904) + (drill * 7162.5)
                + (oredet * 1687.5) + (o2farm * 1700) + (o2tank * 3584) + (h2eng * 3512) + (o2h2 * 2712.5) + (airvent * 1347.5) + (spot * 448) + (largeiont) + (iont);
                double nickeltot = (lcc * 220) + (scc * 40) + (cock * 5) + (battery * 160) + (gyro * 270) + (largeatmot * 5700) + (atmot * 600) + (lhthrust * 1250) + (shthrust * 200) + (oredet * 400) + (drill * 25) + (airvent * 50) + (o2h2 * 20) + (h2eng * 62) + (largeiont) + (iont);
                double cobalttot = (lcc * 72) + (scc * 12) + (gyro * 150) + (largeatmot * 120) + (atmot * 30) + (lhthrust * 750) + (shthrust * 120) + (largeiont) + (iont);
                double silicontot = (lcc * 6.6) + (scc * 5.4) + (cock * 210) + (battery * 85) + (lhtank * 1.6) + (shtank * 1.6) + (gyro) + (ann * 41.6) + (oredet * 5) + (drill) + (airvent) + (spot * 60) + (o2h2) + (h2eng * 1.8) + (o2farm * 1504) + (o2tank * 1.6);

                tbxIronTot.Text = irontot.ToString();
                tbxNickelTot.Text = nickeltot.ToString();
                tbxCobaltTot.Text = cobalttot.ToString();
                tbxSiliconTot.Text = silicontot.ToString();

                int pcu = ((lcc + scc + airvent) * 10) + ((lhthrust + atmot + largeatmot + shthrust + battery) * 15) + ((lhtank + shtank + spot + h2eng + o2farm + o2tank) * 25) + ((gyro + beacon + oredet + o2h2) * 50) + (cock * 150) + (drill * 190) + (ann * 100);

                tbxPCUCost.Text = pcu.ToString();

                tbxSteelPlate.Text = (((hab + lhthrust) * 150) + ((lab + shthrust) * 25) + ((battery + shtank + o2tank + beacon + ann) * 80) + (lhtank * 280) + (lhtank * 280) + (gyro * 600) + (largeatmot * 260) + (atmot * 55) + (oredet * 50) + (spot * 8) + (airvent * 45) + (o2h2 * 120) + (h2eng * 100) + (o2farm * 40)).ToString();
                tbxDetectorComponent.Text = ((oredet) * 25).ToString();
                tbxRadioComponent.Text = ((ann + beacon) * 40).ToString();
                tbxPowerCell.Text = ((battery * 80) + (h2eng * 1)).ToString();
                tbxDisplay.Text = ((lcc+scc) + (cock * 8)).ToString();
                tbxMetalGrid.Text = ((lcc * 24) + (scc * 4) + (gyro * 50) + ((largeatmot + shthrust) * 40) + (atmot * 10) + (lhthrust * 250)).ToString();
                tbxMotor.Text = ((lcc * 20) + ((scc + o2h2) * 4) + (cock * 1) + (gyro * 4) + (largeatmot * 1100) + (atmot * 110) + ((oredet + drill) * 5) + (h2eng * 12) + (airvent * 10)).ToString();
                tbxInteriorPlate.Text = ((lcc * 360) + (scc * 40) + (cock * 30) + (spot * 20)).ToString();
                tbxBulletproofGlass.Text = ((cock * 10) + (spot * 4) + (o2farm * 100)).ToString();
                tbxComputer.Text = ((lcc * 8) + (scc * 2) + (cock * 100) + ((battery + oredet) * 25) + ((lhtank + shtank + ann + beacon + o2tank) * 8) + ((gyro + drill + airvent + o2h2) * 5) + (h2eng * 4)).ToString();
                tbxConstructionComponent.Text = ((lcc * 80) + ((scc + lhtank + shtank + gyro + ann + beacon + oredet + drill + o2tank) * 40) + ((airvent + cock) * 20) + (battery * 30) + ((atmot + h2eng) * 70) + (lhthrust * 180) + (shthrust * 60) + (spot * 15) + (o2h2 * 5)).ToString();
                tbxSmallSteelTube.Text = (((lcc+lhtank+shtank+ann+beacon+o2tank) * 60) + (scc*20) + (h2eng * 20) + (o2farm * 10)).ToString();
                tbxLargeSteelTube.Text = ((lhtank * 80) + ((shtank+ann+lhthrust+beacon+o2tank) * 40) + (gyro * 4) + (largeatmot * 50) + ((atmot+shthrust) * 8) + ((h2eng+drill) * 12) + ((o2h2+spot) * 2) + (o2farm * 20)).ToString();




            }
            else
            {




            }



        }

        private void cbxGridSize_Click(object sender, EventArgs e)
        {
            if (cbxGridSize.SelectedItem == "Large Grid")
            {
                GridSize4 = 1;
            }
            else
            {
                GridSize4 = 2;
            }
        }
    }
}
