﻿using System;
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
        public const int
            LARGURA_PEIXE = 56,
            LARGURA_BOTA = 44,
            ALTURA_BOTA = 36,
            ALTURA_PEIXE = 22;
        public static readonly string[] DEFAULT_IMAGES = { "../../../../imagens/Peixes/", "../../../../imagens/NPCs/", "../../../../imagens/Fundo/" };
        private Menu menu;
        private Peixe[] peixes;
        private Peixe bota;
        private int qtsMesa = 0;
        private bool prmVez = true;
        Cliente[] clientes;
        Vendedor ajudante;

        private FilaCliente fila;

        private Random rand;
        private int posMesa = 212;
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
            rand = new Random();
            peixes = new Peixe[6];
            clientes = new Cliente[FilaCliente.MAXIMO_FILA];

            for (int i = 0; i < peixes.Length; i++)
                peixes[i] = new Peixe(new Point(-LARGURA_PEIXE - rand.Next(0, 4000), rand.Next(380, 530)), 1, new Figura(Image.FromFile(DEFAULT_IMAGES[0] + "Peixe" + (i + 1) + ".png")));

            for (int i = 0; i < clientes.Length; i++)
                clientes[i] = new Cliente(new Stress(new Point(-i * (FilaCliente.LARGURA_NPC + 2), 215 - FilaCliente.ALTURA_NPC - 5), new Point(FilaCliente.LARGURA_NPC /2, FilaCliente.ALTURA_NPC /2)), false, Image.FromFile(DEFAULT_IMAGES[1] + "NPC" + rand.Next(2 ,11) + ".png"), new Point(-i * (FilaCliente.LARGURA_NPC + 2), 215));
            ajudante = new Vendedor(Image.FromFile(DEFAULT_IMAGES[1] + "ajudante.png"),new Point(450,225));
            
            fila = new FilaCliente(clientes, new Point(pbDesenho.Size.Width / 4, 0));
            timerSpawn.Start();
        }

        public void atualizaCoordPeixe()
        {
            for (int i = 0; i < peixes.Length; i++)
                peixes[i].nadar(rand.Next(5, 50));

            fila.andar();

            if(!fila.EstaVazia && ajudante.Coord.X < 730 && !ajudante.AndandoAoContrario)
            {
                if(prmVez)
                {
                    ajudante.Coord = new Point(450, 225);
                    prmVez = false;
                }
                ajudante.AndandoAoContrario = false;
                ajudante.andar();
                
            }
            if(ajudante.Coord.X >= 730)
            {
                //if (!prmVez)
                //{
                //    ajudante.Coord = new Point(730, 225);
                //    prmVez = true;
                //}
                ajudante.AndandoAoContrario = true;
                //ajudante.podeAndar = true;
            }
            if (fila.queremPeixe()  && ajudante.AndandoAoContrario && ajudante.Coord.X > 450)
            {
                ajudante.AndandoAoContrario = true;
                ajudante.andar();
            }

            if(ajudante.Coord.X <= 450 && ajudante.AndandoAoContrario)
            {
                ajudante.AndandoAoContrario = false;
                fila.sairPrimeiro();
            }

            for (int i = 0; i < fila.TamanhoFila; i++)
            {
                fila.Clientes[i].Stress.stressar(rand.Next(1, 2));

                if (!fila.Clientes[i].Stress.PodeStressar)
                {
                    fila.sair(i);
                }
            }
            
            if (bota != null)
                bota.nadar(rand.Next(5, 50));
            pbDesenho.Invalidate();
        }

        private void pbDesenho_MouseMove(object sender, MouseEventArgs e)
        {
            coordMouse = new Point(e.X, e.Y);
        }

        private void pbDesenho_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < peixes.Length; i++)
                peixes[i].Skin.desenhar(g, peixes[i].Coord);
            
            for (int i = 0; i < fila.TamanhoFila; i++)
            {
                fila.Clientes[i].Skin.desenhar(g, fila.Clientes[i].Coord);
                fila.Clientes[i].Stress.coord.X = fila.Clientes[i].Coord.X;
                fila.Clientes[i].Stress.desenhar(g);
            }

            ajudante.Skin.desenhar(g, ajudante.Coord);

            if (bota != null)
                bota.Skin.desenhar(g, bota.Coord);
            if(coordMouse.Y > 222)
                g.DrawLine(new Pen(Color.White,2), new Point(908, 222), new Point(908, coordMouse.Y));

            g.DrawImage(Image.FromFile(DEFAULT_IMAGES[1] + "pescador.png"), new Point(840, 212));
            g.DrawImage(Image.FromFile(DEFAULT_IMAGES[2] + "Fish_Table.png"), new Point(755, 235));

            for(int i = 0; i <peixes.Length;i++)
            {
                if(peixes[i].Pescado)
                    g.DrawImage(Image.FromFile(DEFAULT_IMAGES[0] + "peixe" +(i+1) + "Pescado.png"), new Point(755, peixes[i].PosMesa));
            }

        }

        private void timerSpawn_Tick(object sender, EventArgs e)
        {
            ///////// peixes :
            for (int i = 0; i < peixes.Length; i++)
            {
                if (!peixes[i].Pescado)
                    if (peixes[i].Coord.X > pbDesenho.Size.Width)
                    peixes[i].Coord = new Point(-LARGURA_PEIXE - 1000, rand.Next(380, 530));
            }
            
            ///////// bota :
            if (rand.Next(1, 1001) > 900)
            {
                if (bota == null)
                    bota = new Peixe(new Point(-LARGURA_BOTA, rand.Next(380, 530)), 1, new Figura(Image.FromFile(DEFAULT_IMAGES[0] + "bota.png")));

                if (bota != null && bota.Coord.X > pbDesenho.Size.Width)
                    bota = null;
            }

            //////// peixe volta ao zero : 
            atualizaCoordPeixe();

            for (int i = 0; i < peixes.Length; i++)
            {
                if (!peixes[i].Pescado)
                {
                    if (peixes[i].pescou(new Point(908, coordMouse.Y), ALTURA_PEIXE))
                    {                       
                        peixes[i] = new Peixe(new Point(1600, rand.Next(380, 530)), 1, new Figura(Image.FromFile(DEFAULT_IMAGES[0] + "Peixe" + (i + 1) + ".png"))); ;
                        peixes[i].PosMesa = posMesa;
                        peixes[i].Pescado = true;
                        qtsMesa++;
                        posMesa = posMesa - 22;
                    }
                }  
            }
            
            if (bota != null)
                if (bota.pescou(new Point(908, coordMouse.Y), ALTURA_BOTA))
                    bota = null;

            ///////// Adicionando pessoas na fila aleatoriamente
            if (rand.Next(1, 1000) < 400 && rand.Next(1, 1000) > 950)
            {
                fila.entrarRandomico();
            }
        }
    }
}
