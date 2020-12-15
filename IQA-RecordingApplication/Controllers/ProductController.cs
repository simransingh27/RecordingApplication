using AutoMapper;
using IQA_RecordingApplication.Contracts;
using IQA_RecordingApplication.Data;
using IQA_RecordingApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQA_RecordingApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _repo;
        private readonly IMapper _mapper;
        public ProductController(IProduct repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;    
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var productValue = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Product>, List<ProductViewModel>>(productValue);
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExists(id))
            {
                return NotFound();
            }
            var product = _repo.Find(id);
            var model = _mapper.Map<ProductViewModel>(product);

            return View(model);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var model = new ProductViewModel();
            var productTypeList = _repo.FindProductTypes().ToList();
            //foreach (var item in _repo.FindProductTypes().ToList())
            //{
            //    var s = new SelectListItem();
            //    s.Text = item.ProductTypeName;
            //    s.Value = item.ProductTypeId.ToString();

            //    productTypeList.Add(s);
            //}
            model.ProductTypes = productTypeList;
            return View(model);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                }
                var product = _mapper.Map<Product>(model);
             //   product.ProductId = 2;
                product.CreatedAt = DateTime.Now;
                product.UpdatedAt = DateTime.Now;
                int productypeid = 0;
                bool validation = int.TryParse(model.ProductTypeValue, out productypeid);
                product.ProductTypeId = productypeid;
                
                var isSuccess = _repo.Create(product);
                if (!isSuccess || validation == false)
                {
                    ModelState.AddModelError("", "Something Went Wrong");
                    return View(model);
                }
                int Id = _repo.FindLatestId();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Create", "CustomerCode", new { id = Id });
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExists(id))
            {

                return NotFound();

            }
            var product = _repo.Find(id);
            var model = _mapper.Map<ProductViewModel>(product);

            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                }
                var product = _mapper.Map<Product>(model);
                product.UpdatedAt = DateTime.Now;
                var isSuccess = _repo.Update(product);

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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _repo.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(product);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, ProductViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                var product = _repo.Find(Id);
                if (product == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(product);
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
