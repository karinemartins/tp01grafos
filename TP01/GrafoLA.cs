using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01
{
    public class GrafoLA
    {
        private Dictionary<int, List<int>> DicionarioVertices;

        // Cria o grafo a partir da quantidade de parâmentros passada
        public GrafoLA()
        {
            this.DicionarioVertices = new Dictionary<int, List<int>>();
        }

        public int Ordem()
        {
            return this.DicionarioVertices.Count;
        }

        public bool InserirVertice(int vertice)
        {
            if (!this.DicionarioVertices.ContainsKey(vertice))
            {
                this.DicionarioVertices.Add(vertice, new List<int>());
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoverVertice(int vertice)
        {
            // O próprio método do dicionário retorna true se o elemento for encontrado e removido. Caso contrário, retorna false.
            bool remocaoSucesso = this.DicionarioVertices.Remove(vertice);

            if (remocaoSucesso)
            {
                // Remove o vértice da lista de adjacência dos demais vértices (se houver)
                foreach (KeyValuePair<int, List<int>> verticeGrafo in this.DicionarioVertices)
                    verticeGrafo.Value.Remove(vertice);
            }

            return remocaoSucesso;
        }

        public bool InserirAresta(int v1, int v2)
        {
            //Se os vértices não existem no grafo, não é possível inserir uma aresta
            if (!this.DicionarioVertices.ContainsKey(v1) || !this.DicionarioVertices.ContainsKey(v2))
                return false;

            // Se os vértices são iguais, não é possível inserir uma arestaa
            if (v1 == v2)
                return false;

            this.DicionarioVertices[v1].Add(v2);
            this.DicionarioVertices[v2].Add(v1);

            return true;
        }

        public bool RemoverAresta(int v1, int v2)
        {
            if (!this.DicionarioVertices.ContainsKey(v1) || !this.DicionarioVertices.ContainsKey(v2))
                return false;

            // O próprio método do dicionário retorna true se o elemento for encontrado e removido. Caso contrário, retorna false.
            return this.DicionarioVertices[v1].Remove(v2) && this.DicionarioVertices[v2].Remove(v1);
        }

        public int Grau(int vertice)
        {
            if (!this.DicionarioVertices.ContainsKey(vertice))
                return 0;

            return this.DicionarioVertices[vertice].Count;
        }

        public bool Completo()
        {
            foreach (KeyValuePair<int, List<int>> vertice in this.DicionarioVertices)
            {
                // A quantidade de vértices deverá ser igual ao tamanho do dicionário menos um (para desconsiderar o próprio vértice na contagem)
                if (vertice.Value.Count != this.DicionarioVertices.Count - 1)
                    return false;
            }

            return true;
        }

        public bool Regular()
        {
            int grauPrimeiroVertice = Grau(0);

            foreach (KeyValuePair<int, List<int>> vertice in this.DicionarioVertices)
            {
                if (grauPrimeiroVertice != vertice.Value.Count)
                    return false;
            }

            return true;
        }

        public void ShowLA()
        {
            foreach (KeyValuePair<int, List<int>> vertice in this.DicionarioVertices)
            {
                Console.Write(vertice.Key + ": ");

                for (int i = 0; i < vertice.Value.Count; i++)
                    Console.Write("[" + vertice.Value[i] + "] ");

                Console.WriteLine();
            }
        }

        public void SequenciaGraus()
        {
            List<int> grauVertices = new List<int>(this.DicionarioVertices.Count);

            foreach (KeyValuePair<int, List<int>> vertice in this.DicionarioVertices)
                grauVertices.Add(vertice.Value.Count);

            grauVertices.Sort(); // Método do c# usado para ordenação da lista que armazena o grau de cada vértice

            for (int i = 0; i < grauVertices.Count; i++)
                Console.WriteLine("Grau: " + grauVertices[i]);
        }

        public void VerticesAdjacentes(int vertice)
        {
            if (this.DicionarioVertices.ContainsKey(vertice))
            {
                for (int i = 0; i < this.DicionarioVertices[vertice].Count; i++)
                    Console.Write("[" + this.DicionarioVertices[vertice][i] + "] ");
            }
            else
            {
                Console.WriteLine("Vértice não encontrado!");
            }
        }

        public bool Isolado(int vertice)
        {
            return this.DicionarioVertices[vertice].Count == 0;
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
            foreach (KeyValuePair<int, List<int>> vertice in this.DicionarioVertices)
            {
                foreach (int aresta in vertice.Value)
                {
                    if (aresta == v2)
                        return true;
                }
            }

            return false;
        }
    }
}