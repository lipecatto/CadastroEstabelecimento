using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Context;
using WebApplication1.Models;
using WebApplication1.Repository.Infra;

namespace WebApplication1.Repository
{
    public class CategoriaRepository
        : RepositoryBase
    {
        public CategoriaRepository(FitCardContext context)
            : base(context)
        {

        }

        public void Adiciona(Categoria categoria)
        {
            Contexto.Categorias.Add(categoria);
            Contexto.Entry(categoria).State = EntityState.Added;
        }

        public Categoria SelecionaPorCodigo(int? Cod_categoria)
        {
            return Contexto.Categorias.Find(Cod_categoria);
        }

        public List<Categoria> Listar()
        {
            var categorialist = Contexto.Categorias.ToList();

            return categorialist;
        }
    }
}