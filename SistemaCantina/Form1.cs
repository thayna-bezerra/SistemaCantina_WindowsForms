using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCantina
{
    public partial class Form1 : Form
    {
        string[] produtos = new string[6];
        string[] codigo = new string[6];
        double[] valor = new double[6];
        double soma;
        // arrays para armazenar 6 produtos -- códigos e valores

        public Form1()
        {
            InitializeComponent();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            //se o usuário digitar um código com 3 caracteres (length), esse código é adicionado ao listBox. 
            if (txtCodigo.Text.Length == 3) //length retorna a quantidade de caracteres
            {
                int indice = 0;
                for (int prod = 1; prod < codigo.Length; prod++) // enquanto o prod for menor ou igual a qtde de itens do array 
                {
                    if(txtCodigo.Text == codigo[prod]) //definindo a posição do array
                    {
                        indice = prod;
                    }
                }

                if (indice == 0)
                {
                    MessageBox.Show("Produto não encontrado", "Tente Novamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // se foi encontrado o produto ele retorna as informações de acordo com a posição na array
                    // se não, aparece a caixa de mensagem informando que o produto não foi encontrado
                }

                else
                {
                    lstCaixa.Items.Add(txtCodigo.Text + " -- " + produtos[indice] + "-- R$ " + valor[indice]); //add na listbox
                    soma = soma + valor[indice];
                    label1.Text = ("R$ " + soma);

                    picBox.ImageLocation = "c:/imagens/" + codigo[indice] + ".jpg"; //localização da imagem (pasta imagens no computador // cada foto fica com o código definido como o nome)
                    txtCodigo.Text = "";//o textbox será limpo
                    txtCodigo.Focus();//Focus posiciona o cursor para o TextBox para uma nova digitação
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            carregarArray(); //chama a função com os arrays definidos
            soma = 0; //zera a variável q soma todos os produtos da lista
        }

        private void carregarArray()
        {
            codigo[1] = "001";
            codigo[2] = "002";
            codigo[3] = "003";
            codigo[4] = "004";
            codigo[5] = "005";

            produtos[1] = "Pastel";
            produtos[2] = "Coxinha";
            produtos[3] = "Hot Dog";
            produtos[4] = "Chocolate";
            produtos[5] = "Suco";

            valor[1] = 6.00;
            valor[2] = 5.00;
            valor[3] = 12.00;
            valor[4] = 3.50;
            valor[5] = 8.00;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close(); //fecha form
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lstCaixa.Items.Clear(); //limpa informações da lista
            picBox.ImageLocation = ""; //limpa imagem da picture box
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
