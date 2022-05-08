using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MiniCompiladorXconsola
{
    class Program
    {
        private static List<string> listaRespuestas = new List<string>();
        private static string[] palabrasReservadas = new string[] { "ENTERO", "DECIMAL", "CADENA", "LOGICO", "SI", "ENTONCES", 
        "SINO", "FIN", "VERDADERO", "FALSO" };        

        private static bool ValidacionAZ(String str)
        {
            return Regex.IsMatch(str, @"^[a-z]+$");
        }

        private static bool ValidacionNUM(String str)
        {
            return Regex.IsMatch(str, @"^[0-9]+$");
        }

        private static bool Min(String str)
        {
            bool tieneMinusculas = str.Any(c => char.IsLower(c));
            return tieneMinusculas;
        }

        private static bool May(String str)
        {
            bool tieneMayusculas = str.Any(c => char.IsUpper(c));
            return tieneMayusculas;
        }

        private static bool Dig(String str)
        {
            bool tieneNumeros = str.Any(c => char.IsDigit(c));
            return tieneNumeros;
        }

        static void Verificacion(string [] x)
        {
            string[] cadena = x;
            string texto = "";


            string variable = PalabrasReserv(cadena,0);

            //Obtenemos el ultimo caracter de la ultima posicion de la cadena
            string ultimoCaracter = cadena[cadena.Length -1].Substring(cadena[cadena.Length-1].Length - 1);
            string dato = "";

            //verificamos si es ';' y si, si lo es, se elimina
            if (ValidacionAZ(ultimoCaracter)== false && May(ultimoCaracter) == false && Dig(ultimoCaracter) == false)
            {
                dato = cadena[3].Substring(0, cadena[3].Length - 1);
            }
            else
            {
                dato = cadena[3];
            }


            switch (variable)
            {
                case "ENTERO":

                    Identificador(cadena,1);
                    Token(cadena[2], 0);

                    //Validamos si el valor contenido en la variable dato solo contiene numeros
                    if (ValidacionNUM(dato) == true && ultimoCaracter.Equals(";"))
                    {
                        texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR VALIDO\n" +
                                "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";

                    }
                    else if (ValidacionNUM(dato) == false)
                    {
                        if (!ultimoCaracter.Equals(";") && ValidacionAZ(ultimoCaracter) == true || !ultimoCaracter.Equals(";") && Dig(ultimoCaracter) == true)
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                        }
                        else if (ultimoCaracter.Equals(";"))
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";
                        }
                        else
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                        }

                    }
                    else if (ValidacionNUM(dato) == true && !ultimoCaracter.Equals(";"))
                    {
                        if (!ultimoCaracter.Equals(";") && ValidacionAZ(ultimoCaracter) == true || !ultimoCaracter.Equals(";") && Dig(ultimoCaracter) == true)
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                        }
                        else
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                        }

                    }

                    listaRespuestas.Add(texto);
                    foreach (var item in listaRespuestas)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "DECIMAL":

                    Identificador(cadena,1);
                    Token(cadena[2], 0);

                    //Validamos si el valor contenido en la variable dato solo contiene numeros 
                    if (Dig(dato) == true && ultimoCaracter.Equals(";") && dato.Contains(".") && Min(dato) == false && May(dato) == false)
                    {
                        texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR VALIDO\n" +
                                "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";

                    }
                    else if (Dig(dato) == false)
                    {
                        if (!ultimoCaracter.Equals(";") && ValidacionAZ(ultimoCaracter) == true)
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                        }
                        else if (ultimoCaracter.Equals(";"))
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";
                        }
                        else
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                        }

                    }
                    else if (Dig(dato) == true && dato.Contains(","))
                    {
                        if (!ultimoCaracter.Equals(";") && ValidacionAZ(ultimoCaracter) == true)
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                        }
                        else if (ultimoCaracter.Equals(";"))
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";
                        }
                        else
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                        }

                    }
                    else if (Min(dato) == true || May(dato) == true)
                    {
                        if (ValidacionAZ(ultimoCaracter) == true || Dig(ultimoCaracter) == true)
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                        }
                        else if (ultimoCaracter.Equals(";"))
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";
                        }
                        else
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                        }

                    }
                    else if (ValidacionNUM(dato) == true)
                    {
                        if (ultimoCaracter.Equals(";"))
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";
                        }
                        else if (!ultimoCaracter.Equals(";") && Dig(ultimoCaracter) == true)
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                        }
                        else
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                        }

                    }
                    else if (Dig(dato) == true && !ultimoCaracter.Equals(";") && dato.Contains(".") && Min(dato) == false && May(dato) == false)
                    {

                        if (Dig(ultimoCaracter) == true)
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                        }
                        else
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                        }

                    }

                    listaRespuestas.Add(texto);
                    foreach (var item in listaRespuestas)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "CADENA":

                    Identificador(cadena,1);
                    Token(cadena[2], 0);

                    if (Dig(dato) == false && ultimoCaracter.Equals(";") && (Min(dato) == true || May(dato) == true))
                    {
                        texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR VALIDO\n" +
                                "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";

                    }
                    else if (ValidacionNUM(dato) == true)
                    {
                        if (!ultimoCaracter.Equals(";") && ValidacionNUM(ultimoCaracter) == true)
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                        }
                        else if (ultimoCaracter.Equals(";"))
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";
                        }
                        else
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                        }

                    }
                    else if (Dig(dato) == true)
                    {
                        if (!ultimoCaracter.Equals(";") && ValidacionNUM(ultimoCaracter) == true || !ultimoCaracter.Equals(";") && ValidacionAZ(ultimoCaracter) == true)
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                        }
                        else if (ultimoCaracter.Equals(";"))
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";
                        }
                        else
                        {
                            texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO\n" +
                                    "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                        }

                    }

                    listaRespuestas.Add(texto);
                    foreach (var item in listaRespuestas)
                    {
                        Console.WriteLine(item);
                    }

                    break;
                case "SI":
                    Token(cadena[1], 1);
                    Identificador(cadena, 2);
                    Token(cadena[3], 10);
                    Identificador(cadena, 4);
                    Token(cadena[5], 2);
                    PalabrasReserv(cadena, 6);
                    Identificador(cadena, 7);
                    Token(cadena[8], 0);
                    Identificador(cadena, 9);
                    PalabrasReserv(cadena, 10);

                    foreach (var item in listaRespuestas)
                    {
                        Console.WriteLine(item);
                    }

                    break;               
                default:

                    Identificador(cadena,1);
                    Token(cadena[2], 0);


                    if (!ultimoCaracter.Equals(";") && ValidacionNUM(ultimoCaracter) == true || !ultimoCaracter.Equals(";") && ValidacionAZ(ultimoCaracter) == true || May(ultimoCaracter) == true)
                    {
                        texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO - NO SE DEFINIO UN TIPO DE DATO\n" +
                                "OPERADOR...................\t\t\t\tOPERADOR OMITIDO\n";
                    }
                    else if (ultimoCaracter.Equals(";"))
                    {
                        texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO - NO SE DEFINIO UN TIPO DE DATO\n" +
                                "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR VALIDO\n";
                    }
                    else
                    {
                        texto = "IDENTIFICADOR..............\t\t\t" + dato + "\tIDENTIFICADOR NO VALIDO - NO SE DEFINIO UN TIPO DE DATO\n" +
                                "OPERADOR...................\t\t\t" + ultimoCaracter + "\tOPERADOR NO VALIDO\n";
                    }

                    listaRespuestas.Add(texto);
                    foreach (var item in listaRespuestas)
                    {
                        Console.WriteLine(item);
                    }
                    break;



            }


           
            

        }              

        static void Token(string x, int opc)
        {   

            string[] simbolos = new string[] { "=", "(", ")", "+", "-", "*", "/", ";", "<", ">", "=="};
            string cadena = x;
            int posicion = opc;
            string texto = "";

            //Validamos si el dato de la variable cadena es igual al operador que se espera 
            if (cadena.Equals(simbolos[posicion]))
            {
                texto = "OPERADOR...................\t\t\t" + cadena + "\tOPERADOR VALIDO\n";
            }
            else if (ValidacionAZ(cadena) == true || Dig(cadena) == true || May(cadena) == true)
            {
                texto = "ERROR SEMANTICO.............\t\t\t" + cadena + "\tOPERADOR OMITIDO\n";
            }
            else
            {
                texto = "ERROR SEMANTICO.............\t\t\t" + cadena + "\tOPERADOR NO VALIDO\n";

            }

            //agregamos la respuesta a nuestra lista para mostrarlo posteriormente 
            listaRespuestas.Add(texto);

        }

        static string PalabrasReserv(string[] x, int opc)
        {
            string[] cadena = x;
            string texto = "";
            string variable = "";


            for (int i = 0; i < palabrasReservadas.Length; i++)
            {
                if ((palabrasReservadas[i].Equals(cadena[opc])))
                {
                    texto = "PALABRA RESERVADA...........\t\t\t" + cadena[opc] + "\tPALABRA RESERVADA VALIDA \n";
                    i = palabrasReservadas.Length;
                    variable = cadena[opc];
                }
                else if ((cadena[opc].Equals(palabrasReservadas[i].ToLower())) || ((Min(cadena[opc]) == true) && (palabrasReservadas[i].Equals(cadena[opc].ToUpper()))))
                {
                    texto = "ERROR SEMANTICO.............\t\t\t" + cadena[opc] + "\tPALABRA RESERVADA NO VALIDA\n";
                    i = palabrasReservadas.Length;
                }
                else
                {
                    texto = "ERROR LEXICO................\t\t\t" + cadena[opc] + "\tPALABRA RESERVADA NO VALIDA\n";
                }
            }
            listaRespuestas.Add(texto);
            return variable;
        }

        static void Identificador(string [] x, int opc)
        {
            string[] cadena = x;
            string texto = "";
            
            //validamos en la posicion que se manda
            if (ValidacionAZ(cadena[opc]) == true)
            {
                texto = "IDENTIFICADOR...............\t\t\t" + cadena[opc] + "\tIDENTIFICADOR VALIDO\n";
            }            
            else if (May(cadena[opc]) == true)
            {
                texto = "ERROR SEMANTICO.............\t\t\t" + cadena[opc] + "\tIDENTIFICADOR NO VALIDO\n";
            }
            else
            {
                texto = "ERROR LEXICO................\t\t\t" + cadena[opc] + "\tIDENTIFICADOR NO VALIDO\n";

            }
            
            //agregamos la respuesta a nuestra lista para mostrarlo posteriormente 
            listaRespuestas.Add(texto);

            //Mandamos 0 porque es la pocision donde se encuentra el simbolo =            

        }

        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t\t||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("\t\t\t\t\t----------------------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t\t\t////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("\t\t\t\t\t----------------------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t\t\t-----------------------------MINI COMPILADOR PERSONAL-----------------------------------");
            Console.WriteLine("\t\t\t\t\t----------------------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t\t\t////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("\t\t\t\t\t----------------------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t\t\t||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");

            Console.WriteLine("\n\n\n\t\tIngrese una expresion a analizar: ");
            string cadena = Console.ReadLine();


            string[] vector = cadena.Split(' ');


            Verificacion(vector);

            Console.WriteLine("\n\n\n\n\t\t\t\tDesea continuar?\n\n\t\t\t SI - NO");
            string res = Console.ReadLine();

            while (res != "NO")
            {
                Console.WriteLine("\n\n\n\t\tIngrese una expresion a analizar: ");
                string c = Console.ReadLine();

                listaRespuestas.Clear();

                string[] v = c.Split(' ');


                Verificacion(v);
            }
        }

    }
}
