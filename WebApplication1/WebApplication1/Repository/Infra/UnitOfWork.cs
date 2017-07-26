using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Context;

namespace WebApplication1.Repository.Infra
{
    public class UnitOfWork : RepositoryBase
    {
        private EstabelecimentoRepository _estabelecimentoRepository;
        private CategoriaRepository _categoriaRepository;

        public UnitOfWork()
       : base(new FitCardContext())
        {
        }

        public EstabelecimentoRepository EstabelecimentoRepository
        {
            get { return _estabelecimentoRepository ?? (_estabelecimentoRepository = new EstabelecimentoRepository(Contexto)); }
        }

        public CategoriaRepository CategoriaRepository
        {
            get { return _categoriaRepository ?? (_categoriaRepository = new CategoriaRepository(Contexto)); }
        }


        public void Salvar()
        {
            Contexto.SaveChanges();
        }

    }
}