using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CriterioDeSturges
{
    public partial class Form1 : Form
    {
        List<double> ListaNumeros = new List<double>();
        public Form1()
        {
            InitializeComponent();
            //double[] range = new double[20] { 75.0, 60.1, 74.6, 68.1, 64.3, 67.2, 75.3, 79.3, 66.4, 86.6, 80.0, 85.0, 72.5, 73.2, 68.9, 71.0, 81.3, 64.2, 73.0, 81.2 };
            //ListaNumeros.AddRange(range);
            //double[] range = new double[30] { 52, 27, 46, 15, 22, 20, 68, 73, 19, 30, 33, 58, 24, 35, 32, 27, 42, 30, 45, 40, 70, 21, 27, 50, 51, 31, 17, 20, 60, 63 };
            //ListaNumeros.AddRange(range);
            ListarNumeros();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adicionar();
        }
        private void Adicionar()
        {
            ListaNumeros.Add((double)numericUpDown1.Value);
            CleanAndFocusNUD();
            ListarNumeros();
        }
        private void CleanAndFocusNUD()
        {
            numericUpDown1.Value = 0;
            numericUpDown1.Focus();
            numericUpDown1.Select(0, 3);
        }

        private void ListarNumeros()
        {
            richTextBox1.Clear();

            foreach (double numero in ListaNumeros)
            {
                richTextBox1.AppendText($"{numero} - ");
            }
            label1.Text = $"Numeros adicionados: {ListaNumeros.Count}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
                if (ListaNumeros.Count > 1)
                {
                    FormTabela formTabela = new FormTabela(ListaNumeros);
                    formTabela.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Adicione mais números para gerar a tabela!");
                    CleanAndFocusNUD();
                }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ListaNumeros.Clear();
            richTextBox1.Clear();
            label1.Text = "Numeros adicionados: 0";
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                Adicionar();
            }
        }
    }
}
