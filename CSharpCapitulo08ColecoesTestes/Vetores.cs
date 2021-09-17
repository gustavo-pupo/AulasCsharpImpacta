using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharpCapitulo08ColecoesTestes
{
    [TestClass]
    public class VetoresTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            var inteiros = new int[5];
            inteiros[0] = 1;
            inteiros[1] = 2;
            inteiros[2] = 3;
            inteiros[3] = 4;
            inteiros[4] = 5;
            //inteiros[5] = 6; /*quebra a execução*/

            var decimais = new decimal[] { 0.3m, 0.8m, 0.2m, 4, 3.3m };

            string[] nomes = { };

            var chars = new[] {"l","a"};

            foreach (var @decimal in decimais)
            {
                Console.WriteLine(@decimal);
            }

            Console.WriteLine($"O tamanho do vetor {nameof(decimais)} é {decimais.Length}");

        }

        [TestMethod]
        public void RedimensionamentoTeste()
        {
            var decimais = new decimal[] { 0.3m, 0.8m, 0.2m, 4, 3.3m };

            Array.Resize(ref decimais, 6);

            decimais[5] = 2.3m;
        }
        [TestMethod]
        public void OrdenarTeste()
        {
            var decimais = new decimal[] { 0.3m, 0.8m, 0.2m, 4, 3.3m };

            Array.Sort(decimais);

            Console.WriteLine(decimais[0]);

            Assert.AreEqual(decimais[0], 0.2m);
        }


        [TestMethod]
        public void ParamsTeste()
        {
            var decimais = new decimal[] { 0.3m, 0.8m, 0.2m, 4, 3.3m };

            Console.WriteLine(Media(decimais));

            Console.WriteLine(Media(0.9m, 0.73m, 3.3m, -2.4m, 21.4m));
        }

        public decimal media(decimal x, decimal y)
        {
            //x = 14.3m;
            //y = 23.4m;
            decimal soma = x + y;

            decimal total = soma / 2;

            return total;
        }

        private decimal Media(params decimal[] decimais)
        {
            //decimais = new decimal[] { 0.3m, 0.8m, 0.2m, 4, 3.3m };

            decimal soma = 0;

            foreach (var numero in decimais)
            {
                
                soma += numero;

            }

            decimal media = soma / decimais.Length;  
            

            return media;
        }

        [TestMethod]
        public void TodaStringEhUmVetorTeste()
        {
            var nome = "Gustavo";

            Assert.AreEqual(nome[0], 'G');

            //nome += "Pupo";
            //StringBuilder

            foreach (var @char in nome)
            {
                Console.Write(@char);
            }
        }



    }
 }
