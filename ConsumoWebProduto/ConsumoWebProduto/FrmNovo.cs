using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumoWebProduto
{
    public partial class FrmNovo : Form
    {
        Form1 form1;
        public FrmNovo(Form1 form)
        {
            this.form1 = form;
            InitializeComponent();
        }
        public FrmNovo(Form1 form, int id)
        {
            this.form1 = form;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ServiceProduto.ProdutoServiceSoapClient client = new ServiceProduto.ProdutoServiceSoapClient();
            ServiceProduto.Produtos produto = new ServiceProduto.Produtos();
            produto.Id = int.Parse(txtId.Text);
            produto.Nome = txtNome.Text;
            produto.Preco = double.Parse(txtPreco.Text);
            produto.Estoque = int.Parse(txtEstoque.Text);
            produto.Descricao= txtDescricao.Text;
            client.Post(produto);

            MessageBox.Show("Inserido com sucesso");
           
            form1.AtualizaGrid();
        }
    }
}
