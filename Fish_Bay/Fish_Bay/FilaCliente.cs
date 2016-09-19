using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fish_Bay
{
    class FilaCliente
    {
        private Cliente[] clientes;
        private Point limite;
        private const int LARGURA_NPC = 34;
        private bool primeira = true;
        private int tam ;

        public Cliente[] Clientes
        {
            get
            {
                return clientes;
            }

            set
            {
                clientes = value;
            }
        }

        public Point Limite
        {
            get
            {
                return limite;
            }

            set
            {
                limite = value;
            }
        }

        public FilaCliente(Cliente[] novosClientes, Point novoLimite)
        {
            this.Clientes = novosClientes;
            this.Limite = novoLimite;
        }

        public FilaCliente(Cliente[] novosClientes, Point novoLimite, int tama)
        {
            this.Clientes = novosClientes;
            this.Limite = novoLimite;
            this.tam = tama;
        }

        public Cliente Primeiro()
        {           
            MessageBox.Show(Convert.ToString(tam));
            return clientes[tam];
            
        }
        public void andar()
        {
            for (int i = 0; i < clientes.Length; i++)
                if(this.clientes[i].PodeAndar)
                if (this.clientes[i].Coord.X < this.limite.X) this.clientes[i].andar();
                else this.limite = new Point(this.limite.X - LARGURA_NPC, 0);
        }

        public bool querPeixe()
        {
            for (int i = 0; i < clientes.Length; i++)
                if (this.clientes[i].Coord.X>=this.limite.X)
                    return true;
            return false;
        }
    }
}
