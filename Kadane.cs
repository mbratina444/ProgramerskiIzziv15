using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] meseci = { "Januar", "Februar", "Marec", "April", "Maj", "Junij", "Julij", "Avgust", "September", "Oktober", "November", "December" };
        List<int> mesecnaStanja = new List<int>();

        for (int i = 0; i < 12; i++)
        {
            Console.WriteLine($"\nVnasanje transakcij za {meseci[i]}:");
            Console.Write("Stevilo transakcij: ");
            
            if (!int.TryParse(Console.ReadLine(), out int steviloTransakcij) || steviloTransakcij < 0)
            {
                Console.WriteLine("Napacen vnos! Poskusite znova.");
                i--;
                continue;
            }

            int skupnoStanje = 0;
            for (int j = 0; j < steviloTransakcij; j++)
            {
                Console.Write($"Transakcija {j + 1} (plus/minus znesek): ");
                string[] vnos = Console.ReadLine().Split();

                if (vnos.Length != 2 || !int.TryParse(vnos[1], out int znesek) || (vnos[0] != "plus" && vnos[0] != "minus"))
                {
                    Console.WriteLine("Napacen vnos! Poskusite znova.");
                    j--;
                    continue;
                }

                skupnoStanje += vnos[0] == "plus" ? znesek : -znesek;
            }

            mesecnaStanja.Add(skupnoStanje);
        }

        (int maxVsota, int startMesec, int endMesec) = Kadane(mesecnaStanja);

        Console.WriteLine("\n--- REZULTATI ---");
        Console.WriteLine($"Najvecje obdobje priliva: {meseci[startMesec]} - {meseci[endMesec]}");
        Console.WriteLine($"Najvecja vsota: {maxVsota} EUR");
    }

    /// <summary>
    /// Kadanejev algoritem za iskanje najvecje vsote sosednjih elementov v seznamu.
    /// </summary>
    static (int, int, int) Kadane(List<int> arr)
    {
        int maxVsota = arr[0], trenutnaVsota = arr[0];
        int start = 0, end = 0, tempStart = 0;

        for (int i = 1; i < arr.Count; i++)
        {
            if (arr[i] > trenutnaVsota + arr[i])
            {
                trenutnaVsota = arr[i];
                tempStart = i;
            }
            else
            {
                trenutnaVsota += arr[i];
            }

            if (trenutnaVsota > maxVsota)
            {
                maxVsota = trenutnaVsota;
                start = tempStart;
                end = i;
            }
        }

        return (maxVsota, start, end);
    }
}



