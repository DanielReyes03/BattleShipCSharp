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
            string[,] matrizJugador =  new string[10,9+1];   
            for (int f = 0; f < matrizJugador.GetLength(0); f++){
                Console.Write(f + " | ");
                for (int c = 1; c < matrizJugador.GetLength(1); c++){
                    //Valor de la tabla inicial
                    matrizJugador[f,c] = " . ";
                    //Como se separara los caracteres
                    //Barco 1
                    int bx1 = int.Parse(instancia.barcoj1[0]);
                    int by1 = int.Parse(instancia.barcoj1[1]);
                    //Barco 2
                    int bx2 = int.Parse(instancia.barcoj2[0]);
                    int by2 = int.Parse(instancia.barcoj2[1]);
                    //Barco 3
                    int bx3 = int.Parse(instancia.barcoj3[0]);
                    int by3 = int.Parse(instancia.barcoj3[1]);
                    //Barco 4
                    int bx4 = int.Parse(instancia.barcoj4[0]);
                    int by4 = int.Parse(instancia.barcoj4[1]);
                    //Barco 5
                    int bx5 = int.Parse(instancia.barcoj5[0]);
                    int by5 = int.Parse(instancia.barcoj5[1]);
                    matrizJugador[bx1,by1]=" b ";
                    matrizJugador[bx2,by2]=" b ";
                    matrizJugador[bx3,by3]=" b ";
                    matrizJugador[bx4,by4]=" b ";
                    matrizJugador[bx5,by5]=" b ";
                    Console.Write(matrizJugador[f,c]);
                }
                Console.WriteLine();
            }
        }


    }
}
