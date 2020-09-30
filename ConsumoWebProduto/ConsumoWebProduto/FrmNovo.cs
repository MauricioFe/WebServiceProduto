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
        ServiceProduto.ProdutoServiceSoapClient client = new ServiceProduto.ProdutoServiceSoapClient();
        ServiceProduto.Produtos produto = new ServiceProduto.Produtos();
        public FrmNovo(Form1 form)
        {

            this.form1 = form;
            InitializeComponent();
        }
        public FrmNovo(Form1 form, ServiceProduto.Produtos produto)
        {
            this.produto = produto;
            this.form1 = form;
            InitializeComponent();
            txtId.Text = produto.Id.ToString();
            txtNome.Text = produto.Nome;
            txtPreco.Text = produto.Preco.ToString();
            txtEstoque.Text = produto.Estoque.ToString();
            txtDescricao.Text = produto.Descricao;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (produto.Id > 0)
            {
                produto.Id = int.Parse(txtId.Text);
                produto.Nome = txtNome.Text;
                produto.Preco = double.Parse(txtPreco.Text);
                produto.Estoque = int.Parse(txtEstoque.Text);
                produto.Descricao = txtDescricao.Text;
                client.Put(produto);

                MessageBox.Show("Editado com sucesso");

                form1.AtualizaGrid();
            }
            else
            {
                produto.Id = int.Parse(txtId.Text);
                produto.Nome = txtNome.Text;
                produto.Preco = double.Parse(txtPreco.Text);
                produto.Estoque = int.Parse(txtEstoque.Text);
                produto.Descricao = txtDescricao.Text;
                client.Post(produto);

                MessageBox.Show("Inserido com sucesso");

                form1.AtualizaGrid();
            }
        }

        private void FrmNovo_Load(object sender, EventArgs e)
        {

        }
    }
}
