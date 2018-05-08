using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP01
{
    class Program
    {
        // Foram implementadas duas matrizes de teste nos construtores das classes Grafo (uma de dimensão 4x4 e outra 5x5) 
        // No caso da matriz de adjacência (por não existir método para inclusão/remoção de vértice)
        static int qtdVertices = 5;

        static GrafoMA grafoMA = new GrafoMA(qtdVertices); // Instância do grafo usando matriz de adjacência
        static GrafoLA grafoLA = new GrafoLA(); // Instância do grafo usando lista de adjacência

        static void TesteOrdem(TipoGrafo tipoGrafo)
        {
            Console.WriteLine("*** Ordem do gráfo: ***\n");

            int ordem = 0;

            if (tipoGrafo == TipoGrafo.MATRIZ_ADJACENCIA)
                ordem = grafoMA.Ordem();
            else
                ordem = grafoLA.Ordem();

            Console.WriteLine("Ordem do grafo: " + ordem);
        }

        static void TesteInclusaoAresta(TipoGrafo tipoGrafo)
        {
            Console.WriteLine("*** Inclusão de aresta: ***\n");

            Console.WriteLine("Informe os dois vértices (valores de 0 a " + qtdVertices + "): \n");
            Console.Write("\nVertice 1: ");
            int vertice1 = int.Parse(Console.ReadLine());
            Console.Write("\nVertice 2: ");
            int vertice2 = int.Parse(Console.ReadLine());

            if (tipoGrafo == TipoGrafo.MATRIZ_ADJACENCIA)
            {
                if (!grafoMA.Adjacentes(vertice1, vertice2))
                {
                    if (grafoMA.InserirAresta(vertice1, vertice2))
                        Console.WriteLine("\n\nAresta inserida com sucesso!");
                    else
                        Console.WriteLine("\n\nNão foi possível inserir a aresta entre os dois vértices informados.");
                }
                else
                {
                    Console.WriteLine("\n\nOs vértices informados já são adjacentes.");
                }
            }
            else
            {
                if (!grafoLA.Adjacentes(vertice1, vertice2))
                {
                    if (grafoLA.InserirAresta(vertice1, vertice2))
                        Console.WriteLine("\n\nAresta inserida com sucesso!");
                    else
                        Console.WriteLine("\n\nNão foi possível inserir a aresta entre os dois vértices informados.");
                }
                else
                {
                    Console.WriteLine("\n\nOs vértices informados já são adjacentes.");
                }
            }

        }

        static void TesteRemocaoAresta(TipoGrafo tipoGrafo)
        {
            Console.WriteLine("*** Remoção de aresta: ***\n");

            Console.WriteLine("Informe os dois vértices (valores de 0 a " + qtdVertices + "): \n");
            Console.Write("\nVertice 1: ");
            int vertice1 = int.Parse(Console.ReadLine());
            Console.Write("\nVertice 2: ");
            int vertice2 = int.Parse(Console.ReadLine());

            if (tipoGrafo == TipoGrafo.MATRIZ_ADJACENCIA)
            {
                if (grafoMA.Adjacentes(vertice1, vertice2))
                {
                    grafoMA.RemoverAresta(vertice1, vertice2);
                    Console.WriteLine("\n\nAresta removida com sucesso!");
                }
                else
                {
                    Console.WriteLine("\n\nOs vértices informados não são adjacentes.");
                }
            }
            else
            {
                if (grafoLA.Adjacentes(vertice1, vertice2))
                {
                    grafoLA.RemoverAresta(vertice1, vertice2);
                    Console.WriteLine("\n\nAresta removida com sucesso!");
                }
                else
                {
                    Console.WriteLine("\n\nOs vértices informados não são adjacentes.");
                }
            }

        }

        static void TesteGrauVertice(TipoGrafo tipoGrafo)
        {
            Console.WriteLine("*** Grau de um vértice: ***\n");

            Console.Write("\nInforme o vértice: ");
            int vertice = int.Parse(Console.ReadLine());

            int grau = 0;
            if (tipoGrafo == TipoGrafo.MATRIZ_ADJACENCIA)
                grau = grafoMA.Grau(vertice);
            else
                grau = grafoLA.Grau(vertice);

            Console.WriteLine("\n\n O grau do vértice informado é: " + grau);
        }

        static void TesteVerificarCompleto(TipoGrafo tipoGrafo)
        {
            Console.WriteLine("*** Grafo completo: ***\n");

            bool grafoCompleto = false;

            if (tipoGrafo == TipoGrafo.MATRIZ_ADJACENCIA)
                grafoCompleto = grafoMA.Completo();
            else
                grafoCompleto = grafoLA.Completo();

            if (grafoCompleto)
                Console.WriteLine("O grafo é completo.");
            else
                Console.WriteLine("O grafo não é completo.");
        }

        static void TesteVerificarRegular(TipoGrafo tipoGrafo)
        {
            Console.WriteLine("*** Grafo regular: ***\n");

            bool grafoRegular = false;

            if (tipoGrafo == TipoGrafo.MATRIZ_ADJACENCIA)
                grafoRegular = grafoMA.Regular();
            else
                grafoRegular = grafoLA.Regular();

            if (grafoRegular)
                Console.WriteLine("O grafo é regular.");
            else
                Console.WriteLine("O grafo não é regular.");
        }

        static void TesteImprimirMA()
        {
            Console.WriteLine("*** Impressão da Matriz de Adjacência: ***\n");

            grafoMA.ShowMA();
        }

        static void TesteImprimirLA(TipoGrafo tipoGrafo)
        {
            Console.WriteLine("*** Impressão da Lista de Adjacência: ***\n");

            if (tipoGrafo == TipoGrafo.MATRIZ_ADJACENCIA)
                grafoMA.ShowLA();
            else
                grafoLA.ShowLA();
        }

        static void TesteImprimirSequenciaGraus(TipoGrafo tipoGrafo)
        {
            Console.WriteLine("*** Impressão da sequência de graus: ***\n");

            if (tipoGrafo == TipoGrafo.MATRIZ_ADJACENCIA)
                grafoMA.SequenciaGraus();
            else
                grafoLA.SequenciaGraus();
        }

        static void TesteVerificarVerticesAdjacentes(TipoGrafo tipoGrafo)
        {
            Console.WriteLine("*** Listagem de vértices adjacentes a outro: ***\n");

            Console.Write("\nInforme o vértice: ");
            int vertice = int.Parse(Console.ReadLine());

            if (tipoGrafo == TipoGrafo.MATRIZ_ADJACENCIA)
                grafoMA.VerticesAdjacentes(vertice);
            else
                grafoLA.VerticesAdjacentes(vertice);
        }

        static void TesteVerificarVerticeIsolado(TipoGrafo tipoGrafo)
        {
            Console.WriteLine("*** Verificação de vértice isolado: ***\n");

            Console.Write("\nInforme o vértice: ");
            int vertice = int.Parse(Console.ReadLine());

            bool isolado = false;
            if (tipoGrafo == TipoGrafo.MATRIZ_ADJACENCIA)
                isolado = grafoMA.Isolado(vertice);
            else
                isolado = grafoLA.Isolado(vertice);

            if (isolado)
                Console.WriteLine("\n\nO vértice informado é isolado.");
            else
                Console.WriteLine("\n\nO vértice informado não é isolado.");
        }

        static void TesteVerificarVerticePar(TipoGrafo tipoGrafo)
        {
            Console.WriteLine("*** Verificação de vértice par: ***\n");

            Console.Write("\nInforme o vértice: ");
            int vertice = int.Parse(Console.ReadLine());

            bool par = false;

            if (tipoGrafo == TipoGrafo.MATRIZ_ADJACENCIA)
                par = grafoMA.Par(vertice);
            else
                par = grafoLA.Par(vertice);

            if (par)
                Console.WriteLine("\n\nO vértice informado é par.");
            else
                Console.WriteLine("\n\nO vértice informado não é par.");
        }

        static void TesteVerificarVerticeImpar(TipoGrafo tipoGrafo)
        {
            Console.WriteLine("*** Verificação de vértice ímpar: ***\n");

            Console.Write("\nInforme o vértice: ");
            int vertice = int.Parse(Console.ReadLine());

            bool impar = false;
            if (tipoGrafo == TipoGrafo.MATRIZ_ADJACENCIA)
                impar = grafoMA.Impar(vertice);
            else
                impar = grafoLA.Impar(vertice);

            if (impar)
                Console.WriteLine("\n\nO vértice informado é ímpar.");
            else
                Console.WriteLine("\n\nO vértice informado não é ímpar.");
        }

        static void TesteVerificarDoisVerticesAdjacentes(TipoGrafo tipoGrafo)
        {
            Console.WriteLine("*** Verificação de adjacência entre dois vértices: ***\n");

            Console.Write("\nInforme o primeiro vértice: ");
            int vertice1 = int.Parse(Console.ReadLine());

            Console.Write("\nInforme o segundo vértice: ");
            int vertice2 = int.Parse(Console.ReadLine());

            bool adjacentes = false;
            if (tipoGrafo == TipoGrafo.MATRIZ_ADJACENCIA)
                adjacentes = grafoMA.Adjacentes(vertice1, vertice2);
            else
                adjacentes = grafoLA.Adjacentes(vertice1, vertice2);

            if (adjacentes)
                Console.WriteLine("\n\nOs vértices informados são adjacentes.");
            else
                Console.WriteLine("\n\nOs vértices informados não são adjacentes.");
        }

        static void TesteInclusaoVertice()
        {
            Console.WriteLine("*** Inclusão de vértice: ***\n");

            Console.Write("\nInforme o vértice: ");
            int vertice = int.Parse(Console.ReadLine());

            if (grafoLA.InserirVertice(vertice))
                Console.WriteLine("\n\nVértice inserido com sucesso.");
            else
                Console.WriteLine("\n\nO vértice não pôde ser inserido.");
        }

        static void TesteRemocaoVertice()
        {
            Console.WriteLine("*** Remoção de vértice: ***\n");

            Console.Write("\nInforme o vértice: ");
            int vertice = int.Parse(Console.ReadLine());

            if (grafoLA.RemoverVertice(vertice))
                Console.WriteLine("\n\nVértice foi removido com sucesso.");
            else
                Console.WriteLine("\n\nO vértice não pôde ser removido.");
        }

        static void Main(string[] args)
        {
            string teclaCondicaoRetorno = "";
            do
            {
                string opcao;
                Console.Clear();
                Console.SetWindowSize(70, 38);

                Console.WriteLine("\t\tTP 01 de Grafos - Karine S. M. Silva");

                Console.WriteLine("\nEscolha a opção desejada:");

                Console.WriteLine("\n*** Matriz de adjacência ***");
                Console.WriteLine("\t[a] Retornar ordem do grafo");
                Console.WriteLine("\t[b] Inserir aresta");
                Console.WriteLine("\t[c] Remover aresta");
                Console.WriteLine("\t[d] Retornar grau de um vértice");
                Console.WriteLine("\t[e] Verificar se é completo");
                Console.WriteLine("\t[f] Verificar se é regular");
                Console.WriteLine("\t[g] Imprimir matriz de adjacência");
                Console.WriteLine("\t[h] Imprimir lista de adjacência");
                Console.WriteLine("\t[i] Imprimir sequência de graus");
                Console.WriteLine("\t[j] Verificar adjacentes de um vértice");
                Console.WriteLine("\t[k] Verificar se um vértice está isolado");
                Console.WriteLine("\t[l] Verificar se um vértice é par");
                Console.WriteLine("\t[m] Verificar se um vértice é ímpar");
                Console.WriteLine("\t[n] Verificar se dois vértices são adjacentes");

                Console.WriteLine("\n*** Lista de adjacência ***");
                Console.WriteLine("\t[o] Retornar ordem do grafo");
                Console.WriteLine("\t[p] Inserir aresta");
                Console.WriteLine("\t[q] Remover aresta");
                Console.WriteLine("\t[r] Retornar grau de um vértice");
                Console.WriteLine("\t[s] Verificar se é completo");
                Console.WriteLine("\t[t] Verificar se é regular");
                Console.WriteLine("\t[u] Imprimir lista de adjacência");
                Console.WriteLine("\t[v] Imprimir sequência de graus");
                Console.WriteLine("\t[w] Verificar adjacentes de um vértice");
                Console.WriteLine("\t[x] Verificar se um vértice está isolado");
                Console.WriteLine("\t[y] Verificar se um vértice é par");
                Console.WriteLine("\t[z] Verificar se um vértice é ímpar");
                Console.WriteLine("\t[1] Verificar se dois vértices são adjacentes");
                Console.WriteLine("\t[2] Inserir vértice");
                Console.WriteLine("\t[3] Remover vértice");

                Console.Write("\nOpção Escolhida: ");

                opcao = Console.ReadLine();

                Console.Clear();

                switch (opcao.ToLower())
                {
                    case "a":
                        TesteOrdem(TipoGrafo.MATRIZ_ADJACENCIA);
                        break;
                    case "b":
                        TesteInclusaoAresta(TipoGrafo.MATRIZ_ADJACENCIA);
                        break;
                    case "c":
                        TesteRemocaoAresta(TipoGrafo.MATRIZ_ADJACENCIA);
                        break;
                    case "d":
                        TesteGrauVertice(TipoGrafo.MATRIZ_ADJACENCIA);
                        break;
                    case "e":
                        TesteVerificarCompleto(TipoGrafo.MATRIZ_ADJACENCIA);
                        break;
                    case "f":
                        TesteVerificarRegular(TipoGrafo.MATRIZ_ADJACENCIA);
                        break;
                    case "g":
                        TesteImprimirMA();
                        break;
                    case "h":
                        TesteImprimirLA(TipoGrafo.MATRIZ_ADJACENCIA);
                        break;
                    case "i":
                        TesteImprimirSequenciaGraus(TipoGrafo.MATRIZ_ADJACENCIA);
                        break;
                    case "j":
                        TesteVerificarVerticesAdjacentes(TipoGrafo.MATRIZ_ADJACENCIA);
                        break;
                    case "k":
                        TesteVerificarVerticeIsolado(TipoGrafo.MATRIZ_ADJACENCIA);
                        break;
                    case "l":
                        TesteVerificarVerticePar(TipoGrafo.MATRIZ_ADJACENCIA);
                        break;
                    case "m":
                        TesteVerificarVerticeImpar(TipoGrafo.MATRIZ_ADJACENCIA);
                        break;
                    case "n":
                        TesteVerificarDoisVerticesAdjacentes(TipoGrafo.MATRIZ_ADJACENCIA);
                        break;
                    case "o":
                        TesteOrdem(TipoGrafo.LISTA_ADJACENCIA);
                        break;
                    case "p":
                        TesteInclusaoAresta(TipoGrafo.LISTA_ADJACENCIA);
                        break;
                    case "q":
                        TesteRemocaoAresta(TipoGrafo.LISTA_ADJACENCIA);
                        break;
                    case "r":
                        TesteGrauVertice(TipoGrafo.LISTA_ADJACENCIA);
                        break;
                    case "s":
                        TesteVerificarCompleto(TipoGrafo.LISTA_ADJACENCIA);
                        break;
                    case "t":
                        TesteVerificarRegular(TipoGrafo.LISTA_ADJACENCIA);
                        break;
                    case "u":
                        TesteImprimirLA(TipoGrafo.LISTA_ADJACENCIA);
                        break;
                    case "v":
                        TesteImprimirSequenciaGraus(TipoGrafo.LISTA_ADJACENCIA);
                        break;
                    case "w":
                        TesteVerificarVerticesAdjacentes(TipoGrafo.LISTA_ADJACENCIA);
                        break;
                    case "x":
                        TesteVerificarVerticeIsolado(TipoGrafo.LISTA_ADJACENCIA);
                        break;
                    case "y":
                        TesteVerificarVerticePar(TipoGrafo.LISTA_ADJACENCIA);
                        break;
                    case "z":
                        TesteVerificarVerticeImpar(TipoGrafo.LISTA_ADJACENCIA);
                        break;
                    case "1":
                        TesteVerificarDoisVerticesAdjacentes(TipoGrafo.LISTA_ADJACENCIA);
                        break;
                    case "2":
                        TesteInclusaoVertice();
                        break;
                    case "3":
                        TesteRemocaoVertice();
                        break;
                    default:
                        Console.WriteLine("Opção inexistente! Pressione qualquer tecla para finalizar...");
                        Console.ReadKey();
                        break;
                }

                Console.Write("\nPressione 0 para sair ou qualquer outra tecla para continuar: ");
                teclaCondicaoRetorno = Console.ReadLine();
            }
            while (teclaCondicaoRetorno != "0");
        }
    }
}
