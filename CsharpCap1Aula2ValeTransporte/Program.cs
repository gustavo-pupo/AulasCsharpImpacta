using System;

namespace CsharpCap1Aula2ValeTransporte
{
    class Program
    {
        static void Main(string[] args)
        {
            Inicio:

            Console.WriteLine("Informe o nome do funcionário: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Agora informe o salário: ");
            decimal salario = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Agora informe o valor gasto com transporte: ");
            decimal gastoComTransporte = Convert.ToDecimal(Console.ReadLine());

            decimal descontoMaximo = salario * 0.06m;
            decimal descontoEfetivo = gastoComTransporte > descontoMaximo ? descontoMaximo : gastoComTransporte;

            var resultado = $"\nFuncionário: {nome}" +
                $"\n Salário: {salario:C}" +
                $"\n Desconto Efetivo: {descontoEfetivo:C}";

            Console.WriteLine(resultado);

            Console.WriteLine("Pressone qualquer tecla para continuar ou Esc para sair");
            /*ConsoleKeyInfo */var comando = Console.ReadKey();

            if (comando.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            Console.Clear();

            //ToDo: Trocar o goto por uma estrutura de repetição
            goto Inicio;


        }
    }
}
