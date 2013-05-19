using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{   
    /// <summary>
    /// Nodo es cada elemento de la Serpiente , almacenan la posicion en _x e _y
    /// Nodo esta relacionado con serpiente en relacion 1 a N
    /// </summary>
    class Nodo
    {
        private int _x, _y;
      
        public Nodo(int x, int y) {
            _x=x;
            _y=y;
        }

        public int X {
            get { return _x; }
            set { _x = value; }
        }

        public int Y {
            get { return _y; }
            set { _y = value; }
        }
    }
}
