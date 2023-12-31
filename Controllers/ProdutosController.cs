﻿using API_DoeMais.Model;
using API_DoeMais.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace API_DoeMais.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private ProdutoRepositorio _produtoRepositorio;

        // GET api/produtos
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetProdutos()
        {
            _produtoRepositorio = new ProdutoRepositorio();
            return _produtoRepositorio.GetProdutos();
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> Get(int id)
        {
            _produtoRepositorio = new ProdutoRepositorio();
            return _produtoRepositorio.GetProdutoId(id);
        }


        [HttpPost("/post")]
        public ActionResult<bool> Post([FromBody] JObject jsonData)
        {
            _produtoRepositorio = new ProdutoRepositorio();



            //Produto prod = new Produto();
            //prod.nome = nome;
            //prod.descricao = descricao;
            //_produtoRepositorio.PostProduto(prod);
            return true;
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            _produtoRepositorio = new ProdutoRepositorio();

            _produtoRepositorio.DeleteProduto(id);
            return true;
        }
    }
}
