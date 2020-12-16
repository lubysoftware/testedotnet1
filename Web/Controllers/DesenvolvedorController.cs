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
    public class DesenvolvedorController : Controller
    {
        DesenvolvedorServices desenvolvedorServices = new DesenvolvedorServices();

        // GET: DesenvolvedorController
        public ActionResult Index()
        {
            List<DesenvolvedorModel> model = new List<DesenvolvedorModel>();

            desenvolvedorServices.SetEndpoint("Desenvolvedor");

            var lsEntity = desenvolvedorServices.Get().Result;

            foreach (var item in lsEntity)
            {
                DesenvolvedorModel dev = new DesenvolvedorModel();
                dev.Id = item.Id;
                dev.Nome = item.Nome;

                model.Add(dev);
            }

            return View(model);
        }

        // GET: DesenvolvedorController/Details/5
        public ActionResult Details(int id)
        {
            DesenvolvedorModel model = new DesenvolvedorModel();
            desenvolvedorServices.SetEndpoint("Desenvolvedor");
            Desenvolvedor entity = desenvolvedorServices.GetById(id).Result;
            
            if (entity != null)
            {
                model.Id = entity.Id;
                model.Nome = entity.Nome;
            }

            return View(model);
        }

        // GET: DesenvolvedorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DesenvolvedorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DesenvolvedorModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Desenvolvedor desenvolvedor = new Desenvolvedor();
                    desenvolvedor.Nome = model.Nome;
                    desenvolvedorServices.SetEndpoint("Desenvolvedor");
                    if (desenvolvedorServices.Post(desenvolvedor).Result != null)
                    {
                        return RedirectToAction("Index");
                    }                   
                    
                }

                return View(model);
            }
            catch(Exception e)
            {
                return View(model);
            }
        }

        // GET: DesenvolvedorController/Edit/5
        public ActionResult Edit(int id)
        {
            DesenvolvedorModel model = new DesenvolvedorModel();
            desenvolvedorServices.SetEndpoint("Desenvolvedor");
            Desenvolvedor entity = desenvolvedorServices.GetById(id).Result;

            if (entity != null)
            {
                model.Id = entity.Id;
                model.Nome = entity.Nome;
            }

            return View(model);
        }

        // POST: DesenvolvedorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DesenvolvedorModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    desenvolvedorServices.SetEndpoint("Desenvolvedor");
                    Desenvolvedor desenvolvedor = desenvolvedorServices.GetById(id).Result;

                    if(desenvolvedor != null)
                    {
                        desenvolvedor.Nome = model.Nome;

                        if (desenvolvedorServices.Put(id, desenvolvedor).Result != null)
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

        // GET: DesenvolvedorController/Delete/5
        public ActionResult Delete(int id)
        {
            DesenvolvedorModel model = new DesenvolvedorModel();
            desenvolvedorServices.SetEndpoint("Desenvolvedor");
            Desenvolvedor entity = desenvolvedorServices.GetById(id).Result;

            if (entity != null)
            {
                model.Id = entity.Id;
                model.Nome = entity.Nome;
            }

            return View(model);
        }

        // POST: DesenvolvedorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DesenvolvedorModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    desenvolvedorServices.SetEndpoint("Desenvolvedor");
                    if (desenvolvedorServices.Delete(id).Result != null)
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
