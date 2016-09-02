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
        private Menu menu;
        private Peixe[] peixes;
        private Random rdn;
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
                peixes[i] = new Peixe(new Point(20, rdn.Next(380, 530)), 1, new Figura(Image.FromFile("../../../../imagens/Peixe"+(i+1)+".png")));

            atualizaCoordPeixe();

            timerCoord.Start();
            timerSpawn.Start();
        }

        public void atualizaSpawn()
        {
            for (int i = 0; i < peixes.Length; i++)
            {
                if (peixes[i].Coord.X > 1500)
                    peixes[i].Coord = new Point(20, peixes[0].Coord.Y);
            }
        }

        public void atualizaCoordPeixe()
        {
            for (int i = 0; i < peixes.Length; i++)
                peixes[i].nadar(rdn.Next(5,30));
            pbDesenho.Invalidate();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            atualizaCoordPeixe();
        }

        private void pbDesenho_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < peixes.Length; i++)
                peixes[i].Skin.desenhar(g, peixes[i].Coord);
        }

        private void pbDesenho_Click(object sender, EventArgs e)
        {

        }

        private void timerSpawn_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < peixes.Length; i++)
            {
                if (peixes[i].Coord.X > 1200)
                    peixes[i].Coord = new Point(20, peixes[i].Coord.Y);
            }
        }
    }
}
