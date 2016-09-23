using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Bay
{
    public class Figura
    {
        private Image img;
        private bool ehInvertido;

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

        public bool Invertido
        {
            get
            {
                return ehInvertido;
            }

            set
            {
                ehInvertido = value;
            }
        }

        public Figura(Image novaFigura, bool novoEhInverso)
        {
            this.img = novaFigura;
            this.ehInvertido = novoEhInverso;
        }

        public Figura(Image novaFigura) : this(novaFigura, false)
        {
        }

        public Figura(bool novoEhInverso) : this(null, novoEhInverso)
        {
        }

        public Figura() : this(null , false)
        {
        }

        public void desenhar(Graphics g, Point desenhar)
        {
            if (!ehInvertido)
                g.DrawImage(this.img, desenhar);
            else
                desenharReflexo(g, desenhar);
        }

        protected void desenharReflexo(Graphics g, Point ondeDesenhar)
        {
            int cxImage = img.Width;
            int cyImage = img.Height;
            
            g.DrawImage(img, ondeDesenhar.X, ondeDesenhar.Y, -cxImage, cyImage);
        }

        public static Image RotateImage(Image img, float rotationAngle)
        {
            var bmp = new Bitmap(img);

            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.Clear(Color.Transparent);
                gfx.DrawImage(img, 0, 0, img.Width, img.Height);
            }

            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
            return bmp;
        }
    }
}
