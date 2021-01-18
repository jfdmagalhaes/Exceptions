// using _05_ByteBank;

using System;

namespace ByteBank
{

    
    public class ContaCorrente
    {
        public static double TaxaOperacao { get; set; }
        public Cliente Titular { get; set; }

        public int ContadorSaqueNaoPermitido { get; private set; }
        public int ContadorTransferenciaNaoPermitido { get; private set; }

        public static int TotalDeContasCriadas { get; private set; }


        private int _agencia;
        public int Agencia
        {
            get
            {
                return _agencia;
            }
            set
            {
                if (value <= 0)
                {
                    return;
                }

                _agencia = value;
            }
        }
        public int Numero { get; set; }

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }


        public ContaCorrente(int agencia, int numero)
        {
            Agencia = agencia;
            Numero = numero;

            //TaxaOperacao = 30 / TotalDeContasCriadas;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }


        public void Sacar(double valor)
        {

            if (valor < 0)
            {
                throw new ArgumentException("valor invalido para saque", nameof(valor));

            }
            if (_saldo < valor)
            {
                ContadorSaqueNaoPermitido++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
            //return true;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("valor invalido para a transferencia", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch(SaldoInsuficienteException ex)
            {
                ContadorTransferenciaNaoPermitido++;
                throw new Exception("Não permitido", ex);
                
            }
            contaDestino.Depositar(valor);
        }
    }
}
