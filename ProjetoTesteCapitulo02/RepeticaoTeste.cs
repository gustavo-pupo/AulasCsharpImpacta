using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProjetoTesteCapitulo02
{
    [TestClass]
    public class RepeticaoTeste
    {
        [TestMethod]
        public void TabuadaTeste()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int n = 1; n <= 10; n++)
                {
                    Console.WriteLine($"{i} * {n} = {i * n}");
                }
                Console.WriteLine(new string('=', 50));                
            }
        }

        [TestMethod]
        public void EstruturaForTeste()
        {
            var i = 1;
            for (Console.WriteLine("Come�ou") ; i <= 3; Console.WriteLine(i))
            {
                i++;
            }
            /*for (1. Inicializa��o;2. Condi��o ; 4. P�s Exexu��o)
            {
                3.Execu��o
            }*/
        }

        [TestMethod]
        public void ForApenasComCondi��o()
        {
            var i = 1;
            for (; i <= 3 ;)
            {
                Console.WriteLine(i++);
            }
        }

        [TestMethod]
        public void ContinueTeste()
        {
            for (int i = 0; i <=10; i++)
            {
                if (i<=5)
                {
                    continue;
                }
                Console.WriteLine(i);
            }
        }
        [TestMethod]
        public void BreakTeste()
        {
            for (int i = 1; i <=5 ; i++)
            {
                if (i >= 5)
                {
                    break;
                }
                Console.WriteLine(i);
            }
        }
    }
}