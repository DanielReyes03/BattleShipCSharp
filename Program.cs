using System;

namespace Proyecto_Naval
{
    class Program
    {
        private string barco = "barco";
        private string[] barcoj1 = {"2","2","H","4"};
        private string[] barcoj2 = {"6","1","H","4"};
        private string[] barcoj3 = {"8","5","H","2"};
        private string[] barcoj4 = {"2","8","V","3"};
        private string[] barcoj5 = {"6","9","V","4"};

        static void Main(string[] args)
        {
            matrizJugador();
        }

        public static void matrizInicial(){
            Program instancia = new Program();
            string[,] tablero = new string[10,9];
            tablero[2, 5] = instancia.barco;
            //Comienza la construccion de la tabla
            for (int f = 0; f < tablero.GetLength(0); f++){
                Console.Write(f+1 + " | ");
                for (int c = 0; c < tablero.GetLength(1); c++){
                    //Valor de la tabla inicial
                    tablero[f,c] = " . ";
                    //Como se separara los caracteres
                    Console.Write(tablero[f,c]);
                }
                Console.WriteLine();
            }
            //Termina construccion de tabla
        } 
        public static void matrizJugador(){
            Program instancia = new Program();
            string[,] matrizJugador =  new string[10,9];   
            for (int f = 0; f < matrizJugador.GetLength(0); f++){
                Console.Write(f + " | ");
                for (int c = 0; c < matrizJugador.GetLength(1); c++){
                    //Valor de la tabla inicial
                    matrizJugador[f,c] = " . ";
                    //Como se separara los caracteres
                    int x = int.Parse(instancia.barcoj1[0]);
                    int y = int.Parse(instancia.barcoj1[1]);
                    matrizJugador[x,y]=" - ";
                    Console.Write(matrizJugador[f,c]);
                }
                Console.WriteLine();
            }
        }


    }
}
