﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Bay
{
    public class Cliente
    {
        private bool ehVIP;
        private Stress stress;
        private Figura skin;

        public Figura Skin
        {
            get
            {
                return skin;
            }

            set
            {
                skin = value;
            }
        }

        public Stress Stress
        {
            get
            {
                return stress;
            }

            set
            {
                stress = value;
            }
        }

        public bool EhVIP
        {
            get
            {
                return ehVIP;
            }

            set
            {
                ehVIP = value;
            }
        }
        public Cliente(int novoStress, Point novoStressCoordenada, Point novosStressTamanhos, bool seEhVIP, Image novaSkin, Point novaCoordenada)
        {
            this.stress = new Stress(novoStress, novoStressCoordenada, novosStressTamanhos);
            this.ehVIP = seEhVIP;
            this.skin = new Figura(novaSkin);
        }

        public Cliente() : this(0, default(Point), default(Point), false, null, default(Point))
        {
        }

        public Cliente(int novoStress) : this(novoStress, default(Point), default(Point), false, null, default(Point))
        {
        }

        public Cliente(bool seEhVIP) : this(0, default(Point), default(Point), seEhVIP, null, default(Point))
        {
        }

        public Cliente(Image novaSkin) : this(0, default(Point), default(Point), false, novaSkin, default(Point))
        {
        }

        public Cliente(Figura novaSkin) : this(0, default(Point), default(Point), false, novaSkin.Img, novaSkin.Coord)
        {
        }

        public void desenhar(Graphics g)
        {
            g.DrawImage(skin.Img, skin.Coord);
            stress.desenhar(g);
        }
    }
}