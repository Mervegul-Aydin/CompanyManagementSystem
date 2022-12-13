using AutoMapper;
using CompanyManagementSystem.Core.DTOs;
using CompanyManagementSystem.Core.Models;
using CompanyManagementSystem.Core.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using CompanyManagementSystem.Service.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CompanyManagementSystem.WEB.Controllers
{
    public class BranchOfficeController : Controller
    {
        private readonly IBranchOfficeService _branchOfficeService;
        private readonly ICompanyService _companyService;
       
        private readonly IMapper _mapper;

        public BranchOfficeController(IBranchOfficeService branchOfficeService, ICompanyService companyService, IMapper mapper)
        {
            _branchOfficeService = branchOfficeService;
            _companyService = companyService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {

            var branchOffice = await _branchOfficeService.GetWebAllBranchOffice();
            var company = await _companyService.GetWebAllCompanyAsync();
        



            dynamic mymodel = new ExpandoObject();
            mymodel._branchOffice = branchOffice;
            mymodel._company = company;

            mymodel.activeBranchOfficeCount = branchOffice.Where(t => t.IsActive == 1).Count();
            mymodel.passiveBranchOfficeCount = branchOffice.Where(t => t.IsActive == 0).Count();
            return View(mymodel);
        }



        public async Task<IActionResult> Save()
        {

            var company = await _companyService.GetAllAsync();
            var companyDto = _mapper.Map<List<CompanyDto>>(company.ToList());
            ViewBag.companies = new SelectList(companyDto, "Id", "Name");
            return View();


        }



        [HttpPost]
        public async Task<IActionResult> Save(BranchOfficeDto branchOfficeDto)
        {
            if (ModelState.IsValid)
            {
                var _branchOfficeId = await _branchOfficeService.AddAsync(_mapper.Map<BranchOffice>(branchOfficeDto));
            
                TempData.Add("Success", "Şube Özellikleriyle birlikte eklenmiştir.");
                return RedirectToAction(nameof(Index));
            }
            TempData.Add("Error", "Hata Oluştu.BranchOfficeController|Save|77");
            var companies = await _companyService.GetAllAsync();
            var companiesDto = _mapper.Map<List<CompanyDto>>(companies.ToList());
            ViewBag.companies = new SelectList(companiesDto, "Id", "Name");
            return View();
        }

        public async Task<IActionResult> Update(int Id)
        {
            var branchOffice = await _branchOfficeService.GetByIdAsync(Id);
            var companies = await _branchOfficeService.GetAllAsync();
            var companiesDto = _mapper.Map<List<BranchOfficeDto>>(companies.ToList());
            ViewBag.companies = new SelectList(companiesDto, "Id", "Name", branchOffice.CompanyId);
            return View(_mapper.Map<BranchOfficeDto>(companies));


        }



        [HttpPost]
        public async Task<IActionResult> Update(BranchOfficeDto branchOfficeDto)
        {
            if (ModelState.IsValid)
            {
                await _branchOfficeService.UpdateAsync(_mapper.Map<BranchOffice>(branchOfficeDto));
                TempData.Add("Info", "Şube Güncellenmiştir.");
                return RedirectToAction(nameof(Index));
            }
            TempData.Add("info", "Hata Oluştu.BranchOfficeController|Update|106");
            var companies = await _companyService.GetAllAsync();
            var companiesDto = _mapper.Map<List<CompanyDto>>(companies.ToList());
            ViewBag.companies = new SelectList(companiesDto, "Id", "Name", branchOfficeDto.CompanyId);
            return View(branchOfficeDto);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var branchOffice = await _branchOfficeService.GetByIdAsync(Id);
            await _branchOfficeService.RemoveAsync(branchOffice);
            TempData.Add("Info", "Şube başarıyla silinmiştir.");
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int Id)
        {
            var branchOffice = await _branchOfficeService.GetByIdAsync(Id);
            var companies = await _companyService.GetAllAsync();
            var companiesDto = _mapper.Map<List<CompanyDto>>(companies.ToList());
            ViewBag.companies = new SelectList(companiesDto, "Id", "Name", branchOffice.CompanyId);
            return View(_mapper.Map<BranchOfficeDto>(companies));
        }







    }
}
