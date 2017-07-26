using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;
using WebApplication1.Repository.Infra;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class EstabelecimentoController : Controller
    {

        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        // GET: Estabelecimento
        public ActionResult Index()
        {
            var estabelecimentos = _unitOfWork.EstabelecimentoRepository.ListarEstabelecimento();

            return View(estabelecimentos);
        }
               
        public ActionResult Create()
        {           
            return View();          
        }

        [HttpPost]
        public ActionResult Create(Estabelecimento model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.DataInclusao = DateTime.Now;
                    model.DataAlteracao = null;
                    model.DataExclusao = null;
                    
                    //Se for supermercado, valide o e-mail
                    if(_unitOfWork.CategoriaRepository.SelecionaPorCodigo(model.Cod_Categoria).Descricao == "Super Mercado")
                    {
                        if(String.IsNullOrEmpty(model.Email))
                        {
                            TempData["MensagemAtencao"] = "Telefone é obrigatório para Categoria Supermercado";

                            return View(model);
                        }
                    }

                    _unitOfWork.EstabelecimentoRepository.Adiciona(model);
                    _unitOfWork.Salvar();

                    TempData["MensagemSucesso"] = "Estabelecimento gravado com sucesso.";

                    return RedirectToAction("Index", "Estabelecimento", null);

                }
                else {
                    var errors2 = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
                    var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new { x.Key, x.Value.Errors })
                        .ToArray();

                    TempData["MensagemErro"] = "Ops! Encontramos problemas nos campos:";
                }
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Erro ao cadastrar o estabelicimento";
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? Cod_Estabelecimento)
        {
            var estabelecimento =_unitOfWork.EstabelecimentoRepository.SelecionaPorCodigo(Cod_Estabelecimento);

            if (estabelecimento != null)
            {
                ViewBag.CategoriaList = _unitOfWork.CategoriaRepository.Listar();

                return View(estabelecimento);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Estabelecimento model)
        {
            if(ModelState.IsValid)
            {
                model.DataAlteracao = DateTime.Now;

                //Se for supermercado, valide o e-mail
                if (_unitOfWork.CategoriaRepository.SelecionaPorCodigo(model.Cod_Categoria).Descricao == "Super Mercado")
                {
                    if (String.IsNullOrEmpty(model.Email))
                    {
                        TempData["MensagemAtencao"] = "Telefone é obrigatório para Categoria Supermercado";

                        return View(model);
                    }
                }

                _unitOfWork.EstabelecimentoRepository.Atualiza(model);
                _unitOfWork.Salvar();

                TempData["MensagemSucesso"] = "Estabelecimento gravado com sucesso.";

                return RedirectToAction("Index", "Estabelecimento", null);

            }
            else
            {
                TempData["MensagemErro"] = "Ops! Encontramos problemas nos campos:";
            }

            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? Cod_Estabelecimento)
        {
            var estabelecimento = _unitOfWork.EstabelecimentoRepository.SelecionaPorCodigo(Cod_Estabelecimento);

            if(estabelecimento != null)
            {
                _unitOfWork.EstabelecimentoRepository.Excluir(_unitOfWork.EstabelecimentoRepository.SelecionaPorCodigo(Cod_Estabelecimento));
                _unitOfWork.Salvar();

                TempData["MensagemSucesso"] = "Estabelecimento inativada com sucesso";

                return RedirectToAction("Index", "Estabelecimento");
            }

            return RedirectToAction("Index", "Estabelecimento");
        }       

    }
}