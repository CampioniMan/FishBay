using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fish_Bay
{
    public partial class Jogo : Form
    {
        private const int LARGURA_PEIXE = 56, LARGURA_BOTA = 44, ALTURA_BOTA = 36, ALTURA_PEIXE = 22;
        private const string DEFAULT_IMAGES = "../../../../imagens/";
        private Menu menu;
        private Peixe[] peixes;
        private Peixe bota;
        private Random rdn;
        private Point coordMouse = new Point(0,0);
        public Jogo(Menu menuNovo)
        {
            this.menu = menuNovo;
            InitializeComponent();
        }

        private void Jogo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.menu.Show();
        }

        private void Jogo_Load(object sender, EventArgs e)
        {
            rdn = new Random();
            peixes = new Peixe[6];

            for (int i = 0; i < peixes.Length; i++)
                peixes[i] = new Peixe(new Point(-LARGURA_PEIXE - rdn.Next(0, 4000), rdn.Next(380, 530)), 1, new Figura(Image.FromFile(DEFAULT_IMAGES + "Peixe" + (i + 1) + ".png")));
            
            timerSpawn.Start();
        }

        public void atualizaCoordPeixe()
        {
            for (int i = 0; i < peixes.Length; i++)
                peixes[i].nadar(rdn.Next(5, 50));
            if (bota != null) bota.nadar(rdn.Next(5, 50));
            pbDesenho.Invalidate();
        }

        private void pbDesenho_MouseMove(object sender, MouseEventArgs e)
        {
            lblX.Text = Convert.ToString(e.X);
            lblY.Text = Convert.ToString(e.Y);
            coordMouse = new Point(e.X, e.Y);
        }

        private void pbDesenho_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < peixes.Length; i++)
                peixes[i].Skin.desenhar(g, peixes[i].Coord);
            if (bota != null) bota.Skin.desenhar(g, bota.Coord);
            if(coordMouse.Y > 222)
                g.DrawLine(new Pen(Color.White,2), new Point(908, 222), new Point(908, coordMouse.Y));
            g.DrawImage(Image.FromFile(DEFAULT_IMAGES + "pescadoAtualizado.png"), new Point(840, 212));
        }

        private void timerSpawn_Tick(object sender, EventArgs e)
        {
            ///////// peixes :
            for (int i = 0; i < peixes.Length; i++)
            {
                if (peixes[i].Coord.X > pbDesenho.Size.Width)
                    peixes[i].Coord = new Point(-LARGURA_PEIXE - 1000, rdn.Next(380, 530));
            }

            ///////// bota :
            if (rdn.Next(1, 1001) > 900)
            {
                if (bota == null)
                    bota = new Peixe(new Point(-LARGURA_BOTA, rdn.Next(380, 530)), 1, new Figura(Image.FromFile(DEFAULT_IMAGES + "bota.png")));

                if (bota != null && bota.Coord.X > pbDesenho.Size.Width)
                    bota = null;
            }

            //////// peixe volta ao zero : 
            atualizaCoordPeixe();

            for (int i = 0; i < peixes.Length; i++)
            {
                if (peixes[i].pescou(new Point(908, coordMouse.Y), ALTURA_PEIXE))
                    peixes[i].voltarAoZero();
            }
            if (bota != null)
                if (bota.pescou(new Point(908, coordMouse.Y), ALTURA_BOTA))
                    bota = null;
        }


    }
}
