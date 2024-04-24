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

        static string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
        static string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

        static string numeFisier2 = ConfigurationManager.AppSettings["NumeFisier2"];
        string caleCompletaFisier2 = locatieFisierSolutie + "\\" + numeFisier2;

        public Player player;
        public string linieFisier;
        public Dragon dragon;
        public int pass;

        private Panel LinieDesign;

        private Label lblNume;
        private Label lblNumeAfisare;

        private Label lblStrenght;
        private Label lblIntelicenge;
        private Label lblAgility;

        private Label lblAbilityPoints;
        private Label NoPoints;

        private Label lblHP;
        private Label lblScor;
        private Label lblXP;
        private Label lblLevel;
        private Label lblBani;
        private Label lblStagiu;

        private Label lblDragoni;
        private Label[] lblsNume;
        private Label[] lblsDificultate;
        private Label[] lblsLoot;
        private Label[] lblsHP;

        private Label lblLoad;

        private TextBox txtNume;

        private Button bntNewGame;
        private Button MainMenu;
        private Button SaveGame;

        private Button PlusStr;
        private Button PlusInte;
        private Button PlusAgility;

        private const int latime_control = 100;
        private const int dimensiune_pas_x = 120;
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
            dragon = new Dragon();


            //setare proprietati
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.Location = new Point(0,0);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.LimeGreen;
            this.Text = "Dragons and Apples 2";

            //linii design
            LinieDesign = new Panel();
            LinieDesign.BackColor = Color.Red;
            LinieDesign.Size = new Size(5, this.ClientSize.Height);
            LinieDesign.Location = new Point(100, 0);
            this.Controls.Add(LinieDesign);

            LinieDesign = new Panel();
            LinieDesign.BackColor = Color.Red;
            LinieDesign.Size = new Size(this.ClientSize.Width, 5);
            LinieDesign.Location = new Point(0, 100);
            this.Controls.Add(LinieDesign);

            //BLoc Nume + HP
            lblNume = new Label();
            lblNume.Width = latime_control;
            lblNume.Text = "Nume";
            lblNume.Left = dimensiune_pas_x;
            lblNume.ForeColor = Color.Black;
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

            //End Bloc Nume

            //Bloc Puncte
            lblAbilityPoints = new Label();
            lblAbilityPoints.Width = latime_control + 10;
            lblAbilityPoints.Text = "Puncte Abilitati: " + player.AbilityPoints;
            lblAbilityPoints.Left = 2 * dimensiune_pas_x + 30;
            lblAbilityPoints.ForeColor = Color.Black;
            this.Controls.Add(lblAbilityPoints);

            NoPoints = new Label();
            NoPoints.Width = latime_control + 20;
            NoPoints.Text = "Nu mai ai puncte";
            NoPoints.Left = 3 * dimensiune_pas_x + 20;
            NoPoints.ForeColor = Color.Red;
            NoPoints.Visible = false;
            this.Controls.Add(NoPoints);
            //End Bloc Puncte

            //Bloc Abilitati
            //Label Putere+Buton
            lblStrenght = new Label();
            lblStrenght.Width = latime_control - 40;
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
            lblIntelicenge.Width = latime_control - 20;
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

            //Label XP si level
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
            //Label Bani si scor
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

            //Label Stagiu Joc
            lblStagiu = new Label();
            lblStagiu.Width = latime_control;
            lblStagiu.Text = "Stagiu Joc: " + player.stage;
            lblStagiu.Left = 8 * dimensiune_pas_x;
            lblStagiu.ForeColor = Color.Black;
            this.Controls.Add(lblStagiu);

            //Label Dragoni
            lblDragoni = new Label();
            lblDragoni.Width = latime_control;
            lblDragoni.Left = dimensiune_pas_x;
            lblDragoni.Top = 5 * dimensiune_pas_y;
            lblDragoni.Text = "Dragoni:";
            lblDragoni.ForeColor = Color.Black;
            this.Controls.Add(lblDragoni);

            Dragon[] dragons = adminDragoni.GetDragons(out int nrdragoni);
            lblsNume = new Label[nrdragoni];
            lblsDificultate = new Label[nrdragoni];
            lblsLoot = new Label[nrdragoni];
            lblsHP = new Label[nrdragoni];
            int i = 0, j = 5;
            foreach (Dragon dragon in dragons)
            {
                lblsNume[i] = new Label();
                lblsNume[i].Width = latime_control;
                lblsNume[i].Text = dragon.Name;
                lblsNume[i].Left = dimensiune_pas_x;
                lblsNume[i].Top = (j + 1) * dimensiune_pas_y;
                this.Controls.Add(lblsNume[i]);

                lblsDificultate[i] = new Label();
                lblsDificultate[i].Width = latime_control;
                lblsDificultate[i].Text = "Dificultate:" + dragon.Difficulty;
                lblsDificultate[i].Left = 2 * dimensiune_pas_x;
                lblsDificultate[i].Top = (j + 1) * dimensiune_pas_y;
                this.Controls.Add(lblsDificultate[i]);

                lblsLoot[i] = new Label();
                lblsLoot[i].Width = latime_control;
                lblsLoot[i].Text = "Loot:" + dragon.Loot;
                lblsLoot[i].Left = 3 * dimensiune_pas_x;
                lblsLoot[i].Top = (j + 1) * dimensiune_pas_y;
                this.Controls.Add(lblsLoot[i]);

                lblsHP[i] = new Label();
                lblsHP[i].Width = latime_control;
                lblsHP[i].Text = "HP:" + dragon.HealthPoints;
                lblsHP[i].Left = 4 * dimensiune_pas_x;
                lblsHP[i].Top = (j + 1) * dimensiune_pas_y;
                this.Controls.Add(lblsHP[i]);

                i++;
                j++;
            }
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
            //SaveGame.Click += SalvareJoc;
            this.Controls.Add(SaveGame);
        }

        private void PlusStrenght(object sender, EventArgs e)
        {
            if (player.AbilityPoints > 0)
            {
                player.Strength++;
                player.AbilityPoints--;
                lblStrenght.Text = "Putere: " + player.Strength;
                lblAbilityPoints.Text = "Puncte Abilitati: " + player.AbilityPoints;
            }
            else
            {
                NoPoints.Text = "Nu mai ai puncte";
                NoPoints.Visible = true;
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
            else
            {
                NoPoints.Text = "Nu mai ai puncte";
                NoPoints.Visible = true;
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
            else
            {
                NoPoints.Text = "Nu mai ai puncte";
                NoPoints.Visible = true;
            }

        }

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
        }
    }
}
