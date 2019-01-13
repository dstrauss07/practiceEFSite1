using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VideoGameLibrary
{
    public class CompanyRepositoryFS : ICompanyRepository
    {
        public static List<Company> _companies;
        public static int _nextId = 1;

        private const string PATH = "E:/CodingRepo/data/companydata";
        private const string FILENAME = "companydata.json";

        private readonly string _fileFullPath = Path.Combine(PATH, FILENAME);
        public CompanyRepositoryFS()
        {
            if (_companies == null)
            {
                _companies = LoadFile();
            }
        }
        
        public List<Company> LoadFile()
        {
            try
            {
                string rawListStr = File.ReadAllText(_fileFullPath);
                List<Company> rawCompanyList = JsonConvert.DeserializeObject<List<Company>>(rawListStr);
                return rawCompanyList;
            }
            catch(Exception)
            {
                //TODO log the exception
            }
            return new List<Company>();
        }

        public void SaveFile()
        {
            if(!Directory.Exists(PATH))
                {
                Directory.CreateDirectory(PATH);
                }
            try
            {
                string rawListStr = JsonConvert.SerializeObject(_companies);
                File.WriteAllText(_fileFullPath, rawListStr);
            }
            catch (Exception)
            {
                //TODO log the exception
            }
        }
   

        public void AddCompany(Company NewCompany)
        {
            _companies.Add(NewCompany);
            SaveFile();
        }

        public void DeleteCompany(int id)
        {
            _companies.Remove(GetByID(id));
            SaveFile();
        }

        public void EditCompany(Company EditedCompany)
        {
            var OrigCompany = GetByID(EditedCompany.CompanyId);
            OrigCompany.CompanyName = EditedCompany.CompanyName;
            OrigCompany.Location = EditedCompany.Location;
            SaveFile();
        }

        public Company GetByID(int id)
        {
            return _companies.Find(c => c.CompanyId == id); 
        }

        public List<Company> ListAll()
        {
            return _companies;
        }
    }
}
