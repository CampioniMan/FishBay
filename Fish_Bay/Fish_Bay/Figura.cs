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
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }
    }
}
