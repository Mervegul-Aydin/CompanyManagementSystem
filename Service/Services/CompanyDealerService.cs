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
    public class CompanyDealerService : GenericService<CompanyDealer>, ICompanyDealerService
    {
        private readonly ICompanyDealerRepository _companyDealerRepository;
        private readonly IMapper _mapper;


        public CompanyDealerService(IGenericRepository<CompanyDealer> repository, IGenericUnitOfWork unitOfWork, ICompanyDealerRepository companyDealerRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _companyDealerRepository = companyDealerRepository;
            _mapper = mapper;
        }

        public async Task<List<CompanyDealerDto>> GetWebAllCompanyDealer()
        {
            var companyDealer = await _companyDealerRepository.GetWebAllCompanyDealerAsync();
            var companyDealerDtos = _mapper.Map<List<CompanyDealerDto>>(companyDealer);
            return companyDealerDtos;
        }

        public async Task<CustomResponseDto<List<CompanyDealerDto>>> GetApiAllCompanyDealer()
        {
            var companyDealer = await _companyDealerRepository.GetApiAllCompanyDealerAsync();
            var companyDealerDtos = _mapper.Map<List<CompanyDealerDto>>(companyDealer);
            return CustomResponseDto<List<CompanyDealerDto>>.Success(200, companyDealerDtos);
        }


        public async Task<List<CompanyDealerDto>> GetWebAllCompanyDealerAsync()
        {
            var companyDealer = await _companyDealerRepository.GetWebAllCompanyDealerAsync();
            var companyDealerDtos = _mapper.Map<List<CompanyDealerDto>>(companyDealer);
            return companyDealerDtos;
        }

    }

}

