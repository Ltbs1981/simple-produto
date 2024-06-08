using System;

class Program
{
    static void Main(string[] args)
    {
        RepositorioProduto repositorio = new RepositorioProduto();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Adicionar Produto");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Atualizar Produto");
            Console.WriteLine("4 - Remover Produto");
            Console.WriteLine("5 - Sair");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    AdicionarProduto(repositorio);
                    break;
                case 2:
                    ListarProdutos(repositorio);
                    break;
                case 3:
                    AtualizarProduto(repositorio);
                    break;
                case 4:
                    RemoverProduto(repositorio);
                    break;
                case 5:
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    static void AdicionarProduto(RepositorioProduto repositorio)
    {
        Produto novoProduto = new Produto();
        Console.Write("Id: ");
        novoProduto.Id = int.Parse(Console.ReadLine());
        Console.Write("Nome: ");
        novoProduto.Nome = Console.ReadLine();
        Console.Write("Preço: ");
        novoProduto.Preco = decimal.Parse(Console.ReadLine());
        Console.Write("Quantidade: ");
        novoProduto.Quantidade = int.Parse(Console.ReadLine());

        repositorio.AdicionarProduto(novoProduto);
        Console.WriteLine("Produto adicionado com sucesso!");
    }

    static void ListarProdutos(RepositorioProduto repositorio)
    {
        var produtos = repositorio.ObterTodosProdutos();
        foreach (var produto in produtos)
        {
            Console.WriteLine($"Id: {produto.Id}, Nome: {produto.Nome}, Preço: {produto.Preco}, Quantidade: {produto.Quantidade}");
        }
    }

    static void AtualizarProduto(RepositorioProduto repositorio)
    {
        Console.Write("Id do produto a ser atualizado: ");
        int id = int.Parse(Console.ReadLine());
        var produto = repositorio.ObterProdutoPorId(id);
        if (produto != null)
        {
            Console.Write("Novo Nome: ");
            produto.Nome = Console.ReadLine();
            Console.Write("Novo Preço: ");
            produto.Preco = decimal.Parse(Console.ReadLine());
            Console.Write("Nova Quantidade: ");
            produto.Quantidade = int.Parse(Console.ReadLine());

            repositorio.AtualizarProduto(produto);
            Console.WriteLine("Produto atualizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado!");
        }
    }

    static void RemoverProduto(RepositorioProduto repositorio)
    {
        Console.Write("Id do produto a ser removido: ");
        int id = int.Parse(Console.ReadLine());
        repositorio.RemoverProduto(id);
        Console.WriteLine("Produto removido com sucesso!");
    }
}
