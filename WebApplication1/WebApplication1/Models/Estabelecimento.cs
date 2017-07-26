using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [Table("Estabelecimento")]
    public class Estabelecimento : IDisposable
    {
        #region Propriendades
        [Key]
        [Display(Name = "Código do Estabelecimento")]
        public int Cod_Estabelecimento { get; set; }

        [Required(ErrorMessage = "Favor, digitar o Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Favor digitar o Nome Fantasia")]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }


        [Display(Name = "E-mail")]  
        [EmailAddress(ErrorMessage = "E-mail Inválido")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Categoria")]
        public virtual Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Favor, selecionar a categoria")]
        [Display(Name = "Categoria")]
        public int Cod_Categoria { get; set; }

        [Display(Name = "Status")]
        public Boolean Flg_Situacao { get; set; }

        public Nullable<DateTime> DataInclusao { get; set; }

        public Nullable<DateTime> DataAlteracao { get; set; }

        public Nullable<DateTime> DataExclusao { get; set; }
        #endregion

        #region Construtores

        public Estabelecimento()
        {
            Cod_Estabelecimento = 0;
            Nome = null;
            NomeFantasia = null;
            Cnpj = null;
            Telefone = null;
            Categoria = null;
            Flg_Situacao = true;
        }

        #endregion
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}