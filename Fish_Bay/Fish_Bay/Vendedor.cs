using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Bay
{
    public class Vendedor
    {
        private Figura skin;
        private Point coord;
        private bool podeAndar;

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

        public bool PodeAndar
        {
            get
            {
                return podeAndar;
            }

            set
            {
                podeAndar = value;
            }
        }

        public bool EstaParado
        {
            get
            {
                return !podeAndar;
            }
        }

        public Vendedor(Image novaSkin, Point novaCoordenada)
        {
            this.skin = new Figura(novaSkin);
            this.coord = novaCoordenada;
        }

        public void desenhar(Graphics g)
        {
            g.DrawImage(skin.Img, coord);
        }

        /* direcao= 1 ou direcao= -1 para o player andar para frente ou para trás */
        public void andar(int direcao)
        {
            andar(direcao, 1);
        }

        /* è possível juntar as duas variáveis, mas assim é melhor para o entendimento inicial da função */
        public void andar(int direcao, int velocidade)
        {
            this.coord.X += 5 * direcao * velocidade;
            if (direcao >= 0)
                this.Skin.Invertido = false;
            else
                this.Skin.Invertido = true;
        }
    }
}
