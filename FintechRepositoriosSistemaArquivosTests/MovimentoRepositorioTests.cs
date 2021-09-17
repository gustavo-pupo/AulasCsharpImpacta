using Microsoft.VisualStudio.TestTools.UnitTesting;
using FintechRepositoriosSistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fintech.Dominio.Entidades;

namespace FintechRepositoriosSistemaArquivos.Tests
{
    
    [TestClass()]
    public class MovimentoRepositorioTests
    {

        private readonly MovimentoRepositorio repositorio = new("Dados\\Movimento.txt");

        [TestMethod()]
        public void InserirTest()
        {
            var agencia = new Agencia();
            agencia.Numero = 53;

            var contaFake = new ContaCorrente(agencia, 233, "4");
            var operacao = new Movimento(Operacao.Deposito, 50);
            operacao.Conta = contaFake;

            
            repositorio.Inserir(operacao);
        }

        [TestMethod()]
        public void SelecionarTest()
        {

            var movimentos = repositorio.Selecionar(53, 233);

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Data} - {movimento.Guid} - " +
                    $"{movimento.Operacao} - {movimento.Valor}");
            }
        }
    }
}