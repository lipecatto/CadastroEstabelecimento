using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Categoria : IDisposable
    {
        #region Propriedades

        [Key]
        [Display(Name = "Código da categoria")]
        public int Cod_Categoria { get; set; }

        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        [Display(Name = "Status")]
        public bool Flg_Situacao { get; set; }

        public Nullable<DateTime> DataInclusao { get; set; }

        public Nullable<DateTime> DataAlteracao { get; set; }

        public Nullable<DateTime> DataExclusao { get; set; }
        #endregion

        #region Construtor

        public Categoria()
        {
            Cod_Categoria = 0;
            Descricao = null;
            Flg_Situacao = false;
         
        }
        #endregion
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}