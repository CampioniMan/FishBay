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
        public const int VELOCIDADE_AJUDANTE = 3;
        public static readonly string[] DEFAULT_IMAGES = { "../../../../imagens/Peixes/", "../../../../imagens/NPCs/", "../../../../imagens/Fundo/" };
        public static readonly Point PONTO_FIXO_VARA = new Point(908, 222);

        private Menu menu;
        private Peixe[] peixes;
        private Peixe bota;
        private ControladorPeixe TodosOsPeixes;

        private Cliente[] clientes;
        private Vendedor ajudante;

        private FilaCliente fila;

        private Random rand;
        private Point coordMouse = new Point(0,0);

        private string nomeJogador, nomeAju;
        private bool podeReiniciar;

        public Jogo(Menu menuNovo, string nomeJog)
        {
            this.menu = menuNovo;
            this.nomeJogador = nomeJog;

            if (this.nomeJogador.ToUpper().Equals("PAPAI NOEL"))
                this.nomeAju = "Papai";
            else
                this.nomeAju = "ajudante";

            InitializeComponent();
        }

        private void Jogo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (podeReiniciar)
                this.menu.reiniciar();
            else
                this.menu.Show();
        }

        private void Jogo_Load(object sender, EventArgs e)
        {
            rand = new Random();
            peixes = new Peixe[7];
            clientes = new Cliente[FilaCliente.MAXIMO_FILA];

            for (int i = 0; i < peixes.Length-1; i++)
                peixes[i] = new Peixe(new Point(-ControladorPeixe.LARGURA_PEIXE - rand.Next(0, 4000), rand.Next(380, 530)), 1, new Figura(Image.FromFile(DEFAULT_IMAGES[0] + "Peixe" + (i + 1) + ".png")), false);
            peixes[6] = new Peixe(new Point(-ControladorPeixe.LARGURA_PEIXE - rand.Next(000, 00001), rand.Next(380, 530)), 1, new Figura(Image.FromFile(DEFAULT_IMAGES[0] + "PeixeEsp.png")), true);

            for (int i = 0; i < clientes.Length; i++)
                clientes[i] = new Cliente(new Stress(new Point(-i * (FilaCliente.LARGURA_NPC + 2), 215 - FilaCliente.ALTURA_NPC - 5), new Point(FilaCliente.LARGURA_NPC /2, FilaCliente.ALTURA_NPC /2)), false, Image.FromFile(DEFAULT_IMAGES[1] + "NPC" + rand.Next(2 ,11) + ".png"), new Point(-i * (FilaCliente.LARGURA_NPC + 2), 215));
            
            ajudante = new Vendedor(Image.FromFile(DEFAULT_IMAGES[1] + nomeAju + ".png"),new Point(450,215));

            TodosOsPeixes = new ControladorPeixe(peixes, new Point(755, 212));
            fila = new FilaCliente(clientes, new Point(pbDesenho.Size.Width / 4, 0));
            timerSpawn.Start();
        }

        public void atualizaFilasEAjudante()
        {
            TodosOsPeixes.nadem(rand.Next(5, 50));
            fila.andar();

            if (ajudante.Coord.X >= 730 && TodosOsPeixes.QtosPeixesPescados > 0 && !ajudante.TemPeixe)
            {
                ajudante.TemPeixe = true;
                Peixe aux = TodosOsPeixes.voltarANadarPeixe();
                if (aux.Dourado)
                {
                    aux.TransformaAlimento = aux.transformaSushiDourado;
                }
                else
                    aux.TransformaAlimento = aux.transformaSushiNormal;
                ajudante.Skin.Img = aux.TransformaAlimento(nomeAju);
            }

            if (ajudante.Coord.X <= 450 && ajudante.AndandoAoContrario && ajudante.TemPeixe)
            {
                ajudante.TemPeixe = false;
                fila.sairPrimeiro();
                lblQtosPont.Text = (Convert.ToInt32(lblQtosPont.Text) + 10) + "";
                ajudante.Skin.Img = Image.FromFile(DEFAULT_IMAGES[1] + nomeAju + ".png");
            }

            for (int i = 0; i < fila.TamanhoFila; i++)
            {
                fila.Clientes[i].StressarCliente(rand.Next(1, 6));//Stress.stressar(rand.Next(1, 6));

                if (!fila.Clientes[i].Stress.PodeStressar)
                {
                    fila.sair(i);
                    lblQtosClien.Text = (Convert.ToInt32(lblQtosClien.Text) - 1) + "";
                }
            }
            
            if (bota != null)
                bota.nadar(rand.Next(5, 50));
            pbDesenho.Invalidate();
        }

        private void pbDesenho_MouseMove(object sender, MouseEventArgs e)
        {
            coordMouse = new Point(908, e.Y);
            if (e.Y <= 222)
                TodosOsPeixes.verSeDaPraBotarNaMesa();
        }

        private void pbDesenho_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            TodosOsPeixes.desenharTodos(g, (coordMouse.Y > 222)?(coordMouse):(PONTO_FIXO_VARA));
            
            for (int i = 0; i < fila.TamanhoFila; i++)
            {
                fila.Clientes[i].Draw(g);
                fila.Clientes[i].Stress.coord.X = fila.Clientes[i].Coord.X;
            }

            ajudante.Skin.desenhar(g, ajudante.Coord);

            if (bota != null)
                bota.Skin.desenhar(g, bota.Coord);
            if(coordMouse.Y > 222)
                g.DrawLine(new Pen(Color.White,2), new Point(908, 222), new Point(908, coordMouse.Y));

            g.DrawImage(Image.FromFile(DEFAULT_IMAGES[1] + "pescador.png"), new Point(840, 212));
            g.DrawImage(Image.FromFile(DEFAULT_IMAGES[2] + "Fish_Table.png"), new Point(755, 235));
        }

        private void timerSpawn_Tick(object sender, EventArgs e)
        {
            ///////// peixes :
            TodosOsPeixes.verSePescouAlgumPeixe(coordMouse);
            for (int i = 0; i < TodosOsPeixes.Peixes.Length; i++)
                if (TodosOsPeixes.Peixes[i] != null && TodosOsPeixes.Peixes[i].Coord.X > pbDesenho.Size.Width)
                    TodosOsPeixes.Peixes[i].Coord = new Point(-ControladorPeixe.LARGURA_PEIXE - 1000, rand.Next(380, 530));


            ///////// bota :
            if (rand.Next(1, 1001) > 900)
            {
                if (bota == null)
                    bota = new Peixe(new Point(-ControladorPeixe.LARGURA_BOTA, rand.Next(380, 530)), 1, new Figura(Image.FromFile(DEFAULT_IMAGES[0] + "bota.png")), false);

                if (bota != null && bota.Coord.X > pbDesenho.Size.Width)
                    bota = null;
            }

            //////// peixe volta ao zero : 
            atualizaFilasEAjudante();
            if (bota != null)
            {
                if (bota.pescou(new Point(908, coordMouse.Y), ControladorPeixe.ALTURA_BOTA))
                {
                    TodosOsPeixes.limparMesa();
                    bota = null;
                }
            }

            ///////// Adicionando pessoas na fila aleatoriamente
            if (rand.Next(1, 1000) < 200 && rand.Next(1, 1000) > 500)
                fila.entrarRandomico();

            if (lblQtosClien.Text.Equals("0"))
            {
                timerSpawn.Stop();
                GameOver gv = new GameOver(nomeJogador, lblQtosPont.Text, this);
                gv.Show();
            }
        }

        private void Jogo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString().ToUpper().Equals("A"))
            {
                ajudante.AndandoAoContrario = true;
                this.verificaPosicao();
            }

            else if (e.KeyChar.ToString().ToUpper().Equals("D"))
            {
                ajudante.AndandoAoContrario = false;
                this.verificaPosicao();
            }
        }

        private void verificaPosicao()
        {
            if (ajudante.Coord.X >= 450)
                ajudante.andar(VELOCIDADE_AJUDANTE);
            else
                ajudante.Coord = new Point(450, 215);

            if (ajudante.Coord.X <= 750)
                ajudante.andar(VELOCIDADE_AJUDANTE);
            else
                ajudante.Coord = new Point(750, 215);
        }

        public void setReiniciar(bool novoRein)
        {
            this.podeReiniciar = novoRein;
        }
    }
}
