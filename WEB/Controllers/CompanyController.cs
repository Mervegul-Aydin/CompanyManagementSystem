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
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var company = await _companyService.GetWebAllCompanyAsync();
            dynamic mymodel = new ExpandoObject();
            mymodel._company = company;
            mymodel.activeCompanyCount = company.Where(t => t.IsActive == 1).Count();
            mymodel.passiveCompanyCount = company.Where(t => t.IsActive == 0).Count();
            return View(mymodel);
        }



        public async Task<IActionResult> Save()
        {
            var company = await _companyService.GetAllAsync();
            var companyDto = _mapper.Map<List<CompanyDto>>(company.ToList());
            ViewBag.company = new SelectList(companyDto, "Id", "Name");
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Save(CompanyDto companyDto)
        {
            if (ModelState.IsValid)
            {
                await _companyService.AddAsync(_mapper.Map<Company>(companyDto));
                TempData.Add("Success", "Firma başarıyla eklenmiştir.");
                return RedirectToAction(nameof(Index));
            }
            TempData.Add("Error", "Hata Oluştu. CompanyController|Save|54");
            var company = await _companyService.GetAllAsync();
            var CompanyDto = _mapper.Map<List<CompanyDto>>(company.ToList());
            ViewBag.company = new SelectList(CompanyDto, "Id", "Name");
            return View();
        }

        public async Task<IActionResult> Update(int Id)
        {
            var company = await _companyService.GetByIdAsync(Id);
            var Company = await _companyService.GetAllAsync();
            var companyDto = _mapper.Map<List<CompanyDto>>(Company.ToList());
            ViewBag.company = new SelectList(companyDto, "Id", "Name", company);
            return View(_mapper.Map<CompanyDto>(company));
        }



        [HttpPost]
        public async Task<IActionResult> Update(CompanyDto companyDto)
        {
            if (ModelState.IsValid)
            {
                await _companyService.UpdateAsync(_mapper.Map<Company>(companyDto));
                TempData.Add("Info", "Firma başarıyla güncellenmiştir.");
                return RedirectToAction(nameof(Index));
            }
            TempData.Add("Info", "Hata Oluştu. CompanyController|Update|79");
            var company = await _companyService.GetAllAsync();
            var CompanyDto = _mapper.Map<List<CompanyDto>>(company.ToList());
            ViewBag.company = new SelectList(CompanyDto, "Id", "Name", CompanyDto);
            return View();
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var company = await _companyService.GetByIdAsync(Id);
            await _companyService.RemoveAsync(company);
            TempData.Add("Info", "Firma başarıyla silinmiştir.");
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int Id)
        {
            var company = await _companyService.GetByIdAsync(Id);
            var Companies= await _companyService.GetAllAsync();
            var companyDto = _mapper.Map<List<CompanyDto>>(Companies.ToList());
            ViewBag.company = new SelectList(companyDto, "Id", "Name", company);
            return View(_mapper.Map<CompanyDto>(company));
        }





    }
}
