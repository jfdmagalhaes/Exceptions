using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {

            //ContaCorrente cota = new ContaCorrente(1212, 121212);
            //Console.WriteLine(ContaCorrente.TaxaOperacao);

            try
            {
                Metodo();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                Console.WriteLine("Exceção tratada.");
            }

            Console.ReadLine();
        }

        public static int Dividir(int numero, int divisor)
        {
            return numero / divisor;
        }

        static void Metodo()
        {
            TestaDivisao(0);
        }

        static void TestaDivisao(int divisor)
        {
            Dividir(10, divisor);
        }


    }
}
