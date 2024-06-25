using System; 
using System.Collections.Generic;

class Program
{
    static List<Produto> produtos = new List<Produto>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Adicionar Produto");
            Console.WriteLine("2 - Remover Produto");
            Console.WriteLine("3 - Editar Produto");
            Console.WriteLine("4 - Visualizar Produtos");
            Console.WriteLine("5 - Sair");

            int opcao;
            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                switch (opcao)
                {
                    case 1:
                        AdicionarProduto();
                        break;
                    case 2:
                        RemoverProduto();
                        break;
                    case 3:
                        EditarProduto();
                        break;
                    case 4:
                        VisualizarProdutos();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }
    }

    static void AdicionarProduto()
    {
        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine();

        Produto produto = new Produto { Nome = nome };
        produtos.Add(produto);

        Console.WriteLine("Produto adicionado com sucesso!");
    }

    static void RemoverProduto()
    {
        Console.Write("Digite o ID do produto a ser removido: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Produto produto = produtos.Find(p => p.ID == id);
            if (produto != null)
            {
                produtos.Remove(produto);
                Console.WriteLine("Produto removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }

    static void EditarProduto()
    {
        Console.Write("Digite o ID do produto a ser editado: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Produto produto = produtos.Find(p => p.ID == id);
            if (produto != null)
            {
                Console.Write("Digite o novo nome do produto: ");
                string novoNome = Console.ReadLine();
                produto.Nome = novoNome;
                Console.WriteLine("Produto editado com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido. Tente novamente.");
        }
    }

    static void VisualizarProdutos()
    {
        Console.WriteLine("Lista de Produtos:");
        foreach (var produto in produtos)
        {
            Console.WriteLine($"ID: {produto.ID}, Nome: {produto.Nome}");
        }
    }
}

class Produto
{
    private static int proximoID = 1;

    public int ID { get; private set; }
    public string Nome { get; set; }

    public Produto()
    {
        ID = proximoID++;
    }
}
