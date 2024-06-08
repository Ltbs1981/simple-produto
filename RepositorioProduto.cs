using System;
using System.Collections.Generic;
using System.Linq;

public class RepositorioProduto
{
    private List <Produto> produtos = new List<Produto>();
    
    // Create
    public void AdicionarProduto(Produto produto)
    {
        produtos.Add(produto);
    }

    // Read
    public List<Produto> ObterTodosProdutos()
    {
        return produtos;
    }

    public Produto ObterProdutoPorId(int id)
    {
        return produtos.FirstOrDefault(p => p.Id == id);
    }

    // Update
    public void AtualizarProduto(Produto produtoAtualizado)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == produtoAtualizado.Id);
        if (produto != null)
        {
            produto.Nome = produtoAtualizado.Nome;
            produto.Preco = produtoAtualizado.Preco;
            produto.Quantidade = produtoAtualizado.Quantidade;
        }
    }

    // Delete
    public void RemoverProduto(int id)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);
        if (produto != null)
        {
            produtos.Remove(produto);
        }
    }
}
