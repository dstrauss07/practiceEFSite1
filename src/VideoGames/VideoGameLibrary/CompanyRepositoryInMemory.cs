using System;
using System.Collections.Generic;
using System.Text;

namespace VideoGameLibrary
{
    public class CompanyRepositoryInMemory : ICompanyRepository
    {
        public static List<Company> _Companies;
        public static int _nextId = 1;


    public CompanyRepositoryInMemory()
        {
            if (_Companies ==null)
            {
                _Companies = new List<Company>();
            }
        }

        public void AddCompany(Company NewCompany)
        {
            NewCompany.CompanyId = _nextId++;
            _Companies.Add(NewCompany);

        }

        public void DeleteCompany(int id)
        {
           _Companies.Remove(GetByID(id));
        }

        public void EditCompany(Company EditedCompany)
        {
            var OrigCompany = GetByID(EditedCompany.CompanyId);
            OrigCompany.CompanyName = EditedCompany.CompanyName;
            OrigCompany.Location = EditedCompany.Location;

        }

        public Company GetByID(int id)
        {
            return _Companies.Find(c => c.CompanyId == id);
        }

        public List<Company> ListAll()
        {
            return _Companies;
        }
    }
}
