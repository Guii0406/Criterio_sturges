using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriterioDeSturges
{
    public partial class FormTabela : Form
    {
        List<double> ListaNumeros;
        double maiorNumero;
        double menorNumero;
        public FormTabela(List<double> ListaNumeros)
        {
            InitializeComponent();
            this.ListaNumeros = ListaNumeros;
            maiorNumero = ListaNumeros.Max();
            menorNumero = ListaNumeros.Min();
            GerarTabela();
        }
        private int CalcularH()
        {
            int quantidadeNumeros = ListaNumeros.Count;
            double k = 1 + 3.3 * Math.Log10(quantidadeNumeros);
            int h = Convert.ToInt32(Math.Round((maiorNumero - menorNumero) / k));
            return h;
        }
        private void GerarTabela()
        {
            int somaFs = 0;
            double somaPorcentagens = 0;
            int h = CalcularH();
            int novoMenornumero = Convert.ToInt32(menorNumero);

            for (; novoMenornumero < maiorNumero; novoMenornumero += h)
            {
                string primeiraCelula = $"{novoMenornumero} a {novoMenornumero + h}";
                int f = 0;
                foreach (double numero in ListaNumeros)
                {
                    if (numero >= novoMenornumero && numero < novoMenornumero + h)
                    {
                        f++;
                    }
                }
                somaFs += f;
                somaPorcentagens += CalcularPorcentagem(f);
                string segundaCelula = f.ToString();
                string terceiraCelula = somaFs.ToString();
                double quartaCelula = Math.Round(CalcularPorcentagem(f), 1);
                double quintaCelula = Math.Round(somaPorcentagens, 1);

                string[] linha = new string[5] { primeiraCelula, segundaCelula, terceiraCelula, $"{quartaCelula}%", $"{quintaCelula}%" };

                listView1.Items.Add(new ListViewItem(linha));
            }
            string[] total = new string[5] { "Total", somaFs.ToString(), "", $"{Math.Round(somaPorcentagens)}%", "" };
            listView1.Items.Add(new ListViewItem(total));
        }

        private double CalcularPorcentagem(int f)
        {
            double x = (100.0 * f) / ListaNumeros.Count;
            return x;
        }
    }
}
