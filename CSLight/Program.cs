using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;

            Table[] tables = { new Table(1, 4), new Table(2, 8), new Table(3, 10) };

            while (isOpen)
            {
                Console.WriteLine("Администрирование кафе.\n");

                for (int i = 0; i < tables.Length; i++)
                {
                    tables[i].Showinfo();
                }

                Console.Write("\nВведите номер стола: ");
                int wishTable = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("\nВведите количество мест для брони: ");
                int desirePlace = Convert.ToInt32(Console.ReadLine());

                bool isReservationComleted = tables[wishTable].Reserve(desirePlace);

                if (isReservationComleted)
                {
                    Console.WriteLine("Бронь прошла успешно!");
                }
                else
                {
                    Console.WriteLine("Бронь не прошла. Недостаточно мест.");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Table
    {
        public int Number;
        public int MaxPlaces;
        public int FreePlace;

        public Table(int number, int maxPlaces)
        {
            Number = number;
            MaxPlaces = maxPlaces;
            FreePlace = maxPlaces;
        }

        public void Showinfo()
        {
            Console.WriteLine($"Стол: {Number}. Свободно мест: {FreePlace} из {MaxPlaces}.");
        }

        public bool Reserve(int place)
        {
            if (FreePlace >= place)
            {
                FreePlace -= place;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}