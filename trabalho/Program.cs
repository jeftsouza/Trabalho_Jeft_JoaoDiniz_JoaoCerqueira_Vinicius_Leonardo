using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_C
{
    class Program
    {
        static List<string> codigos = new List<string>();
        static List<string> nomes = new List<string>();
        static List<double> custos = new List<double>();
        static List<int> quantidades = new List<int>();

        static List<string> itensRequisitados = new List<string>();
        static List<int> qtdRequisitada = new List<int>();

        static double caixaGeralGastos = 0.0; // Acumula todos os gastos do dia
        static int totalParagensSucesso = 0;   // Conta quantas paradas deram certo


        // Histórico acumulado do dia INTEIRO (Para o Relatório Geral)
        static List<string> historicoPecasDia = new List<string>();
        static List<int> historicoQtdDia = new List<int>();
        static List<double> historicoValoresDia = new List<double>();

        // Dados apenas da ÚLTIMA paragem (Para o Manifesto)
        static int ultimoCarroAssistido = 0;
        static int ultimoTipoParada = 0;
        static double ultimoCustoFinal = 0;
        static List<string> ultimoItensManifesto = new List<string>();
        static List<int> ultimoQtdManifesto = new List<int>();


        static void Main(string[] args)
        {
            InicializarDados();
            Menu();
        }
        private static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*** PIT STOP ****");

                Console.WriteLine("(1) - Controle de Inventario ");
                Console.WriteLine("(2) - Requisicoes");
                Console.WriteLine("(3) - Custos");

                Console.WriteLine("(0) - Sair do Programa");

                if (!int.TryParse(Console.ReadLine(), out int menu))
                {
                    Console.WriteLine("Opção inválida! Digite um número.");
                    Console.ReadKey();
                    continue;
                }

                if (menu == 0) break;

                switch (menu)
                {
                    case 1: MenuInventario(); break;
                    case 2: MenuRequisicao(); break;
                    case 3: MenuCustos(); break;
                    //case 4: MenuBuscar(lista_musicas); break;
                    //case 5: MenuQtd(lista_musicas); break;
                    //case 6: MenuAleatorio(lista_musicas); break;
                    //case 7: MenuLimpar(lista_musicas); break;

                    default: break;
                }


            }
        }
        private static void MenuInventario()
        {

            //Console.WriteLine($"Musica: {lista_musicas[i]}");

            while (true)
            {
                Console.Clear();

                Console.WriteLine("*** Inventario ****");

                Console.WriteLine("(1) - Listar Inventario ");
                Console.WriteLine("(2) - Consultar Peças");
                Console.WriteLine("(3) - Entrada de Peças");

                Console.WriteLine("(0) - Voltar");

                if (!int.TryParse(Console.ReadLine(), out int menu))
                {
                    Console.WriteLine("Opção inválida! Digite um número.");
                    Console.ReadKey();
                    continue;
                }

                if (menu == 0) break;

                switch (menu)
                {
                    case 1: ListarInventario(); break;
                    case 2: ConsultarPeca(); break;
                    case 3: RecepcaoFabrica(); break;
                    default: break;
                }
            }
        }

        private static void MenuRequisicao()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("*** Requisicao ****");

                Console.WriteLine("(1) - Paragem nos Boxes ");
                // Console.WriteLine("(2) - Carrinho de Componentes");

                Console.WriteLine("(0) - Voltar");

                if (!int.TryParse(Console.ReadLine(), out int menu))
                {
                    Console.WriteLine("Opção inválida! Digite um número.");
                    Console.ReadKey();
                    continue;
                }

                if (menu == 0) break;

                switch (menu)
                {
                    case 1: IniciarParagemBoxes(); break;
                    //case 2: MenuListar(lista_musicas); break;
                    //case 3: MenuRemover(lista_musicas); break;
                    //case 4: MenuBuscar(lista_musicas); break;
                    //case 5: MenuQtd(lista_musicas); break;
                    //case 6: MenuAleatorio(lista_musicas); break;
                    //case 7: MenuLimpar(lista_musicas); break;

                    default: break;
                }
            }
        }

        private static void MenuCustos()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*** Custos Financeiros ****");

                Console.WriteLine("(1) - Relatorio");
                Console.WriteLine("(0) - Voltar");

                if (!int.TryParse(Console.ReadLine(), out int menu))
                {
                    Console.WriteLine("Opção inválida! Digite um número.");
                    Console.ReadKey();
                    continue;
                }

                if (menu == 0) break;

                switch (menu)
                {
                    case 1: MenuCustosRelatorio(); break;
                    default: break;
                }
            }
        }

        static void InicializarDados()
        {
            codigos.Add("P001");
            nomes.Add("Pneu");
            custos.Add(2500);
            quantidades.Add(8);

            codigos.Add("P002");
            nomes.Add("Pastilha de Freio");
            custos.Add(800);
            quantidades.Add(3);

            codigos.Add("P003");
            nomes.Add("Asa Dianteira");
            custos.Add(5200);
            quantidades.Add(2);
        }

        static void ListarInventario()
        {
            Console.Clear();
            // Aumentamos os traços para cobrir a largura total com as novas bordas
            Console.WriteLine("====================================================================");
            // Adicionamos || no começo e no fim da string
            Console.WriteLine($"|| {"Código",-10} | {"Nome",-25} | {"Custo (R$)",12} | {"Qtd",6} ||");
            Console.WriteLine("====================================================================");

            for (var i = 0; i < codigos.Count; i++)
            {
                // Mesma coisa aqui: || no início e no fim de cada linha do loop
                Console.WriteLine($"|| {codigos[i],-10} | {nomes[i],-25} | {custos[i],12:F2} | {quantidades[i],6} ||");
            }

            Console.WriteLine("====================================================================");
            Console.ReadKey();
        }

        static void ConsultarPeca()
        {
            Console.WriteLine("Digite o codigo da peça desejada: ");
            string codigoPeca = Console.ReadLine().ToUpper();

            bool encontrou = false;

            for (int i = 0; i < codigos.Count; i++)
            {
                if (codigoPeca == codigos[i])

                {
                    Console.WriteLine("\n=== PEÇA ENCONTRADA ===");
                    Console.WriteLine("Código: " + codigos[i]);
                    Console.WriteLine("Nome: " + nomes[i]);
                    Console.WriteLine("Custo: R$ " + custos[i]);
                    Console.WriteLine("Quantidade: " + quantidades[i]);

                    if (quantidades[i] < 4)
                    {
                        Console.WriteLine("** STOCK CRÍTICO PARA A CORRIDA! **");
                    }

                    encontrou = true;
                    break;
                }
            }

            if (encontrou == false)
            {
                Console.WriteLine("Peça não encontrada.");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        static void RecepcaoFabrica()
        {
            Console.WriteLine("Digite o código da peça que deseja adicionar: ");
            string codigoPeca = Console.ReadLine()?.ToUpper() ?? string.Empty;


            int index = codigos.IndexOf(codigoPeca);

            if (index != -1)
            {
                Console.WriteLine("Quantidade recebida: ");

                if (int.TryParse(Console.ReadLine(), out int quantidadeRecebida) && quantidadeRecebida > 0)
                {
                    quantidades[index] += quantidadeRecebida;

                    Console.WriteLine("=== Estoque Atualizado com Sucesso! ===");
                    Console.WriteLine($"Peça: {codigoPeca}");
                    Console.WriteLine($"Nova quantidade: {quantidades[index]}");
                }
                else
                {
                    Console.WriteLine("\n[Erro] Quantidade inválida digitada.");
                }
            }
            else
            {
                Console.WriteLine("\n[Erro] Peça não encontrada.");
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        private static void IniciarParagemBoxes()
        {
            int carro;
            int tipo;

            while (true)
            {

                Console.WriteLine("Selecione o carro (1 ou 2): ");

                if (int.TryParse(Console.ReadLine(), out carro) && (carro == 1 || carro == 2))
                    break;

                Console.WriteLine("Carro inválido.");
            }

            while (true)
            {

                Console.WriteLine("Tipo de paragem (1-Emergencial ou 2-Planejada): ");

                if (int.TryParse(Console.ReadLine(), out tipo) && (tipo == 1 || tipo == 2))
                    break;

                Console.WriteLine("Tipo de paragem inválido.");
            }

            List<string> codigoPecas = new List<string>();
            List<int> quantidades = new List<int>();

            Console.WriteLine($"\nParagem iniciada para o Carro {carro}");
            string codigo = "";
            int quantidade = 0;

            while (true)
            {

                Console.WriteLine("\nCódigo de peça (0 para finalizar): ");
                codigo = Console.ReadLine().ToUpper();
                if (codigo == "0")
                    break;

                int index = codigos.IndexOf(codigo);

                if (index == -1)
                {
                    Console.WriteLine("Digite um codigo válido.");
                    continue;
                }

                quantidade = 0;
                Console.WriteLine("Quantidade: ");

                if (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade <= 0)
                {

                    Console.WriteLine("Quantidade inválida. ");
                    continue;

                }

                codigoPecas.Add(codigo);
                quantidades.Add(quantidade);

                Console.WriteLine("Peça adicionada ao pedido.");

            }

            ReceberPedido(carro, codigoPecas, quantidades, tipo);

        }

        static void ReceberPedido(int carro, List<string> codigoPecas, List<int> lQuantidades, int tipo)
        {

            itensRequisitados.Clear();
            qtdRequisitada.Clear();

            for (int i = 0; i < codigoPecas.Count; i++)
            {

                int indiceEstoque = codigos.IndexOf(codigoPecas[i]);

                if (indiceEstoque == -1)
                {
                    Console.WriteLine("Codigo da peca nao existe!");
                    continue;
                }

                if (quantidades[indiceEstoque] < lQuantidades[i])
                {
                    Console.WriteLine("Falha de Estrategia");
                    continue;
                }

                quantidades[indiceEstoque] -= lQuantidades[i];

                itensRequisitados.Add(codigoPecas[i]);
                qtdRequisitada.Add(lQuantidades[i]);

                Console.WriteLine("Item adicionado ao carrinho");

            }

            if (itensRequisitados.Count == 0)
            {
                Console.WriteLine("\nNenhum item pôde ser processado. Retornando ao menu...");
                Console.ReadKey();
                return;
            }

            //Console.WriteLine("Passando dados para o Integrante 3");
            //for (int i = 0; i < itensRequisitados.Count; i++)
            //{
            //    Console.WriteLine($"Peca: {itensRequisitados[i]} | Qtd: {qtdRequisitada[i]}");
            //}
            //Console.ReadKey();

            ultimoCarroAssistido = carro;
            Despacho(tipo);


        }

        private static void Despacho(int tipo)
        {
            Console.Clear();
            Console.WriteLine("*** PROCESSANDO DESPACHO E ORÇAMENTO ***\n");

            ultimoTipoParada = tipo;
            ultimoCustoFinal = 0;
            ultimoItensManifesto.Clear();
            ultimoQtdManifesto.Clear();

            if (itensRequisitados.Count == 0)
            {
                Console.WriteLine("Nenhum item foi requisitado com sucesso. Despacho cancelado.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < itensRequisitados.Count; i++)
            {
                int indiceEstoque = codigos.IndexOf(itensRequisitados[i]);
                if (indiceEstoque == -1) continue;

                double custoUnitario = custos[indiceEstoque];
                int qtd = qtdRequisitada[i];
                double custoTotalBase = custoUnitario * qtd;
                double totalItem = 0;

                if (tipo == 1) // Emergência
                {
                    double acrescimo = custoTotalBase * 0.20;
                    totalItem = custoTotalBase + acrescimo;
                }
                else // Planejada
                {
                    double desconto = custoTotalBase * 0.05;
                    totalItem = custoTotalBase - desconto;
                }

                ultimoCustoFinal += totalItem;

                // Alimenta o Manifesto (Última paragem)
                ultimoItensManifesto.Add(itensRequisitados[i]);
                ultimoQtdManifesto.Add(qtd);

                // --- Alimenta o Relatório Geral (Histórico do dia) ---
                historicoPecasDia.Add(itensRequisitados[i]);
                historicoQtdDia.Add(qtd);
                historicoValoresDia.Add(totalItem);

            }

            // --- ATUALIZA O CAIXA GERAL DA ESCUDERIA ---
            caixaGeralGastos += ultimoCustoFinal;
            totalParagensSucesso++;

            Console.WriteLine("=================================================");
            Console.WriteLine("        ORDEM DE SERVIÇO PROCESSADA!             ");
            Console.WriteLine($" Total desta Operação: CC {ultimoCustoFinal:F2}  ");
            Console.WriteLine("=================================================");
            Console.WriteLine("\nPressione para imprimir Manifesto.");
            Console.ReadKey();

            Manifesto();
        }

        private static void Manifesto()
        {
            Console.Clear();
            Console.WriteLine("=============================================================");
            Console.WriteLine("||             MANIFESTO DE PIT STOP (COMPROVANTE)         ||");
            Console.WriteLine("=============================================================");

            if (ultimoCarroAssistido == 0)
            {
                Console.WriteLine("|| Nenhuma paragem foi processada ainda nesta corrida.     ||");
                Console.WriteLine("=============================================================");
                Console.ReadKey();
                return;
            }

            string txtTipo = ultimoTipoParada == 1 ? "EMERGÊNCIA (+20%)" : "PLANEJADA (-5%)";
            string txtCarro = $"Carro {ultimoCarroAssistido}";

            Console.WriteLine($"|| Carro Assistido: {txtCarro,-38} ||");
            Console.WriteLine($"|| Estratégia: {txtTipo,-43} ||");
            Console.WriteLine("||---------------------------------------------------------||");
            Console.WriteLine("|| Itens Instalados:                                       ||");

            for (int i = 0; i < ultimoItensManifesto.Count; i++)
            {
                Console.WriteLine($"||   - Peça: {ultimoItensManifesto[i],-10} | Qtd: {ultimoQtdManifesto[i],-3}                        ||");
            }

            Console.WriteLine("||---------------------------------------------------------||");

            string txtTotal = $"CC {ultimoCustoFinal:F2}";
            Console.WriteLine($"|| CUSTO FINAL CONSOLIDADO: {txtTotal,30} ||");
            Console.WriteLine("=============================================================");
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        private static void MenuCustosRelatorio()
        {
            Console.Clear();
            Console.WriteLine("=============================================================");
            Console.WriteLine("||         RELATÓRIO DE CAIXA GERAL DA ESCUDERIA           ||");
            Console.WriteLine("=============================================================");

            string txtGastos = $"CC {caixaGeralGastos:F2}";
            Console.WriteLine($"|| Total de Créditos Despendidos: {txtGastos,-24} ||");
            Console.WriteLine($"|| Quantidade de Paragens com Sucesso: {totalParagensSucesso,-19} ||");
            Console.WriteLine("||---------------------------------------------------------||");
            Console.WriteLine("|| DETALHAMENTO DE PEÇAS UTILIZADAS NO DIA:                ||");

            if (historicoPecasDia.Count == 0)
            {
                Console.WriteLine("||   Nenhuma peça foi utilizada ainda.                     ||");
            }
            else
            {
                for (int i = 0; i < historicoPecasDia.Count; i++)
                {
                    string txtValorItem = $"CC {historicoValoresDia[i]:F2}";
                    Console.WriteLine($"|| - {historicoPecasDia[i],-5} | Qtd: {historicoQtdDia[i],-3} | Total Item: {txtValorItem,-16} ||");
                }
            }

            Console.WriteLine("=============================================================");
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }
    }
}