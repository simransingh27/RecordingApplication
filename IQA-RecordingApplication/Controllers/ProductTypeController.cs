using AutoMapper;
using IQA_RecordingApplication.Contracts;
using IQA_RecordingApplication.Data;
using IQA_RecordingApplication.Models;
using IQA_RecordingApplication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQA_RecordingApplication.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly IProductType _repo;
        private readonly IMapper _mapper;
        private readonly IErrorMessageTracker _repo1;
        private readonly ApplicationDbContext _db;



        public ProductTypeController(IProductType repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: ProductTypeController
        public ActionResult Index()
        {
            var productTypeValue = _repo.FindAll().ToList();
            var model = _mapper.Map<List<ProductType>, List<ProductTypeViewModel>>(productTypeValue);
            return View(model);
          
        }

        // GET: ProductTypeController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExists(id))
            {
                return NotFound();
            }
            var productType = _repo.Find(id);
            var model = _mapper.Map<ProductTypeViewModel>(productType);
            return View(model);
        }

        // GET: ProductTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductTypeViewModel model)
        {
            
            try
            {
                var errorMessageTrack = new ErrorMessageTrackerRepository();
                if (!ModelState.IsValid)
                {

                    return View(model);
                }
                var productType = _mapper.Map<ProductType>(model);
               // productType.ProductTypeId = 2;
                productType.CreatedAt = DateTime.Now;
                productType.UpdatedAt = DateTime.Now;

             //   errorMessageTrack.ErrorMessageTrackId = 1;
                
                var isSuccess = _repo.Create(productType);
              
           //   var errorTrackCreated = 
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExists(id))
            {

                return NotFound();

            }
            var productType = _repo.Find(id);
            var model = _mapper.Map<ProductTypeViewModel>(productType);

            return View(model);
        }

        // POST: ProductTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                }
                var productType = _mapper.Map<ProductType>(model);
                productType.UpdatedAt = DateTime.Now;
                var isSuccess = _repo.Update(productType);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong");
                return View();
            }
        }

        // GET: ProductTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            var productType = _repo.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(productType);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductTypeViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                var productType = _repo.Find(id);
                if (productType == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(productType);
                if (!isSuccess)
                {
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
