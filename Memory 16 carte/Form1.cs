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
        public int cliccate = 0; public object[] vo = new object[2]; //cliccate serve per capire quante carte l'utente ha premuto, v serve quando ho cliccato le carte esso contiene gli oggetti carte
        public int mosse = 0, punti = 0, max = 16; //variabili utilizzate per salvare i punti e le mosse
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stopWatch.Start(); //Faccio partire il cronometro
            timer1.Enabled = false; //Disattivo il timer utilizzato per girare le carte sbagliate
            int px = 20, py = 20; //px e py sono le posizioni di partenza in pixel
            Random random = new Random();
            int[] v = new int[max]; //v utilizzato per l'estrazione e la randomizzazione delle carte

            for (int i = 0; i < max; i++) v[i] = (i < 8) ? i : (i - 8); //Inizializzo il vettore v
            for (int i = 0; i < max; i++) //Ciclo per la randomizzazione dei numeri nel vettore v
            {
                int k = random.Next(8) + 1;
                int temp = v[i];
                v[i] = v[k];
                v[k] = temp;
            }

            for (int i = 0, j = 1; i < max; i++, j++)
            {
                carte[i] = new tessera(px, py, 75, 65, v[i]); //Widht = 75, Height = 65;
                px = (j % 4 == 0) ? 20 : px + 70;
                py = (j % 4 == 0) ? py +  85 : py;
                carte[i].Click += new EventHandler(this.moveup);
                this.Controls.Add(carte[i]);
                carte[i].Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) //Richiamata appena il timer delle carte sbagliate finisces
        {
            if (vo[0] != null) ((tessera)vo[0]).copri();
            if (vo[1] != null) ((tessera)vo[1]).copri(); //Rigiro le carte che sono sbagliate
            for (int i = 0; i < 16; i++) carte[i].Enabled = true; //Riattivo tutte le carte
            vo[0] = null; vo[1] = null; //Resetto il vettore di oggetti
        }

        public void moveup(object sender, EventArgs e)
        {
            if (!((tessera)sender).clicked) //verifico se la tessera e' stata cliccata
            {
                vo[cliccate] = sender; //Salvo nel vettore di oggetti l'oggetto tessera che e' stato cliccato, mi servira' dopo
                if (vo[0] != vo[1]) //Verifico se le carte cliccate se sono diverse, mi serve per capire se hoo cliccato la stessa carta
                {
                    ((tessera)sender).copri(); //Giro la carta
                    cliccate++; //Aumento la variabile cliccate

                    if (cliccate == 2) //Se ho cliccato 2 carte 
                    { 
                        mosse++; //Aumento le mosse di 1
                        cliccate = 0; //Azzero la variabile cliccate
                        Mosse_labels.Text = "Mosse = " + mosse; //Aggiorno il contatore carte nel form
                        if (Convert.ToInt32(((tessera)vo[0]).Tag) != Convert.ToInt32(((tessera)vo[1]).Tag)) //Verifico che siano diverse
                        {
                            for (int i = 0; i < 16; i++) carte[i].Enabled = false; //Disattivo tutte le carte temporaneamente  
                            timer1.Enabled = true;  //Avvio il timer per poi rigirarle
                        }
                        else if (Convert.ToInt32(((tessera)vo[0]).Tag) == Convert.ToInt32(((tessera)vo[1]).Tag)) //Verifico che siano uguali
                        {
                            timer1.Enabled = false; //disattivo il timer
                            ((tessera)vo[0]).clicked = true; //Assegno a clicked delle due carte true
                            ((tessera)vo[1]).clicked = true;
                            punti++; //Aumento i punti 
                            vo[0] = null; vo[1] = null; //Resetto il vettore di oggetti utilizzato per le carte
                            Punti_label.Text = "Punti = " + punti; //Aggiorno i punti nel Form
                        }


                        if (punti == (max / 2)) //Verifico che i punti siano 8
                        {
                            stopWatch.Stop(); //Fermo il cronometro
                            TimeSpan ts = stopWatch.Elapsed; //ts variabile che mi serve per salvare il cronometro
                            elapsedTime = String.Format("{2:00}.{3:00}", ts.Seconds, ts.Milliseconds / 10);
                            MessageBox.Show("Hai vinto!! Hai fatto " + mosse + " mosse\nCi hai impiegato " + elapsedTime); //Creo una messagebox con tutte le mosse e ffettuate e il tempo impiegato
                            Application.Exit();
                        }
                    }
                }
            }
        }
    }
}
