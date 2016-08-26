using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Bay
{
    public class Figura
    {
        private Point coord;
        private Image img;

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

        public Image Img
        {
            get
            {
                return img;
            }

            set
            {
                img = value;
            }
        }

        public Figura(Image novaFigura, Point novaCoordenada)
        {
            this.coord = novaCoordenada;
            this.img = novaFigura;
        }

        public Figura() : this(null , default(Point))
        {
        }

        public Figura(Image novaFigura) : this(novaFigura, default(Point))
        {
        }

        public Figura(Point novaCoordenada) : this(null, novaCoordenada)
        {
        }

        public void desenhar(Graphics g)
        {
            g.DrawImage(this.img, this.coord);
        }
    }
}
