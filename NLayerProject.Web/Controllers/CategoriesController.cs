using AutoMapper;
using Microsoft.AspNetCore.Mvc;
//using NLayerProject.Core.Models;
//using NLayerProject.Core.Services;
using NLayerProject.Web.ApiService;
using NLayerProject.Web.Dto;
using NLayerProject.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.Controllers
{
    //Yorum satırında olan kodlar mvc ile haberleşme için o yüzden kapalı. Web tarafında direk api ile haberleşmek için Apiservice katmanıyla haberleşiyor.
    public class CategoriesController : Controller
    {

        //private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly CategoryApiService _categoryApiService;

        public CategoriesController( IMapper mapper, CategoryApiService categoryApiService)
        {
            
            _mapper = mapper;
            _categoryApiService = categoryApiService;

        }


        public async Task<IActionResult> Index()
        {
            //var categories = await _categoryService.GetAllAsync();
            var categories = await _categoryApiService.GetAllAsync();
             

            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            //await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            await _categoryApiService.AddAsync(categoryDto);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryApiService.GetById(id);

            return View(_mapper.Map<CategoryDto>(category));
        }


        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            //_categoryService.Update(_mapper.Map<Category>(categoryDto));

            await _categoryApiService.Update(categoryDto);

            return RedirectToAction("index");
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {

            await _categoryApiService.Remove(id);

            return RedirectToAction("index");
        }

       
    }
}
