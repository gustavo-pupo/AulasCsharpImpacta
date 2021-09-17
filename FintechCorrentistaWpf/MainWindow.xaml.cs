using Fintech.Dominio;
using Fintech.Dominio.Entidades;
using FintechRepositoriosSistemaArquivos;
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
        private readonly MovimentoRepositorio movimentoRepositorio = new(Properties.Settings.Default.CaminhoArquivoMovimento);
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public Cliente ClienteSelecionado { get; set; }

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

            var banco = new Banco() { Nome = "Banco Um", Numero = 154 };


            bancoComboBox.Items.Add(banco);
            bancoComboBox.Items.Add(new Banco() { Nome = "Banco Dois", Numero = 420 });

            tipoContaComboBox.Items.Add(TipoContas.ContaCorrente);
            tipoContaComboBox.Items.Add(TipoContas.ContaEspecial);
            tipoContaComboBox.Items.Add(TipoContas.Poupanca);

            operacaoComboBox.Items.Add(Operacao.Deposito);
            operacaoComboBox.Items.Add(Operacao.Saque);


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

        private void SelecionarClienteButtonClick(object sender, RoutedEventArgs e)
        {
            SelecionarCliente(sender);

            clienteTextBox.Text = ClienteSelecionado.ToString();

            contasTabItem.Focus();
        }

        private void SelecionarCliente(object sender)
        {
            var botaoClicado = (Button)sender;
            var clienteSelecionado = botaoClicado.DataContext;

            ClienteSelecionado = (Cliente)clienteSelecionado;
        }

        private void tipoContaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (tipoContaComboBox.SelectedIndex == -1) return;
            
            var tipoConta = (TipoContas)tipoContaComboBox.SelectedItem;

            if (tipoConta == TipoContas.ContaEspecial)
            {
                limiteDockPanel.Visibility = Visibility.Visible;
                limiteTextBox.Focus();
            }
            else
            {
                limiteDockPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void incluirContaButton_Click(object sender, RoutedEventArgs e)
        {
            
            Conta conta = null;
            var agencia = new Agencia();
            agencia.Banco = (Banco)bancoComboBox.SelectedItem;
            agencia.Numero = Convert.ToInt32(numeroAgenciaTextBox.Text);
            agencia.DigitoVerificador = Convert.ToInt32(dvAgenciaTextBox.Text);

            var numero = Convert.ToInt32(numeroContaTextBox.Text);
            var digitoVerificador = dvContaTextBox.Text;

            switch ((TipoContas)tipoContaComboBox.SelectedItem)
            {
                case TipoContas.ContaCorrente:
                    conta = new ContaCorrente(agencia, numero, digitoVerificador);
                    break;

                case TipoContas.ContaEspecial:
                    var limite = Convert.ToDecimal(limiteTextBox.Text);
                    conta = new ContaEspecial(agencia, numero, digitoVerificador, limite);
                    break;

                case TipoContas.Poupanca:
                    conta = new Poupanca(agencia, numero, digitoVerificador);
                    break;
            }

            ClienteSelecionado.Contas.Add(conta);

            MessageBox.Show("Conta adicionada com sucesso");
            LimparControlesConta();

            clienteDataGrid.Items.Refresh();
            clientesTabItem.Focus();

        }

        private void LimparControlesConta()
        {
            clienteTextBox.Clear();
            bancoComboBox.SelectedIndex = -1;
            numeroAgenciaTextBox.Clear();
            dvAgenciaTextBox.Clear();
            numeroContaTextBox.Clear();
            tipoContaComboBox.SelectedIndex = -1;
            limiteTextBox.Clear();
        }

        private void SelecionarContaButtonClick(object sender, RoutedEventArgs e)
        {
            SelecionarCliente(sender);

            contaTextBox.Text = ClienteSelecionado.ToString();

            contaComboBox.ItemsSource = ClienteSelecionado.Contas;
            contaComboBox.Items.Refresh();

            operacoesTabItem.Focus();
        }

        private void incluirOperacaoButton_Click(object sender, RoutedEventArgs e)
        {
            var conta = (Conta)contaComboBox.SelectedItem;
            var operacao = (Operacao)operacaoComboBox.SelectedItem;
            var valor = Convert.ToDecimal(valorTextBox.Text);

            var movimento = conta.EfetuarOperacao(valor, operacao);

            if (movimento != null)
            {
                var repositorio = new MovimentoRepositorio("");
                repositorio.Inserir(movimento); 
            }

           
            AtualizarGridMovimentacao(conta);

        }

        private void AtualizarGridMovimentacao(Conta conta)
        {
            movimentacaoDataGrid.ItemsSource = conta.Movimentos;
            movimentacaoDataGrid.Items.Refresh();

            saldoTextBox.Text = conta.Saldo.ToString("C");
        }

        private void contaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var conta = (Conta)contaComboBox.SelectedItem;

            movimentoRepositorio.Selecionar(conta.Agencia.Numero, conta.Numero);

            AtualizarGridMovimentacao(conta);
        }
    }
}
