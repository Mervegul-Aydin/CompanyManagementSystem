using CompanyManagementSystem.Core;
using CompanyManagementSystem.Core.DTOs;
using CompanyManagementSystem.Core.Repositories;
using CompanyManagementSystem.Core.Services;
using CompanyManagementSystem.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CompanyManagementSystem.Core.Models;
using CompanyManagementSystem.Repository.UnitOfWorks;
using System.Reflection.Metadata.Ecma335;
using CompanyManagementSystem.Repository.Repositories;

namespace CompanyManagementSystem.Service.Services
{
    public class CompanyService : GenericService<Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;


        public CompanyService(IGenericRepository<Company> repository, IGenericUnitOfWork unitOfWork, ICompanyRepository companyRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<CompanyDto>> GetWebAllCompany()
        {
            var company = await _companyRepository.GetWebAllCompanyAsync();
            var companyDtos = _mapper.Map<List<CompanyDto>>(company);
            return companyDtos;
        }

        public async Task<CustomResponseDto<List<CompanyDto>>> GetApiAllCompany()
        {
            var company = await _companyRepository.GetApiAllCompanyAsync();
            var companyDtos = _mapper.Map<List<CompanyDto>>(company);
            return CustomResponseDto<List<CompanyDto>>.Success(200, companyDtos);
        }


        public async Task<List<CompanyDto>> GetWebAllCompanyAsync()
        {
            var company = await _companyRepository.GetWebAllCompanyAsync();
            var companyDtos = _mapper.Map<List<CompanyDto>>(company);
            return companyDtos;
        }

        public Task<CustomResponseDto<CompanyDto>> GetApiCompanyIdAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<CompanyDto>> GetApiAllCompanyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyDto>> GetWebCompanyIdCompanyDealerAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyDto>> GetWebCompanyIdBranchOfficeAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyDto>> GetWebCompanyCompanyDealerAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyDto>> GetWebCompanyBranchOfficeAsync()
        {
            throw new NotImplementedException();
        }
    }

}

