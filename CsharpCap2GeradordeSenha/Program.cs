using System;


namespace CsharpCap2GeradordeSenha
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Informe a quantidade de dígitos da senha (par, entre 4 e 10)");

            var qtdDigitos = 0;

            while (qtdDigitos == 0)
            {
                qtdDigitos = ObterQuantidadeDigitos();
            }*/

            //var qtdDigitos = Convert.ToInt32(Console.ReadLine());

            //if (qtdDigitos < 4 || qtdDigitos % 2 != 0 || qtdDigitos > 10)


            int qtdDigitos;

            do
            {
                Console.WriteLine("Informe a quantidade de dígitos da senha (par, entre 4 e 10)");
                qtdDigitos = ObterQuantidadeDigitos();
            } while (qtdDigitos == 0);

            var senha = new Senha(qtdDigitos);
            

            Console.WriteLine($"Senha gerada: {senha.Valor}");
            Console.ReadLine();

            static int ObterQuantidadeDigitos()
            {
                int.TryParse(Console.ReadLine(), out int qtdDigitos);
                if (qtdDigitos is < 4 or > 10 || qtdDigitos % 2 != 0)
                {
                    Console.WriteLine($"A quantidade {qtdDigitos}, é inválida, tente novamente.");
                    qtdDigitos = 0;
                    //Console.ReadKey();
                    //return;
                }
                return qtdDigitos;
            }
        }
    }
}
