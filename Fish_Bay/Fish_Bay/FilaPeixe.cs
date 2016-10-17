using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Bay
{
    class FilaPeixe
    {
        private Peixe[] pescados;
        private int posicao;

        public Peixe[] Pescados
        {
            get
            {
                return pescados;
            }

            set
            {
                pescados = value;
            }
        }

        public int Posicao
        {
            get
            {
                return posicao;
            }

            set
            {
                posicao = value;
            }
        }

        public FilaPeixe()
        {
            this.pescados = new Peixe[6];
            posicao = 0;
        }

        public int armazenar(Peixe peixe, int posMesa)
        {
            pescados[posicao] = peixe;
            pescados[posicao++].PosMesa = posMesa;
            return posMesa -= 23;
        }

        public int retirar()
        {
            int posMesa = pescados[--posicao].PosMesa;
            pescados[posicao--] = null;
            return posMesa += 23;
        }

        public bool estaCheio()
        {
            return Posicao < Pescados.Length;
        }
    }
}
