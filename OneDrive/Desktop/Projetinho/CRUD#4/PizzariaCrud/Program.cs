//Crud final da pizzaria.
using System;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
//list pagamento
List<string> metodosDePagamento = new List<string>();

//Dicionários do valor de entrega por bairros
Dictionary<string, int> valorBairros = new Dictionary<string, int>()
{
    {"Manaira", 5},
    {"Estados", 7},
    {"Valentina",20},
    {"Bancários", 12},
    {"Tambaúzinho", 9},
    {"Altiplano", 12},
    {"Ipês", 5},
    {"Mangabeira", 19},
    {"Outro", 11},
    {"Bessa", 11},
};

//list Refrigerante
List<int> valorRefrigerante = new List<int>();
List<string> tipoRefrigerante = new List<string>();

//List pizza
List<string> saborPizza = new List<string>();
List<int> valorPizza = new List<int>();

//lsit carrinho
List<string> carrinho = new List<string>();
List<int> valorItem = new List<int>();

//variaveis do while e tryparse
int valorTotal = 0;
int escolhaMenu = 1;
int UsuarioEscolhaRefrigerante = 1;

//variaveis valores dos refrigerantes 
int coca = 12;
int guarana = 10;

//variaveis valores das pizzas
int muçarela = 65;
int calabresa = 70;
int frango = 68;
int doisAmores = 75;
int abacaxi = 80;

void PrintMenuSaboresPizza()
{
    Console.WriteLine("====================FAMILIA OLIVEIRA============================");
    Console.WriteLine("[1] - Pizza de Muçarela.................................R$ 65,00");
    Console.WriteLine("[2] - Pizza de Calabresa................................R$ 70,00");
    Console.WriteLine("[3] - Pizza de Frango...................................R$ 68,00");
    Console.WriteLine("[4] - Pizza de Dois Amores..............................R$ 75,00");
    Console.WriteLine("[5] - Pizza de Abacaxi..................................R$ 80,00");
    Console.WriteLine("================================================================");
}

void PrintMenuRefrigerantes()
{
    Console.WriteLine("====================REFRIGERANTES===============================");
    Console.WriteLine("[1] - Coca-Cola 1 L.....................................R$ 12,00");
    Console.WriteLine("[2] - Guaraná   1 L.....................................R$ 10,00");
    Console.WriteLine("================================================================");
}

// fluxo das pizzas 
void escolhaSaborDaPizza()
{
    bool continuar = true;

    while (continuar)
    {
        PrintMenuSaboresPizza();

        if (!int.TryParse(Console.ReadLine(), out int numeroEscolhaSaborDaPizza) ||
            numeroEscolhaSaborDaPizza < 1 || numeroEscolhaSaborDaPizza > 5)
        {
            Console.WriteLine("Opção inválida, tente novamente");
            continue;
        }

        switch (numeroEscolhaSaborDaPizza)
        {
            case 1:
                Console.WriteLine("Você adicionou pizza de muçarela ao carrinho");
                carrinho.Add("Pizza de MUÇARELA");
                valorPizza.Add(muçarela);
                valorTotal += muçarela;
                valorItem.Add(muçarela);
                break;
            case 2:
                Console.WriteLine("Você adicionou pizza de calabresa ao carrinho");
                carrinho.Add("Pizza de CALABRESA");
                valorPizza.Add(calabresa);
                valorTotal += calabresa;
                valorItem.Add(calabresa);
                break;
            case 3:
                Console.WriteLine("Você adicionou pizza de frango ao carrinho");
                carrinho.Add("Pizza de FRANGO");
                valorPizza.Add(frango);
                valorTotal += frango;
                valorItem.Add(frango);

                break;
            case 4:
                Console.WriteLine("Você adicionou pizza de Dois Amores ao carrinho");
                carrinho.Add("Pizza de DOIS AMORES");
                valorPizza.Add(doisAmores);
                valorTotal += doisAmores;
                valorItem.Add(doisAmores);

                break;
            case 5:
                Console.WriteLine("Você adicionou pizza de abacaxi ao carrinho");
                carrinho.Add("Pizza de ABACAXI");
                valorPizza.Add(abacaxi);
                valorTotal += abacaxi;
                valorItem.Add(abacaxi);
                break;
        }

        continuar = ConfirmaçãoQuerMaisUmaPizza() == 1;
    }

    ConfirmacaoQuerRefrigerante();
}

