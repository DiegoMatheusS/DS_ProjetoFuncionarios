using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Aula03Colecoes.Models.Enuns;
using Aula03Colecoes.Models;
using System.ComponentModel;

//MÉTODOS
namespace Aula03Colecoes.Models
{

    public class Funcionarios
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;

        public DateTime DataAdmissao { get; set; }

        public decimal Salario { get; set; }

        public TipoFuncionarioEnum TipoFuncionario { get; set; }
        public void ReajustarSalario()
        {
            Salario = Salario +(Salario * 10/100);
        
        }

        public string ExibirPeriodoExperiencia()
        {
            String periodoExperiencia = 
                string.Format("Periodo de Experiencia: {0} até {1}", DataAdmissao, DataAdmissao.AddMonths(3));
            return periodoExperiencia;
        }

        public decimal CalcularDescontoVT (decimal percentual) //quem usar esse metodo tem que utilizar um percentual
        {
            decimal desconto = this.Salario * percentual/100; //this.salario é referenciar o salario 
            return desconto;
        }

        private int ContarCaracteres(string dado)
        {
            return dado.Length;
        }
        public bool ValidarCpf()
        {
            if(ContarCaracteres(Cpf) == 11)
                return true;
            else
                return false;
        }

    }
}