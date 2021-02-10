using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Memory_16_carte
{
    public partial class tessera : System.Windows.Forms.PictureBox
    {
        bool coperto = false; public bool clicked = false;
        string coertina = "foto/retro.jpg";
        public string retro;
        PictureBox cart = new PictureBox();
        public tessera(int posx, int posy, int gx, int gy, int tip)
        {
            Size = new Size(gy, gx);
            Load(coertina);
            SizeMode = PictureBoxSizeMode.StretchImage;
            Location = new Point(posx, posy);
            Tag = tip;
            retro = "foto/" + Convert.ToString(tip) + ".jpg";
        }

        public void copri()
        {
            if (coperto)
            {
                coperto = false;
                Load(coertina);
            }
            else
            {
                coperto = true;
                Load(retro);
            }
        }
    }
}