using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mineração
{
    class Conjunto
    {
        public Conjunto(int faixaIdade, int faixaReprovacao)
        {
            this.faixaIdade = faixaIdade;
            this.faixaReprovacao = faixaReprovacao;
            this.quantIdade = 0;
            this.quantReprovacao = 0;
        }

        public int faixaIdade { get; set; } //1(16-22)\\2(23-30)\\3(31-40)\\4(41++)
        public int faixaReprovacao { get; set; }//1(0)\\2(1-2)\\3(3-4)\\4(5-6)\\5(7+)
        public int quantIdade { get; set; }
        public int quantReprovacao { get; set; }
        public double regra { get; set; }
        public List<Conjunto> conjuntos()
        {
            var conjuntos = new List<Conjunto>();
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    conjuntos.Add(new Conjunto(i, j));
                }
            }
            return conjuntos;
        }
        public void setIdade(int idade)
        {
            if ((idade >= 16) && (idade <= 22))
            {//1(16-22)\\2(23-30)\\3(31-40)\\4(41++)
                this.faixaIdade = 1;
            }
            else if ((idade >= 23) && (idade <= 30))
            {
                this.faixaIdade = 2;
            }
            else if ((idade >= 31) && (idade <= 40))
            {
                this.faixaIdade = 3;
            }
            else if (idade >= 41)
            {
                this.faixaIdade = 4;
            }
        }
        public void setReprovacao(int faixaReprovacao)
        {
            if ((faixaReprovacao == 0))
            {//1(0)\\2(1-2)\\3(3-4)\\4(4-5)\\5(6+)
                this.faixaReprovacao = 1;
            }
            else if ((faixaReprovacao >= 1) && (faixaReprovacao <= 2))
            {
                this.faixaReprovacao = 2;
            }
            else if ((faixaReprovacao >= 3) && (faixaReprovacao <= 4))
            {
                this.faixaReprovacao = 3;
            }
             else if ((faixaReprovacao >= 5) && (faixaReprovacao <= 6))
            {
                this.faixaReprovacao = 4;
            }
            else if (faixaReprovacao >= 7)
            {
                this.faixaReprovacao = 5;
            }
        }
        public string getIdade()
        {
            if (this.faixaIdade == 1)
            {//1(16-22)\\2(23-30)\\3(31-40)\\4(41++)
                return "16 a 22";
            }
            else if (this.faixaIdade == 2)
            {
                return "23 a 30";
            }
            else if (this.faixaIdade == 3)
            {
                return "31 a 40";
            }
            else if (this.faixaIdade == 4)
            {
                return "Mais de 40";
            }
            return null;
        }
        public string getReprovacao()
        {
            if (this.faixaReprovacao == 1)
            {//1(0)\\2(1-2)\\3(3-4)\\4(4-5)\\5(6+)
                return "nenhuma";
            }
            else if (this.faixaReprovacao == 2)
            {
                return "1 a 2";
            }
            else if (this.faixaReprovacao == 3)
            {
                return "3 a 4";
            }
            else if (this.faixaReprovacao == 4)
            {
                return "5 a 6";
            }
            else if (this.faixaReprovacao == 5)
            {
                return "7 ou mais";
            }
            return null;
        }
    }


}
