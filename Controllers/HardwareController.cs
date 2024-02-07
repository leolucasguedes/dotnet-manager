using System;
using Microsoft.AspNetCore.Mvc;
using Admin.Context;
using Admin.Models;
using global::NHibernate;

namespace Admin.Controllers
{
    public class HardwareController : Controller
    {
        // GET: /hardware
        public IActionResult Index()
        {
            using (global::NHibernate.ISession session = HardwareContext.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var equipamentos = session.QueryOver<Hardware>().List();
                return View("Hardware/Index", equipamentos);
            }
        }

        // GET: /hardware/Details/1
        public IActionResult Details(int id)
        {
            using (global::NHibernate.ISession session = HardwareContext.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var equipamento = session.Get<Hardware>(id);
                return View("Hardware/Details", equipamento);
            }
        }

        // GET: /hardware/Create
        public IActionResult Create()
        {
            return View("Hardware/Create");
        }

        // POST: /hardware/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hardware equipamento)
        {
            if (ModelState.IsValid)
            {
                using (global::NHibernate.ISession session = HardwareContext.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    equipamento.Aquisicao = DateTime.Now;
                    session.Save(equipamento);
                    transaction.Commit();
                }

                return RedirectToAction("Index");
            }

            return View("Hardware/Create", equipamento);
        }

        // GET: /hardware/Edit/1
        public IActionResult Edit(int id)
        {
            using (global::NHibernate.ISession session = HardwareContext.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var equipamento = session.Get<Hardware>(id);
                return View("Hardware/Edit", equipamento);
            }
        }

        // POST: /hardware/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Hardware equipamento)
        {
            if (ModelState.IsValid)
            {
                using (global::NHibernate.ISession session = HardwareContext.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var existingEquipamento = session.Get<Hardware>(id);

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

            return View("Hardware/Edit", equipamento);
        }

        // GET: /hardware/Delete/1
        public IActionResult Delete(int id)
        {
            using (global::NHibernate.ISession session = HardwareContext.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var equipamento = session.Get<Hardware>(id);
                return View("Hardware/Delete", equipamento);
            }
        }

        // POST: /hardware/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            using (global::NHibernate.ISession session = HardwareContext.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var equipamento = session.Get<Hardware>(id);

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
