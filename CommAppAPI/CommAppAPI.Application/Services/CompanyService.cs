using AutoMapper;
using CommAppAPI.Application.DTOs.Company;
using CommAppAPI.Application.Interfaces;
using CommAppAPI.Application.Repositories;
using CommAppAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyReadRepository _read;
        private readonly ICompanyWriteRepository _write;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyReadRepository read,
                              ICompanyWriteRepository write,
                              IMapper mapper)
        {
            _read = read;
            _write = write;
            _mapper = mapper;
        }

        public List<CompanyGetDto> GetAll()
        {
            var companies = _read.GetAll().ToList();
            return _mapper.Map<List<CompanyGetDto>>(companies);
        }

        public CompanyGetDto GetById(int id)
        {
            var company = _read.GetByIdAsync(id).Result;
            return _mapper.Map<CompanyGetDto>(company);
        }

        public CompanyGetDto Add(CompanyCreateDto dto)
        {
            var company = _mapper.Map<Company>(dto);

            _write.AddAsync(company).Wait();
            _write.SaveAsync().Wait();

            return _mapper.Map<CompanyGetDto>(company);
        }

        public CompanyGetDto Update(int id, CompanyUpdateDto dto)
        {
            var company = _read.GetByIdAsync(id).Result;

            _mapper.Map(dto, company);

            _write.Update(company);
            _write.SaveAsync().Wait();

            return _mapper.Map<CompanyGetDto>(company);
        }

        public void Delete(int id)
        {
            var company = _read.GetByIdAsync(id).Result;

            _write.Remove(company);
            _write.SaveAsync().Wait();
        }

        public CompanyGetDetailDto GetDetail(int id)
        {
            var company = _read.GetCompanyDetails(id);
            return _mapper.Map<CompanyGetDetailDto>(company);
        }


    }
}

