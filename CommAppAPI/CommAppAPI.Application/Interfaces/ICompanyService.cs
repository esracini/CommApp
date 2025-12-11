using CommAppAPI.Application.DTOs.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.Interfaces
{
    public interface ICompanyService
    {
        List<CompanyGetDto> GetAll();
        public CompanyGetDetailDto GetDetail(int id);
        CompanyGetDto GetById(int id);
        CompanyGetDto Add(CompanyCreateDto dto);
        CompanyGetDto Update(int id, CompanyUpdateDto dto);
        void Delete(int id);
    }
}
