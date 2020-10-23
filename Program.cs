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
            int filas = 10;
            int columnas = 9;
            string[,] matrizJugador =  new string[filas+1,columnas+1];   
            for (int f = 1; f < matrizJugador.GetLength(0); f++){
                Console.Write(f + " | ");
                for (int c = 1; c < matrizJugador.GetLength(1); c++){
                    //Valor de la tabla inicial
                    matrizJugador[f,c] = " . ";
                    //Variables de barcos
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
                    //Validaciones para imprimir los barcos
                    //Validacion barco 1
                    if(bx1 >= matrizJugador.GetLength(0) || by1 >= matrizJugador.GetLength(1)){
                        Console.WriteLine("Parece que el barco no cabe");
                    }else{
                        if(bx1 == bx2 && bx1 == bx3 && bx1 == bx4 && bx1 == bx5 && by1 == by2 && by1 == by3 && by1 == by4 && by1 == by5){
                            Console.WriteLine("Parece que el barco esta duplicado");

                        }else{
                            matrizJugador[bx1,by1]=" B ";
                        }
                    }
                    //Validacion barco 2
                    if(bx2 >= matrizJugador.GetLength(0) || by2 >= matrizJugador.GetLength(1)){
                        Console.WriteLine("Parece que el barco no cabe");
                    }else{
                         if(bx2 == bx1 && bx2 == bx3 && bx2 == bx4 && bx2 == bx5 && by2 == by1 && by2 == by3 && by2 == by4 && by2 == by5){
                            Console.WriteLine("Parece que el barco esta duplicado");

                        }else{
                            matrizJugador[bx2,by2]=" B ";
                        }
                    }
                    //Validacion barco 3
                    if(bx3 >= matrizJugador.GetLength(0) || by3 >= matrizJugador.GetLength(1)){
                        Console.WriteLine("Parece que el barco no cabe");
                    }else{
                         if(bx3 == bx1 && bx3 == bx2 && bx3 == bx4 && bx3 == bx5 && by3 == by1 && by3 == by2 && by3 == by4 && by3 == by5){
                            Console.WriteLine("Parece que el barco esta duplicado");

                        }else{
                            matrizJugador[bx3,by3]=" B ";
                        }
                    }
                    //Validacion barco 4
                    if(bx4 >= matrizJugador.GetLength(0) || by4 >= matrizJugador.GetLength(1)){
                        Console.WriteLine("Parece que el barco no cabe");
                    }else{
                         if(bx4 == bx1 && bx4 == bx2 && bx4 == bx3 && bx4 == bx5 && by4 == by1 && by4 == by2 && by4 == by3 && by4 == by5){
                            Console.WriteLine("Parece que el barco esta duplicado");

                        }else{
                            matrizJugador[bx4,by4]=" B ";
                        }
                    }
                    //Validacion barco 5
                    if(bx5 >= matrizJugador.GetLength(0) || by5 >= matrizJugador.GetLength(1)){
                        Console.WriteLine("Parece que el barco no cabe");
                    }else{
                        if(bx5 == bx1 && bx5 == bx2 && bx5 == bx3 && bx5 == bx4 && by5 == by1 && by5 == by2 && by5 == by3 && by5 == by4){
                            Console.WriteLine("Parece que el barco esta duplicado");
                        }else{
                            matrizJugador[bx5,by5]=" B ";
                        }
                    }
                    Console.Write(matrizJugador[f,c]);
                }
                Console.WriteLine();
            }
        }
    // //Por si sirve
    //                 int bx1 = int.Parse(instancia.barcoj1[0]);
    //                 int by1 = int.Parse(instancia.barcoj1[1]);
    //                 //Barco 2
    //                 int bx2 = int.Parse(instancia.barcoj2[0]);
    //                 int by2 = int.Parse(instancia.barcoj2[1]);
    //                 //Barco 3
    //                 int bx3 = int.Parse(instancia.barcoj3[0]);
    //                 int by3 = int.Parse(instancia.barcoj3[1]);
    //                 //Barco 4
    //                 int bx4 = int.Parse(instancia.barcoj4[0]);
    //                 int by4 = int.Parse(instancia.barcoj4[1]);
    //                 //Barco 5
    //                 int bx5 = int.Parse(instancia.barcoj5[0]);
    //                 int by5 = int.Parse(instancia.barcoj5[1]);
    //                 matrizJugador[bx1,by1]=" B ";
    //                 matrizJugador[bx2,by2]=" B ";
    //                 matrizJugador[bx3,by3]=" B ";
    //                 matrizJugador[bx4,by4]=" B ";
    //                 matrizJugador[bx5,by5]=" B ";

    }
}
