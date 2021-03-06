﻿using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
namespace Proyecto_Naval
{
    class Program
    {   
        private string[] jugador = {"0",""};
        private string[] computadora = {"0","Richard BOT"};
        private string jugadorOut = "/Users/jose/Desktop/Jose/Tutorias/Andres c#/Proyecto_Naval/puntosJugadorOut.txt";
        private string oponenteOut = "/Users/jose/Desktop/Jose/Tutorias/Andres c#/Proyecto_Naval/puntosOponenteOut.txt";
        private string puntosJugador = "/Users/jose/Desktop/Jose/Tutorias/Andres c#/Proyecto_Naval/puntosJugador.txt";
        private string puntosOponente = "/Users/jose/Desktop/Jose/Tutorias/Andres c#/Proyecto_Naval/puntosOponente.txt";
        private string configJugador = "/Users/jose/Desktop/Jose/Tutorias/Andres c#/Proyecto_Naval/jugador.txt";
        private string configOponente ="/Users/jose/Desktop/Jose/Tutorias/Andres c#/Proyecto_Naval/oponente.txt" ;
        private string ataquesOponente = "/Users/jose/Desktop/Jose/Tutorias/Andres c#/Proyecto_Naval/AtaquesOponente.txt";
        private string ataquesJugador = "/Users/jose/Desktop/Jose/Tutorias/Andres c#/Proyecto_Naval/AtaquesJugador.txt";
        static void Main(string[] args)
        {        
        Menu();
        }
         public static void Menu(){
            Console.WriteLine("Bienvenido a mi juego");
            Console.WriteLine("Opciones");
            Console.WriteLine("1. Jugar");
            Console.WriteLine("2. Como Jugar");
            Console.WriteLine("3. Salir");
            int decision = int.Parse(Console.ReadLine()); //Leyendo Decision de la persona
            switch (decision)
            {
                // Si la persona escribe 1 entrara aqui
                case 1:
                    ObtenerDatos();
                break;
                // Si la persona escribe 2 entrara aqui
                case 2:
                    Console.WriteLine("Case 2");
                break;
                // Si la persona escribe 3 entrara aqui
                case 3:
                Environment.Exit(0);
                break;
                // Si ninguno de estos se cumple 
                default:
                    Console.WriteLine("Porfavor ponga un numero valido");
                break;
            }
        }

        public static void ObtenerDatos(){
            Limpiarpantalla();
            Program jugadores = new Program();
            Console.WriteLine("Hola tu sera el jugador dime tu nombre");
            jugadores.jugador[0] =  Console.ReadLine().ToLower();
            Limpiarpantalla();
            Console.WriteLine("Hola bienvenido al juego");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Hola " + jugadores.jugador[1] + " Tu puntaje inicial es " + jugadores.jugador[0]);
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Hola " + jugadores.computadora[1] + " Tu puntaje inicial es " + jugadores.computadora[0]);
            GenerarJuego(jugadores.jugador[0], jugadores.computadora[1]);
        }
        public static void GenerarJuego(string jugador, string computadora){
            try{
            Program instancia = new Program();
            int totalBarcosOponente = int.Parse(ObtenerTotalBarcos(instancia.configOponente));
            while(AciertosTotales() <= totalBarcosOponente && IntentosFallidos() != 3){
                Console.WriteLine("----------------------------------------");
                instruccionesJugador();
                Limpiarpantalla();
                instruccionesOponente();
                Limpiarpantalla();
            }
            PantallaFinal();
            }catch(FileNotFoundException){
                PantallaFinal();
            }
        }

        public static void instruccionesJugador(){
            Program instancia = new Program();
            Console.WriteLine("ES TU TURNO JUGADOR " + instancia.jugador[0]);
            Console.WriteLine("----------------JUGADOR------------------------");
            GenerarTXTJugador();
            Console.WriteLine("----------------OPONENTE------------------------");
            GenerarTXTOponente(1);
            Console.WriteLine("Que cordenada deseas ?");
            string[] CordenadaDeAtaque = Console.ReadLine().Split(",");
            string t = string.Join(",",CordenadaDeAtaque);
            if(t.ToUpper() == "S"){
                Console.WriteLine("Saliendo del juego");
                Environment.Exit(0);
            }else{
            ModificarTxtJugador(CordenadaDeAtaque);
            }
        }
        public static void instruccionesOponente(){
            Program instancia = new Program();
            Console.WriteLine("ES UN TU TURNO OPONENTE " + instancia.computadora[0]);
            Console.WriteLine("----------------JUGADOR------------------------");
            GenerarTXTJugador();
            Console.WriteLine("----------------OPONENTE------------------------");
            GenerarTXTOponente(1);
            string[] CordenadaDeAtaqueOponente = cordenadaRandom().Split(",");
            Console.WriteLine("Cordenada elegida automaticamente " + CordenadaDeAtaqueOponente[0] + "," +CordenadaDeAtaqueOponente[1]);
            ModificarTxtOponente(CordenadaDeAtaqueOponente);
            Console.WriteLine("Presione enter para continuar");
            Console.ReadLine();
        }

