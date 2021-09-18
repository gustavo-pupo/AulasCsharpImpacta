using Microsoft.VisualStudio.TestTools.UnitTesting;
using FintechRepositoriosSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fintech.Dominio.Entidades;

namespace FintechRepositoriosSqlServer.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {

        private readonly MovimentoRepositorio repositorio = new(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Fintech; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        [TestMethod()]
        public void InserirTest()
        {
            var agencia = new Agencia();
            agencia.Numero = 53;

            var contaFake = new ContaCorrente(agencia, 233, "4");
            var movimento = new Movimento(Operacao.Deposito, 50);
            movimento.Conta = contaFake;

            repositorio.Inserir(movimento);
        }
    }
}