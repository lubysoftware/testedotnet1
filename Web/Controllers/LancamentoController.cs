using Domain;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class LancamentoController : Controller
    {
        LancamentoServices lancamentoServices = new LancamentoServices();

        // GET: LancamentoController1
        public ActionResult Index()
        {
            List<LancamentoModel> model = new List<LancamentoModel>();

            lancamentoServices.SetEndpoint("Lancamento");

            var lsEntity = lancamentoServices.Get().Result;

            foreach (var l in lsEntity)
            {
                LancamentoModel lancamento = new LancamentoModel();
                lancamento.Id = l.Id;
                lancamento.DataFim = l.DataFim;
                lancamento.DataInicio = l.DataInicio;
                lancamento.IdDesenvolvedor = l.IdDesenvolvedor;
                
                model.Add(lancamento);
            }

            return View(model);
        }

        // GET: LancamentoController1/Details/5
        public ActionResult Details(int id)
        {
            LancamentoModel model = new LancamentoModel();
            lancamentoServices.SetEndpoint("Lancamento");
            Lancamento entity = lancamentoServices.GetById(id).Result;

            if (entity != null)
            {
                model.Id = entity.Id;
                model.DataFim = entity.DataFim;
                model.DataInicio = entity.DataInicio;
                model.IdDesenvolvedor = entity.IdDesenvolvedor;
            }

            return View(model);
        }

        // GET: LancamentoController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LancamentoController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LancamentoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Lancamento lancamento = new Lancamento();
                    lancamento.DataFim = model.DataFim;
                    lancamento.DataInicio = model.DataInicio;
                    lancamento.IdDesenvolvedor = model.IdDesenvolvedor;

                    lancamentoServices.SetEndpoint("Lancamento");
                    if (lancamentoServices.Post(lancamento).Result != null)
                    {
                        return RedirectToAction("Index");
                    }

                }

                return View(model);
            }
            catch (Exception e)
            {
                return View(model);
            }
        }

        // GET: LancamentoController1/Edit/5
        public ActionResult Edit(int id)
        {
            LancamentoModel model = new LancamentoModel();
            lancamentoServices.SetEndpoint("Lancamento");
            Lancamento entity = lancamentoServices.GetById(id).Result;

            if (entity != null)
            {
                model.Id = entity.Id;
                model.DataFim = entity.DataFim;
                model.DataInicio = entity.DataInicio;
                model.IdDesenvolvedor = entity.IdDesenvolvedor;
            }

            return View(model);
        }

        // POST: LancamentoController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LancamentoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    lancamentoServices.SetEndpoint("Lancamento");
                    Lancamento lancamento = lancamentoServices.GetById(id).Result;

                    if (lancamento != null)
                    {
                        lancamento.DataFim = model.DataFim;
                        lancamento.DataInicio = model.DataInicio;
                        lancamento.IdDesenvolvedor = model.IdDesenvolvedor;

                        if (lancamentoServices.Put(id, lancamento).Result != null)
                        {
                            return RedirectToAction("Index");
                        }
                    }

                }

                return View(model);
            }
            catch (Exception e)
            {
                return View(model);
            }
        }

        // GET: LancamentoController1/Delete/5
        public ActionResult Delete(int id)
        {
            LancamentoModel model = new LancamentoModel();
            lancamentoServices.SetEndpoint("Lancamento");
            Lancamento entity = lancamentoServices.GetById(id).Result;

            if (entity != null)
            {
                model.Id = entity.Id;
                model.DataFim = entity.DataFim;
                model.DataInicio = entity.DataInicio;
                model.IdDesenvolvedor = entity.IdDesenvolvedor;
            }

            return View(model);
        }

        // POST: LancamentoController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LancamentoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    lancamentoServices.SetEndpoint("Lancamento");
                    if (lancamentoServices.Delete(id).Result != null)
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View(model);
            }
            catch (Exception e)
            {
                return View(model);
            }
        }
    }
}
