

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Timers;




namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //Tamaño es el numero de nodos que entran  en el tablero y escala el numero de pixeles de cada uno
        //coordendadas es un array temporal
        private int _tamaño = 20;
        private int escala;
        private Juego partida ;
        private int _direccion;
        private int[] _coordenadas;
        Nodo n;

        public Form1()
        
        {
            InitializeComponent();
            timer1.Start();
            partida = new Juego(_tamaño);
        }

        // p pausa el juego y n crea una nueva partida, los movimientos se generan con las teclas de direccion
        private void Form1_Key(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Up)
            {
                _direccion=3;
            }

            if (e.KeyData == Keys.Right)
            {
                _direccion=0;               
            }
           
            if (e.KeyData == Keys.Down)
            {
                _direccion=1; 
            }

            
            if (e.KeyData == Keys.Left)
            {
                _direccion=2; 
            }

            if (e.KeyData == Keys.P)
            { 
                
                if (timer1.Enabled == true)
                    timer1.Enabled = false;
                else
                    timer1.Enabled = true;
            }
            if (e.KeyData == Keys.N)
            {
                timer1.Stop();
                partida = new Juego(_tamaño);
               timer1.Start();
            }


        }
        //pinta el picturebox con la serpiente, el tablero o la comida
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            _coordenadas=new int[2];
            escala = pictureBox1.Width / _tamaño;
            Graphics lienzo;
            lienzo = e.Graphics; 
            _coordenadas= partida.Comida;
            
           
            
            System.Collections.IEnumerator ent = partida.Tablero.GetEnumerator();
            System.Collections.IEnumerator ens = partida.CuerpoSerpiente.GetEnumerator();
            while (ent.MoveNext())
            {
                
                _coordenadas = (int[])ent.Current;
                lienzo.FillRectangle(Brushes.Red, _coordenadas[0] * escala, _coordenadas[1] * escala, escala, escala);
                
            }

            while (ens.MoveNext())
            {
                n = (Nodo)ens.Current;
                lienzo.FillRectangle(Brushes.Green, n.X * escala, n.Y * escala, escala, escala);

            }


            _coordenadas = partida.Comida;
            lienzo.FillRectangle(Brushes.Blue, _coordenadas[0] * escala, _coordenadas[1] * escala, escala, escala);
            lienzo.DrawString(partida.cantidadComida.ToString(), new Font("Arial", 12), Brushes.Yellow, _coordenadas[0] * escala, _coordenadas[1] * escala);




            if (partida.Fin)
                lienzo.DrawString("GAME OVER", new Font("Arial", 12), Brushes.Yellow, 1, 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void cambiarDireccion(int direccion ) {
            partida.cambiardireccion(direccion);
                }


      //  Cada tick del reloj cambia la direccion (sim procede) y actualiza la serpiente y el picturebox
        private void timer1_Tick(object sender, EventArgs e)
        {
            cambiarDireccion(_direccion);
            partida.actualizar(sender, e);
            pictureBox1.Refresh();

            if (partida.Fin)
            {
                timer1.Stop();
            }


        }
    
    }
}
