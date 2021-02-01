using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Timers;

namespace Memory_16_carte
{
    public partial class Form1 : Form
    {
        public string elapsedTime; //Stringa del timer che mi servira' alla fine
        public System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch(); //Inizializzo il cronometro della partita
        public static tessera[] carte = new tessera[16]; //Vettore delle carte
        public int cliccate = 0; public object[] v = new object[2]; //cliccate serve per capire quante carte l'utente ha premuto, v serve quando ho cliccato le carte esso contiene gli oggetti carte
        public int mosse = 0, punti = 0; //variabili utilizzate per salvare i punti e le mosse
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stopWatch.Start(); //Faccio partire il cronometro
            timer1.Enabled = false; //Disattivo il timer utilizzato per girare le carte sbagliate
            int max = 16, px = 20, py = 20; //px e py sono le posizioni di partenza in pixel
            Random random = new Random();
            int[] v = new int[max]; //v utilizzato per l'estrazione e la randomizzazione delle carte

            for (int i = 0; i < max; i++)
            {
                v[i] = (i < 8) ? i : (i - 8);
            }

            for (int i = 0; i < max; i++)
            {
                int k = random.Next(8) + 1;
                int temp = v[i];
                v[i] = v[k];
                v[k] = temp;
            }

            for (int i = 0, j = 1; i < max; i++, j++)
            {
                carte[i] = new tessera(px, py, 75, 65, v[i]);
                px = (j % 4 == 0) ? 20 : px + 70;
                py = (j % 4 == 0) ? py +  85 : py;
                carte[i].Click += new EventHandler(this.moveup);
                this.Controls.Add(carte[i]);
                carte[i].Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ((tessera)v[0]).copri();
            ((tessera)v[1]).copri(); //Rigiro le carte se sono sbagliate
            for (int i = 0; i < 16; i++) carte[i].Enabled = true;
            v[0] = null; v[1] = null;
        }

        public void moveup(object sender, EventArgs e)
        {
            if (!((tessera)sender).clicked)
            {
                v[cliccate] = sender;
                if (v[0] != v[1])
                {
                    ((tessera)sender).copri();
                    cliccate++;
                    Console.Write("\nHai cliccato la carta n " + Convert.ToInt32(((tessera)sender).Tag));

                    if (cliccate == 2)
                    {
                        mosse++;
                        cliccate = 0;
                        Mosse_labels.Text = "Mosse = " + mosse;
                        if (Convert.ToInt32(((tessera)v[0]).Tag) != Convert.ToInt32(((tessera)v[1]).Tag))
                        {
                            Console.WriteLine("\nSono diverse");
                            for (int i = 0; i < 16; i++) carte[i].Enabled = false;
                            timer1.Enabled = true;
                        }
                        else if (Convert.ToInt32(((tessera)v[0]).Tag) == Convert.ToInt32(((tessera)v[1]).Tag))
                        {
                            timer1.Enabled = false;
                            Console.WriteLine("\nSono uguali");
                            ((tessera)v[0]).clicked = true;
                            ((tessera)v[1]).clicked = true;
                            punti++;
                            Punti_label.Text = "Punti = " + punti;
                        }


                        if (punti == 8)
                        {
                            stopWatch.Stop();
                            TimeSpan ts = stopWatch.Elapsed;
                            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                            MessageBox.Show("Hai vinto!! Hai fatto " + mosse + " mosse\nCi hai impiegato " + elapsedTime);
                            Application.Exit();
                        }
                    }
                }
            }
        }
    }
}
