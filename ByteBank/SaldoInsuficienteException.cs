using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class SaldoInsuficienteException : Exception
        
    {
        public double Saldo { get; }
        public double ValorSaque { get;}

        public SaldoInsuficienteException()
          
        {

        }
        public SaldoInsuficienteException(double saldo, double valorSaque)
            : this("Saque no valor de " + valorSaque + " na conta que possui saldo de " + saldo)
        {
            Saldo = saldo;
            ValorSaque = valorSaque;

        }

        public SaldoInsuficienteException(string mensagem)
            : base(mensagem)
        {

        }
    }
}
