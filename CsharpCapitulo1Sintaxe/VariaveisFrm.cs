using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpCapitulo1Sintaxe
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void AritmeticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultadoListBox.Items.Clear();
            //tipos de dados pg.25

            int x = 21;
            string nome = "Gustavo";
            string sobreNome = "Pupo";

            x = 1;
            //x = "29"; //estaticamente tipada

            char letra = 'a';
            bool aprovado = true;
            string KEKW = "KE\"KW";
            DateTime nascimento = new DateTime(2003, 2, 24);

            decimal valor = 21.289m;
            double outroValor = 12.345;

            long populacao = 8978978964568787L;
            float distancia = 100.32f;
            decimal media = x + valor;

            object camaleao = "Erik";
            camaleao = 5;
            camaleao = DateTime.Now;

            int a = 2;
            var b = 6;
            var c = 10;
            var d = 13;

            //var nomeCanção = "Dreamy Nights"; evitar caracteres como ç e ~ em nomes de variáveis
            //var @class = "3D"; /*("@" quebra o sentido da palavra seguinte)*/

            // tipos diferentes de concatenação
            resultadoListBox.Items.Add("Valor de A: " + a/*.ToString()*/);  // Shift + Ctrl + Space; ler de trás para 
            resultadoListBox.Items.Add(string.Concat("Valor de B: ", b));
            resultadoListBox.Items.Add(string.Format("Valor de C: {0}", c));
            //resultadoListBox.Items.Add(string.Format("Valor de C: {0} - D: ", c, d));
            resultadoListBox.Items.Add($"Valor de D: {d}"); //tipo JS


            resultadoListBox.Items.Add($"C X D = {c * d}");
            resultadoListBox.Items.Add($"D / A = {d / a}");
            resultadoListBox.Items.Add($"D % A = {d % a}");



        }

        private void reduzidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultadoListBox.Items.Clear();

            var x = 5;
            resultadoListBox.Items.Add($"x = {x}");
            resultadoListBox.Items.Add("--------------------------------");

            //x = x - 3;
            x -= 3;
            resultadoListBox.Items.Add($"x - 3 = {x}");
        }

        private void incrementaisDecrementaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultadoListBox.Items.Clear();

            int a;

            a = 5;
            resultadoListBox.Items.Add("Exemplo de pré");
            resultadoListBox.Items.Add($"a={a}");
            resultadoListBox.Items.Add($"2 + ++a = {2 + ++a}");//8
            resultadoListBox.Items.Add($"a = {a}");

            resultadoListBox.Items.Add(new string('=', 100));

            a = 5;
            resultadoListBox.Items.Add("Exemplo de pós");
            resultadoListBox.Items.Add($"a={a}");
            resultadoListBox.Items.Add($"2 + a++ = {2 + a++}");//7
            resultadoListBox.Items.Add($"a = {a}");
        }

        int x = 32;
        int y = 16;
        int z = 45;
        int sig = 48;

        private void BooleanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirValores();

            resultadoListBox.Items.Add($"sig <= x = {sig <= x}");
            resultadoListBox.Items.Add($"x == z = {x == z}");
            resultadoListBox.Items.Add($"x != z = {x != z}");


        }
        void ExibirValores()
        {
            resultadoListBox.Items.Clear();

            resultadoListBox.Items.Add($"x = {x}");
            resultadoListBox.Items.Add($"y = {y}");
            resultadoListBox.Items.Add($"z = {z}");
            resultadoListBox.Items.Add($"sig = {sig}");

            resultadoListBox.Items.Add(new string('=', 100));
        }
        private void logicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultadoListBox.Items.Add($"sig <= x || sig y == 16 = {sig <= x || y == 16}");
            resultadoListBox.Items.Add($"x == z && x != z = {x == z && x != z}");
            resultadoListBox.Items.Add($"(y > sig){!(y > sig)}");







            //if (true) 
            //{
            //    var x = 10;
            //}
            //var x = 5;
        }

        private void ternarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultadoListBox.Items.Clear();
            int ano;

            //não fazer ternários muito extensos
            ano = 2014;
            resultadoListBox.Items.Add($"O ano {ano} é bissexto? { (ano % 4 == 0 ? "sim" : "não")}");

            ano = 2016;
            resultadoListBox.Items.Add($"O ano {ano} é bissexto? { (DateTime.IsLeapYear(ano)? "sim" : "não")}");

            ano = 1988;
            var resposta = "";
            if (DateTime.IsLeapYear(ano))
            {
                resposta = "Sim";
                resultadoListBox.Items.Add($"O ano {ano} é bissexto? {resposta}");
            }
            else
            {
                resposta = "Não"; 
                resultadoListBox.Items.Add($"O ano {ano} é bissexto? {resposta}");
            }

        }
    }
}
