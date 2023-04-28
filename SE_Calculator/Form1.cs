using System;
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
        int antHoll = 1;
            
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

        private void btnRäkna_Click(object sender, EventArgs e)
        {

            double[] valdItom = new double[]
             {1,0.25,0.9,0.25,0.25,1.1};
            gravv = valdItom[comboBox3.SelectedIndex];

            double lc2 = double.Parse(tbxLargeContainer2.Text);
            int sc2 = int.Parse(tbxSmallContainer2.Text);
            int sw2 = int.Parse(tbxShipWeight2.Text);
            int bht2 = int.Parse(tbxHydrogenThrusterBig.Text);
            int sht2 = int.Parse(tbxHydrogenThrusterSmall.Text);
            int bat2 = int.Parse(tbxAtmosphericThrusterBig.Text);
            int sat2 = int.Parse(tbxAtmosphericThrusterSmall.Text);
            int bit2 = int.Parse(tbxIonThrusterBig.Text);
            int sit2 = int.Parse(tbxIonThrusterSmall.Text);
            int Drills = int.Parse(tbxDrills.Text);

            double totsw = 0;
            double totst = 0;
            double maxlift = 0;



            if (gs2 == 1)
            {
                //den,sw,st,maxlift
                double[,] WeightTab = new double[10, 4] {
                {lc2,421000,0,0 },
                {sc2,15625,0,0},
                {sw2,1,0,0 },
                {bht2,0,7200000,734694 },
                {sht2,0,1080000,110204 },
                {bat2,0,6480000,661224 },
                {sat2,0,648000,66122 },
                {bit2,0,4320000,88163 },
                {sit2,0,345600,7053 },
                {Drills,46875,0,0 } };               

                for (int i = 0; i < WeightTab.GetLength(0); i++)
                {
                    totsw = WeightTab[0, 0] * (WeightTab[0, 1] / ContainerItem) + WeightTab[1, 0] * (WeightTab[1, 1] / ContainerItem) + WeightTab[2, 0] + WeightTab[9, 0] * (WeightTab[9, 1] / ContainerItem);
                    totst += (WeightTab[i, 0] * WeightTab[i, 2]) / gravv;
                    maxlift += (WeightTab[i, 0] * WeightTab[i, 3]) / gravv;
                }
                
            }
            else if (gs2 == 2)
            {
                //den,sw,st,maxlift
                double[,] WeightTab2 = new double[10, 4] {
                {lc2,15625,0,0 },
                {sc2,125,0,0},
                {sw2,1,0,0 },
                {bht2,0,480000,48980 },
                {sht2,0,98400,10041 },
                {bat2,0,576000,58776 },
                {sat2,0,96000,9796 },
                {bit2,0,172800,3527 },
                {sit2,0,14400,294 },
                {Drills,6750,0,0 } };

                for (int i = 0; i < WeightTab2.GetLength(0); i++)
                {
                    totsw = WeightTab2[0, 0] * (WeightTab2[0, 1] / ContainerItem) + WeightTab2[1, 0] * (WeightTab2[1, 1] / ContainerItem) + WeightTab2[2,0] + WeightTab2[9, 0] * (WeightTab2[9, 1] / ContainerItem);
                    totst += (WeightTab2[i, 0] * WeightTab2[i, 2]) / gravv;
                    maxlift += (WeightTab2[i, 0] * WeightTab2[i, 3]) / gravv;
                }              

            }
            else
            {
                tbxSvar.Text = " WTF did you do wrong?";
                tbxSvar2.Text = " WTF did you do wrong?";
                tbxSvar3.Text = " WTF did you do wrong?";
                tbxSvar4.Text = " WTF did you do wrong?";
            }
            tbxSvar.Text = Math.Round(totsw,2).ToString() + " kg";
            double res = totsw / totst;
            tbxSvar2.Text = Math.Round(res,2).ToString();
            tbxSvar3.Text = Math.Round(maxlift, 2).ToString() + " kg";
            double liftcompare = maxlift / totsw;
            tbxSvar4.Text = Math.Round(liftcompare, 2).ToString();

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


        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nuValdItem = comboBox4.SelectedIndex;
            double[] föremåtListo = new double[]
            {0.75,0.37,0.15,5,0.25,2.5,(5/3),0.13,0.43,0.11,0.58,0.1,0.052,0.01,1.6,(1/3),1.52,0.5,(8 / (0.024)),1.2,8.75,(8 / (15))};
            ContainerItem = föremåtListo[nuValdItem];


            
        }

        public void comboBox2_Click(object sender, EventArgs e)
        {
            gs2 = comboBox2.SelectedIndex + 1;

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            GridSize1 = comboBox1.SelectedIndex + 1;
            
        }

        (double pcu, double steelplates, double largesteeltube, double smallsteeltube, double construction, double computer, double bulletproof, double interior, double motor, double metalgrid, double display, double powercell, double radio, double detector, double superconducter, double reactor, double thruster, double irontot, double nickeltot, double cobalttot, double silicontot, double silvertot, double graveltot, double goldtot, double platinatot, double powerproduction, double powerconsumption, double hydrogenproduction, double hydrogenconsumption) StorArray(double lcc, double mcc, double scc, double hab, double lab, double cock, double battery, double lhtank, double shtank, double gyro, double lhthrust, double shthrust, double ann, double beacon, double oredet, double drill, double spot, double airvent, double o2h2, double h2eng, double o2farm, double o2tank, double largeiont, double iont, double largeatmot, double atmot, double lreactor, double sractor)
        {
            double pcu = 0;
            double steelplates = 0;
            double largesteeltube = 0;
            double smallsteeltube = 0;
            double construction = 0;
            double computer = 0;
            double bulletproof = 0;
            double interior = 0;
            double motor = 0;
            double metalgrid = 0;
            double display = 0;
            double powercell = 0;
            double radio = 0;
            double detector = 0;
            double superconducter = 0;
            double reactor = 0;
            double thruster = 0;
            double irontot = 0;
            double nickeltot = 0;
            double cobalttot = 0;
            double silicontot = 0;
            double silvertot = 0;
            double graveltot = 0;
            double goldtot = 0;
            double platinatot = 0;
            double powerproduction = 0;
            double powerconsumption = 0;
            double hydrogenproduction = 0;
            double hydrogenconsumption = 0;

            if (GridSize4 == 1)
            {
                //PCU, Stell Plates, L Steel tube, S Stell tubes, constructiom, computer, bulletproof, interior, motor, metal grid, display, power cell, radio comp, detector comp, superconducter, reactor comp, thruster comp, iron, nickel, cobalt, silicon, silver, gravel, gold, platina, power pro, power con, hydro pro/storage, hydro con
                double[,] CostList = new double[28, 30] {
                    {lcc,10, 0,0,60,80,8,0,360,20,24,1,0,0,0,0,0,0,3053,220,72,6.6,0,0,0,0,0,0,0,0 },
                    {scc, 10,0,0,20,40,2,0,40,4,4,1,0,0,0,0,0,0,770,40,12,5.4,0,0,0,0,0,0,0,0 },
                    {hab,1,150,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3150,0,0,0,0,0,0,0,0,0,0,0 },
                    {lab,1,25,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,525,0,0,0,0,0,0,0,0,0,0,0 },
                    {cock,150,0,0,0,20,100,10,30,1,0,8,0,0,0,0,0,0,383,5,0,210,0,0,0,0,0,0,0,0 },
                    {battery,15,80,0,0,30,25,0,0,0,0,0,80,0,0,0,0,0,2792.5,160,0,85,0,0,0,0,0,0,0,0 },
                    {lhtank,25,280,80,60,40,8,0,0,0,0,0,0,0,0,0,0,0,8984,0,0,1.6,0,0,0,0,0,0.001,15000000,0 },
                    {shtank,25,80,40,60,40,8,0,0,0,0,0,0,0,0,0,0,0,3584,0,0,1.6,0,0,0,0,0,0.001,1000000,0 },
                    {gyro,50,600,4,0,40,5,0,0,4,50,0,0,0,0,0,0,0,13802.5,270,150,1,0,0,0,0,0,0.00003,0,0 },
                    {largeatmot,15,260,50,0,80,0,0,0,1100,40,0,0,0,0,0,0,0,30240,5700,120,0,0,0,0,0,0,16.36,0,0 },
                    {atmot,15,55,8,0,70,0,0,0,110,10,0,0,0,0,0,0,0,4415,600,30,0,0,0,0,0,0,2.36,0,0 },
                    {ann,100,80,40,60,40,8,0,0,0,0,0,0,40,0,0,0,0,3094,0,0,41.6,0,0,0,0,0,0.2,0,0 },
                    {lhthrust,15,150,40,0,180,0,0,0,0,250,0,0,0,0,0,0,0,9150,1250,750,0,0,0,0,0,0,0,0,4821.29 },
                    {shthrust,15,25,8,0,60,0,0,0,0,40,0,0,0,0,0,0,0,1845,200,120,0,0,0,0,0,0,0,0,803.55 },
                    {beacon,50,80,40,60,40,9,0,0,0,0,0,0,40,0,0,0,0,3904,0,0,41.6,0,0,0,0,0,0.01,0,0 },
                    {oredet,50,50,0,0,40,25,0,0,5,0,0,0,0,25,0,0,0,1687.5,400,0,5,0,0,0,0,0,0.002,0,0 },
                    {drill,190,300,12,0,40,5,0,0,5,0,0,0,0,0,0,0,0,7162.5,25,0,1,0,0,0,0,0,0.002,0,0 },
                    {spot,25,8,2,0,15,0,4,20,0,0,0,0,0,0,0,0,0,448,0,0,60,0,0,0,0,0,0.001,0,0 },
                    {airvent,10,45,0,0,20,5,0,0,10,0,0,0,0,0,0,0,0,1347.5,50,0,1,0,0,0,0,0,0,0,0},
                    {o2h2,50,120,2,0,5,5,0,0,4,0,0,0,0,0,0,0,0,2712.5,20,0,1,0,0,0,0,0,0.33,100000,0 },
                    {h2eng,25,100,12,20,70,4,0,0,12,0,0,1,0,0,0,0,0,3512,62,0,1.8,0,0,0,0,5,0,0,500 },
                    {o2farm,25,40,20,10,20,20,100,0,0,0,0,0,0,0,0,0,0,1700,0,0,1504,0,0,0,0,0,0.001,0,0 },
                    {o2tank,25,80,40,60,40,8,0,0,0,0,0,0,0,0,0,0,0,3584,0,0,1.6,0,0,0,0,0,0.001,0,0},
                    {lreactor,25,1000,40,0,70,75,0,0,20,40,0,0,0,0,100,2000,0,54817.5,300,120,15,40000,10000,200,0,300,0,0,0 },
                    {sractor,25,80,8,0,40,25,0,0,6,4,0,0,0,0,0,100,0,4000.5,50,12,5,2000,500,0,0,15,0,0,0 },
                    {largeiont,15,150,100,0,100,0,0,0,0,0,0,0,0,0,0,0,960,25950,0,9600,0,0,0,960,384,0,33.6,0,0 },
                    {iont,15,25,8,0,60,0,0,0,0,0,0,0,0,0,0,0,80,3765,0,800,0,0,0,80,32,0,3.36,0,0 },
                    {mcc,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 } };


                for (int i = 0; i < CostList.GetLength(0); i++)
                {
                    pcu += CostList[i, 0] * CostList[i, 1];
                    steelplates += CostList[i, 0] * CostList[i, 2];
                    largesteeltube += CostList[i, 0] * CostList[i, 3];
                    smallsteeltube += CostList[i, 0] * CostList[i, 4];
                    construction += CostList[i, 0] * CostList[i, 5];
                    computer += CostList[i, 0] * CostList[i, 6];
                    bulletproof += CostList[i, 0] * CostList[i, 7];
                    interior += CostList[i, 0] * CostList[i, 8];
                    motor += CostList[i, 0] * CostList[i, 9];
                    metalgrid += CostList[i, 0] * CostList[i, 10];
                    display += CostList[i, 0] * CostList[i, 11];
                    powercell += CostList[i, 0] * CostList[i, 12];
                    radio += CostList[i, 0] * CostList[i, 13];
                    detector += CostList[i, 0] * CostList[i, 14];
                    superconducter += CostList[i, 0] * CostList[i, 15];
                    reactor += CostList[i, 0] * CostList[i, 16];
                    thruster += CostList[i, 0] * CostList[i, 17];
                    irontot += CostList[i, 0] * CostList[i, 18];
                    nickeltot += CostList[i, 0] * CostList[i, 19];
                    cobalttot += CostList[i, 0] * CostList[i, 20];
                    silicontot += CostList[i, 0] * CostList[i, 21];
                    silvertot += CostList[i, 0] * CostList[i, 22];
                    graveltot += CostList[i, 0] * CostList[i, 23];
                    goldtot += CostList[i, 0] * CostList[i, 24];
                    platinatot += CostList[i, 0] * CostList[i, 25];
                    powerproduction += CostList[i, 0] * CostList[i, 26];
                    powerconsumption += CostList[i, 0] * CostList[i, 27];
                    hydrogenproduction += CostList[i, 0] * CostList[i, 28];
                    hydrogenconsumption += CostList[i, 0] * CostList[i, 29];

                }


            }
            else 
            {
                //PCU, Stell Plates, L Steel tube, S Stell tubes, constructiom, computer, bulletproof, interior, motor, metal grid, display, power cell, radio comp, detector comp, superconducter, reactor comp, thruster comp, iron, nickel, cobalt, silicon, silver, gravel, gold, platina, power pro, power con, hydro pro/storage, hydro con
                double[,] CostList2 = new double[28, 30] {
                    {lcc,10,0,0,0,25,6,0,75,8,0,1,0,0,0,0,0,0,676.5,40,0,6.2,0,0,0,0,0,0,0,0 },
                    {mcc,10,0,0,0,10,4,0,30,4,0,1,0,0,0,0,0,0,288,20,0,5.8,0,0,0,0,0,0,0,0 },
                    {scc,10,0,0,2,1,1,0,3,2,0,1,0,0,0,0,0,0,72,10,0,5.2,0,0,0,0,0,0,0,0 },
                    {hab,1,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,105,0,0,0,0,0,0,0,0,0,0,0 },
                    {scc,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,21,0,0,0,0,0,0,0,0,0,0,0 },
                    {cock,150,0,0,0,10,15,30,10,1,0,5,0,0,0,0,0,0,167.5,5,0,478,0,0,0,0,0,0,0,0},
                    {battery,15,25,0,0,5,2,0,0,0,0,0,20,0,0,0,0,0,776,40,0,20.4,0,0,0,0,0,0,0,0 },
                    {lhtank,25,80,40,60,40,8,0,0,0,0,0,0,0,0,0,0,0,3584,0,0,1.6,0,0,0,0,0,0.001,0,0 },
                    {shtank,25,3,1,2,4,2,0,0,0,0,0,0,0,0,0,0,0,144,0,0,0.4,0,0,0,0,0,0,0,0 },
                    {gyro,50,25,1,0,5,3,0,0,2,0,0,0,0,0,0,0,0,646.5,10,0,0.6,0,0,0,0,0,0.000001,0,0},
                    {largeatmot,15,20,4,0,30,0,0,0,90,8,0,0,0,0,0,0,0,2736,490,24,0,0,0,0,0,0,2.4,0,0 },
                    {atmot,15,3,1,0,22,0,0,0,18,1,0,0,0,0,0,0,0,685,95,3,0,0,0,0,0,0,0.701,0,0 },
                    {ann,100,1,0,1,2,1,0,0,0,0,0,0,4,0,0,0,0,78.5,0,0,4.2,0,0,0,0,0,0.02,0,0 },
                    {lhthrust,15,30,10,0,30,0,0,0,0,22,0,0,0,0,0,0,0,1494,110,66,0,0,0,0,0,0,0,0,0 },
                    {shthrust,15,7,2,0,15,0,0,0,0,4,0,0,0,0,0,0,0,405,20,12,0,0,0,0,0,0,0,0,0 },
                    {beacon,100,2,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,57.5,0,0,0.2,0,0,0,0,0,0.01,0,0 },
                    {oredet,50,3,0,0,2,1,0,0,1,0,0,0,0,1,0,0,0,108.5,20,0,0.2,0,0,0,0,0,0.002,0,0 },
                    {drill,190,32,4,8,8,1,0,0,1,0,0,0,0,0,0,0,0,932.5,5,0,0.2,0,0,0,0,0,0.002,0,0 },
                    {spot,10,1,1,0,1,0,2,1,0,0,0,0,0,0,0,0,0,64.5,0,0,30,0,0,0,0,0,0.0002,0,0 },
                    {airvent,25,8,0,0,10,15,0,0,2,0,0,0,0,0,0,0,0,315.5,10,0,3,0,0,0,0,0,0,0,0 },
                    {o2h2,50,8,2,0,8,3,0,0,1,0,0,0,0,0,0,0,0,329.5,5,0,0.6,0,0,0,0,0,0,0,0 },
                    {h2eng,25,30,4,6,20,1,0,0,1,0,0,1,0,0,0,0,0,1010.5,7,0,1.2,0,0,0,0,0.5,0,0,0 },
                    {o2farm,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                    {o2tank,25,16,8,10,10,8,0,0,0,0,0,0,0,0,0,0,0,730,0,0,1.6,0,0,0,0,0,0.001,0,0 },
                    {lreactor,25,60,3,0,9,25,0,0,5,9,0,0,0,0,0,50,0,1660.5,70,27,5,250,1000,100,0,10.5,0,0,0 },
                    {sractor,25,2,1,0,1,10,0,0,1,1,0,0,0,0,0,1,0,119,10,3,2,5,20,2,0,0.5,0,0,0 },
                    {largeiont,15,5,5,0,2,0,0,0,0,0,0,0,0,0,0,0,12,275,0,0,0,0,0,12,4.8,0,2.4,0,0 },
                    {iont,15,2,1,0,1,0,0,0,0,0,0,0,0,0,0,0,1,82,0,0,0,0,0,1,0.4,0,0.201,0,0 } };

                for (int i = 0; i < CostList2.GetLength(0); i++)
                {
                    pcu += CostList2[i, 0] * CostList2[i, 1];
                    steelplates += CostList2[i, 0] * CostList2[i, 2];
                    largesteeltube += CostList2[i, 0] * CostList2[i, 3];
                    smallsteeltube += CostList2[i, 0] * CostList2[i, 4];
                    construction += CostList2[i, 0] * CostList2[i, 5];
                    computer += CostList2[i, 0] * CostList2[i, 6];
                    bulletproof += CostList2[i, 0] * CostList2[i, 7];
                    interior += CostList2[i, 0] * CostList2[i, 8];
                    motor += CostList2[i, 0] * CostList2[i, 9];
                    metalgrid += CostList2[i, 0] * CostList2[i, 10];
                    display += CostList2[i, 0] * CostList2[i, 11];
                    powercell += CostList2[i, 0] * CostList2[i, 12];
                    radio += CostList2[i, 0] * CostList2[i, 13];
                    detector += CostList2[i, 0] * CostList2[i, 14];
                    superconducter += CostList2[i, 0] * CostList2[i, 15];
                    reactor += CostList2[i, 0] * CostList2[i, 16];
                    thruster += CostList2[i, 0] * CostList2[i, 17];
                    irontot += CostList2[i, 0] * CostList2[i, 18];
                    nickeltot += CostList2[i, 0] * CostList2[i, 19];
                    cobalttot += CostList2[i, 0] * CostList2[i, 20];
                    silicontot += CostList2[i, 0] * CostList2[i, 21];
                    silvertot += CostList2[i, 0] * CostList2[i, 22];
                    graveltot += CostList2[i, 0] * CostList2[i, 23];
                    goldtot += CostList2[i, 0] * CostList2[i, 24];
                    platinatot += CostList2[i, 0] * CostList2[i, 25];
                    powerproduction += CostList2[i, 0] * CostList2[i, 26];
                    powerconsumption += CostList2[i, 0] * CostList2[i, 27];
                    hydrogenproduction += CostList2[i, 0] * CostList2[i, 28];
                    hydrogenconsumption += CostList2[i, 0] * CostList2[i, 29];

                }

                
            }

            return (pcu, steelplates, largesteeltube, smallsteeltube, construction, computer, bulletproof, interior, motor, metalgrid, display, powercell, radio, detector, superconducter, reactor, thruster, irontot, nickeltot, cobalttot, silicontot, silvertot, graveltot, goldtot, platinatot, powerproduction, powerconsumption, hydrogenproduction, hydrogenconsumption);


        }

        private void btnResource_Click(object sender, EventArgs e)
        {
            GridSize4 = (cbxGridSize.SelectedIndex) + 1;
            double lcc = int.Parse(tbxLargeCargo.Text);
            double mcc = int.Parse(tbxMediumCargo.Text);
            double scc = int.Parse(tbxSmallCargo.Text);
            double hab = int.Parse(tbxHeavyArmorBlock.Text);
            double lab = int.Parse(tbxLightArmorBlock.Text);
            double cock = int.Parse(tbxCockpit.Text);
            double battery = int.Parse(tbxBattery.Text);
            double lhtank = int.Parse(tbxLargeHydroTank.Text);
            double shtank = int.Parse(tbxSmallHydroTank.Text);
            double gyro = int.Parse(tbxGyroscope.Text);
            double lhthrust = int.Parse(tbxLargeHydroThruster.Text);
            double shthrust = int.Parse(tbxHydroThruster.Text);
            double ann = int.Parse(tbxAntenna.Text);
            double beacon = int.Parse(tbxBeacon.Text);
            double oredet = int.Parse(tbxOreDetector.Text);
            double drill = int.Parse(tbxDrill.Text);
            double spot = int.Parse(tbxSpotlight.Text);
            double airvent = int.Parse(tbxAirVent.Text);
            double o2h2 = int.Parse(tbxO2H2gen.Text);
            double h2eng = int.Parse(tbxHydroEngine.Text);
            double o2farm = int.Parse(tbxOxygenFarm.Text);
            double o2tank = int.Parse(tbxOxygenTank.Text);
            double largeiont = int.Parse(tbxLargeIonThruster.Text);
            double iont = int.Parse(tbxIonThruster.Text);
            double largeatmot = int.Parse(tbxLargeAtmosphericThruster.Text);
            double atmot = int.Parse(tbxAtmosphericThruster.Text);
            double lreactor = int.Parse(tbxLReactor.Text);
            double sractor = int.Parse(tbxSReactor.Text);



            (double pcu, double steelplates, double largesteeltube, double smallsteeltube, double construction, double computer, double bulletproof, double interior, double motor, double metalgrid, double display, double powercell, double radio, double detector, double superconducter, double reactor, double thruster, double irontot, double nickeltot, double cobalttot, double silicontot, double silvertot, double graveltot, double goldtot, double platinatot, double powerproduction, double powerconsumption, double hydrogenproduction, double hydrogenconsumption) arrayres = StorArray(lcc, mcc, scc, hab, lab, cock, battery, lhtank, shtank, gyro, lhthrust, shthrust, ann, beacon, oredet, drill, spot, airvent, o2h2, h2eng, o2farm, o2tank, largeiont, iont, largeatmot, atmot, lreactor, sractor); 


            tbxSteelPlate.Text = arrayres.steelplates.ToString();
            tbxIronTot.Text = arrayres.irontot.ToString();
            tbxNickelTot.Text = arrayres.nickeltot.ToString();
            tbxCobaltTot.Text = arrayres.cobalttot.ToString();
            tbxSiliconTot.Text = arrayres.silicontot.ToString();
            tbxTotalSilverCost.Text = arrayres.silvertot.ToString();
            tbxTotalGravelCost.Text = arrayres.graveltot.ToString();
            tbxTotalGoldCost.Text = arrayres.goldtot.ToString();
            tbxTotalPlatinaCost.Text = arrayres.platinatot.ToString();
            tbxConstructionComponent.Text = arrayres.construction.ToString();
            tbxMetalGrid.Text = arrayres.metalgrid.ToString();
            tbxMotor.Text = arrayres.motor.ToString();
            tbxComputer.Text = arrayres.computer.ToString();
            tbxLargeSteelTube.Text = arrayres.largesteeltube.ToString();
            tbxDetectorComponent.Text = arrayres.detector.ToString();
            tbxRadioComponent.Text = arrayres.radio.ToString();
            tbxPowerCell.Text = arrayres.powercell.ToString();
            tbxDisplay.Text = arrayres.display.ToString();
            tbxInteriorPlate.Text = arrayres.interior.ToString();
            tbxBulletproofGlass.Text = arrayres.bulletproof.ToString();
            tbxSmallSteelTube.Text = arrayres.smallsteeltube.ToString();
            tbxSuperConducter.Text = arrayres.superconducter.ToString();
            tbxReactorComponent.Text = arrayres.reactor.ToString();
            tbxThrusterComponent.Text = arrayres.thruster.ToString();
            tbxPCUCost.Text = arrayres.pcu.ToString();

            tbxPowerProduction.Text = arrayres.powerproduction.ToString() + " MW";
            tbxPowerConsumption.Text = Math.Round(arrayres.powerconsumption, 2).ToString() + " MW";

            if (arrayres.powerproduction < arrayres.powerconsumption)
            {
                double power = arrayres.powerconsumption - arrayres.powerproduction;
                double batterylife = battery * 3;
                double powerlife = batterylife / power;
                tbxTotalPowerUsage.Text = Math.Round(powerlife, 2).ToString() + " h";



            }
            else
            {
                tbxTotalPowerUsage.Text = " Infinity";
            }


            double hydrogentime = arrayres.hydrogenproduction / arrayres.hydrogenconsumption;

            if (hydrogentime >= 300)
            {
                tbxHydrogenTime.Text = Math.Round((hydrogentime / 60), 2).ToString() + " minuts";
            }
            else
            {
                tbxHydrogenTime.Text = Math.Round(hydrogentime, 2).ToString() + " s";
            }

            tbxHydrogenCapacity.Text = arrayres.hydrogenproduction.ToString() + " L";
            tbxHydrogenUse.Text = arrayres.hydrogenconsumption.ToString() + " L/s";



        }

        private void cbxGridSize_Click(object sender, EventArgs e)
        {
            GridSize4 = (cbxGridSize.SelectedIndex) + 1;
            
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {

            double PCU2 = 1;
            double massa = 1;
            antHoll = 1;

         
                if (double.TryParse(tbxPCU2.Text, out PCU2))
                    PCU2 = double.Parse(tbxPCU2.Text);
           
                if (double.TryParse(tbxTheMass.Text, out massa))
                    massa = double.Parse(tbxTheMass.Text);
            if(int.TryParse(tbxAxlar.Text,out antHoll))
            {
                antHoll = int.Parse(tbxAxlar.Text);
            }
            

            double GBlock = PCU2 / (185 * antHoll + 185);
            double MassaB = GBlock * 7.4;
            double Kraft = 495000 * GBlock * MassaB;
            lblMassBlockSvar.Text = Math.Round(MassaB, 2).ToString();
            lblGGeneratorSvar.Text = Math.Round(GBlock, 2).ToString()+" * " + antHoll.ToString()+" Axlar";
            lblForceSvar.Text = Math.Round(Kraft, 2).ToString();
            massa += GBlock * 8532 + MassaB * 9544;
            double Speed = 100 / (Kraft / massa);
            lblSpeedTo100Svar.Text = Math.Round(Speed,2).ToString();
            lblReactorMassBlock.Text = MassaB.ToString();
            lblGravityDrivers.Text = GBlock.ToString();
            tbxAxeleration.Text = (Kraft/massa).ToString();



        }

        private void btnSolve2_Click(object sender, EventArgs e)
        {
            double Massa = double.Parse(tbxSpaceMass.Text);
            double TidH = double.Parse(tbxSpaceTime.Text);
            double GMengd = double.Parse(tbxSpaceG.Text);
            double antall = Massa / (1964 * GMengd * TidH - 7144);
            lblSpaceBallsSvar.Text = Math.Round(antall, 1).ToString();
                           
          
        }

        private void btnSolve3_Click(object sender, EventArgs e)
        {
            double MassaC = double.Parse(tbxReaxtorMassBlock.Text);
            double Gravitation = double.Parse(tbxGravityDrivers.Text);
            double Rail = double.Parse(tbxRailgun.Text);
            double Gyro = double.Parse(tbxGyro.Text);
            MassaC += 567.13;
            Gravitation *= 600 * antHoll;
            Rail *= 38000;
            Gyro *= 10;
            lblSpaceMassSvar.Text = Math.Round(MassaC, 1).ToString() + " kw";
            lblSpaceGravitySvar.Text = Math.Round(Gravitation, 1).ToString() + " kw";
            lblSpaceRailgunSvar.Text = Math.Round(Rail, 1).ToString() + " kw";
            lbl0kW.Text = Math.Round(Gyro, 1).ToString() + " kw";
            double Resultat = MassaC + Gravitation + Rail + Gyro;
            lblSpaceSvar1.Text = Resultat.ToString();
            lblSpaceSvar2.Text = Math.Round((Resultat / 300000), 2).ToString();
            lblSpaceSvar3.Text = Math.Round((Resultat / 15000), 2).ToString();

        }

        private void btnSolve4_Click(object sender, EventArgs e)
        {
            double axeleration = double.Parse(tbxAxeleration.Text);
            double diameter = double.Parse(tbxDiameter.Text);
            double projektiv = double.Parse(tbxProjektivSpeed.Text);
            diameter *= 2.5;
            lblMinimalDodgeSvar.Text = ((Math.Round(diameter/axeleration)) * projektiv).ToString();

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridSize3 = comboBox5.SelectedIndex + 1;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            double[] planeterGravitation = new double[]
           {1,0.25,0.9,0.25,0.25,1.1 };
            gravv2 = planeterGravitation[comboBox5.SelectedIndex];
        }
    }
}
