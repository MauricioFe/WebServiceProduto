using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Linq;

namespace WebService
{
    /// <summary>
    /// Summary description for ProdutoService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProdutoService : System.Web.Services.WebService
    {
        string currentFile = $@"{AppDomain.CurrentDomain.BaseDirectory}Produto.xml";
        [WebMethod]
        public Produtos Post(int id, string nome, double preco, int estoque, string descricao)
        {
            Produtos produto = new Produtos(id, nome, preco, estoque, descricao);
            XElement x = new XElement("Produto");
            x.Add(new XElement("ID", produto.Id.ToString()));
            x.Add(new XElement("Nome", produto.Nome.ToString()));
            x.Add(new XElement("Preco", produto.Preco.ToString("F2")));
            x.Add(new XElement("Estoque", produto.Estoque.ToString()));
            x.Add(new XElement("Descricao", produto.Descricao.ToString()));
            XElement xml = null;
            if (!File.Exists(currentFile))
            {
                var document = new XDocument(new XElement("Produtos"));
                document.Save(currentFile);
            }
            xml = XElement.Load(currentFile);
            xml.Add(x);
            xml.Save(currentFile);
            return produto;
        }

        [WebMethod]
        public List<Produtos> GetProdutos()
        {
            List<Produtos> produtosList = new List<Produtos>();
            XElement xml = XElement.Load(currentFile);
            foreach (XElement element in xml.Elements())
            {
                Produtos produto = new Produtos()
                {
                    Id = int.Parse(element.Element("ID").Value),
                    Nome = element.Element("Nome").Value,
                    Preco = Convert.ToDouble(element.Element("Preco").Value, CultureInfo.InvariantCulture),
                    Estoque = int.Parse(element.Element("Estoque").Value),
                    Descricao = element.Element("Descricao").Value
                };
                produtosList.Add(produto);
            }
            return produtosList;
        }
        [WebMethod]
        public Produtos GetProdutoById(int id)
        {
            Produtos produto = new Produtos();
            var xml = XElement.Load(currentFile);
            var elements = xml.Elements().Where(p => p.Element("ID").Value.Equals(id.ToString())).First();
            produto.Id = int.Parse(elements.Element("ID").Value);
            produto.Nome = elements.Element("Nome").Value;
            produto.Preco = double.Parse(elements.Element("Preco").Value, CultureInfo.InvariantCulture) ;
            produto.Estoque = int.Parse(elements.Element("Estoque").Value);
            produto.Descricao = elements.Element("Descricao").Value;

            return produto;
        }

        [WebMethod]
        public string Delete(int id)
        {
            var xml = XElement.Load(currentFile);
            var element = xml.Elements().Where(p => p.Element("ID").Value.Equals(id.ToString())).First();
            if (element == null)
            {
                return "Produto não encontrado";
            }

            element.Remove();
            xml.Save(currentFile);
            return "Produto exlcuído com sucesso";
        }

        [WebMethod]
        public Produtos Put(int id, string nome, double preco, int estoque, string descricao)
        {
            Produtos produto = new Produtos(id, nome, preco, estoque, descricao);
            var xml = XElement.Load(currentFile);
            var element = xml.Elements().Where(p => p.Element("ID").Value.Equals(produto.Id.ToString())).First();
            if (element != null)
            {
                element.Element("Nome").SetValue(produto.Nome);
                element.Element("Preco").SetValue(produto.Preco.ToString("F2"));
                element.Element("Estoque").SetValue(produto.Estoque);
                element.Element("Descricao").SetValue(produto.Descricao);
            }
            xml.Save(currentFile);
            return produto;
        }

    }
}
