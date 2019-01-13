using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VideoGameLibrary;

namespace WebGameManager.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _CompanyRepo;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _CompanyRepo = companyRepository;
        }
        // GET: Company
        public ActionResult Index()
        {
            return View(_CompanyRepo.ListAll());
        }

        // GET: Company/Details/5
        public ActionResult Details(int id)
        {
            return View(_CompanyRepo.GetByID(id));
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View(new Company());
        }

        // POST: Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company NewCompany, IFormCollection collection)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(NewCompany);
                }

                _CompanyRepo.AddCompany(NewCompany);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                //TODO LOG THE ERRORS
                return View();
            }
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_CompanyRepo.GetByID(id));
        }

        // POST: Company/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Company EditedCompany, IFormCollection collection)
        {
            try
            {
                _CompanyRepo.EditCompany(EditedCompany);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                //Todo log the exception
            }
            return View(EditedCompany);
        }
        

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_CompanyRepo.GetByID(id));
        }

        // POST: Company/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _CompanyRepo.DeleteCompany(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
               //TODO log the issues
            }
            return View(_CompanyRepo.GetByID(id));
        }
    }
}