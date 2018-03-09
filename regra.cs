using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mineração
{
    class Regra
    {
        public List<List<string>> lerAquivo()
        {
            try
            {
                StreamReader rd = new StreamReader("./Info.csv");
                string linha = null;
                string[] linhaseparada = null;
                linha = rd.ReadLine();
                List<List<string>> strings = new List<List<string>>();
                List<string> lista;

                while ((linha = rd.ReadLine()) != null)
                {
                    lista = new List<string>();
                    linhaseparada = linha.Split(';');
                    lista.Add(linhaseparada[0]);
                    lista.Add(linhaseparada[4]);

                    strings.Add(lista);


                }
                rd.Close();
                return strings;

            }
            catch
            {
                Console.WriteLine("Erro ao executar Leitura do Arquivo");
                return null;
            }
        }
        public void metodo1(List<Conjunto> listas, List<List<string>> strings, double supmin, double confia)
        {
            int i = 0;
            while (i < strings.Count)
            {
                Conjunto conjunto = new Conjunto(0, 0);

                var date = new DateTime();
                date = Convert.ToDateTime(strings[i][0]);
                conjunto.setIdade(2018 - date.Year);

                if (strings[i][1] == "")
                {
                    conjunto.setReprovacao(0);
                }
                else
                {
                    conjunto.setReprovacao(Convert.ToInt32(strings[i][1]));
                }
                listas = preencher(listas, conjunto);
                i++;

            }
            buscarAssosiacoes(listas, supmin, confia, strings.Count);
            resultado(listas);


        }
        public void metodo2(List<Conjunto> listas, double supmin, double confia)
        {
            try
            {
                StreamReader rd = new StreamReader("./Info.csv");
                string linha = null;
                string[] linhaseparada = null;
                DateTime date = new DateTime();
                linha = rd.ReadLine();


                int cont = 0;
                var conj = new Conjunto(0, 0);
                while ((linha = rd.ReadLine()) != null)
                {
                    linhaseparada = linha.Split(';');
                    date = Convert.ToDateTime(linhaseparada[0]);
                    cont++;

                    conj.setIdade(2018 - date.Year);

                    if (linhaseparada[4] == "")
                    {
                        conj.setReprovacao(0);
                    }
                    else
                    {
                        conj.setReprovacao(Convert.ToInt32(linhaseparada[4]));
                    }

                    listas = preencher(listas, conj);

                }
                rd.Close();
                buscarAssosiacoes(listas, supmin, confia, cont);
                resultado(listas);

            }
            catch
            {
                Console.WriteLine("Erro ao executar Leitura do Arquivo");
            }
        }
        
        private List<Conjunto> preencher(List<Conjunto> listas, Conjunto conjunto)
        {
            for (int i = 0; i < listas.Count; i++)
            {
                if (listas[i].faixaIdade == conjunto.faixaIdade)
                {
                    listas[i].quantIdade++;
                    if (listas[i].faixaReprovacao == conjunto.faixaReprovacao)
                    {
                        listas[i].quantReprovacao++;
                    }
                }
            }
            return listas;
        }
        private List<Conjunto> buscarAssosiacoes(List<Conjunto> listas, double supmin, double confia, int total)
        {
            for (int i = 0; i < listas.Count; i++)
            {
                if (supmin < (listas[i].quantReprovacao / ((double)total)))
                {
                    if (confia < (listas[i].quantReprovacao / (double)listas[i].quantIdade))
                    {
                        listas[i].regra = listas[i].quantReprovacao / (double)listas[i].quantIdade;
                    }
                }
            }
            return listas;
        }
        private void resultado(List<Conjunto> listas)
        {
            int i = 0;
            int j = 0;
            while (i < listas.Count)
            {
                Console.Write("Com idades entre " + listas[i].getIdade() + ":\n");
                j = i;
                while (((j < listas.Count) && listas[j].faixaIdade == listas[i].faixaIdade))
                {
                    if(j==0){
                        Console.Write("  " + (listas[j].regra * 100) + "% de chance de reprovar " + listas[j].getReprovacao() + " vez\n");
                   
                    }else{
                    Console.Write("  " + (listas[j].regra * 100) + "% de chance de reprovar entre " + listas[j].getReprovacao() + " vezes\n");
                    }
                    j++;
                }
                i = j;
            }
        }
    }
}
