using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Bay
{
    public class ControladorPeixe
    {
        // constantes
        public const int 
            LIMITE_PEIXES = 7,
            LARGURA_PEIXE = 56,
            LARGURA_BOTA = 44,
            ALTURA_BOTA = 36,
            ALTURA_PEIXE = 22,
            LARGURA_DOURADO = 26,
            ALTURA_DOURADO = 14;

        // vetores de peixes
        private Peixe[] peixes, peixesPescados, peixePescando;

        // quantidades
        private int qtosPeixesNadando, qtosPeixesPescando, qtosPeixesPescados;

        // posição do primeiro(debaixo) peixe da fila
        private Point posicaoMinima;

        // Propriedade do vetor de peixesNadando
        public Peixe[] Peixes
        {
            get
            {
                return peixes;
            }

            set
            {
                peixes = value;
            }
        }

        // Propriedade do vetor de peixesPescados
        public Peixe[] PeixesPescados
        {
            get
            {
                return peixesPescados;
            }

            set
            {
                peixesPescados = value;
            }
        }

        // Propriedade do vetor de peixesPescando
        public Peixe[] PeixePescando
        {
            get
            {
                return peixePescando;
            }

            set
            {
                peixePescando = value;
            }
        }

        // Propriedade de quantos peixes estão sendo utilizados e nadando
        public int QtosPeixesNadando
        {
            get
            {
                return qtosPeixesNadando;
            }

            set
            {
                qtosPeixesNadando = value;
            }
        }

        // Propriedade de quantos peixes estão sendo utilizados e pescados
        public int QtosPeixesPescados
        {
            get
            {
                return qtosPeixesPescados;
            }

            set
            {
                qtosPeixesPescados = value;
            }
        }

        // Propriedade de quantos peixes estão sendo utilizados e pescando
        public int QtosPeixesPescando
        {
            get
            {
                return qtosPeixesPescando;
            }

            set
            {
                qtosPeixesPescando = value;
            }
        }

        /**
        * Faz os peixes nadarem em uma proporção parecida
        *   param randomico -> número randômico aí
        */
        public void nadem(int randomico)
        {
            Random rand = new Random();
            for (int i = 0; i < qtosPeixesNadando; i++)
                peixes[i].nadar(randomico+rand.Next(1, 3));
        }

        /**
        * Desenha todos os peixes dos 3 vetores
        *   param g -> Gráfico para desenho
        *   param vara -> Coordenada da vara para desenhar o peixe pescado
        */
        public void desenharTodos(Graphics g, Point vara)
        {
            // desenhando os peixes que estão nadando
            for (int i = 0; i < qtosPeixesNadando; i++)
                peixes[i].Skin.desenhar(g, peixes[i].Coord);
            
            // desenhando os peixes que esntão na mesa
            for (int ind = 0; ind < QtosPeixesPescados; ind++)
                peixesPescados[ind].Skin.desenhar(g, new Point(this.posicaoMinima.X, ondeDesenharPilhaNoIndice(ind)));

            // desenhando o peixe que está na vara
            if (this.peixePescando[0] != null)
                g.DrawImage(Figura.RotateImage(this.peixePescando[0].Skin.Img), new Point(vara.X - 12,vara.Y));
            
        }

        /**
        * Verifica se há a possibilidade de pescar algum peixe, caso tenha ele é pescado
        *   param vara -> Coordenada da vara para ver se "está" em algum peixe
        */
        public void verSePescouAlgumPeixe(Point vara)
        {
            for (int i = 0; i < this.qtosPeixesNadando; i++)
            {
                if (!this.peixes[i].Pescado)
                {
                    if (this.peixes[i].pescou(new Point(vara.X - 10, vara.Y + 12), ALTURA_PEIXE))
                        this.pescarPeixeNoIndice(i);
                }
            }
        }

        /**
        * Remove o peixe do vetor de "nadando" e adiciona um igual no "pescaNdo"
        *   param index -> ìndice do peixe que irá para a vara
        */
        public void pescarPeixeNoIndice(int index)
        {
            // vendo se o index está no vetor
            if (index < 0 || index >= this.qtosPeixesNadando || this.peixePescando[0] != null)
                return;

            this.adicionarPescando(this.PegarOQueEstaNadando(index));
        }

        /**
        * Remove do vetor de "pescaNdo" e adiciona em "pescado"(quando vai botar na mesa)
        * 
        */

        public bool podeBotarNaMesa()
        {
            if (this.peixePescando[0] != null)
                return true;

            return false;
        }
        public void botarNaMesa()
        {
            if (this.peixePescando[0] != null)
                this.adicionarPescado(this.removerPescando());
        }

        /**
        * Adiciona um novo peixe ao vetor de "pescado"
        *   param peixe -> O peixe a ser pescado
        */
        private void adicionarPescado(Peixe peixe)
        {
            if (peixe != null)
                this.peixesPescados[this.QtosPeixesPescados++] = peixe.clone();
        }

        /**
        * Reseta o peixe pêgo e retorna um clone dele
        *   param - index -> Contém o índice do peixe no vetor de peixesNadando
        */
        private Peixe PegarOQueEstaNadando(int index)
        {
            Peixe aux = this.peixes[index].clone();
            Random rand = new Random();
            if(index ==6)
                this.peixes[index] = new Peixe(new Point(-LARGURA_PEIXE - rand.Next(1500, 9000), rand.Next(380, 530)), 1, this.peixes[index].Skin, aux.Dourado);
            else
            this.peixes[index] = new Peixe(new Point(-LARGURA_PEIXE - rand.Next(1500, 3500), rand.Next(380, 530)), 1, this.peixes[index].Skin, aux.Dourado);
            return aux;
        }

        /**
        * adiciona um peixe à mesa
        *   param outro -> Contém o peixe a ser adicionado
        */
        private void adicionarPescando(Peixe outro)
        {
            outro.Pescado = true;
            this.peixePescando[0] = outro.clone();
            this.qtosPeixesPescando++;
        }

        /**
        * Remove o peixe que está na vara
        *   
        */
        public Peixe removerPescando()
        {
            if (this.qtosPeixesPescados < 6)
            {
                Peixe aux = this.peixePescando[0].clone();
                this.peixePescando[0] = null;
                this.qtosPeixesPescando--;
                return aux;
            }
            return null;
        }

        /**
        * Retira o peixe do topo da mesa
        *   
        */
        public Peixe tirarDaMesaPeixeDoTopo()
        {
            if (this.qtosPeixesPescados > 0)
                return removerPescado();
            return null; // nunca cairá aqui
        }

        /**
        * Remove o peixe do vetor de pescados
        *   Normalmente utilizado quando o vendedor pega um peixe
        */
        private Peixe removerPescado()
        {
            Peixe aux = peixesPescados[this.QtosPeixesPescados - 1];
            peixesPescados[this.QtosPeixesPescados - 1] = null;
            this.qtosPeixesPescados--;
            return aux;
        }

        /**
        * Função que retorna o lugar onde será desenhado um tal peixe
        *   param index -> Contém o índice do peixe que será desenhado
        */
        private int ondeDesenharPilhaNoIndice(int index)
        {
            return (this.posicaoMinima.Y) - (ALTURA_PEIXE+1) * index;
        }

        /**
        * Limpa o vetor de pescados
        *   
        */
        public void limparMesa()
        {
            for (int i = QtosPeixesPescados; i > 0; i--)
                this.removerPescado();
        }

        /**
        * Construtor único da classe
        *   param novosPeixes -> Vetor de peixes que contém os peixes possíveis
        *   param novaPosicaoMinima -> Contém a posição mínima de um peixe pescado
        */
        public ControladorPeixe(Peixe[] novosPeixes, Point novaPosicaoMinima)
        {
            this.peixes = novosPeixes;
            this.qtosPeixesNadando = novosPeixes.Length;
            this.peixesPescados = new Peixe[this.qtosPeixesNadando];
            this.posicaoMinima = novaPosicaoMinima;
            this.peixePescando = new Peixe[1];
        }
    }
}
