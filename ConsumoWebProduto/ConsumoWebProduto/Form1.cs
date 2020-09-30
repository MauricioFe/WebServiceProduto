﻿using ConsumoWebProduto.ServiceProduto;
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
        ServiceProduto.Produtos produto = new Produtos();
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

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            produto.Id = Convert.ToInt32(dgvProdutos.Rows[e.RowIndex].Cells[0].Value);
            produto.Nome = dgvProdutos.Rows[e.RowIndex].Cells[0].Value.ToString();
            produto.Preco = Convert.ToDouble(dgvProdutos.Rows[e.RowIndex].Cells[0].Value);
            produto.Estoque = Convert.ToInt32(dgvProdutos.Rows[e.RowIndex].Cells[0].Value);
            produto.Descricao= dgvProdutos.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}
