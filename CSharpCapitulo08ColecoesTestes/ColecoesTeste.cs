using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCapitulo08ColecoesTestes
{
    [TestClass]
    public class ColecoesTeste
    {
        [TestMethod]
        public void ListTeste()
        {
            var inteiros = new List<int>(1000) { 1, 8, 33, 16, -78 };
            inteiros.Add(10);
            inteiros[0] = 13;
            //inteiros[20] = -25;
            inteiros.Add(27);
            inteiros.Add(-8);

            var maisInteiros = new List<int> { 16, 78, 23, 323, 12 };

            inteiros.AddRange(maisInteiros);

            inteiros.Insert(2, 42);

            inteiros.Remove(8);

            inteiros.RemoveAt(5);

            inteiros.Sort();

            var primeiro = inteiros[0];
            primeiro = inteiros.First();

            var ultimo = inteiros[inteiros.Count - 1];
            ultimo = inteiros.Last();


            foreach (var numero in inteiros)
            {

                Console.WriteLine($"{inteiros.IndexOf(numero)}:{numero}");
            
            }

        }

        [TestMethod]
        public void DictionaryTeste()
        {
            var feriados = new Dictionary<DateTime, string>();

            feriados.Add(new DateTime(2022, 1, 1), "Ano Novo");
            feriados.Add(Convert.ToDateTime("25/12/2021"), "Natal");
            feriados.Add(Convert.ToDateTime("2022/9/7"), "Independência");
            //feriados.Add(Convert.ToDateTime("2022/9/7"), "Independência");
             

            var natal = feriados[Convert.ToDateTime("2021/12/25")];

            foreach (var dia in feriados.OrderBy(f => f.Key))
            {
                Console.WriteLine($"{dia.Key:d}:{dia.Value}");
            }

            Assert.IsTrue(feriados.ContainsKey(new DateTime(2022,1,1)));
            Assert.IsTrue(feriados.ContainsValue("Natal"));
        }
    }
}
