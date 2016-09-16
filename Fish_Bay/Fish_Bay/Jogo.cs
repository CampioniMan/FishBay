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
        private const int
            LARGURA_PEIXE = 56,
            LARGURA_BOTA = 44,
            LARGURA_NPC = 34,
            ALTURA_BOTA = 36,
            ALTURA_PEIXE = 22,
            ALTURA_NPC = 56;
        private string[] DEFAULT_IMAGES = new string[3]; // 0-> peixes, 1 -> NPCs, 2 -> Fundo

        private Menu menu;
        private Peixe[] peixes;
        private Peixe bota;

        private FilaCliente fila;

        private Random rdn;
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
            DEFAULT_IMAGES[0] = "../../../../imagens/Peixes/";
            DEFAULT_IMAGES[1] = "../../../../imagens/NPCs/";
            DEFAULT_IMAGES[2] = "../../../../imagens/Fundo/";

            rdn = new Random();
            peixes = new Peixe[6];

            Cliente[] clientes = new Cliente[10];

            for (int i = 0; i < peixes.Length; i++)
                peixes[i] = new Peixe(new Point(-LARGURA_PEIXE - rdn.Next(0, 4000), rdn.Next(380, 530)), 1, new Figura(Image.FromFile(DEFAULT_IMAGES[0] + "Peixe" + (i + 1) + ".png")));

            for (int i = 0; i < clientes.Length; i++)
                clientes[i] = new Cliente(new Stress(new Point(i * (LARGURA_NPC + 2) - 500, 215 - ALTURA_NPC - 5), new Point(LARGURA_NPC/2, ALTURA_NPC/2)), false, Image.FromFile(DEFAULT_IMAGES[1] + "NPC" + (11 - i) + ".png"), new Point(i * (LARGURA_NPC + 2) - 500, 215));

            fila = new FilaCliente(clientes, new Point(pbDesenho.Size.Width / 4, 0));
            timerSpawn.Start();
        }

        public void atualizaCoordPeixe()
        {
            for (int i = 0; i < peixes.Length; i++)
                peixes[i].nadar(rdn.Next(5, 50));

            fila.andar();
            Random r = new Random();
            for (int i = 0; i < fila.Clientes.Length; i++)
                fila.Clientes[i].Stress.stressar(r.Next(1, 6));

            if (bota != null) bota.nadar(rdn.Next(5, 50));
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

            for (int i = 0; i < fila.Clientes.Length; i++)
            {
                fila.Clientes[i].Skin.desenhar(g, fila.Clientes[i].Coord);
                fila.Clientes[i].Stress.coord.X = fila.Clientes[i].Coord.X;
                fila.Clientes[i].Stress.desenhar(g);
            }

            if (bota != null) bota.Skin.desenhar(g, bota.Coord);
            if(coordMouse.Y > 222)
                g.DrawLine(new Pen(Color.White,2), new Point(908, 222), new Point(908, coordMouse.Y));

            g.DrawImage(Image.FromFile(DEFAULT_IMAGES[1] + "pescador.png"), new Point(840, 212));
            g.DrawImage(Image.FromFile(DEFAULT_IMAGES[2] + "Fish_Table.png"), new Point(755, 235));
            g.DrawImage(Image.FromFile(DEFAULT_IMAGES[1] + "ajudante.png"), new Point(450, 225));

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
                    peixes[i].Coord = new Point(-LARGURA_PEIXE - 1000, rdn.Next(380, 530));
            }



            ///////// bota :
            if (rdn.Next(1, 1001) > 900)
            {
                if (bota == null)
                    bota = new Peixe(new Point(-LARGURA_BOTA, rdn.Next(380, 530)), 1, new Figura(Image.FromFile(DEFAULT_IMAGES[0] + "bota.png")));

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
                        peixes[i] = new Peixe(new Point(1600, rdn.Next(380, 530)), 1, new Figura(Image.FromFile(DEFAULT_IMAGES[0] + "Peixe" + (i + 1) + ".png"))); ;
                        peixes[i].PosMesa = posMesa;
                        peixes[i].Pescado = true;
                        posMesa = posMesa - 22;
                    }
                        
                }
                    
            }
            if (bota != null)
                if (bota.pescou(new Point(908, coordMouse.Y), ALTURA_BOTA))
                    bota = null;
        }
    }
}