        public static void matrizJugador(string[] dimnesionOponente, string[] barcoO1,string[] barcoO2,string[] barcoO3,string[] barcoO4,string[] barcoO5){
            Program instancia = new Program();
            string db = instancia.ataquesOponente;
            string coxJ1 = barcoO1[0];
            string coyJ2 = barcoO1[1];
            string cobxJ2 = barcoO2[0];
            string cobyJ2 =  barcoO2[1];
            string cobxJ3 = barcoO3[0];
            string cobyJ3 = barcoO3[1];
            string cobxJ4 = barcoO4[0];
            string cobyJ4 = barcoO4[1];
            string cobxJ5 = barcoO5[0];
            string cobyJ5 = barcoO5[1];
            string cordenadasBarcoJ1 = coxJ1+","+coyJ2;
            string cordenadasBarcoJ2 = cobxJ2+","+cobyJ2;
            string cordenadasBarcoJ3 = cobxJ3+","+cobyJ3;
            string cordenadasBarcoJ4 = cobxJ4+","+cobyJ4;
            string cordenadasBarcoJ5 = cobxJ5+","+cobyJ5;
            int filas = int.Parse(dimnesionOponente[0]);
            int columnas = int.Parse(dimnesionOponente[1]);
            string[,] matrizJugador =  new string[filas,columnas];
            Console.WriteLine("     1  2  3  4  5  6  7  8  9");
            for (int f = 1; f < matrizJugador.GetLength(0); f++){
                Console.Write(f + " | ");
                for (int c = 1; c < matrizJugador.GetLength(1); c++){
                    //Valor de la tabla inicial
                    matrizJugador[f,c] = " . ";
                    //Variables de barcos
                    int bxo1 = int.Parse(barcoO1[0]);
                    int byo1 = int.Parse(barcoO1[1]);
                    //Barco 2
                    int bxo2 = int.Parse(barcoO2[0]);
                    int byo2 = int.Parse(barcoO2[1]);
                    //Barco 3
                    int bxo3 = int.Parse(barcoO3[0]);
                    int byo3 = int.Parse(barcoO3[1]);
                    //Barco 4
                    int bxo4 = int.Parse(barcoO4[0]);
                    int byo4 = int.Parse(barcoO4[1]);
                    //Barco 5
                    int bxo5 = int.Parse(barcoO5[0]);
                    int byo5 = int.Parse(barcoO5[1]);
                    //Validaciones para imprimir los barcos
                        //Validacion barco 1
                            //Validacion de que no quepa
                    if(bxo1 >= matrizJugador.GetLength(0) || byo1 >= matrizJugador.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.2 no cabe en el tablero del oponente");
                    }else{ 
                        //Validacion de que no este repetido
                        if(bxo1 == bxo2 && bxo1 == bxo3 && bxo1 == bxo4 && bxo1 == bxo5 && byo1 == byo2 && byo1 == byo3 && byo1 == byo4 && byo1 == byo5){
                            Console.WriteLine("Parece que el barco no.1 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO1[3]) == 2){
                                //Validacion de horizontal y posiciones
                               if(barcoO1[2] == "H"){
                                   matrizJugador[bxo1,byo1] = " B1 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1;
                                        int b = byo1+i;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizJugador[bxo1,byo1+i] = " X ";
                                            AgregarPuntoOponente(z);
                                        }else{
                                            matrizJugador[bxo1,byo1+i] = " B1 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarcoJ1)){
                                         matrizJugador[bxo1+1,byo1] = " X ";
                                         AgregarPuntoOponente(cordenadasBarcoJ1);
                                     }
                                }else if(barcoO1[2] == "V"){
                                    //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1+i;
                                        int b = byo1;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizJugador[bxo1+i,byo1] = " X ";
                                            AgregarPuntoOponente(z);
                                        }else{
                                            matrizJugador[bxo1+i,byo1] = " B1 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarcoJ1)){
                                        matrizJugador[bxo1,byo1] = " X ";
                                        AgregarPuntoOponente(cordenadasBarcoJ1);
                                    }
                                }
                            }else if(int.Parse(barcoO1[3]) == 3){
                               if(barcoO1[2] == "H"){
                                   matrizJugador[bxo1,byo1] = " B1 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1;
                                        int b = byo1+i;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizJugador[bxo1,byo1+i] = " X ";
                                            AgregarPuntoOponente(z);
                                        }else{
                                            matrizJugador[bxo1,byo1+i] = " B1 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarcoJ1)){
                                         matrizJugador[bxo1+1,byo1] = " X ";
                                         AgregarPuntoOponente(cordenadasBarcoJ1);
                                     }
                                }else if(barcoO1[2] == "V"){
                                    //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1+i;
                                        int b = byo1;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizJugador[bxo1+i,byo1] = " X ";
                                            AgregarPuntoOponente(z);
                                        }else{
                                            matrizJugador[bxo1+i,byo1] = " B1 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarcoJ1)){
                                        matrizJugador[bxo1,byo1] = " X ";
                                        AgregarPuntoOponente(cordenadasBarcoJ1);
                                    }
                                }
                            }else if(int.Parse(barcoO1[3]) == 4){
                                if(barcoO1[2] == "H"){
                                   matrizJugador[bxo1,byo1] = " B1 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1;
                                        int b = byo1+i;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizJugador[bxo1,byo1+i] = " X ";
                                            AgregarPuntoOponente(z);
                                        }else{
                                            matrizJugador[bxo1,byo1+i] = " B1 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarcoJ1)){
                                         matrizJugador[bxo1,byo1] = " X ";
                                         AgregarPuntoOponente(cordenadasBarcoJ1);
                                     }
                                }else if(barcoO1[2] == "V"){
                                    //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1+i;
                                        int b = byo1;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizJugador[bxo1+i,byo1] = " X ";
                                            AgregarPuntoOponente(z);
                                        }else{
                                            matrizJugador[bxo1+i,byo1] = " B1 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarcoJ1)){
                                        matrizJugador[bxo1,byo1] = " X ";
                                        AgregarPuntoOponente(cordenadasBarcoJ1);
                                    }
                                }
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 1 del oponente del oponente");
                            }
                        }
                    }
                    //Validacion barco 2
                        //Validacion de que no quepa
                    if(bxo2 >= matrizJugador.GetLength(0) || byo2 >= matrizJugador.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.2 no cabe en el tablero del oponente");
                    }else{
                        //Validacion de que no este repetido
                         if(bxo2 == bxo1 && bxo2 == bxo3 && bxo2 == bxo4 && bxo2 == bxo5 && byo2 == byo1 && byo2 == byo3 && byo2 == byo4 && byo2 == byo5){
                            Console.WriteLine("Parece que el barco no.2 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO2[3]) == 2){
                                if(barcoO2[2] == "H"){
                                    matrizJugador[bxo2,byo2] = " B2 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2;
                                        int b2 = byo2+i;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizJugador[bxo2,byo2+i] = " X ";
                                            AgregarPuntoOponente(z2);
                                        }else{
                                            matrizJugador[bxo2,byo2+i] = " B2 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarcoJ2)){
                                         matrizJugador[bxo2+1,byo2] = " X ";
                                         AgregarPuntoOponente(cordenadasBarcoJ2);
                                     }
                                }else if(barcoO2[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2+i;
                                        int b2 = byo2;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizJugador[bxo2+i,byo2] = " X ";
                                            AgregarPuntoOponente(z2);
                                        }else{
                                            matrizJugador[bxo2+i,byo2] = " B2 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarcoJ2)){
                                        matrizJugador[bxo1,byo1] = " X ";
                                        AgregarPuntoOponente(cordenadasBarcoJ2);
                                    }
                                }
                            }else if(int.Parse(barcoO2[3]) == 3){
                                 if(barcoO2[2] == "H"){
                                    matrizJugador[bxo2,byo2] = " B2 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2;
                                        int b2 = byo2+i;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizJugador[bxo2,byo2+i] = " X ";
                                            AgregarPuntoOponente(z2);
                                        }else{
                                            matrizJugador[bxo2,byo2+i] = " B2 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarcoJ2)){
                                         matrizJugador[bxo2,byo2] = " X ";
                                         AgregarPuntoOponente(cordenadasBarcoJ2);
                                     }
                                }else if(barcoO2[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2+i;
                                        int b2 = byo2;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizJugador[bxo2+i,byo2] = " X ";
                                            AgregarPuntoOponente(z2);
                                        }else{
                                            matrizJugador[bxo2+i,byo2] = " B2 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarcoJ2)){
                                        matrizJugador[bxo2,byo2] = " X ";
                                        AgregarPuntoOponente(cordenadasBarcoJ2);
                                    }
                                }
                            }else if(int.Parse(barcoO2[3]) == 4){
                                 if(barcoO2[2] == "H"){
                                    matrizJugador[bxo2,byo2] = " B2 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2;
                                        int b2 = byo2+i;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizJugador[bxo2,byo2+i] = " X ";
                                            AgregarPuntoOponente(z2);
                                        }else{
                                            matrizJugador[bxo2,byo2+i] = " B2 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarcoJ2)){
                                         matrizJugador[bxo2,byo2] = " X ";
                                         AgregarPuntoOponente(cordenadasBarcoJ2);
                                     }
                                }else if(barcoO2[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2+i;
                                        int b2 = byo2;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizJugador[bxo2+i,byo2] = " X ";
                                            AgregarPuntoOponente(z2);
                                        }else{
                                            matrizJugador[bxo2+i,byo2] = " B2 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarcoJ2)){
                                        matrizJugador[bxo2,byo2] = " X ";
                                        AgregarPuntoOponente(cordenadasBarcoJ2);
                                    }
                                }
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 2 del oponente del oponente");
                            }
                        }
                    }
                    //Validacion barco 3
                        //Validacion de que no quepa
                    if(bxo3 >= matrizJugador.GetLength(0) || byo3 >= matrizJugador.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.3 no cabe en el tablero del oponente");
                    }else{
                            //Validacion de que no este repetido
                         if(bxo3 == bxo1 && bxo3 == bxo2 && bxo3 == bxo4 && bxo3 == bxo5 && byo3 == byo1 && byo3 == byo2 && byo3 == byo4 && byo3 == byo5){
                            Console.WriteLine("Parece que el barco no.3 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO3[3]) == 2){
                                if(barcoO3[2] == "H"){
                                    matrizJugador[bxo3,byo3] = " B3 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO3[3]); i++)
                                    {
                                        int a3 = bxo3;
                                        int b3 = byo3+i;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizJugador[bxo3,byo3+i] = " X ";
                                            AgregarPuntoOponente(z3);
                                        }else{
                                            matrizJugador[bxo3,byo3+i] = " B3 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarcoJ3)){
                                         matrizJugador[bxo3,byo3] = " X ";
                                         AgregarPuntoOponente(cordenadasBarcoJ3);
                                     }
                                }else if(barcoO3[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a3 = bxo3+i;
                                        int b3 = byo3;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizJugador[bxo3+i,byo3] = " X ";
                                            AgregarPuntoOponente(z3);
                                        }else{
                                            matrizJugador[bxo3+i,byo3] = " B3 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarcoJ3)){
                                        matrizJugador[bxo3,byo3] = " X ";
                                        AgregarPuntoOponente(cordenadasBarcoJ3);
                                    }
                                }
                            }else if(int.Parse(barcoO3[3]) == 3){
                                if(barcoO3[2] == "H"){
                                    matrizJugador[bxo3,byo3] = " B3 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO3[3]); i++)
                                    {
                                        int a3 = bxo3;
                                        int b3 = byo3+i;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizJugador[bxo3,byo3+i] = " X ";
                                            AgregarPuntoOponente(z3);
                                        }else{
                                            matrizJugador[bxo3,byo3+i] = " B3 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarcoJ3)){
                                         matrizJugador[bxo3,byo3] = " X ";
                                         AgregarPuntoOponente(cordenadasBarcoJ3);
                                     }
                                }else if(barcoO3[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a3 = bxo3+i;
                                        int b3 = byo3;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizJugador[bxo3+i,byo3] = " X ";
                                            AgregarPuntoOponente(z3);
                                        }else{
                                            matrizJugador[bxo3+i,byo3] = " B3 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarcoJ3)){
                                        matrizJugador[bxo3,byo3] = " X ";
                                        AgregarPuntoOponente(cordenadasBarcoJ3);
                                    }
                                }                                                       
                            }else if(int.Parse(barcoO3[3]) == 4){
                                if(barcoO3[2] == "H"){
                                    matrizJugador[bxo3,byo3] = " B3 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO3[3]); i++)
                                    {
                                        int a3 = bxo3;
                                        int b3 = byo3+i;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizJugador[bxo3,byo3+i] = " X ";
                                            AgregarPuntoOponente(z3);
                                        }else{
                                            matrizJugador[bxo3,byo3+i] = " B3 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarcoJ3)){
                                         matrizJugador[bxo3,byo3] = " X ";
                                         AgregarPuntoOponente(cordenadasBarcoJ3);
                                     }
                                }else if(barcoO3[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a3 = bxo3+i;
                                        int b3 = byo3;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizJugador[bxo3+i,byo3] = " X ";
                                            AgregarPuntoOponente(z3);
                                        }else{
                                            matrizJugador[bxo3+i,byo3] = " B3 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarcoJ3)){
                                        matrizJugador[bxo3,byo3] = " X ";
                                        AgregarPuntoOponente(cordenadasBarcoJ3);
                                    }
                                }
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 3 del oponente");
                            }
                        }
                    }
                    //Validacion barco 4
                        //Validacion de que no quepa
                    if(bxo4 >= matrizJugador.GetLength(0) || byo4 >= matrizJugador.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.4 no cabe en el tablero del oponente");
                    }else{
                            //Validacion de que no este repetido
                         if(bxo4 == bxo1 && bxo4 == bxo2 && bxo4 == bxo3 && bxo4 == bxo5 && byo4 == byo1 && byo4 == byo2 && byo4 == byo3 && byo4 == byo5){
                            Console.WriteLine("Parece que el barco no.4 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO4[3]) == 2){
                                if(barcoO4[2] == "H"){
                                    matrizJugador[bxo4,byo4] = " B4 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4;
                                        int b4 = byo4+i;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizJugador[bxo4,byo4+i] = " X ";
                                            AgregarPuntoOponente(z4);
                                        }else{
                                            matrizJugador[bxo4,byo4+i] = " B4 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarcoJ4)){
                                         matrizJugador[bxo4,byo4] = " X ";
                                         AgregarPuntoOponente(cordenadasBarcoJ4);
                                     }
                                }else if(barcoO4[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4+i;
                                        int b4 = byo4;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizJugador[bxo4+i,byo4] = " X ";
                                            AgregarPuntoOponente(z4);
                                        }else{
                                            matrizJugador[bxo4+i,byo4] = " B4 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarcoJ4)){
                                        matrizJugador[bxo4,byo4] = " X ";
                                        AgregarPuntoOponente(cordenadasBarcoJ4);
                                    }
                                }
                            }else if(int.Parse(barcoO4[3]) == 3){
                            if(barcoO4[2] == "H"){
                                    matrizJugador[bxo4,byo4] = " B4 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4;
                                        int b4 = byo4+i;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizJugador[bxo4,byo4+i] = " X ";
                                            AgregarPuntoOponente(z4);
                                        }else{
                                            matrizJugador[bxo4,byo4+i] = " B4 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarcoJ4)){
                                         matrizJugador[bxo4,byo4] = " X ";
                                         AgregarPuntoOponente(cordenadasBarcoJ4);
                                     }
                                }else if(barcoO4[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4+i;
                                        int b4 = byo4;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizJugador[bxo4+i,byo4] = " X ";
                                            AgregarPuntoOponente(z4);
                                        }else{
                                            matrizJugador[bxo4+i,byo4] = " B4 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarcoJ4)){
                                        matrizJugador[bxo4,byo4] = " X ";
                                        AgregarPuntoOponente(cordenadasBarcoJ4);
                                    }
                                }                                                      
                            }else if(int.Parse(barcoO4[3]) == 4){
                            if(barcoO4[2] == "H"){
                                    matrizJugador[bxo4,byo4] = " B4 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4;
                                        int b4 = byo4+i;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizJugador[bxo4,byo4+i] = " X ";
                                            AgregarPuntoOponente(z4);
                                        }else{
                                            matrizJugador[bxo4,byo4+i] = " B4 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarcoJ4)){
                                         matrizJugador[bxo4,byo4] = " X ";
                                         AgregarPuntoOponente(cordenadasBarcoJ4);
                                     }
                                }else if(barcoO4[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4+i;
                                        int b4 = byo4;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizJugador[bxo4+i,byo4] = " X ";
                                            AgregarPuntoOponente(z4);
                                        }else{
                                            matrizJugador[bxo4+i,byo4] = " B4 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarcoJ4)){
                                        matrizJugador[bxo4,byo4] = " X ";
                                        AgregarPuntoOponente(cordenadasBarcoJ4);
                                    }
                                }
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 4 del oponente");
                            }
                        }
                    }
                    //Validacion barco 5
                        //Validacion de que no quepa
                    if(bxo5 >= matrizJugador.GetLength(0) || byo5 >= matrizJugador.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.5 no cabe en el tablero del oponente");
                    }else{
                        //Validacion de que no este repetido
                        if(bxo5 == bxo1 && bxo5 == bxo2 && bxo5 == bxo3 && bxo5 == bxo4 && byo5 == byo1 && byo5 == byo2 && byo5 == byo3 && byo5 == byo4){
                            Console.WriteLine("Parece que el barco no.5 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO5[3]) == 2){
                                if(barcoO5[2] == "H"){
                                    matrizJugador[bxo5,byo5] = " B5 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5;
                                        int b5 = byo5+i;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizJugador[bxo5,byo5+i] = " X ";
                                            AgregarPuntoOponente(z5);
                                        }else{
                                            matrizJugador[bxo5,byo5+i] = " B5 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarcoJ5)){
                                         matrizJugador[bxo5,byo5] = " X ";
                                         AgregarPuntoOponente(cordenadasBarcoJ5);
                                     }
                                }else if(barcoO5[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5+i;
                                        int b5 = byo5;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizJugador[bxo5+i,byo5] = " X ";
                                            AgregarPuntoOponente(z5);
                                        }else{
                                            matrizJugador[bxo5+i,byo5] = " B5 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarcoJ5)){
                                        matrizJugador[bxo5,byo5] = " X ";
                                        AgregarPuntoOponente(cordenadasBarcoJ5);
                                    }
                                }
                            }else if(int.Parse(barcoO5[3]) == 3){
                            if(barcoO5[2] == "H"){
                                    matrizJugador[bxo5,byo5] = " B5 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5;
                                        int b5 = byo5+i;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizJugador[bxo5,byo5+i] = " X ";
                                            AgregarPuntoOponente(z5);
                                        }else{
                                            matrizJugador[bxo5,byo5+i] = " B5 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarcoJ5)){
                                         matrizJugador[bxo5,byo5] = " X ";
                                         AgregarPuntoOponente(cordenadasBarcoJ5);
                                     }
                                }else if(barcoO5[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5+i;
                                        int b5 = byo5;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizJugador[bxo5+i,byo5] = " X ";
                                            AgregarPuntoOponente(z5);
                                        }else{
                                            matrizJugador[bxo5+i,byo5] = " B5 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarcoJ5)){
                                        matrizJugador[bxo5,byo5] = " X ";
                                        AgregarPuntoOponente(cordenadasBarcoJ5);
                                    }
                                }                                            
                            }else if(int.Parse(barcoO5[3]) == 4){
                            if(barcoO5[2] == "H"){
                                    matrizJugador[bxo5,byo5] = " B5 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5;
                                        int b5 = byo5+i;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizJugador[bxo5,byo5+i] = " X ";
                                            AgregarPuntoOponente(z5);
                                        }else{
                                            matrizJugador[bxo5,byo5+i] = " B5 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarcoJ5)){
                                         matrizJugador[bxo5,byo5] = " X ";
                                         AgregarPuntoOponente(cordenadasBarcoJ5);
                                     }
                                }else if(barcoO5[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5+i;
                                        int b5 = byo5;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizJugador[bxo5+i,byo5] = " X ";
                                            AgregarPuntoOponente(z5);
                                        }else{
                                            matrizJugador[bxo5+i,byo5] = " B5 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarcoJ5)){
                                        matrizJugador[bxo5,byo5] = " X ";
                                        AgregarPuntoOponente(cordenadasBarcoJ5);
                                    }
                                }
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 5 del oponente");
                            }
                        }
                    }
                    Console.Write(matrizJugador[f,c]);
                }
                Console.WriteLine();
            }
        }

        public static void matrizInicialOponente(string[] dimnesionOponente, string[] barcoO1,string[] barcoO2,string[] barcoO3,string[] barcoO4,string[] barcoO5){
            Program instancia = new Program();
            string db = instancia.ataquesJugador;
            string cox1 = barcoO1[0];
            string coy2 = barcoO1[1];
            string cobx2 = barcoO2[0];
            string coby2 =  barcoO2[1];
            string cobx3 = barcoO3[0];
            string coby3 = barcoO3[1];
            string cobx4 = barcoO4[0];
            string coby4 = barcoO4[1];
            string cobx5 = barcoO5[0];
            string coby5 = barcoO5[1];
            string cordenadasBarco1 = cox1+","+coy2;
            string cordenadasBarco2 = cobx2+","+coby2;
            string cordenadasBarco3 = cobx3+","+coby3;
            string cordenadasBarco4 = cobx4+","+coby4;
            string cordenadasBarco5 = cobx5+","+coby5;
            int filas = int.Parse(dimnesionOponente[0]);
            int columnas = int.Parse(dimnesionOponente[1]);
            string[,] matrizOponente =  new string[filas,columnas];   
            Console.WriteLine("     1  2  3  4  5  6  7  8  9");
            for (int f = 1; f < matrizOponente.GetLength(0); f++){
                Console.Write(f + " | ");
                for (int c = 1; c < matrizOponente.GetLength(1); c++){
                    //Valor de la tabla inicial
                    matrizOponente[f,c] = " . ";
                    //Variables de barcos
                    int bxo1 = int.Parse(barcoO1[0]);
                    int byo1 = int.Parse(barcoO1[1]);
                    //Barco 2
                    int bxo2 = int.Parse(barcoO2[0]);
                    int byo2 = int.Parse(barcoO2[1]);
                    //Barco 3
                    int bxo3 = int.Parse(barcoO3[0]);
                    int byo3 = int.Parse(barcoO3[1]);
                    //Barco 4
                    int bxo4 = int.Parse(barcoO4[0]);
                    int byo4 = int.Parse(barcoO4[1]);
                    //Barco 5
                    int bxo5 = int.Parse(barcoO5[0]);
                    int byo5 = int.Parse(barcoO5[1]);
                    //Validaciones para imprimir los barcos
                        //Validacion barco 1
                            //Validacion de que no quepa
                    if(bxo1 >= matrizOponente.GetLength(0) || byo1 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.2 no cabe en el tablero del oponente");
                    }else{ 
                        //Validacion de que no este repetido
                        if(bxo1 == bxo2 && bxo1 == bxo3 && bxo1 == bxo4 && bxo1 == bxo5 && byo1 == byo2 && byo1 == byo3 && byo1 == byo4 && byo1 == byo5){
                            Console.WriteLine("Parece que el barco no.1 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO1[3]) == 2){
                                //Validacion de horizontal y posiciones
                               if(barcoO1[2] == "H"){
                                   matrizOponente[bxo1,byo1] = " . ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1;
                                        int b = byo1+i;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizOponente[bxo1,byo1+i] = " X ";
                                            AgregarPuntoJugador(z);
                                        }else{
                                            matrizOponente[bxo1,byo1+i] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco1)){
                                         matrizOponente[bxo1+1,byo1] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco1);
                                     }
                                }else if(barcoO1[2] == "V"){
                                    //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1+i;
                                        int b = byo1;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizOponente[bxo1+i,byo1] = " X ";
                                            AgregarPuntoJugador(z);
                                        }else{
                                            matrizOponente[bxo1+i,byo1] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco1)){
                                        matrizOponente[bxo1,byo1] = " X ";
                                       AgregarPuntoJugador(cordenadasBarco1);
                                    }
                                }
                            }else if(int.Parse(barcoO1[3]) == 3){
                               if(barcoO1[2] == "H"){
                                   matrizOponente[bxo1,byo1] = " . ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1;
                                        int b = byo1+i;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizOponente[bxo1,byo1+i] = " X ";
                                             AgregarPuntoJugador(z);
                                        }else{
                                            matrizOponente[bxo1,byo1+i] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco1)){
                                         matrizOponente[bxo1+1,byo1] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco1);
                                     }
                                }else if(barcoO1[2] == "V"){
                                    //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1+i;
                                        int b = byo1;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizOponente[bxo1+i,byo1] = " X ";
                                             AgregarPuntoJugador(z);
                                        }else{
                                            matrizOponente[bxo1+i,byo1] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco1)){
                                        matrizOponente[bxo1,byo1] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco1);
                                    }
                                }
                            }else if(int.Parse(barcoO1[3]) == 4){
                                if(barcoO1[2] == "H"){
                                   matrizOponente[bxo1,byo1] = " . ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1;
                                        int b = byo1+i;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizOponente[bxo1,byo1+i] = " X ";
                                             AgregarPuntoJugador(z);
                                        }else{
                                            matrizOponente[bxo1,byo1+i] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco1)){
                                         matrizOponente[bxo1,byo1] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco1);
                                     }
                                }else if(barcoO1[2] == "V"){
                                    //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1+i;
                                        int b = byo1;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizOponente[bxo1+i,byo1] = " X ";
                                             AgregarPuntoJugador(z);
                                        }else{
                                            matrizOponente[bxo1+i,byo1] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco1)){
                                        matrizOponente[bxo1,byo1] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco1);
                                    }
                                }
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 1 del oponente del oponente");
                            }
                        }
                    }
                    //Validacion barco 2
                        //Validacion de que no quepa
                    if(bxo2 >= matrizOponente.GetLength(0) || byo2 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.2 no cabe en el tablero del oponente");
                    }else{
                        //Validacion de que no este repetido
                         if(bxo2 == bxo1 && bxo2 == bxo3 && bxo2 == bxo4 && bxo2 == bxo5 && byo2 == byo1 && byo2 == byo3 && byo2 == byo4 && byo2 == byo5){
                            Console.WriteLine("Parece que el barco no.2 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO2[3]) == 2){
                                if(barcoO2[2] == "H"){
                                    matrizOponente[bxo2,byo2] = " . ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2;
                                        int b2 = byo2+i;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizOponente[bxo2,byo2+i] = " X ";
                                            AgregarPuntoJugador(z2);
                                        }else{
                                            matrizOponente[bxo2,byo2+i] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco2)){
                                         matrizOponente[bxo2+1,byo2] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco2);
                                     }
                                }else if(barcoO2[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2+i;
                                        int b2 = byo2;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizOponente[bxo2+i,byo2] = " X ";
                                            AgregarPuntoJugador(z2);
                                        }else{
                                            matrizOponente[bxo2+i,byo2] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco2)){
                                        matrizOponente[bxo1,byo1] = " X ";
                                       AgregarPuntoJugador(cordenadasBarco2);
                                    }
                                }
                            }else if(int.Parse(barcoO2[3]) == 3){
                                 if(barcoO2[2] == "H"){
                                    matrizOponente[bxo2,byo2] = " . ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2;
                                        int b2 = byo2+i;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizOponente[bxo2,byo2+i] = " X ";
                                            AgregarPuntoJugador(z2);
                                        }else{
                                            matrizOponente[bxo2,byo2+i] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco2)){
                                         matrizOponente[bxo2,byo2] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco2);
                                     }
                                }else if(barcoO2[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2+i;
                                        int b2 = byo2;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizOponente[bxo2+i,byo2] = " X ";
                                            AgregarPuntoJugador(z2);
                                        }else{
                                            matrizOponente[bxo2+i,byo2] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco2)){
                                        matrizOponente[bxo2,byo2] = " X ";
                                       AgregarPuntoJugador(cordenadasBarco2);
                                    }
                                }
                            }else if(int.Parse(barcoO2[3]) == 4){
                                 if(barcoO2[2] == "H"){
                                    matrizOponente[bxo2,byo2] = " . ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2;
                                        int b2 = byo2+i;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizOponente[bxo2,byo2+i] = " X ";
                                            AgregarPuntoJugador(z2);
                                        }else{
                                            matrizOponente[bxo2,byo2+i] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco2)){
                                         matrizOponente[bxo2,byo2] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco2);
                                     }
                                }else if(barcoO2[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2+i;
                                        int b2 = byo2;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizOponente[bxo2+i,byo2] = " X ";
                                            AgregarPuntoJugador(z2);
                                        }else{
                                            matrizOponente[bxo2+i,byo2] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco2)){
                                        matrizOponente[bxo2,byo2] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco2);
                                    }
                                }
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 2 del oponente del oponente");
                            }
                        }
                    }
                    //Validacion barco 3
                        //Validacion de que no quepa
                    if(bxo3 >= matrizOponente.GetLength(0) || byo3 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.3 no cabe en el tablero del oponente");
                    }else{
                            //Validacion de que no este repetido
                         if(bxo3 == bxo1 && bxo3 == bxo2 && bxo3 == bxo4 && bxo3 == bxo5 && byo3 == byo1 && byo3 == byo2 && byo3 == byo4 && byo3 == byo5){
                            Console.WriteLine("Parece que el barco no.3 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO3[3]) == 2){
                                if(barcoO3[2] == "H"){
                                    matrizOponente[bxo3,byo3] = " . ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO3[3]); i++)
                                    {
                                        int a3 = bxo3;
                                        int b3 = byo3+i;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizOponente[bxo3,byo3+i] = " X ";
                                            AgregarPuntoJugador(z3);
                                        }else{
                                            matrizOponente[bxo3,byo3+i] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco3)){
                                         matrizOponente[bxo3,byo3] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco3);
                                     }
                                }else if(barcoO3[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a3 = bxo3+i;
                                        int b3 = byo3;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizOponente[bxo3+i,byo3] = " X ";
                                            AgregarPuntoJugador(z3);
                                        }else{
                                            matrizOponente[bxo3+i,byo3] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco3)){
                                        matrizOponente[bxo3,byo3] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco3);
                                    }
                                }
                            }else if(int.Parse(barcoO3[3]) == 3){
                                if(barcoO3[2] == "H"){
                                    matrizOponente[bxo3,byo3] = " . ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO3[3]); i++)
                                    {
                                        int a3 = bxo3;
                                        int b3 = byo3+i;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizOponente[bxo3,byo3+i] = " X ";
                                            AgregarPuntoJugador(z3);
                                        }else{
                                            matrizOponente[bxo3,byo3+i] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco3)){
                                         matrizOponente[bxo3,byo3] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco3);
                                     }
                                }else if(barcoO3[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a3 = bxo3+i;
                                        int b3 = byo3;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizOponente[bxo3+i,byo3] = " X ";
                                            AgregarPuntoJugador(z3);
                                        }else{
                                            matrizOponente[bxo3+i,byo3] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco3)){
                                        matrizOponente[bxo3,byo3] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco3);
                                    }
                                }                                                   
                            }else if(int.Parse(barcoO3[3]) == 4){
                                if(barcoO3[2] == "H"){
                                    matrizOponente[bxo3,byo3] = " . ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO3[3]); i++)
                                    {
                                        int a3 = bxo3;
                                        int b3 = byo3+i;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizOponente[bxo3,byo3+i] = " X ";
                                            AgregarPuntoJugador(z3);
                                        }else{
                                            matrizOponente[bxo3,byo3+i] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco3)){
                                         matrizOponente[bxo3,byo3] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco3);
                                     }
                                }else if(barcoO3[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a3 = bxo3+i;
                                        int b3 = byo3;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizOponente[bxo3+i,byo3] = " X ";
                                            AgregarPuntoJugador(z3);
                                        }else{
                                            matrizOponente[bxo3+i,byo3] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco3)){
                                        matrizOponente[bxo3,byo3] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco3);
                                    }
                                }
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 3 del oponente");
                            }
                        }
                    }
                    //Validacion barco 4
                        //Validacion de que no quepa
                    if(bxo4 >= matrizOponente.GetLength(0) || byo4 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.4 no cabe en el tablero del oponente");
                    }else{
                            //Validacion de que no este repetido
                         if(bxo4 == bxo1 && bxo4 == bxo2 && bxo4 == bxo3 && bxo4 == bxo5 && byo4 == byo1 && byo4 == byo2 && byo4 == byo3 && byo4 == byo5){
                            Console.WriteLine("Parece que el barco no.4 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO4[3]) == 2){
                                if(barcoO4[2] == "H"){
                                    matrizOponente[bxo4,byo4] = " . ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4;
                                        int b4 = byo4+i;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizOponente[bxo4,byo4+i] = " X ";
                                            AgregarPuntoJugador(z4);
                                        }else{
                                            matrizOponente[bxo4,byo4+i] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco4)){
                                         matrizOponente[bxo4,byo4] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco4);
                                     }
                                }else if(barcoO4[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4+i;
                                        int b4 = byo4;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizOponente[bxo4+i,byo4] = " X ";
                                            AgregarPuntoJugador(z4);
                                        }else{
                                            matrizOponente[bxo4+i,byo4] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco4)){
                                        matrizOponente[bxo4,byo4] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco4);
                                    }
                                }
                            }else if(int.Parse(barcoO4[3]) == 3){
                            if(barcoO4[2] == "H"){
                                    matrizOponente[bxo4,byo4] = " . ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4;
                                        int b4 = byo4+i;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizOponente[bxo4,byo4+i] = " X ";
                                            AgregarPuntoJugador(z4);
                                        }else{
                                            matrizOponente[bxo4,byo4+i] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco4)){
                                         matrizOponente[bxo4,byo4] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco4);
                                     }
                                }else if(barcoO4[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4+i;
                                        int b4 = byo4;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizOponente[bxo4+i,byo4] = " X ";
                                            AgregarPuntoJugador(z4);
                                        }else{
                                            matrizOponente[bxo4+i,byo4] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco4)){
                                        matrizOponente[bxo4,byo4] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco4);
                                    }
                                }                                                      
                            }else if(int.Parse(barcoO4[3]) == 4){
                            if(barcoO4[2] == "H"){
                                    matrizOponente[bxo4,byo4] = " . ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4;
                                        int b4 = byo4+i;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizOponente[bxo4,byo4+i] = " X ";
                                            AgregarPuntoJugador(z4);
                                        }else{
                                            matrizOponente[bxo4,byo4+i] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco4)){
                                         matrizOponente[bxo4,byo4] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco4);
                                     }
                                }else if(barcoO4[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4+i;
                                        int b4 = byo4;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizOponente[bxo4+i,byo4] = " X ";
                                            AgregarPuntoJugador(z4);
                                        }else{
                                            matrizOponente[bxo4+i,byo4] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco4)){
                                        matrizOponente[bxo4,byo4] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco4);
                                    }
                                }
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 4 del oponente");
                            }
                        }
                    }
                    //Validacion barco 5
                        //Validacion de que no quepa
                    if(bxo5 >= matrizOponente.GetLength(0) || byo5 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.5 no cabe en el tablero del oponente");
                    }else{
                        //Validacion de que no este repetido
                        if(bxo5 == bxo1 && bxo5 == bxo2 && bxo5 == bxo3 && bxo5 == bxo4 && byo5 == byo1 && byo5 == byo2 && byo5 == byo3 && byo5 == byo4){
                            Console.WriteLine("Parece que el barco no.5 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO5[3]) == 2){
                                if(barcoO5[2] == "H"){
                                    matrizOponente[bxo5,byo5] = " . ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5;
                                        int b5 = byo5+i;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizOponente[bxo5,byo5+i] = " X ";
                                            AgregarPuntoJugador(z5);
                                        }else{
                                            matrizOponente[bxo5,byo5+i] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco5)){
                                         matrizOponente[bxo5,byo5] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco5);
                                     }
                                }else if(barcoO5[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5+i;
                                        int b5 = byo5;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizOponente[bxo5+i,byo5] = " X ";
                                            AgregarPuntoJugador(z5);
                                        }else{
                                            matrizOponente[bxo5+i,byo5] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco5)){
                                        matrizOponente[bxo5,byo5] = " X ";
                                       AgregarPuntoJugador(cordenadasBarco5);
                                    }
                                }
                            }else if(int.Parse(barcoO5[3]) == 3){
                            if(barcoO5[2] == "H"){
                                    matrizOponente[bxo5,byo5] = " . ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5;
                                        int b5 = byo5+i;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizOponente[bxo5,byo5+i] = " X ";
                                            AgregarPuntoJugador(z5);
                                        }else{
                                            matrizOponente[bxo5,byo5+i] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco5)){
                                         matrizOponente[bxo5,byo5] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco5);
                                     }
                                }else if(barcoO5[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5+i;
                                        int b5 = byo5;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizOponente[bxo5+i,byo5] = " X ";
                                            AgregarPuntoJugador(z5);
                                        }else{
                                            matrizOponente[bxo5+i,byo5] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco5)){
                                        matrizOponente[bxo5,byo5] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco5);
                                    }
                                }                                            
                            }else if(int.Parse(barcoO5[3]) == 4){
                            if(barcoO5[2] == "H"){
                                    matrizOponente[bxo5,byo5] = " . ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5;
                                        int b5 = byo5+i;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizOponente[bxo5,byo5+i] = " X ";
                                            AgregarPuntoJugador(z5);
                                        }else{
                                            matrizOponente[bxo5,byo5+i] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco5)){
                                         matrizOponente[bxo5,byo5] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco5);
                                     }
                                }else if(barcoO5[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5+i;
                                        int b5 = byo5;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizOponente[bxo5+i,byo5] = " X ";
                                            AgregarPuntoJugador(z5);
                                        }else{
                                            matrizOponente[bxo5+i,byo5] = " . ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco5)){
                                        matrizOponente[bxo5,byo5] = " X ";
                                       AgregarPuntoJugador(cordenadasBarco5);
                                    }
                                }else{
                                      Console.WriteLine("Fuera de rango barco no. 5 del oponente");
                                }
                            }
                        }
                    }
                    Console.Write(matrizOponente[f,c]);
                }
                Console.WriteLine();
            }
        }
       public static void matrizOponente(string[] dimnesionOponente, string[] barcoO1,string[] barcoO2,string[] barcoO3,string[] barcoO4,string[] barcoO5){
            Program instancia = new Program();
            string db = instancia.ataquesJugador;
            string cox1 = barcoO1[0];
            string coy2 = barcoO1[1];
            string cobx2 = barcoO2[0];
            string coby2 =  barcoO2[1];
            string cobx3 = barcoO3[0];
            string coby3 = barcoO3[1];
            string cobx4 = barcoO4[0];
            string coby4 = barcoO4[1];
            string cobx5 = barcoO5[0];
            string coby5 = barcoO5[1];
            string cordenadasBarco1 = cox1+","+coy2;
            string cordenadasBarco2 = cobx2+","+coby2;
            string cordenadasBarco3 = cobx3+","+coby3;
            string cordenadasBarco4 = cobx4+","+coby4;
            string cordenadasBarco5 = cobx5+","+coby5;
            int filas = int.Parse(dimnesionOponente[0]);
            int columnas = int.Parse(dimnesionOponente[1]);
            string[,] matrizOponente =  new string[filas,columnas];   
            Console.WriteLine("     1  2  3  4  5  6  7  8  9");
            for (int f = 1; f < matrizOponente.GetLength(0); f++){
                Console.Write(f + " | ");
                for (int c = 1; c < matrizOponente.GetLength(1); c++){
                    //Valor de la tabla inicial
                    matrizOponente[f,c] = " . ";
                    //Variables de barcos
                    int bxo1 = int.Parse(barcoO1[0]);
                    int byo1 = int.Parse(barcoO1[1]);
                    //Barco 2
                    int bxo2 = int.Parse(barcoO2[0]);
                    int byo2 = int.Parse(barcoO2[1]);
                    //Barco 3
                    int bxo3 = int.Parse(barcoO3[0]);
                    int byo3 = int.Parse(barcoO3[1]);
                    //Barco 4
                    int bxo4 = int.Parse(barcoO4[0]);
                    int byo4 = int.Parse(barcoO4[1]);
                    //Barco 5
                    int bxo5 = int.Parse(barcoO5[0]);
                    int byo5 = int.Parse(barcoO5[1]);
                    //Validaciones para imprimir los barcos
                        //Validacion barco 1
                            //Validacion de que no quepa
                    if(bxo1 >= matrizOponente.GetLength(0) || byo1 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.2 no cabe en el tablero del oponente");
                    }else{ 
                        //Validacion de que no este repetido
                        if(bxo1 == bxo2 && bxo1 == bxo3 && bxo1 == bxo4 && bxo1 == bxo5 && byo1 == byo2 && byo1 == byo3 && byo1 == byo4 && byo1 == byo5){
                            Console.WriteLine("Parece que el barco no.1 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO1[3]) == 2){
                                //Validacion de horizontal y posiciones
                               if(barcoO1[2] == "H"){
                                   matrizOponente[bxo1,byo1] = " B1 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1;
                                        int b = byo1+i;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizOponente[bxo1,byo1+i] = " X ";
                                            AgregarPuntoJugador(z);
                                        }else{
                                            matrizOponente[bxo1,byo1+i] = " B1 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco1)){
                                         matrizOponente[bxo1+1,byo1] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco1);
                                     }
                                }else if(barcoO1[2] == "V"){
                                    //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1+i;
                                        int b = byo1;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizOponente[bxo1+i,byo1] = " X ";
                                            AgregarPuntoJugador(z);
                                        }else{
                                            matrizOponente[bxo1+i,byo1] = " B1 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco1)){
                                        matrizOponente[bxo1,byo1] = " X ";
                                       AgregarPuntoJugador(cordenadasBarco1);
                                    }
                                }
                            }else if(int.Parse(barcoO1[3]) == 3){
                               if(barcoO1[2] == "H"){
                                   matrizOponente[bxo1,byo1] = " B1 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1;
                                        int b = byo1+i;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizOponente[bxo1,byo1+i] = " X ";
                                             AgregarPuntoJugador(z);
                                        }else{
                                            matrizOponente[bxo1,byo1+i] = " B1 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco1)){
                                         matrizOponente[bxo1+1,byo1] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco1);
                                     }
                                }else if(barcoO1[2] == "V"){
                                    //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1+i;
                                        int b = byo1;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizOponente[bxo1+i,byo1] = " X ";
                                             AgregarPuntoJugador(z);
                                        }else{
                                            matrizOponente[bxo1+i,byo1] = " B1 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco1)){
                                        matrizOponente[bxo1,byo1] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco1);
                                    }
                                }
                            }else if(int.Parse(barcoO1[3]) == 4){
                                if(barcoO1[2] == "H"){
                                   matrizOponente[bxo1,byo1] = " B1 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1;
                                        int b = byo1+i;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizOponente[bxo1,byo1+i] = " X ";
                                             AgregarPuntoJugador(z);
                                        }else{
                                            matrizOponente[bxo1,byo1+i] = " B1 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco1)){
                                         matrizOponente[bxo1,byo1] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco1);
                                     }
                                }else if(barcoO1[2] == "V"){
                                    //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO1[3]); i++)
                                    {
                                        int a = bxo1+i;
                                        int b = byo1;
                                        string z = a+","+b;
                                        if(File.ReadAllText(db).Contains(z)){
                                            matrizOponente[bxo1+i,byo1] = " X ";
                                             AgregarPuntoJugador(z);
                                        }else{
                                            matrizOponente[bxo1+i,byo1] = " B1 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco1)){
                                        matrizOponente[bxo1,byo1] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco1);
                                    }
                                }
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 1 del oponente del oponente");
                            }
                        }
                    }
                    //Validacion barco 2
                        //Validacion de que no quepa
                    if(bxo2 >= matrizOponente.GetLength(0) || byo2 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.2 no cabe en el tablero del oponente");
                    }else{
                        //Validacion de que no este repetido
                         if(bxo2 == bxo1 && bxo2 == bxo3 && bxo2 == bxo4 && bxo2 == bxo5 && byo2 == byo1 && byo2 == byo3 && byo2 == byo4 && byo2 == byo5){
                            Console.WriteLine("Parece que el barco no.2 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO2[3]) == 2){
                                if(barcoO2[2] == "H"){
                                    matrizOponente[bxo2,byo2] = " B2 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2;
                                        int b2 = byo2+i;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizOponente[bxo2,byo2+i] = " X ";
                                            AgregarPuntoJugador(z2);
                                        }else{
                                            matrizOponente[bxo2,byo2+i] = " B2 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco2)){
                                         matrizOponente[bxo2+1,byo2] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco2);
                                     }
                                }else if(barcoO2[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2+i;
                                        int b2 = byo2;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizOponente[bxo2+i,byo2] = " X ";
                                            AgregarPuntoJugador(z2);
                                        }else{
                                            matrizOponente[bxo2+i,byo2] = " B2 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco2)){
                                        matrizOponente[bxo1,byo1] = " X ";
                                       AgregarPuntoJugador(cordenadasBarco2);
                                    }
                                }
                            }else if(int.Parse(barcoO2[3]) == 3){
                                 if(barcoO2[2] == "H"){
                                    matrizOponente[bxo2,byo2] = " B2 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2;
                                        int b2 = byo2+i;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizOponente[bxo2,byo2+i] = " X ";
                                            AgregarPuntoJugador(z2);
                                        }else{
                                            matrizOponente[bxo2,byo2+i] = " B2 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco2)){
                                         matrizOponente[bxo2,byo2] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco2);
                                     }
                                }else if(barcoO2[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2+i;
                                        int b2 = byo2;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizOponente[bxo2+i,byo2] = " X ";
                                            AgregarPuntoJugador(z2);
                                        }else{
                                            matrizOponente[bxo2+i,byo2] = " B2 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco2)){
                                        matrizOponente[bxo2,byo2] = " X ";
                                       AgregarPuntoJugador(cordenadasBarco2);
                                    }
                                }
                            }else if(int.Parse(barcoO2[3]) == 4){
                                 if(barcoO2[2] == "H"){
                                    matrizOponente[bxo2,byo2] = " B2 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2;
                                        int b2 = byo2+i;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizOponente[bxo2,byo2+i] = " X ";
                                            AgregarPuntoJugador(z2);
                                        }else{
                                            matrizOponente[bxo2,byo2+i] = " B2 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco2)){
                                         matrizOponente[bxo2,byo2] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco2);
                                     }
                                }else if(barcoO2[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a2 = bxo2+i;
                                        int b2 = byo2;
                                        string z2 = a2+","+b2;
                                        if(File.ReadAllText(db).Contains(z2)){
                                            matrizOponente[bxo2+i,byo2] = " X ";
                                            AgregarPuntoJugador(z2);
                                        }else{
                                            matrizOponente[bxo2+i,byo2] = " B2 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco2)){
                                        matrizOponente[bxo2,byo2] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco2);
                                    }
                                }
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 2 del oponente del oponente");
                            }
                        }
                    }
                    //Validacion barco 3
                        //Validacion de que no quepa
                    if(bxo3 >= matrizOponente.GetLength(0) || byo3 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.3 no cabe en el tablero del oponente");
                    }else{
                            //Validacion de que no este repetido
                         if(bxo3 == bxo1 && bxo3 == bxo2 && bxo3 == bxo4 && bxo3 == bxo5 && byo3 == byo1 && byo3 == byo2 && byo3 == byo4 && byo3 == byo5){
                            Console.WriteLine("Parece que el barco no.3 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO3[3]) == 2){
                                if(barcoO3[2] == "H"){
                                    matrizOponente[bxo3,byo3] = " B3 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO3[3]); i++)
                                    {
                                        int a3 = bxo3;
                                        int b3 = byo3+i;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizOponente[bxo3,byo3+i] = " X ";
                                            AgregarPuntoJugador(z3);
                                        }else{
                                            matrizOponente[bxo3,byo3+i] = " B3 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco3)){
                                         matrizOponente[bxo3,byo3] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco3);
                                     }
                                }else if(barcoO3[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a3 = bxo3+i;
                                        int b3 = byo3;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizOponente[bxo3+i,byo3] = " X ";
                                            AgregarPuntoJugador(z3);
                                        }else{
                                            matrizOponente[bxo3+i,byo3] = " B3 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco3)){
                                        matrizOponente[bxo3,byo3] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco3);
                                    }
                                }
                            }else if(int.Parse(barcoO3[3]) == 3){
                                if(barcoO3[2] == "H"){
                                    matrizOponente[bxo3,byo3] = " B3 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO3[3]); i++)
                                    {
                                        int a3 = bxo3;
                                        int b3 = byo3+i;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizOponente[bxo3,byo3+i] = " X ";
                                            AgregarPuntoJugador(z3);
                                        }else{
                                            matrizOponente[bxo3,byo3+i] = " B3 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco3)){
                                         matrizOponente[bxo3,byo3] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco3);
                                     }
                                }else if(barcoO3[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a3 = bxo3+i;
                                        int b3 = byo3;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizOponente[bxo3+i,byo3] = " X ";
                                            AgregarPuntoJugador(z3);
                                        }else{
                                            matrizOponente[bxo3+i,byo3] = " B3 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco3)){
                                        matrizOponente[bxo3,byo3] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco3);
                                    }
                                }                                                   
                            }else if(int.Parse(barcoO3[3]) == 4){
                                if(barcoO3[2] == "H"){
                                    matrizOponente[bxo3,byo3] = " B3 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO3[3]); i++)
                                    {
                                        int a3 = bxo3;
                                        int b3 = byo3+i;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizOponente[bxo3,byo3+i] = " X ";
                                            AgregarPuntoJugador(z3);
                                        }else{
                                            matrizOponente[bxo3,byo3+i] = " B3 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco3)){
                                         matrizOponente[bxo3,byo3] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco3);
                                     }
                                }else if(barcoO3[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO2[3]); i++)
                                    {
                                        int a3 = bxo3+i;
                                        int b3 = byo3;
                                        string z3 = a3+","+b3;
                                        if(File.ReadAllText(db).Contains(z3)){
                                            matrizOponente[bxo3+i,byo3] = " X ";
                                            AgregarPuntoJugador(z3);
                                        }else{
                                            matrizOponente[bxo3+i,byo3] = " B3 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco3)){
                                        matrizOponente[bxo3,byo3] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco3);
                                    }
                                }
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 3 del oponente");
                            }
                        }
                    }
                    //Validacion barco 4
                        //Validacion de que no quepa
                    if(bxo4 >= matrizOponente.GetLength(0) || byo4 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.4 no cabe en el tablero del oponente");
                    }else{
                            //Validacion de que no este repetido
                         if(bxo4 == bxo1 && bxo4 == bxo2 && bxo4 == bxo3 && bxo4 == bxo5 && byo4 == byo1 && byo4 == byo2 && byo4 == byo3 && byo4 == byo5){
                            Console.WriteLine("Parece que el barco no.4 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO4[3]) == 2){
                                if(barcoO4[2] == "H"){
                                    matrizOponente[bxo4,byo4] = " B4 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4;
                                        int b4 = byo4+i;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizOponente[bxo4,byo4+i] = " X ";
                                            AgregarPuntoJugador(z4);
                                        }else{
                                            matrizOponente[bxo4,byo4+i] = " B4 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco4)){
                                         matrizOponente[bxo4,byo4] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco4);
                                     }
                                }else if(barcoO4[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4+i;
                                        int b4 = byo4;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizOponente[bxo4+i,byo4] = " X ";
                                            AgregarPuntoJugador(z4);
                                        }else{
                                            matrizOponente[bxo4+i,byo4] = " B4 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco4)){
                                        matrizOponente[bxo4,byo4] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco4);
                                    }
                                }
                            }else if(int.Parse(barcoO4[3]) == 3){
                            if(barcoO4[2] == "H"){
                                    matrizOponente[bxo4,byo4] = " B4 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4;
                                        int b4 = byo4+i;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizOponente[bxo4,byo4+i] = " X ";
                                            AgregarPuntoJugador(z4);
                                        }else{
                                            matrizOponente[bxo4,byo4+i] = " B4 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco4)){
                                         matrizOponente[bxo4,byo4] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco4);
                                     }
                                }else if(barcoO4[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4+i;
                                        int b4 = byo4;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizOponente[bxo4+i,byo4] = " X ";
                                            AgregarPuntoJugador(z4);
                                        }else{
                                            matrizOponente[bxo4+i,byo4] = " B4 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco4)){
                                        matrizOponente[bxo4,byo4] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco4);
                                    }
                                }                                                      
                            }else if(int.Parse(barcoO4[3]) == 4){
                            if(barcoO4[2] == "H"){
                                    matrizOponente[bxo4,byo4] = " B4 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4;
                                        int b4 = byo4+i;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizOponente[bxo4,byo4+i] = " X ";
                                            AgregarPuntoJugador(z4);
                                        }else{
                                            matrizOponente[bxo4,byo4+i] = " B4 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco4)){
                                         matrizOponente[bxo4,byo4] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco4);
                                     }
                                }else if(barcoO4[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO4[3]); i++)
                                    {
                                        int a4 = bxo4+i;
                                        int b4 = byo4;
                                        string z4 = a4+","+b4;
                                        if(File.ReadAllText(db).Contains(z4)){
                                            matrizOponente[bxo4+i,byo4] = " X ";
                                            AgregarPuntoJugador(z4);
                                        }else{
                                            matrizOponente[bxo4+i,byo4] = " B4 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco4)){
                                        matrizOponente[bxo4,byo4] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco4);
                                    }
                                }
                            }else{
                                Console.WriteLine("Fuera de rango barco no. 4 del oponente");
                            }
                        }
                    }
                    //Validacion barco 5
                        //Validacion de que no quepa
                    if(bxo5 >= matrizOponente.GetLength(0) || byo5 >= matrizOponente.GetLength(1)){
                        Console.WriteLine("Parece que el barco no.5 no cabe en el tablero del oponente");
                    }else{
                        //Validacion de que no este repetido
                        if(bxo5 == bxo1 && bxo5 == bxo2 && bxo5 == bxo3 && bxo5 == bxo4 && byo5 == byo1 && byo5 == byo2 && byo5 == byo3 && byo5 == byo4){
                            Console.WriteLine("Parece que el barco no.5 esta duplicado del oponente");
                        }else{
                            //Validacion de que sea 2,3 y 4
                            if(int.Parse(barcoO5[3]) == 2){
                                if(barcoO5[2] == "H"){
                                    matrizOponente[bxo5,byo5] = " B5 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5;
                                        int b5 = byo5+i;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizOponente[bxo5,byo5+i] = " X ";
                                            AgregarPuntoJugador(z5);
                                        }else{
                                            matrizOponente[bxo5,byo5+i] = " B5 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco5)){
                                         matrizOponente[bxo5,byo5] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco5);
                                     }
                                }else if(barcoO5[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5+i;
                                        int b5 = byo5;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizOponente[bxo5+i,byo5] = " X ";
                                            AgregarPuntoJugador(z5);
                                        }else{
                                            matrizOponente[bxo5+i,byo5] = " B5 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco5)){
                                        matrizOponente[bxo5,byo5] = " X ";
                                       AgregarPuntoJugador(cordenadasBarco5);
                                    }
                                }
                            }else if(int.Parse(barcoO5[3]) == 3){
                            if(barcoO5[2] == "H"){
                                    matrizOponente[bxo5,byo5] = " B5 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5;
                                        int b5 = byo5+i;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizOponente[bxo5,byo5+i] = " X ";
                                            AgregarPuntoJugador(z5);
                                        }else{
                                            matrizOponente[bxo5,byo5+i] = " B5 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco5)){
                                         matrizOponente[bxo5,byo5] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco5);
                                     }
                                }else if(barcoO5[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5+i;
                                        int b5 = byo5;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizOponente[bxo5+i,byo5] = " X ";
                                            AgregarPuntoJugador(z5);
                                        }else{
                                            matrizOponente[bxo5+i,byo5] = " B5 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco5)){
                                        matrizOponente[bxo5,byo5] = " X ";
                                        AgregarPuntoJugador(cordenadasBarco5);
                                    }
                                }                                            
                            }else if(int.Parse(barcoO5[3]) == 4){
                            if(barcoO5[2] == "H"){
                                    matrizOponente[bxo5,byo5] = " B5 ";
                                    //Validacion para escribir barcos de corrido   
                                    for (int i = 1; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5;
                                        int b5 = byo5+i;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizOponente[bxo5,byo5+i] = " X ";
                                            AgregarPuntoJugador(z5);
                                        }else{
                                            matrizOponente[bxo5,byo5+i] = " B5 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                     if(File.ReadAllText(db).Contains(cordenadasBarco5)){
                                         matrizOponente[bxo5,byo5] = " X ";
                                         AgregarPuntoJugador(cordenadasBarco5);
                                     }
                                }else if(barcoO5[2] == "V"){
                                   //Validacion para escribir barcos de corrido
                                    for (int i = 0; i < int.Parse(barcoO5[3]); i++)
                                    {
                                        int a5 = bxo5+i;
                                        int b5 = byo5;
                                        string z5 = a5+","+b5;
                                        if(File.ReadAllText(db).Contains(z5)){
                                            matrizOponente[bxo5+i,byo5] = " X ";
                                            AgregarPuntoJugador(z5);
                                        }else{
                                            matrizOponente[bxo5+i,byo5] = " B5 ";
                                        }
                                    }
                                    //Aqui se hace la validacion del barco para ver si acerto o no
                                    if(File.ReadAllText(db).Contains(cordenadasBarco5)){
                                        matrizOponente[bxo5,byo5] = " X ";
                                       AgregarPuntoJugador(cordenadasBarco5);
                                    }
                                }else{
                                      Console.WriteLine("Fuera de rango barco no. 5 del oponente");
                                }
                            }
                        }
                    }
                    Console.Write(matrizOponente[f,c]);
                }
                Console.WriteLine();
            }
        }
        public static void Limpiarpantalla()
        {
            Console.Clear();
        }
        public static void GenerarTXTJugador(){
            Program instancia = new Program();
            //Direccion de archivo de jugador.txt
            string path = instancia.configJugador;
            StreamReader reader = new StreamReader(path);
            string linea1 = reader.ReadLine();
            string[] dimension;
            dimension = linea1.Split(",");
            reader.ReadLine();
            string barco1 = reader.ReadLine();
            string barco2 = reader.ReadLine();
            string barco3 = reader.ReadLine();
            string barco4 = reader.ReadLine();
            string barco5 = reader.ReadLine();
            string[] barcoj1 = barco1.Split(","); 
            string[] barcoj2 = barco2.Split(","); 
            string[] barcoj3 = barco3.Split(","); 
            string[] barcoj4 = barco4.Split(","); 
            string[] barcoj5 = barco5.Split(",");
            reader.ReadLine();
            //Destinatario
            matrizJugador(dimension,barcoj1,barcoj2,barcoj3,barcoj4,barcoj5);            
        }
        public static void GenerarTXTOponente(int paso){
            Program instancia = new Program();
            //Direccion de archivo de jugador.txt
            string path = instancia.configOponente;
            StreamReader reader = new StreamReader(path);
            string linea1 = reader.ReadLine();
            string[] dimension;
            dimension = linea1.Split(",");
            reader.ReadLine();
            string barco1 = reader.ReadLine();
            string barco2 = reader.ReadLine();
            string barco3 = reader.ReadLine();
            string barco4 = reader.ReadLine();
            string barco5 = reader.ReadLine();
            string[] barcoO1 = barco1.Split(","); 
            string[] barcoO2 = barco2.Split(","); 
            string[] barcoO3 = barco3.Split(","); 
            string[] barcoO4 = barco4.Split(","); 
            string[] barcoO5 = barco5.Split(",");
            reader.ReadLine();
            //Destinatario
            if(paso == 1){
                matrizInicialOponente(dimension,barcoO1,barcoO2,barcoO3,barcoO4,barcoO5);
            }else{
                matrizOponente(dimension,barcoO1,barcoO2,barcoO3,barcoO4,barcoO5);   
            }         
        }

        public static void ModificarTxtJugador(string[] ataque){
            Program instancia = new Program();
            try{
                // Direccion de nuestro archivo nuevo
                string path = instancia.ataquesJugador;
                using(StreamWriter writer = new StreamWriter(path,true)){
                    string linea = string.Join(",",ataque);
                    writer.WriteLine(linea);
                }
            }catch(Exception e){
                Console.Write(e);
                throw;
            }
        }
        public static void ModificarTxtOponente(string[] ataque){
            Program instancia = new Program();
            try{
                // Direccion de nuestro archivo nuevo
                string path = instancia.ataquesOponente;
                using(StreamWriter writer = new StreamWriter(path,true)){
                    string linea = string.Join(",",ataque);
                    writer.WriteLine(linea);
                }
            }catch(Exception e){
                Console.Write(e);
                throw;
            }
        }
        public static string cordenadaRandom(){
            Random instancia = new Random();
            int numero1 = instancia.Next(1,9);
            int numero2 = instancia.Next(1,9);
            string numeros = numero1+","+numero2;
            return numeros;
        }


        public static void AgregarPuntoOponente(string cordenada){
            Program instancia = new Program();
            HashSet<string> lineasAnteriores = new HashSet<string>();
            string path = instancia.puntosOponente;
            try{
                using(StreamWriter writer = new StreamWriter(path, true)){
                    string a = cordenada;
                    writer.WriteLine(a);
                }
            }catch(Exception e){
                Console.WriteLine("Algun error ocurrio :(");
                Console.WriteLine(e);
            }
            string origin = path;
            string dest =  instancia.oponenteOut;
            EliminarLineasRepetidas(origin, dest);
        }
        public static void AgregarPuntoJugador(string cordenada){
            Program instancia = new Program();
            HashSet<string> lineasAnteriores = new HashSet<string>();
            string path = instancia.puntosJugador;
            try{
                using(StreamWriter writer = new StreamWriter(path, true)){
                    string a = cordenada;
                    writer.WriteLine(a);
                }
            }catch(Exception e){
                Console.WriteLine("Algun error ocurrio :(");
                Console.WriteLine(e);
            }
            string origin = path;
            string dest =  instancia.jugadorOut;
            EliminarLineasRepetidas(origin, dest);
        }
        public static void EliminarLineasRepetidas(string origin, string dest){
            var sr = new StreamReader(File.OpenRead(origin)); 
            var sw = new StreamWriter(File.OpenWrite(dest)); 
            var lines = new HashSet<int>(); 
            while (!sr.EndOfStream) 
            { 
            string line = sr.ReadLine(); 
            int hc = line.GetHashCode(); 
            if(lines.Contains(hc)) 
            continue; 

            lines.Add(hc); 
            sw.WriteLine(line); 
            } 
            sw.Flush(); 
            sw.Close(); 
            sr.Close(); 
        }

        public static int totalLines(string path){
            var totalLineas = File.ReadAllLines(path).Length;
            return totalLineas;
        }

        public static string ObtenerTotalBarcos(string path){
            try{
            StreamReader reader = new StreamReader(path);
            string linea1 = reader.ReadLine(); 
            string[] dimnesion; 
            dimnesion = linea1.Split(",");
            reader.ReadLine();
            string barco1s = reader.ReadLine();
            string barco2s = reader.ReadLine();
            string barco3s = reader.ReadLine();
            string barco4s = reader.ReadLine();
            string barco5s = reader.ReadLine();
            string[] barco1 = barco1s.Split(",");
            string[] barco2 = barco2s.Split(",");
            string[] barco3 = barco3s.Split(",");
            string[] barco4 = barco4s.Split(",");
            string[] barco5 = barco5s.Split(",");
            reader.ReadLine();
            int totalBarcos = int.Parse(barco1[3])+int.Parse(barco2[3])+int.Parse(barco3[3])+int.Parse(barco4[3])+int.Parse(barco5[3]);
            return totalBarcos.ToString();
            }catch(NullReferenceException){
                return "0";
            }
        }

        public static void PantallaFinal(){
            Program instancia = new Program();
            Thread.Sleep(2);
            Console.WriteLine("JUEGO FINALIZADO");
            Console.WriteLine("------------------JUGADOR----------------------");
            GenerarTXTJugador();
            Console.WriteLine("------------------OPONENTE----------------------");
            GenerarTXTOponente(2);
            
            try{
            int turnosJugador = File.ReadAllLines(instancia.ataquesJugador).Length;
            int puntosJugador = File.ReadAllLines(instancia.jugadorOut).Length;
            string totalBarcosOponente = ObtenerTotalBarcos(instancia.configOponente);
            Console.WriteLine("------------------RESULTADOS JUGADOR----------------------");
            Console.WriteLine("TURNOS REALIZADOS: " + turnosJugador);
            Console.WriteLine("PUNTOS: " + puntosJugador*10);
            Console.WriteLine("ACIERTOS: " + puntosJugador+"/"+totalBarcosOponente);

            }catch(FileNotFoundException){
                int turnosJugador = File.ReadAllLines(instancia.ataquesJugador).Length;
                Console.WriteLine("------------------RESULTADOS JUGADOR----------------------");
                Console.WriteLine("TURNOS REALIZADOS: " + turnosJugador);
                Console.WriteLine("PUNTOS: 0");
                Console.WriteLine("ACIERTOS: 0");
            }


            try{
            int puntosOponente = File.ReadAllLines(instancia.oponenteOut).Length;
            string totalBarcosJugador = ObtenerTotalBarcos(instancia.configJugador);
            Console.WriteLine("------------------RESULTADOS OPONENTE----------------------");
            Console.WriteLine("PUNTOS: " + puntosOponente*10);
            Console.WriteLine("ACIERTOS: " + puntosOponente+"/"+totalBarcosJugador);

            }catch(FileNotFoundException){
                Console.WriteLine("------------------RESULTADOS OPONENTE----------------------");
                Console.WriteLine("PUNTOS: 0");
                Console.WriteLine("ACIERTOS: 0");
            }

            try{
                File.Delete(instancia.puntosJugador);
                File.Delete(instancia.puntosOponente);
                File.Delete(instancia.oponenteOut);
                File.WriteAllText(instancia.jugadorOut, string.Empty);
                File.WriteAllText(instancia.ataquesJugador, string.Empty);
                File.WriteAllText(instancia.ataquesOponente, string.Empty);
            }catch(FileNotFoundException){
               
            }

        }

        public static int IntentosFallidos(){
            Program instancia = new Program();
            int totalAciertos = totalLines(instancia.jugadorOut);
            int totalAtaques = totalLines(instancia.ataquesJugador);
            int totalFallos = totalAtaques - totalAciertos;
            return totalFallos;
        }
        public static int AciertosTotales(){
            Program instancia = new Program();
            int totalAciertos = totalLines(instancia.jugadorOut);
            return totalAciertos;
        }    
    }
}
