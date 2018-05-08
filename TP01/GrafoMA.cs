using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01
{
    public class GrafoMA
    {
        private int[,] MA;
        private int qtVertices;

        public GrafoMA(int qtVertices)
        {
            this.qtVertices = qtVertices;
            this.MA = new int[qtVertices, qtVertices];


            /*************** Matriz de teste de dimensão 4 x 4 ******************* 
               0	1	0	1
               1	0	1	0
               0	1	0	1
               1	0	1	0
             ***********************************************************************/
            if (qtVertices == 4)
                this.MA = new int[,] { { 0, 1, 0, 1 }, { 1, 0, 1, 0 }, { 0, 1, 0, 1 }, { 1, 0, 1, 0 } };

            /*************** Matriz de teste de dimensão 5 x 5 ******************* 
            0	1	0	1	1
            1	0	0	1	1
            0	0	0	0	1
            1	1	0	0	1
            1	1	1	1	0
            ***********************************************************************/
            if (qtVertices == 5)
                this.MA = new int[,] { { 0, 1, 0, 1, 1 }, { 1, 0, 0, 1, 1 }, { 0, 0, 0, 0, 1 }, { 1, 1, 0, 0, 1 }, { 1, 1, 1, 1, 0 } };
        }

        public int Ordem()
        {
            return this.qtVertices;
        }

        public bool InserirAresta(int v1, int v2)
        {
            // Maior ou igual porque o primeiro índice da matriz é zero
            if (v1 < 0 || v1 >= qtVertices || v2 < 0 || v2 >= qtVertices)
                return false;

            this.MA[v1, v2] = 1;
            this.MA[v2, v1] = 1;

            return true;
        }

        public bool RemoverAresta(int v1, int v2)
        {
            // Maior ou igual porque o primeiro índice da matriz é zero
            if (v1 < 0 || v1 >= qtVertices || v2 < 0 || v2 >= qtVertices)
                return false;

            this.MA[v1, v2] = 0;
            this.MA[v2, v1] = 0;

            return true;
        }

        public int Grau(int vertice)
        {
            int grau = 0;
            for (int i = 0; i < this.qtVertices; i++)
                grau += MA[i, vertice];

            return grau;
        }

        public bool Completo()
        {
            bool completo = true;
            for (int i = 0; i < this.qtVertices && completo; i++) // se o grafo não for completo, para a repetição quando isso for descoberto
            {
                for (int j = 0; j < this.qtVertices && completo; j++) // se o grafo não for completo, para a repetição quando isso for descoberto
                {
                    if (i != j && this.MA[i, j] == 0)
                        completo = false;
                }
            }

            return completo;
        }

        public bool Regular()
        {
            // Descobre o grau do primeiro vértice
            int grauPrimeiroVertice = Grau(0);

            bool regular = true;
            // verifica se o grau dos demais vértices é igual ao grau do primeiro vértice
            for (int i = 1; i < qtVertices && regular; i++) // se o grafo não for regular, para a repetição assim que isso for descoberto
            {
                int grauVertice = Grau(i);
                if (grauVertice != grauPrimeiroVertice)
                    regular = false;
            }

            return regular;
        }

        public void ShowMA()
        {
            for (int i = 0; i < this.qtVertices; i++)
            {
                for (int j = 0; j < this.qtVertices; j++)
                    Console.Write(" " + this.MA[i, j]);

                Console.WriteLine();
            }
        }

        public void ShowLA()
        {
            for (int i = 0; i < this.qtVertices; i++)
            {
                Console.Write(i + ": ");

                for (int j = 0; j < this.qtVertices; j++)
                {
                    if (this.MA[i, j] == 1)
                        Console.Write("[" + j + "] ");
                }

                Console.WriteLine();
            }
        }

        public void SequenciaGraus()
        {
            int[] grauVertices = new int[this.qtVertices];

            for (int i = 0; i < qtVertices; i++)
                grauVertices[i] = Grau(i);

            Array.Sort(grauVertices); // Método do c# usado para ordenação do vetor que armazena o grau de cada vértice

            for (int i = 0; i < grauVertices.Length; i++)
                Console.WriteLine("Grau: " + grauVertices[i]);
        }

        public void VerticesAdjacentes(int vertice)
        {
            for (int i = 0; i < this.MA.GetLength(0); i++)
            {
                if (this.MA[i, vertice] == 1)
                    Console.Write("[" + i + "] ");
            }
        }

        public bool Isolado(int vertice)
        {
            bool isolado = true;

            for (int i = 0; i < this.MA.GetLength(0) && isolado; i++) // se descobrir que o vértice não está isolado, para a repetição assim que isso for descoberto
            {
                if (this.MA[i, vertice] == 1)
                    isolado = false;
            }

            return isolado;
        }

        public bool Impar(int vertice)
        {
            return Grau(vertice) % 2 != 0;
        }

        public bool Par(int vertice)
        {
            return Grau(vertice) % 2 == 0;
        }

        public bool Adjacentes(int v1, int v2)
        {
            return this.MA[v1, v2] == 1;
        }
    }
}

