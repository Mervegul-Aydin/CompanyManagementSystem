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
    public class BranchOfficeService : GenericService<BranchOffice>, IBranchOfficeService
    {
        private readonly IBranchOfficeRepository _branchOfficeRepository;
        private readonly IMapper _mapper;


        public BranchOfficeService(IGenericRepository<BranchOffice> repository, IGenericUnitOfWork unitOfWork, IBranchOfficeRepository branchOfficeRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _branchOfficeRepository = branchOfficeRepository;
            _mapper = mapper;
        }

        public async Task<List<BranchOfficeDto>> GetWebAllBranchOffice()
        {
            var branchOffice = await _branchOfficeRepository.GetWebAllBranchOfficeAsync();
            var branchOfficeDtos = _mapper.Map<List<BranchOfficeDto>>(branchOffice);
            return branchOfficeDtos;
        }

        public async Task<CustomResponseDto<List<BranchOfficeDto>>> GetApiAllBranchOffice()
        {
            var branchOffice = await _branchOfficeRepository.GetApiAllBranchOfficeAsync();
            var branchOfficeDtos = _mapper.Map<List<BranchOfficeDto>>(branchOffice);
            return CustomResponseDto<List<BranchOfficeDto>>.Success(200, branchOfficeDtos);
        }


        public async Task<List<BranchOfficeDto>> GetWebAllBranchOfficeAsync()
        {
            var branchOffice = await _branchOfficeRepository.GetWebAllBranchOfficeAsync();
            var branchOfficeDtos = _mapper.Map<List<BranchOfficeDto>>(branchOffice);
            return branchOfficeDtos;
        }


    }

}

