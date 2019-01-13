using System;
using System.Collections.Generic;
using System.Text;

namespace VideoGameLibrary
{
    public interface ICompanyRepository
    {
        List<Company> ListAll();
        Company GetByID(int id);
        void AddCompany(Company NewCompany);
        void EditCompany(Company EditedCompany);
        void DeleteCompany(int id);
    }
}
