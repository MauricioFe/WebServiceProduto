using ConsumoWebProduto.ServiceProduto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumoWebProduto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        public void AtualizaGrid()
        {
            ServiceProduto.ProdutoServiceSoapClient client = new ProdutoServiceSoapClient();
            dgvProdutos.DataSource = client.GetProdutos();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmNovo form = new FrmNovo(this);
            form.ShowDialog();
        }
    }
}
