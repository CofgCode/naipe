using System;
/*using System.Collections.Generic;
 * */

/*
 * baraja española tiene 48 naipes y 2 comodines, repartidos en cuatro palos: oros, copas, espadas y bastos. 
 * La baraja de 48 cartas está numerada del 1 al 9, siendo las figuras el 10 (sota), 
 * el 11 (caballo) y el 12 (rey). 
 * 1) Elabore una clase llamada Naipe, la cual debe tener como atributos el palo y el número. 
 * 2) cree una clase llamada Baraja,  la cual tendrá como atributo un arreglo de 48 Naipe. 
 * 3) Agregue a la clase Baraja 
 * un método para inicializar todos los naipes del arreglo. 
 * Un método llamado ordenar que ordene el arreglo de naipes por el palo –oros, copas, espadas y bastos- y por el número. 
 * Un método llamado barajar que “revuelva” aleatoriamente todos los naipes en el arreglo. 
 * Por último un método llamado imprimir, que permita imprimir el arreglo de naipes cuando se requiera.

 * */
using System;

class Naipe
{
    public string Palo { get; set; }
    public int Numero { get; set; }

    public Naipe(string palo, int numero)
    {
        Palo = palo;
        Numero = numero;
    }
}

class Baraja
{
    Naipe[] naipes = new Naipe[50];

    public Baraja()
    {
        InicializarNaipes();
    }

    private void InicializarNaipes()
    {
        int index = 0;
        // Inicializa los 48 naipes 
        for (int i = 1; i <= 12; i++)
        {
            naipes[index++] = new Naipe("Oros", i);
            naipes[index++] = new Naipe("Copas", i);
            naipes[index++] = new Naipe("Espadas", i);
            naipes[index++] = new Naipe("Bastos", i);
        }
        // Inicializa los comodines
        naipes[49] = new Naipe("Comodin", 0);
        naipes[48] = new Naipe("Comodin", 0);
    }

    public void Ordenar()
    {
        Array.Sort(naipes, (a, b) =>
            a.Palo.CompareTo(b.Palo) != 0
                ? a.Palo.CompareTo(b.Palo) : a.Numero.CompareTo(b.Numero));
    }

    public void Barajar()
    {
        Random r = new Random();
        naipes = naipes.OrderBy(x => r.Next()).ToArray();
    }

    public void Imprimir()
    {
        foreach (Naipe naipe in naipes)
        {
            Console.WriteLine(naipe.Palo + " " + naipe.Numero);
        }
    }
}
public class Program
{
    public static void Main()
    {
        Baraja baraja = new Baraja();

        Console.WriteLine("Baraja Inicializada:");
        baraja.Imprimir();

        Console.WriteLine("\nBaraja Ordenada:");
        baraja.Ordenar();
        baraja.Imprimir();

        Console.WriteLine("\nBaraja Barajada:");
        baraja.Barajar();
        baraja.Imprimir();
    }
}
