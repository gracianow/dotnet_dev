using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppEstudanteMD.Models;

namespace WebAppEstudanteMD.Controllers
{
    public class EstudantesController : Controller
    {
        private DadosDbContext db = new DadosDbContext();

        // GET: Estudantes
        public ActionResult Index()
        {
            return View(db.Estudantes.ToList());
        }

        // GET: Estudantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudante estudante = db.Estudantes.Find(id);
            if (estudante == null)
            {
                return HttpNotFound();
            }
            return View(estudante);
        }

        // GET: Estudantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstudanteId,Nome,Idade,Sexo")] Estudante estudante)
        {
            if (ModelState.IsValid)
            {
                db.Estudantes.Add(estudante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estudante);
        }

        // GET: Estudantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudante estudante = db.Estudantes.Find(id);
            if (estudante == null)
            {
                return HttpNotFound();
            }

            var CursosEstudantes = from c in db.Cursos
                                   select new
                                   {
                                       c.CursoId,
                                       c.Nome,
                                       Checked = ((from ce in db.CursosEstudantes
                                                   where (ce.EstudanteId == id) & (ce.CursoId == c.CursoId)
                                                   select ce).Count() > 0)
                                   };
            var estudanteViewModel = new EstudantesViewModel();
            estudanteViewModel.EstudanteId = id.Value;
            estudanteViewModel.Nome = estudante.Nome;
            estudanteViewModel.Idade = estudante.Idade;
            estudanteViewModel.Sexo = estudante.Sexo;
            var checkboxListCursos = new List<CheckBoxViewModel>();
            foreach (var item in CursosEstudantes)
            {
                checkboxListCursos.Add(new CheckBoxViewModel
                {
                    Id = item.CursoId,
                    Nome = item.Nome,
                    Checked = item.Checked
                });
            }
            estudanteViewModel.Cursos = checkboxListCursos;
            return View(estudanteViewModel);
        }

        //return View(estudante);




        // POST: Estudantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Edit(EstudantesViewModel estudante)
        {
            if (ModelState.IsValid)
            {
                var estudanteSelecionado = db.Estudantes.Find(estudante.EstudanteId);
                estudanteSelecionado.Nome = estudante.Nome;
                estudanteSelecionado.Idade = estudante.Idade;
                estudanteSelecionado.Sexo = estudante.Sexo;
                foreach (var item in db.CursosEstudantes)
                {
                    if (item.EstudanteId == estudante.EstudanteId)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                }
                foreach (var item in estudante.Cursos)
                {
                    if (item.Checked)
                    {
                        db.CursosEstudantes.Add(new CursoEstudante()
                        {
                            EstudanteId = estudante.EstudanteId,
                            CursoId = item.Id
                        });
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudante);
        }


        // GET: Estudantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudante estudante = db.Estudantes.Find(id);
            if (estudante == null)
            {
                return HttpNotFound();
            }
            return View(estudante);
        }

        // POST: Estudantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estudante estudante = db.Estudantes.Find(id);
            db.Estudantes.Remove(estudante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

