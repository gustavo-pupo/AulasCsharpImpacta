using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpCap2GeradordeSenha
{
    public class Senha
    {
        //public Senha()
        //{
        //    Valor = Gerar();
        //}

        public Senha(int tamanho = TamanhoMinimo)
        {
            Tamanho = tamanho;
            Valor = Gerar();
        }

        public const int TamanhoMinimo = 4;
        public const int TamanhoMaximo = 10;
        public string Valor { get; set; }
        public int Tamanho { get; set; }

        public string Gerar()
        {
            var senha = string.Empty /* "" */;
            var randomico = new Random();

            for (int i = 0; i < Tamanho; i++)
            {
                var digito = randomico.Next(10);

                senha += digito;
                //senha = senha + digito;
            }
            return senha;
        }
    }
}
