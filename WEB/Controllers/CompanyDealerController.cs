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
    public class CompanyDealerController:Controller
    {
        private readonly ICompanyDealerService _companyDealerService;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyDealerController(ICompanyDealerService companyDealerService,ICompanyService companyService, IMapper mapper)
        {
            _companyDealerService = companyDealerService;
            _companyService = companyService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {

            var companyDealer = await _companyDealerService.GetWebAllCompanyDealer();
            var company = await _companyService.GetWebAllCompanyAsync();
         



            dynamic mymodel = new ExpandoObject();
            mymodel._companyDealer = companyDealer;
            mymodel._company = company;

            mymodel.activeCompanyDealerCount = companyDealer.Where(t => t.IsActive == 1).Count();
            mymodel.passiveCompanyDealerCount = companyDealer.Where(t => t.IsActive == 0).Count();
            return View(mymodel);
        }



        public async Task<IActionResult> Save()
        {
            var company= await _companyService.GetAllAsync();
            var companyDto = _mapper.Map<List<CompanyDto>>(company.ToList());
            ViewBag.companies = new SelectList(companyDto, "Id", "Name");//
            return View();


        }



        [HttpPost]
        public async Task<IActionResult> Save(CompanyDealerDto companyDealerDto, CompanyDto companyDto)
        {
            if (ModelState.IsValid)
            {
                await _companyDealerService.AddAsync(_mapper.Map<CompanyDealer>(companyDealerDto));
                TempData.Add("Success", "Bayi Özellikleriyle birlikte eklenmiştir.");
                return RedirectToAction(nameof(Index));
            }
            TempData.Add("Error", "Hata Oluştu.CompanyDealerController|Save|77");
            var companies = await _companyService.GetAllAsync();
            var companiesDto = _mapper.Map<List<CompanyDto>>(companies.ToList());
            ViewBag.companies = new SelectList(companiesDto, "Id", "Name");
            return View();
        }

        public async Task<IActionResult> Update(int Id)
        {
                var companyDealer = await _companyDealerService.GetByIdAsync(Id);
                var companies = await _companyDealerService.GetAllAsync();
                var companiesDto = _mapper.Map<List<CompanyDealerDto>>(companies.ToList());
                ViewBag.companies = new SelectList(companiesDto, "Id", "Name", companyDealer.CompanyId);
                return View(_mapper.Map<CompanyDealerDto>(companies));
            

        }



        [HttpPost]
        public async Task<IActionResult> Update(CompanyDealerDto companyDealerDto)
        {
            if (ModelState.IsValid)
            {
                await _companyDealerService.UpdateAsync(_mapper.Map<CompanyDealer>(companyDealerDto));
                TempData.Add("Info", "Bayi Güncellenmiştir.");
                return RedirectToAction(nameof(Index));
            }
            TempData.Add("info", "Hata Oluştu.CompanyDealerController|Update|106");
            var companies = await _companyService.GetAllAsync();
            var companiesDto = _mapper.Map<List<CompanyDto>>(companies.ToList());
            ViewBag.companies = new SelectList(companiesDto, "Id", "Name", companyDealerDto.CompanyId);
            return View(companyDealerDto);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var companyDealer = await _companyDealerService.GetByIdAsync(Id);
            await _companyDealerService.RemoveAsync(companyDealer);
            TempData.Add("Info", "Firma başarıyla silinmiştir.");
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int Id)
        {
            var companyDealer = await _companyDealerService.GetByIdAsync(Id);
            var companies = await _companyService.GetAllAsync();
            var companiesDto = _mapper.Map<List<CompanyDto>>(companies.ToList());
            ViewBag.companies = new SelectList(companiesDto, "Id", "Name", companyDealer.CompanyId);
            return View(_mapper.Map<CompanyDealerDto>(companies));
        }







    }
}
