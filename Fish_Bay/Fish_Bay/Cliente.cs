using System;
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
        private Point coord;
        private bool querPeixe;

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

        public Point Coord
        {
            get
            {
                return coord;
            }

            set
            {
                coord = value;
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

        public bool QuerPeixe
        {
            get
            {
                return querPeixe;
            }

            set
            {
                querPeixe = value;
            }
        }

        public void desenhar(Graphics g)
        {
            g.DrawImage(skin.Img, coord);
            stress.desenhar(g);
        }

        /* direcao= 1 ou direcao= -1 para o player andar para frente ou para trás */
        public void andar(int direcao)
        {
            andar(direcao, 1);
        }

        /* É possível juntar as duas variáveis, mas assim é melhor para o entendimento inicial da função */
        public void andar(int direcao, int velocidade)
        {
            this.coord.X += 5 * direcao * velocidade;
            if (direcao >= 0)
                this.Skin.Invertido = false;
            else
                this.Skin.Invertido = true;
        }
        
        public bool PodeAndar(int limiteX)
        {
            return this.coord.X < limiteX;
        }

        public Cliente(Stress novoEstresse, bool seEhVIP, Image novaSkin, Point novaCoordenada)
        {
            this.stress = novoEstresse;
            this.ehVIP = seEhVIP;
            this.skin = new Figura(novaSkin);
            this.coord = novaCoordenada;
            querPeixe = true;
        }

        public Cliente(int novoStress, Point novoStressCoordenada, Point novosStressTamanhos, bool seEhVIP, Image novaSkin, Point novaCoordenada) : this(new Stress(novoStress, novaCoordenada, novosStressTamanhos), seEhVIP, novaSkin, novaCoordenada)
        {
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

        public Cliente(Figura novaSkin) : this(0, default(Point), default(Point), false, novaSkin.Img, default(Point))
        {
        }
    }
}
