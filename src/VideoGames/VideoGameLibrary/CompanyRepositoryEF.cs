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
            throw new NotImplementedException();
        }

        public void EditCompany(Company EditedCompany)
        {
            throw new NotImplementedException();
        }

        public Company GetByID(int id)
        {
            throw new NotImplementedException();
            //return _companyContext.Games.Where(b => b.CompanyId == id);
        }

        public List<Company> ListAll()
        {
            return _companyContext.Company.ToList();
        }
    }
}
