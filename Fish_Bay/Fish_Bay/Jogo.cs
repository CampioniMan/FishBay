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
        // Constantes
        public const int VELOCIDADE_AJUDANTE = 3;
        public static readonly string[] DEFAULT_IMAGES = { "../../../../imagens/Peixes/", "../../../../imagens/NPCs/", "../../../../imagens/Fundo/" };
        public static readonly Point PONTO_FIXO_VARA = new Point(908, 222);

        private Menu menu;

        // variáveis para peixes
        private Peixe[] peixes;
        private Peixe bota;
        private ControladorPeixe TodosOsPeixes;

        // variáveis para personagens
        private Cliente[] clientes;
        private FilaCliente fila;
        private Vendedor ajudante;
        private int ind = 0;
        private bool ehDourado = true;

        // randômico global
        private Random rand;

        // inicializando a coordenada do mouse
        private Point coordMouse = new Point(0,0);

        // nome dos jogadores
        private string nomeJogador, nomeAju;

        // Variável para reinicialização
        private bool podeReiniciar;

        // variável que contém a quantidade de pontos à ser adicionada quando se entrega o peixe
        private int pont;

        public Jogo(Menu menuNovo, string nomeJog)
        {
            this.menu = menuNovo;
            this.nomeJogador = nomeJog;

            // Easter Egg do papai noel
            if (this.nomeJogador.ToUpper().Equals("PAPAI NOEL"))
                this.nomeAju = "Papai";
            else
                this.nomeAju = "ajudante";

            InitializeComponent();
        }

        private void Jogo_FormClosed(object sender, FormClosedEventArgs e)
        {
            // se irá reiniciar ou se irá para o menu principal
            if (podeReiniciar)
                this.menu.reiniciar();
            else
                this.menu.Show();
        }

        private void Jogo_Load(object sender, EventArgs e)
        {
            // criando os vetores
            rand = new Random();
            peixes = new Peixe[ControladorPeixe.LIMITE_PEIXES];
            clientes = new Cliente[FilaCliente.MAXIMO_FILA];

            // criando os peixes
            for (int i = 0; i < peixes.Length-1; i++)
                peixes[i] = new Peixe(new Point(-ControladorPeixe.LARGURA_PEIXE - rand.Next(400, 4000), rand.Next(380, 530)), 1, new Figura(Image.FromFile(DEFAULT_IMAGES[0] + "Peixe" + (i + 1) + ".png")), false);


                peixes[6] = new Peixe(new Point(-ControladorPeixe.LARGURA_PEIXE - rand.Next(400, 9000), rand.Next(380, 530)), 1, new Figura(Image.FromFile(DEFAULT_IMAGES[0] + "PeixeEsp.png")), true);
            

            // criando os clientes iniciais
            for (int i = 0; i < clientes.Length; i++)
                clientes[i] = new Cliente(new Stress(new Point(-i * (FilaCliente.LARGURA_NPC + 2), 215 - FilaCliente.ALTURA_NPC - 5), new Point(FilaCliente.LARGURA_NPC /2, FilaCliente.ALTURA_NPC /2)), (rand.Next(0, 100) > 85) ? true : false, Image.FromFile(DEFAULT_IMAGES[1] + "NPC" + rand.Next(2 ,11) + ".png"), new Point(-i * (FilaCliente.LARGURA_NPC + 2), 215));
            
            // Criando o vendedor
            ajudante = new Vendedor(Image.FromFile(DEFAULT_IMAGES[1] + nomeAju + ".png"),new Point(450,215));

            // Iniciando a fila e a pilha
            TodosOsPeixes = new ControladorPeixe(peixes, new Point(755, 212));
            fila = new FilaCliente(clientes, new Point(pbDesenho.Size.Width / 4, 0));

            // Começando o jogo em si
            timerSpawn.Start();
        }

        public void atualizaFilasEAjudante()
        {
            // atualizando coordenadas dos peixes e dos clientes
            TodosOsPeixes.nadem(rand.Next(5, 50));
            fila.andar();

            // estressando clientes e vendo se já estressaram ao máximo
            for (int i = 0; i < fila.TamanhoFila; i++)
            {
                fila.Clientes[i].StressarCliente(rand.Next(1, 6));

                if (!fila.Clientes[i].Stress.PodeStressar)
                {
                    fila.sair(i);
                    lblQtosClien.Text = (Convert.ToInt32(lblQtosClien.Text) - 1) + "";
                }
            }
            
            // fazendo a bota andar
            if (bota != null)
                bota.nadar(rand.Next(5, 50));

            // desenhando tudo
            pbDesenho.Invalidate();
        }

        private void pbDesenho_MouseMove(object sender, MouseEventArgs e)
        {
            // obtendo a coordenada atual do mouse
            coordMouse = new Point(908, e.Y);

            // tenta botar o peixe, que está na vara, na mesa se não estiver cheia
            if (e.Y <= 222)
                TodosOsPeixes.verSeDaPraBotarNaMesa();
        }

        private void pbDesenho_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // desenhando todos os peixes
            TodosOsPeixes.desenharTodos(g, (coordMouse.Y > 222)?(coordMouse):(PONTO_FIXO_VARA));
            
            // desenhando todos os clentes
            for (int i = 0; i < fila.TamanhoFila; i++)
            {
                fila.Clientes[i].Draw(g);
                fila.Clientes[i].Stress.coord.X = fila.Clientes[i].Coord.X;
            }

            // desenhando o ajudante
            ajudante.Skin.desenhar(g, ajudante.Coord);

            //desenhando a bota
            if (bota != null)
                bota.Skin.desenhar(g, bota.Coord);

            // desenhando a linha da vara
            if(coordMouse.Y > 222)
            {
                g.DrawLine(new Pen(Color.White, 2), new Point(908, 222), new Point(908, coordMouse.Y));
                g.DrawImage(Image.FromFile(DEFAULT_IMAGES[2] + "anzol.png"), new Point(895, coordMouse.Y-13));
            }
                

            // desenhando o pescador e a mesa
            g.DrawImage(Image.FromFile(DEFAULT_IMAGES[1] + "pescador.png"), new Point(840, 212));
            g.DrawImage(Image.FromFile(DEFAULT_IMAGES[2] + "Fish_Table.png"), new Point(755, 235));
        }

        private void timerSpawn_Tick(object sender, EventArgs e)
        {
            // calcular posições dos peixes
            TodosOsPeixes.verSePescouAlgumPeixe(coordMouse);
            for (int i = 0; i < TodosOsPeixes.Peixes.Length; i++)
                if (TodosOsPeixes.Peixes[i] != null && TodosOsPeixes.Peixes[i].Coord.X > pbDesenho.Size.Width)
                    if(i != 6)
                    TodosOsPeixes.Peixes[i].Coord = new Point(-ControladorPeixe.LARGURA_PEIXE - rand.Next(500,3500), rand.Next(380, 530));
                    else
                        TodosOsPeixes.Peixes[i].Coord = new Point(-ControladorPeixe.LARGURA_PEIXE - rand.Next(500,9000), rand.Next(380, 530));


            // calcular posições da bota
            if (rand.Next(1, 1001) > 950)
            {
                if (bota == null)
                    bota = new Peixe(new Point(-ControladorPeixe.LARGURA_BOTA, rand.Next(380, 530)), 1, new Figura(Image.FromFile(DEFAULT_IMAGES[0] + "bota.png")), false);

                if (bota != null && bota.Coord.X > pbDesenho.Size.Width)
                    bota = null;
            }

            // peixe volta ao zero
            atualizaFilasEAjudante();

            // ver se pescou a bota
            if (bota != null)
            {
                if (bota.pescou(new Point(908, coordMouse.Y), ControladorPeixe.ALTURA_BOTA))
                {
                    TodosOsPeixes.limparMesa();
                    bota = null;
                }
            }

            // Adicionando pessoas na fila aleatoriamente
            if (rand.Next(1, 1000) < 200 && rand.Next(1, 1000) > 500)
                fila.entrarRandomico();

            // Vendo se o usuário perdeu
            if (lblQtosClien.Text.Equals("0"))
            {
                timerSpawn.Stop();
                GameOver gv = new GameOver(nomeJogador, lblQtosPont.Text, this);
                gv.Show();
            }
        }

        private void Jogo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // andando ao contrário(indo pegar peixe)
            if (e.KeyChar.ToString().ToUpper().Equals("A")) 
            {
                ajudante.AndandoAoContrario = true;
                this.verificaPosicao();
            }

            // andando certo(peixe na mão)
            else if (e.KeyChar.ToString().ToUpper().Equals("D"))  
            {
                ajudante.AndandoAoContrario = false;
                this.verificaPosicao();
            }

            // apertou espaço
            else if (e.KeyChar.ToString().ToUpper().Equals(" "))
            {
                if (ajudante.EstaNoCanto[0])// entrega peixe
                {
                    if (ajudante.TemPeixe)
                    {
                        ajudante.TemPeixe = false;
                        Peixe aux = new Peixe(new Point(-ControladorPeixe.LARGURA_BOTA, rand.Next(380, 530)), 1, new Figura(Image.FromFile(DEFAULT_IMAGES[0] + "bota.png")), ehDourado);
                        ind = fila.vaiSair();
                        fila.sairIndice(ind);
                        lblQtosPont.Text = (Convert.ToInt32(lblQtosPont.Text) + pont) + "";
                        ajudante.Skin.Img = Image.FromFile(DEFAULT_IMAGES[1] + nomeAju + ".png");
                    }
                }
                else if (ajudante.EstaNoCanto[1])// pega peixe
                {
                    if (TodosOsPeixes.QtosPeixesPescados > 0 && !ajudante.TemPeixe)
                    {
                        ajudante.TemPeixe = true;
                        Peixe aux = TodosOsPeixes.tirarDaMesaPeixeDoTopo();
                        ajudante.Skin.Img = aux.TransformaAlimento(nomeAju);
                    }
                }
            }
        }

        private void verificaPosicao()
        {
            // ver se passou do balcão de clientes
            if (ajudante.Coord.X >= 450)
            {
                ajudante.EstaNoCanto[0] = false;
                ajudante.andar(VELOCIDADE_AJUDANTE);
            }
            else
            {
                ajudante.Coord = new Point(450, 215);
                ajudante.EstaNoCanto[0] = true;
                ajudante.EstaNoCanto[1] = false;
            }

            // ver se passou da mesa de peixes
            if (ajudante.Coord.X <= 750)
            {
                ajudante.EstaNoCanto[1] = false;
                ajudante.andar(VELOCIDADE_AJUDANTE);
            }
            else
            {
                ajudante.Coord = new Point(750, 215);
                ajudante.EstaNoCanto[1] = true;
                ajudante.EstaNoCanto[0] = false;
            }
        }

        private void pbDesenho_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                if (TodosOsPeixes.PeixePescando[0] != null)
                    TodosOsPeixes.removerPescando();
        }

        public void setReiniciar(bool novoRein)
        {
            // mudando a variável responsável pelo controle da reinicialização
            this.podeReiniciar = novoRein;
        }
    }
}
