using Fintech.Dominio;
using Fintech.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FintechCorrentistaWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();


        public MainWindow()
        {
            InitializeComponent();
            PopularControles();
        }

        private void PopularControles()
        {
            sexoComboBox.Items.Add(Sexo.Feminino);
            sexoComboBox.Items.Add(Sexo.Masculino);
            sexoComboBox.Items.Add(Sexo.Outro);

            clienteDataGrid.ItemsSource = Clientes;

        }

        private void incluirClienteButton_Click(object sender, RoutedEventArgs e)
        {
            //int x = 10;//

            Cliente cliente = new();
            cliente.Cpf = cpfTextBox.Text;
            cliente.DataNascimento = Convert.ToDateTime(dataNascimentoTextBox.Text);

            var endereco = new Endereco();

            endereco.Logradouro = logradouroTextBox.Text;
            endereco.Cidade = cidadeTextBox.Text;
            endereco.Cep = cepTextBox.Text;
            endereco.Numero = numeroTextBox.Text;

            cliente.Endereco = endereco;

            cliente.Nome = nomeTextBox.Text;
            cliente.Sexo = (Sexo)sexoComboBox.SelectedItem;

            Clientes.Add(cliente);

            MessageBox.Show("Cliente cadastrado com sucesso");

            LimparControlesCliente();

            clienteDataGrid.Items.Refresh();

            pesquisaClienteTabItem.Focus();
        }

        private void LimparControlesCliente()
        {
            cpfTextBox.Clear();
            nomeTextBox.Clear();
            dataNascimentoTextBox.Clear();
            logradouroTextBox.Clear();
            cidadeTextBox.Clear();
            cepTextBox.Clear();
            numeroTextBox.Clear();
            sexoComboBox.SelectedIndex = -1;
            nomeTextBox.Clear();
        }
    }
}
