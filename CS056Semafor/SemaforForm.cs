using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS056Semafor
{
    public partial class SemaforForm : Form
    {
        public SemaforForm()
        {
            InitializeComponent();
        }
       

        class Semafor
        {
            public enum Stav
            {
                Vypnuto,
                Zapnuto
            }

            public enum Svetla
            {
                Stop = 0,
                PripravitVolno = 1,
                Volno = 2,
                PripravitStop = 3,
                OranzoveSviti = 4,
                Zhasnute
            }

            Stav semafor = Stav.Vypnuto;
            Stav rizeni = Stav.Vypnuto;
            Svetla svetla = Svetla.Zhasnute;
            DateTime casPrechodu;                                       //cas prechodu do aktualniho stavu rizeni
            Timer casovac = new Timer();
            private void casovac_Tick(object sender, EventArgs e)
            {
                this.Aktualizovat();
            }

            //TimeSpan intervalStop = new TimeSpan(0, 0, 5); 
            //TimeSpan intervalPripravitVolno = new TimeSpan(0, 0, 2);
            //TimeSpan intervalVolno = new TimeSpan(0, 0, 10);
            //TimeSpan intervalPripravitStop = new TimeSpan(0, 0, 2);
            //TimeSpan intervalBlikani = new TimeSpan(0, 0, 1);

            TimeSpan[] intervaly = {
                new TimeSpan(0, 0, 5),
                new TimeSpan(0, 0, 2),
                new TimeSpan(0, 0, 10),
                new TimeSpan(0, 0, 2),
                new TimeSpan(0, 0, 1)};

            PictureBox svetloCervene;
            PictureBox svetloOranzove;
            PictureBox svetloZelene;

            public Semafor(PictureBox svetloCervene, PictureBox svetloOranzove, PictureBox svetloZelene)
            {
                this.svetloCervene = svetloCervene;
                this.svetloOranzove = svetloOranzove;
                this.svetloZelene = svetloZelene;

                casPrechodu = DateTime.Now;

            }

            public Semafor(int souradniceX, int souradniceY, Form formular) 
            {
                //Vytvorit panel pro semafor
                Panel p = new Panel();
                p.Left = souradniceX;
                p.Top = souradniceY;
                p.Width = 50;
                p.Height = 140;
                p.BackColor = Color.FromArgb(49, 49, 49);

                //Vytvorit pictureboxy pro svetla semaforu
                PictureBox sc = new PictureBox();
                sc.Width = 40;
                sc.Height = 40;
                sc.Top = 5;
                sc.Left = 5;
                sc.Image = Properties.Resources.svetloVypnute;
                sc.SizeMode = PictureBoxSizeMode.StretchImage;
                this.svetloCervene = sc;
                p.Controls.Add(sc);

                PictureBox so = new PictureBox();
                so.Width = 40;
                so.Height = 40;
                so.Top = 50;
                so.Left = 5;
                so.Image = Properties.Resources.svetloVypnute;
                so.SizeMode = PictureBoxSizeMode.StretchImage;
                this.svetloOranzove = so;
                p.Controls.Add(so);

                PictureBox sz = new PictureBox();
                sz.Width = 40;
                sz.Height = 40;
                sz.Top = 95;
                sz.Left = 5;
                sz.Image = Properties.Resources.svetloVypnute;
                sz.SizeMode = PictureBoxSizeMode.StretchImage;
                this.svetloZelene = sz;
                p.Controls.Add(sz);

                formular.Controls.Add(p);

                ZmenitStav(Svetla.Zhasnute);

                this.casovac.Interval = 50;
                this.casovac.Tick += casovac_Tick;
                this.casovac.Start();
            }

            //nastavi stav rizeni podle parametru
            private void ZmenitStav(Svetla novyStav)
            {
                this.svetla = novyStav;
                casPrechodu = DateTime.Now;                 //zapamatovat cas prechodu
                Vykreslit();                                //zobrazit svetla podle stavu
            }

            public void Zapnout()
            {
                semafor = Stav.Zapnuto;
                ZmenitStav(Svetla.OranzoveSviti);

            }
            public void Vypnout()
            {
                semafor = Stav.Vypnuto;
                ZmenitStav(Svetla.Zhasnute);
           
            }

            public void RizeniZapnout()
            {
                rizeni = Stav.Zapnuto;
                ZmenitStav(Svetla.Stop);
            }

            public void RizeniVypnout()
            {
                rizeni = Stav.Vypnuto;
                ZmenitStav(Svetla.OranzoveSviti);
            }

            //vykresli aktualni stav semaforu (rozsviceni svetel)
            public void Aktualizovat()
            {
                TimeSpan casOdPrepnuti = DateTime.Now - casPrechodu;

                //stav se zmeni jen kdyz je potreba - vykresli se jen, kdyz je potreba
                bool zmenitStav = (semafor == Stav.Zapnuto);

                if (rizeni == Stav.Zapnuto)
                {

                    zmenitStav = zmenitStav && (casOdPrepnuti > intervaly[(int)svetla]);
                    if (zmenitStav && svetla == Svetla.Stop)
                    {
                        ZmenitStav(Svetla.PripravitVolno);
                    }
                    else if (zmenitStav && svetla == Svetla.PripravitVolno)
                    {
                        ZmenitStav(Svetla.Volno);
                    }
                    else if (zmenitStav && svetla == Svetla.Volno)
                    {
                        ZmenitStav(Svetla.PripravitStop);
                    }
                    else if (zmenitStav && svetla == Svetla.PripravitStop)
                    {
                        ZmenitStav(Svetla.Stop);
                    }
                }
                else
                {
                    zmenitStav = zmenitStav && (casOdPrepnuti > intervaly[(int)Svetla.OranzoveSviti]);
                    if (zmenitStav && svetla == Svetla.Zhasnute)
                    {
                        ZmenitStav(Svetla.OranzoveSviti);
                    }
                    else if (zmenitStav)
                    {
                        ZmenitStav(Svetla.Zhasnute);
                    }

                }
            }
         
            public void Vykreslit()
            {
                ZhasnoutSvetla();

                switch (svetla)
                {
                    case Svetla.Zhasnute:
                        break;

                    case Svetla.OranzoveSviti:
                        svetloOranzove.Image = Properties.Resources.svetloZluta;
                        break;

                    case Svetla.Stop:
                        svetloCervene.Image = Properties.Resources.svetloCervena;
                        break;

                    case Svetla.PripravitVolno:
                        svetloCervene.Image = Properties.Resources.svetloCervena;
                        svetloOranzove.Image = Properties.Resources.svetloZluta;
                        break;

                    case Svetla.Volno:
                        svetloZelene.Image = Properties.Resources.svetloZelena;
                        break;

                    case Svetla.PripravitStop:
                        svetloOranzove.Image = Properties.Resources.svetloZluta;
                        break;
                }

            }
            private void ZhasnoutSvetla()
            {
                svetloCervene.Image = Properties.Resources.svetloVypnute;
                svetloOranzove.Image = Properties.Resources.svetloVypnute;
                svetloZelene.Image = Properties.Resources.svetloVypnute;

            }
        }
     


        private void semaforTimer_Tick(object sender, EventArgs e)
        {
            //this.semafor.Aktualizovat();
            //this.semafor2.Aktualizovat();
        }

        //Semafor semafor;
        //Semafor semafor2;

        List<Semafor> semafory = new List<Semafor>();               //seznam vytvorenych semaforu

        private void CS056Semafor_Load(object sender, EventArgs e)
        {
            //this.semafor = new Semafor(pictureBox1, pictureBox2, pictureBox4);
            //this.semafor2 = new Semafor(pictureBox6, pictureBox5, pictureBox3);
        }

        private void zapnoutButton_Click(object sender, EventArgs e)
        {
            //this.semafor.Zapnout();
            //this.semafor2.Zapnout();
            this.semafory[int.Parse(cisloSemaforuTextBox.Text)].Zapnout();
        }

        private void vypnoutButton_Click(object sender, EventArgs e)
        {
            //this.semafor.Vypnout();
            //this.semafor2.Vypnout();
            this.semafory[int.Parse(cisloSemaforuTextBox.Text)].Vypnout();
        }

        private void rizeniVypnoutButton_Click(object sender, EventArgs e)
        {
            //this.semafor.RizeniVypnout();
            //this.semafor2.RizeniVypnout();
            this.semafory[int.Parse(cisloSemaforuTextBox.Text)].RizeniVypnout();
        }

        private void rizeniZapnoutButton_Click(object sender, EventArgs e)
        {
            //this.semafor.RizeniZapnout();
            //this.semafor2.RizeniZapnout();
            this.semafory[int.Parse(cisloSemaforuTextBox.Text)].RizeniZapnout();
        }

        private void SemaforForm_MouseClick(object sender, MouseEventArgs e)
        {
            this.semafory.Add(new Semafor(e.X, e.Y, this));
        }

        private bool panel1Presun = false;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1Presun = true;
            label1.Text = e.Location.ToString();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (panel1Presun)
            {
                panel1.Left = panel1.Left - e.X;
                panel1.Top = panel1.Top - e.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            panel1Presun = false;
        }

        private void SemaforForm_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}