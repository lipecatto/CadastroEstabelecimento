using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Context;
using WebApplication1.Models;
using WebApplication1.Repository.Infra;

namespace WebApplication1.Repository
{
    public class EstabelecimentoRepository
        : RepositoryBase
    {
        public EstabelecimentoRepository(FitCardContext context)
            : base(context)
        {
        }


        public void Adiciona(Estabelecimento estabelecimento)
        {
            Contexto.Estabelecimentos.Add(estabelecimento);
            Contexto.Entry(estabelecimento).State = EntityState.Added;
        }

        public void Atualiza(Estabelecimento estabelecimento)
        {
            Contexto.Estabelecimentos.Attach(estabelecimento);
            Contexto.Entry(estabelecimento).State = EntityState.Modified;
        }

        public Estabelecimento SelecionaPorCodigo(int? Cod_Estabelecimento)
        {
            return Contexto.Estabelecimentos.Find(Cod_Estabelecimento);
        }

        public List<Estabelecimento> ListarEstabelecimento()
        {
            var arrayEstabelecimentos = Contexto.Estabelecimentos.Where(p=>p.Flg_Situacao).ToList();

            return arrayEstabelecimentos;
        }

        public void Excluir(Estabelecimento estabelecimento)
        {
            estabelecimento.Flg_Situacao = false;
            Atualiza(estabelecimento);
        }
    }
}