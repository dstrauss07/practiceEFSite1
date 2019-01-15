using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;

namespace VideoGameLibrary
{
    public class CompanyRepositoryEF : ICompanyRepository
    {
        private readonly GamesContext _companyContext;
        public CompanyRepositoryEF(GamesContext dbContext)
        {
            _companyContext = dbContext;
        }

        public void AddCompany(Company NewCompany)
        {
            _companyContext.Add(NewCompany);
            _companyContext.SaveChanges();
        }

        public void DeleteCompany(int id)
        {
            _companyContext.Remove(GetByID(id));
            _companyContext.SaveChanges();
        }

        public void EditCompany(Company EditedCompany)
        {
            var OrigCompany = GetByID(EditedCompany.CompanyId);
            OrigCompany.CompanyName = EditedCompany.CompanyName;
            OrigCompany.Location = EditedCompany.Location;
            _companyContext.SaveChanges();
        }

        public Company GetByID(int id)
        {
            //throw new NotImplementedException();
            return _companyContext.Company
                .Single(b => b.CompanyId == id);


      }

        public List<Company> ListAll()
        {
            return _companyContext.Company.ToList();
        }
    }
}
