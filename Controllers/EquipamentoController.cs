using System;
using Microsoft.AspNetCore.Mvc;
using Admin.Context;
using Admin.Models;
using NHibernate;

namespace Admin.Controllers
{
    public class EquipamentoController : Controller
    {
        // GET: /Equipamento/Index
        public IActionResult Index()
        {
            using (ISession session = EquipamentoContext.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var equipamentos = session.QueryOver<Equipamento>().List();
                return View(equipamentos);
            }
        }

        // GET: /Equipamento/Details/1
        public IActionResult Details(int id)
        {
            using (ISession session = EquipamentoContext.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var equipamento = session.Get<Equipamento>(id);
                return View(equipamento);
            }
        }

        // GET: /Equipamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Equipamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                using (ISession session = EquipamentoContext.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    equipamento.Aquisicao = DateTime.Now; // Defina a data de aquisição como a data atual
                    session.Save(equipamento);
                    transaction.Commit();
                }

                return RedirectToAction("Index");
            }

            return View(equipamento);
        }

        // GET: /Equipamento/Edit/1
        public IActionResult Edit(int id)
        {
            using (ISession session = EquipamentoContext.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var equipamento = session.Get<Equipamento>(id);
                return View(equipamento);
            }
        }

        // POST: /Equipamento/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                using (ISession session = EquipamentoContext.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var existingEquipamento = session.Get<Equipamento>(id);

                    if (existingEquipamento != null)
                    {
                        existingEquipamento.Tipo = equipamento.Tipo;
                        existingEquipamento.NumeroSerie = equipamento.NumeroSerie;
                        existingEquipamento.Nome = equipamento.Nome;
                        existingEquipamento.Status = equipamento.Status;
                        existingEquipamento.EnderecoHardware = equipamento.EnderecoHardware;

                        session.Update(existingEquipamento);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }

            return View(equipamento);
        }

        // GET: /Equipamento/Delete/1
        public IActionResult Delete(int id)
        {
            using (ISession session = EquipamentoContext.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var equipamento = session.Get<Equipamento>(id);
                return View(equipamento);
            }
        }

        // POST: /Equipamento/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using (ISession session = EquipamentoContext.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var equipamento = session.Get<Equipamento>(id);

                if (equipamento != null)
                {
                    session.Delete(equipamento);
                    transaction.Commit();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
