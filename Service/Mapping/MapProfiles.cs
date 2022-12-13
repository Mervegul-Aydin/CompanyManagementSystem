using AutoMapper;
using CompanyManagementSystem.Core.DTOs;
using CompanyManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Service.Mapping
{
    public class MapProfiles:Profile
    {
        public MapProfiles()
        {
     
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<CompanyDealer, CompanyDealerDto>().ReverseMap();
            CreateMap<BranchOffice, BranchOfficeDto>().ReverseMap();



        }
    }
}