//  confirma mais pizza 
int ConfirmaçãoQuerMaisUmaPizza()
{
    Console.WriteLine("Adicionar outra pizza? [1]-SIM / [2]-NÃO");
    while (true)
    {
        if (!int.TryParse(Console.ReadLine(), out int verificacaoPizza) ||
            (verificacaoPizza != 1 && verificacaoPizza != 2))
        {
            Console.WriteLine("Opção inválida, tente novamente");
            continue;
        }
        return verificacaoPizza;
    }
}

//  refri: quer ou não 
void ConfirmacaoQuerRefrigerante()
{
    Console.WriteLine("Adicionar refrigerante? [1]-SIM / [2]-NÃO");
    while (true)
    {
        if (!int.TryParse(Console.ReadLine(), out int ConfirmaRefrigerante) ||
            (ConfirmaRefrigerante != 1 && ConfirmaRefrigerante != 2))
        {
            Console.WriteLine("Opção inválida, tente novamente");
            continue;
        }

        if (ConfirmaRefrigerante == 1)
            EscolhaRefrigerante();

        ConfirmarCompras();
        break;

    }
}

//  fluxo dos refris 
void EscolhaRefrigerante()
{
    bool continuar = true;

    while (continuar)
    {
        PrintMenuRefrigerantes();

        if (!int.TryParse(Console.ReadLine(), out int escolhaDorefri) ||
            (escolhaDorefri != 1 && escolhaDorefri != 2))
        {
            Console.WriteLine("Opção inválida, tente novamente");
            continue;
        }

        switch (escolhaDorefri)
        {
            case 1:
                Console.WriteLine("Coca-Cola 1 L adicionada");
                carrinho.Add("Coca-Cola de 1 litro");
                valorTotal += coca;
                valorItem.Add(coca);
                break;
            case 2:
                Console.WriteLine("Guaraná 1 L adicionada");
                carrinho.Add("Guaraná de 1 litro");
                valorTotal += guarana;
                valorItem.Add(guarana);
                break;
        }

        Console.WriteLine("Adicionar outro refri? [1]-SIM / [2]-NÃO");
        continuar = int.TryParse(Console.ReadLine(), out int resp) && resp == 1;
    }
}

int ConfirmarCompras()
{
    Console.WriteLine($"O valor do seu carrinho está em: {valorTotal:C} ");
    Console.WriteLine("Gostaria de ver seu carrinho? [1] - SIM /  [2] - NÃO");
    while (true)
    {
        if (!int.TryParse(Console.ReadLine(), out int confirmaVerCarrinho) || confirmaVerCarrinho != 1 && confirmaVerCarrinho != 2)
        {
            Console.WriteLine("Opção inválida, tente novamente");
            return ConfirmarCompras();
        }
        if (confirmaVerCarrinho == 1)
        {
            MostrarResumoCompra();
        }
        else
            MetodosDePagamento();
    }
}
//Mostrar Carrinho
void MostrarResumoCompra()
{
    while (true)
    {
        if (carrinho.Count == 0)
        {
            Console.WriteLine("Não há nada no seu carrinho");
            return;
        }
        Console.WriteLine("====Seu carrinho=====");
        for (int i = 0; i < carrinho.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {carrinho[i]}  .................... {valorItem[i]:C}");
        }
        Console.WriteLine("Gostaria de remover algum item do carrinho? [1] - SIM / [2] - NAO");
        if (!int.TryParse(Console.ReadLine(), out int ConfirmaMenuRemoverCarrinho))
        {
            Console.WriteLine("Opção inválida, tente novamente");
            return;
        }
        if (ConfirmaMenuRemoverCarrinho != 1 && ConfirmaMenuRemoverCarrinho != 2)
        {
            Console.WriteLine("Opção inválida, tente novamente");
            return;
        }
        if (ConfirmaMenuRemoverCarrinho == 1)
        {
            ExcluirItemCarrinho();
            MetodosDePagamento();

        }
        else
            MetodosDePagamento();
    }

}
//Excluir item carrinho
void ExcluirItemCarrinho()
{
    while (true)
    {

        if (carrinho.Count == 0)
        {
            Console.WriteLine("Não há nada no seu carrinho");
            return;
        }
        Console.WriteLine("====Seu carrinho=====");
        for (int i = 0; i < carrinho.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {carrinho[i]}");
        }

        Console.WriteLine("Escolha qual item deseja remover");
        if (!int.TryParse(Console.ReadLine(), out int removerCarrinho))
        {
            Console.WriteLine("Número inválido, tente novamente");
            return;
        }
        if (removerCarrinho >= 1 && removerCarrinho <= carrinho.Count)
        {
            int precoRemovido = valorItem[removerCarrinho - 1];
            string Removido = carrinho[removerCarrinho - 1];
            carrinho.RemoveAt(removerCarrinho - 1);
            valorItem.RemoveAt(removerCarrinho - 1);
            valorTotal -= precoRemovido;
            Console.WriteLine($"Item {Removido} foi removido com sucesso");
            Console.WriteLine($"Valor total: {valorTotal:C} ");
            Console.WriteLine("Gostaria de remover algum outro item? [1] - SIM / [2] - NÃO");

            if (!int.TryParse(Console.ReadLine(), out int voltarCarrinho))
            {
                Console.WriteLine("Opção inválida, tente novamente");
            }
            if (voltarCarrinho == 1)
            {
                ExcluirItemCarrinho();
            }
            if (voltarCarrinho == 2)
            {
                MetodosDePagamento();
            }
            else
            {
                Console.WriteLine("Opção inválida, tente novamente");
            }

        }
    }
}

