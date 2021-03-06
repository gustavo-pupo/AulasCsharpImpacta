using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTesteCapitulo02
{
    [TestClass]
    public class DecisaoTeste
    {
        [TestMethod]
        public void AvalicaoFinalReprovadoTeste()
        {
            var notaFinal = 2.9;
            var resultadoFinal = "";

            if (notaFinal < 3)
            {
                resultadoFinal = "Reprovado!";
            }

            else if (notaFinal is >= 3 and < 5)
            {
                resultadoFinal = "Recuperação";
            }

            else
            {
                resultadoFinal = "Aprovado";
            }

            Assert.AreEqual(resultadoFinal, "Reprovado!");
        }
        
        [TestMethod]
        public void AvFinalRecTeste()
        {
            var notaFinal = 3.0;
            var resultadoFinal = "";

            switch (notaFinal)
            {
                case < 3:
                    resultadoFinal = "Reprovado";
                    break;

                case >= 3 and < 5:
                    resultadoFinal = "Recuperação";
                    break;

                default:
                    resultadoFinal = "Aprovado";
                    break;
            }
            Assert.AreEqual(resultadoFinal, "Recuperação");
        }
        [TestMethod]
        public void AvFinalRec4Teste()
        {
            var notaFinal = 4.9;
            var resultadoFinal = "";

            resultadoFinal = notaFinal switch
            {
                < 3 => "Reprovado",

                >=3 and <5 => "Recuperação",

                _ => "Aprovado"
            };
            Assert.AreEqual(resultadoFinal, "Recuperação");
        }
        [TestMethod]
        [DataRow(2.9, "Reprovado")]
        [DataRow(3, "Recuperação")]
        [DataRow(4.9, "Recuperação")]
        [DataRow(5, "Aprovado")]


        public void AvFinalTeste(double notaFinal, string resultadoEsperado)
        {
            var resultadoFinal = notaFinal switch
            {
                < 3 => "Reprovado",
                
                >= 3 and < 5 => "Recuperação",

                _ => "Aprovado"
            };
            Assert.AreEqual(resultadoFinal, resultadoEsperado);
        }
    }
}
