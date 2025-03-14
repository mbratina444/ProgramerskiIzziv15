using System;

class Program
{
    static void Main()
    {
        // Uporabnik vnese geslo (črke in številke)
        Console.Write("Vnesite svoje geslo (crke in stevilke): ");
        string geslo = Console.ReadLine();

        // Preverimo, da geslo ni prazno
        while (string.IsNullOrEmpty(geslo))
        {
            Console.Write("Geslo ne sme biti prazno! Vnesite geslo: ");
            geslo = Console.ReadLine();
        }

        // Uporabnik vnese število mest za rotacijo
        Console.Write("Vnesite stevilo mest za vrtenje v desno: ");
        int koraki;
        while (!int.TryParse(Console.ReadLine(), out koraki) || koraki < 0)
        {
            Console.Write("Neveljaven vnos! Vnesite pozitivno stevilo: ");
        }

        // Prilagodimo korake, če so večji od dolžine gesla
        koraki %= geslo.Length;

        // Pretvorimo geslo v char array za obdelavo
        char[] znaki = geslo.ToCharArray();

        // Uporabimo algoritem za vrtenje
        Obrni(znaki, 0, znaki.Length - 1);  // Obrnemo celoten niz
        Obrni(znaki, 0, koraki - 1);        // Obrnemo prvih 'k' znakov
        Obrni(znaki, koraki, znaki.Length - 1); // Obrnemo preostanek

        // Izpišemo novo geslo
        string novoGeslo = new string(znaki);
        Console.WriteLine($"Vase novo, varnejse geslo: {novoGeslo}");
    }

    /// <summary>
    /// Funkcija za obrat znakov v danem segmentu polja
    /// </summary>
    static void Obrni(char[] arr, int start, int end)
    {
        while (start < end)
        {
            char temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
            start++;
            end--;
        }
    }
}