//metodos de pagamento 
void MetodosDePagamento()
{
    Console.WriteLine("=======================================");
    Console.WriteLine("      Escolha o método de pagamento    ");
    Console.WriteLine("[1] - Débito");
    Console.WriteLine("[2] - Crédito");
    Console.WriteLine("[3] - Pix");
    Console.WriteLine("[4] - Dinheiro");
    Console.WriteLine("=======================================");
    Console.WriteLine("[5] - Retornar para o carrinho");


    while (true)
    {
        if (!int.TryParse(Console.ReadLine(), out int EscolhaMetodoPagamento) || EscolhaMetodoPagamento < 1 || EscolhaMetodoPagamento > 5)
        {
            Console.WriteLine("Opção inválida, tente novamente");
            return;
        }
        switch (EscolhaMetodoPagamento)
        {
            case 1:
                {
                    Console.WriteLine("Método de pagamento selecionado = Débito");
                    metodosDePagamento.Add("Débito");
                    break;
                }
            case 2:
                {
                    Console.WriteLine("Método de pagamento selecionado = Crédito");
                    metodosDePagamento.Add("Crédito");

                    break;
                }
            case 3:
                {
                    Console.WriteLine("Método de pagamento selecionado = Pix");
                    metodosDePagamento.Add("Pix");
                    break;
                }
            case 4:
                {
                    Console.WriteLine("Método de pagamento selecionado = Dinheiro");
                    metodosDePagamento.Add("Dinheiro");
                    Console.WriteLine("Vai precisar de troco? [1] - SIM / [2] - NÃO");
                    if (!int.TryParse(Console.ReadLine(), out int precisaDetroco))
                    {
                        Console.WriteLine("Opção inválida, tente novamente");
                        return;
                    }
                    if (precisaDetroco == 1)
                    {
                        Console.WriteLine("Troco adicionado");
                    }
                    if (precisaDetroco == 2)
                    {
                        Console.WriteLine("Selecionou não precisa de troco");
                    }
                    break;
                }
            case 5:
                {
                    MostrarResumoCompra();
                    break;
                }
        }
        menu();
        Environment.Exit(0);
    }
}

void menu()
{
    Console.WriteLine("Digite seu nome: ");
    string nome = Console.ReadLine();
    Console.WriteLine("Digite seu endereço");
    string endereço = Console.ReadLine();
    Console.WriteLine("=======================PIZZARIA FAMÍLIA OLIVEIRA==============================");
    Console.WriteLine($"NOME:{nome}");
    Console.WriteLine($"ENDEREÇO: {endereço}");
    Console.WriteLine("Pedidos");
    //Colocar lista de pedidos do usuário
    
        for (int i = 0; i < carrinho.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {carrinho[i]}");
        }
    
    foreach (string pagamentos in metodosDePagamento)
    {
        Console.WriteLine($"Forma de pagamento: {pagamentos}");
    }
    Random tempo = new Random();
    int entrega = tempo.Next(30, 61);
    Console.WriteLine($"Seu pedido chegará em {entrega} minutos");
    Console.WriteLine("=======================OBRIGADO POR COMPRAR CONOSCO===========================");

}
// ----------- start -----------
escolhaSaborDaPizza();

