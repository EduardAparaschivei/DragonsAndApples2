using DataStorageLevel;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfataUtilizator_WindowsForms
{
    public partial class MainGame : Form
    {
        PlayerDataStorage_FisierText adminPlayers;
        DragonsDataStorage_FisierText adminDragoni;

        Random random = new Random();

        static string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
        static string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

        static string numeFisier2 = ConfigurationManager.AppSettings["NumeFisier2"];
        string caleCompletaFisier2 = locatieFisierSolutie + "\\" + numeFisier2;

        public Player player;
        public string linieFisier;
        public Dragon DragonGlobal;
        public int pass;

        #region Panel,Labels,TextBoxes,Buttons
        private Panel LinieDesign;

        private Label lblNume;
        private Label lblNumeAfisare;

        private Label lblStrenght;
        private Button PlusStr;
        private Label lblIntelicenge;
        private Button PlusInte;
        private Label lblAgility;
        private Button PlusAgility;

        private Label lblAbilityPoints;
        private Label NoPoints;

        private Label lblHP;
        private Label lblScor;
        private Label lblXP;
        private Label lblLevel;
        private Label lblBani;
        private Label lblStagiu;

        private Button MainMenu;
        private Button SaveGame;

        private Button btnExplore;
        private Button btnFight;
        private Button btnAttack;
        private Button btnFlee;
        #endregion

        private Label lblNumeDragon;
        private Label lblDificultateDragon;
        private Label lblLootDragon;
        private Label lblHPDragon;

        private Label Informatii;

        private const int latime_control = 100;
        private const int inaltime_control = 50;
        private const int dimensiune_pas_x = 140;
        private const int dimensiune_pas_y = 30;
        public MainGame()
        {
            InitializeComponent();
            adminPlayers = new PlayerDataStorage_FisierText(caleCompletaFisier);
            int nrPlayers = 0;
            Player[] players = adminPlayers.GetPlayers(out nrPlayers);
            using(StreamReader sr = new StreamReader(caleCompletaFisier))
            {
                linieFisier = sr.ReadLine();
            }
            player = new Player(linieFisier);

            adminDragoni = new DragonsDataStorage_FisierText(caleCompletaFisier2);
            int nrDragoni = 0;
            Dragon[] dragoni = adminDragoni.GetDragons(out nrDragoni);
            DragonGlobal = new Dragon();


            //setare proprietati
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.Location = new Point(0,0);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.LimeGreen;
            this.Text = "Dragons and Apples 2";

            #region linii design
            LinieDesign = new Panel();
            LinieDesign.BackColor = Color.Red;
            LinieDesign.Size = new Size(5, this.ClientSize.Height);
            LinieDesign.Location = new Point(100, 0);
            this.Controls.Add(LinieDesign);

            LinieDesign = new Panel();
            LinieDesign.BackColor = Color.Red;
            LinieDesign.Size = new Size(this.ClientSize.Width, 5);
            LinieDesign.Location = new Point(0, 85);
            this.Controls.Add(LinieDesign);

            LinieDesign = new Panel();
            LinieDesign.BackColor = Color.Red;
            LinieDesign.Size = new Size(this.ClientSize.Width, 5);
            LinieDesign.Location = new Point(0,this.ClientSize.Height-100);
            this.Controls.Add(LinieDesign);

            
            #endregion

            #region BLoc Nume + HP
            lblNume = new Label();
            lblNume.Width = latime_control;
            lblNume.Text = "Nume";
            lblNume.Left = dimensiune_pas_x;
            lblNume.ForeColor = Color.Black;
            lblNume.BackColor = Color.White;
            this.Controls.Add(lblNume);

            lblNumeAfisare = new Label();
            lblNumeAfisare.Width = latime_control;
            lblNumeAfisare.Text = player.Name;
            lblNumeAfisare.Left = dimensiune_pas_x;
            lblNumeAfisare.Top = dimensiune_pas_y;
            lblNumeAfisare.ForeColor = Color.Black;
            this.Controls.Add(lblNumeAfisare);

            lblHP = new Label();
            lblHP.Width = latime_control;
            lblHP.Text = "HP: " + player.HealthPoints;
            lblHP.Left = dimensiune_pas_x;
            lblHP.Top = 2 * dimensiune_pas_y;
            lblHP.ForeColor = Color.Black;
            this.Controls.Add(lblHP);

            #endregion

            #region Bloc Puncte
            lblAbilityPoints = new Label();
            lblAbilityPoints.Width = latime_control + 10;
            lblAbilityPoints.Text = "Puncte Abilitati: " + player.AbilityPoints;
            lblAbilityPoints.Left = 2 * dimensiune_pas_x + 30;
            lblAbilityPoints.ForeColor = Color.Black;
            this.Controls.Add(lblAbilityPoints);

            #endregion

            #region Bloc Abilitati
            //Label Putere+Buton
            lblStrenght = new Label();
            lblStrenght.Width = latime_control - 30;
            lblStrenght.Text = "Putere: " + player.Strength;
            lblStrenght.Left = 2 * dimensiune_pas_x + 30;
            lblStrenght.Top = dimensiune_pas_y;
            lblStrenght.ForeColor = Color.Black;
            this.Controls.Add(lblStrenght);

            PlusStr = new Button();
            PlusStr.Width = 20;
            PlusStr.Location = new System.Drawing.Point(3 * dimensiune_pas_x - 20, dimensiune_pas_y);
            PlusStr.Text = "+";
            PlusStr.Click += PlusStrenght;
            PlusStr.Visible = false;
            this.Controls.Add(PlusStr);

            //Label Inteligenta+Buton
            lblIntelicenge = new Label();
            lblIntelicenge.Width = latime_control - 10;
            lblIntelicenge.Text = "Inteligenta: " + player.Intelligence;
            lblIntelicenge.Left = 3 * dimensiune_pas_x;
            lblIntelicenge.Top = dimensiune_pas_y;
            lblIntelicenge.ForeColor = Color.Black;
            this.Controls.Add(lblIntelicenge);

            PlusInte = new Button();
            PlusInte.Width = 20;
            PlusInte.Location = new System.Drawing.Point(4 * dimensiune_pas_x - 30, dimensiune_pas_y);
            PlusInte.Text = "+";
            PlusInte.Click += PlusInteligence;
            PlusInte.Visible = false;
            this.Controls.Add(PlusInte);

            //Label Agilitate+Buton
            lblAgility = new Label();
            lblAgility.Width = latime_control - 20;
            lblAgility.Text = "Agilitate: " + player.Agility;
            lblAgility.Left = 4 * dimensiune_pas_x;
            lblAgility.Top = dimensiune_pas_y;
            lblAgility.ForeColor = Color.Black;
            this.Controls.Add(lblAgility);

            PlusAgility = new Button();
            PlusAgility.Width = 20;
            PlusAgility.Location = new System.Drawing.Point(5 * dimensiune_pas_x - 30, dimensiune_pas_y);
            PlusAgility.Text = "+";
            PlusAgility.Click += PlusAgilitate;
            PlusAgility.Visible = false;
            this.Controls.Add(PlusAgility);
            #endregion

            #region Label XP si level
            lblXP = new Label();
            lblXP.Width = latime_control;
            lblXP.Text = "XP: " + player.xp;
            lblXP.Left = 5 * dimensiune_pas_x;
            lblXP.ForeColor = Color.Black;
            this.Controls.Add(lblXP);

            lblLevel = new Label();
            lblLevel.Width = latime_control;
            lblLevel.Text = "Level: " + player.Level;
            lblLevel.Left = 5 * dimensiune_pas_x;
            lblLevel.Top = dimensiune_pas_y;
            lblLevel.ForeColor = Color.Black;
            this.Controls.Add(lblLevel);
            #endregion

            #region Label Bani si scor
            lblBani = new Label();
            lblBani.Width = latime_control;
            lblBani.Text = "Bani: " + player.Money;
            lblBani.Left = 6 * dimensiune_pas_x;
            lblBani.ForeColor = Color.Black;
            this.Controls.Add(lblBani);

            lblScor = new Label();
            lblScor.Width = latime_control;
            lblScor.Text = "Scor: " + player.scor;
            lblScor.Left = 6 * dimensiune_pas_x;
            lblScor.Top = dimensiune_pas_y;
            lblScor.ForeColor = Color.Black;
            this.Controls.Add(lblScor);
            #endregion

            #region Label Stagiu Joc
            lblStagiu = new Label();
            lblStagiu.Width = latime_control;
            lblStagiu.Text = "Stagiu Joc: " + player.stage;
            lblStagiu.Left = 7 * dimensiune_pas_x;
            lblStagiu.ForeColor = Color.Black;
            this.Controls.Add(lblStagiu);
            #endregion

            #region Dragon
            lblNumeDragon = new Label();
            lblNumeDragon.Text = DragonGlobal.Name;
            lblNumeDragon.Width = latime_control;
            lblNumeDragon.ForeColor = Color.Red;
            lblNumeDragon.Left = dimensiune_pas_x;
            lblNumeDragon.Top = 4*dimensiune_pas_y;
            lblNumeDragon.Visible = false;
            this.Controls.Add(lblNumeDragon);

            lblDificultateDragon = new Label();
            lblDificultateDragon.Text =""+ DragonGlobal.Difficulty;
            lblDificultateDragon.Width = latime_control;
            lblDificultateDragon.ForeColor = Color.Red;
            lblDificultateDragon.Left = 2*dimensiune_pas_x;
            lblDificultateDragon.Top = 4 * dimensiune_pas_y;
            lblDificultateDragon.Visible = false;
            this.Controls.Add(lblDificultateDragon);

            lblLootDragon = new Label();
            lblLootDragon.Text = ""+ DragonGlobal.Loot;
            lblLootDragon.Width = latime_control;
            lblLootDragon.ForeColor = Color.Red;
            lblLootDragon.Left = 3*dimensiune_pas_x;
            lblLootDragon.Top = 4 * dimensiune_pas_y;
            lblLootDragon.Visible = false;
            this.Controls.Add(lblLootDragon);

            lblHPDragon = new Label();
            lblHPDragon.Text =""+ DragonGlobal.HealthPoints;
            lblHPDragon.Width = latime_control;
            lblHPDragon.ForeColor = Color.Red;
            lblHPDragon.Left = 4*dimensiune_pas_x;
            lblHPDragon.Top = 4 * dimensiune_pas_y;
            lblHPDragon.Visible = false;
            this.Controls.Add(lblHPDragon);

            #endregion

            #region Informatii
            Informatii = new Label();
            Informatii.Left = dimensiune_pas_x * 7;
            Informatii.Top = dimensiune_pas_y;
            Informatii.ForeColor = Color.Purple;
            Informatii.Text = "Informatii";
            Informatii.Width = latime_control * 3;
            this.Controls.Add(Informatii);

            #endregion

            #region Butoane Interactiuni Tip Explorare
            btnExplore = new Button();
            btnExplore.Width = latime_control;
            btnExplore.Height = latime_control/2;
            btnExplore.Text = "Exploreaza";
            btnExplore.ForeColor = Color.OrangeRed;
            btnExplore.Location = new System.Drawing.Point(dimensiune_pas_x, this.ClientSize.Height - 3*dimensiune_pas_y);
            btnExplore.Click += Explorare;
            this.Controls.Add(btnExplore);
           

           
            btnFight = new Button();
            btnFight.Width = latime_control;
            btnFight.Height = latime_control / 2;
            btnFight.Text = "Lupta!";
            btnFight.ForeColor = Color.OrangeRed;
            btnFight.Location = new System.Drawing.Point(dimensiune_pas_x *2, this.ClientSize.Height - 3 * dimensiune_pas_y);
            btnFight.Visible = false;
            btnFight.Click += Lupta;
            this.Controls.Add(btnFight);
            #endregion

            #region Butoane Tip Lupta
            btnAttack = new Button();
            btnAttack.Width = latime_control;
            btnAttack.Height = latime_control / 2;
            btnAttack.Text = "Ataca!";
            btnAttack.ForeColor = Color.OrangeRed;
            btnAttack.Location = new System.Drawing.Point(dimensiune_pas_x, this.ClientSize.Height - 3 * dimensiune_pas_y);
            btnAttack.Visible = false;
            btnAttack.Click += Ataca;
            this.Controls.Add(btnAttack);

            btnFlee = new Button();
            btnFlee.Width = latime_control;
            btnFlee.Height = latime_control / 2;
            btnFlee.Text = "FUGI!";
            btnFlee.ForeColor = Color.OrangeRed;
            btnFlee.Location = new System.Drawing.Point(dimensiune_pas_x * 2, this.ClientSize.Height - 3 * dimensiune_pas_y);
            btnFlee.Visible = false;
            this.Controls.Add(btnFlee);
            #endregion

            #region Butoane Menu si Savegame
            //MainMenu
            MainMenu = new Button();
            MainMenu.Width = latime_control;
            MainMenu.Location = new System.Drawing.Point(0, dimensiune_pas_y);
            MainMenu.Text = "Meniu Principal";
            MainMenu.Click += MeniuPrincipal;
            this.Controls.Add(MainMenu);
            //SaveGame
            SaveGame = new Button();
            SaveGame.Width = latime_control;
            SaveGame.Location = new System.Drawing.Point(0, 0);
            SaveGame.Text = "Salvare Joc";
            SaveGame.Click += SalvareJoc;
            this.Controls.Add(SaveGame);
            #endregion

            #region Fundaluri

            LinieDesign = new Panel();
            LinieDesign.BackColor = Color.IndianRed;
            LinieDesign.Size = new Size(this.Width, inaltime_control*2-15);
            this.Controls.Add(LinieDesign);

            LinieDesign = new Panel();
            LinieDesign.BackColor = Color.IndianRed;
            LinieDesign.Size = new Size(this.Width,inaltime_control*2);
            LinieDesign.Top = this.Height-(inaltime_control*2+40);
            this.Controls.Add(LinieDesign);
            #endregion
        }

        #region Plus Abilitati
        private void PlusStrenght(object sender, EventArgs e)
        {
            if (player.AbilityPoints > 0)
            {
                player.Strength++;
                player.AbilityPoints--;
                lblStrenght.Text = "Putere: " + player.Strength;
                lblAbilityPoints.Text = "Puncte Abilitati: " + player.AbilityPoints;
            }
           
            if(player.AbilityPoints == 0)
            {
                PlusStr.Visible = false;
                PlusInte.Visible = false;
                PlusAgility.Visible = false;
            }

        }

        private void PlusInteligence(object sender, EventArgs e)
        {
            if (player.AbilityPoints > 0)
            {
                player.Intelligence++;
                player.AbilityPoints--;
                lblIntelicenge.Text = "Inteligenta: " + player.Intelligence;
                lblAbilityPoints.Text = "Puncte Abilitati: " + player.AbilityPoints;
            }
            if (player.AbilityPoints == 0)
            {
                PlusStr.Visible = false;
                PlusInte.Visible = false;
                PlusAgility.Visible = false;
            }

        }

        private void PlusAgilitate(object sender, EventArgs e)
        {
            if (player.AbilityPoints > 0)
            {
                player.Agility++;
                player.AbilityPoints--;
                lblAgility.Text = "Agilitate: " + player.Agility;
                lblAbilityPoints.Text = "Puncte Abilitati: " + player.AbilityPoints;
            }
            if (player.AbilityPoints == 0)
            {
                PlusStr.Visible = false;
                PlusInte.Visible = false;
                PlusAgility.Visible = false;
            }

        }

        #endregion

        #region Metode pentru functionalitate
        private void MeniuPrincipal(object sender, EventArgs e)
        {
            var MenuForm = new MainMenu();
            MenuForm.Show();
            this.Hide();
        }

        private void SalvareJoc(object sender, EventArgs e)
        {
            File.WriteAllText(caleCompletaFisier, string.Empty);
            adminPlayers.AddPlayer(player);
            Informatii.Text = "Proges Salvat!";
        }
        #endregion

        #region Metode de tip Explorare
        private void Explorare(object sender, EventArgs e)
        {
            btnFight.Visible = false;
            int randomNumber = random.Next(1, 11);
            if(randomNumber <= 5)
            {
                Informatii.Text = "Dragon gasit!";
                btnFight.Visible = true;
            }else
            {
                Informatii.Text = "Nu s-a gasit nimic!";
            }
        }

        private void Lupta(object sender, EventArgs e)
        {
            btnFight.Visible = false;
            btnExplore.Visible = false;

            btnAttack.Visible = true;
            btnFlee.Visible = true;

            SaveGame.Visible = false;

            PickDragon(player.stage);
        }
        

        private void PickDragon(int stagiu)
        {
            Dragon dragon = new Dragon();
            using (StreamReader reader = new StreamReader(caleCompletaFisier2))
            {
                string linie;
                do
                {
                    linie = reader.ReadLine();
                    dragon = new Dragon(linie);

                } while (dragon.IdDragon != stagiu);

            }
            DragonGlobal = dragon;
            lblNumeDragon.Text = DragonGlobal.Name;
            lblNumeDragon.Visible = true;
            lblDificultateDragon.Text = "" + DragonGlobal.Difficulty;
            lblDificultateDragon.Visible = true;
            lblLootDragon.Text = "" + DragonGlobal.Loot;
            lblLootDragon.Visible = true;
            lblHPDragon.Text = "" + DragonGlobal.HealthPoints;
            lblHPDragon.Visible = true;
            
            
        }
        #endregion

        #region Metode tip lupta
        private void Ataca(object sender, EventArgs e) 
        {
            Informatii.Text = "Ai atacat!";
            int randomnumber = random.Next(1, 11);
            DragonGlobal.HealthPoints -= 10 + player.Strength * 2;
            if (randomnumber > player.Agility)
            {

                player.HealthPoints -= DragonGlobal.Difficulty * 2;
            }
            else
            {
                Informatii.Text =Informatii.Text+"Si ai evitat atacul dragonului!";
            }
            lblHP.Text = "HP: " + player.HealthPoints;
            lblHPDragon.Text = "HP:" + DragonGlobal.HealthPoints;

            if(player.HealthPoints <= 0) 
            {
                var LoseGame = new LoseScreen();
                LoseGame.Show();
                this.Hide();
            }
            if(DragonGlobal.HealthPoints <= 0) 
            {
                Informatii.Text = "Dragon Ucis!(Poti salva progresul)";
                SaveGame.Visible = true;

                lblNumeDragon.Visible = false;
                lblDificultateDragon.Visible = false;
                lblLootDragon.Visible = false;
                lblHPDragon.Visible = false;

                btnAttack.Visible = false;
                btnFlee.Visible = false;

                btnExplore.Visible = true;

                player.Money = DragonGlobal.Loot;
                player.scor = 100 * DragonGlobal.Difficulty;
                player.xp = 100* DragonGlobal.Difficulty;
                player.stage++;

                if(player.xp >= player.Level*100)
                {
                    player.xp = player.xp - (player.Level * 100);
                    player.Level++;
                    player.AbilityPoints = 5;
                    Informatii.Text = "Ai avansat un nivel!(Nu uita sa salvezi)";
                    PlusStr.Visible = true;
                    PlusAgility.Visible = true;
                    PlusInte.Visible = true;
                    lblAbilityPoints.Text = "Puncte Abilitati: " + player.AbilityPoints;
                }

                lblXP.Text = "XP: " + player.xp;
                lblLevel.Text = "Level: " + player.Level;
                lblBani.Text = "Bani: " + player.Money;
                lblScor.Text = "Scor: " + player.scor;
                lblStagiu.Text = "Stagiu Joc: " + player.stage;

                

            }
        }

        #endregion
    }

}
