using AutoMapper;
using IQA_RecordingApplication.Contracts;
using IQA_RecordingApplication.Data;
using IQA_RecordingApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQA_RecordingApplication.Controllers
{
    public class CustomerCodeController : Controller
    {
        private readonly ICustomerCode _repo;
        private readonly IMapper _mapper;

        public CustomerCodeController(ICustomerCode repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: CustomerCOde
        public ActionResult Index()
        {
            var customerCode = _repo.FindAll().ToList();
            var model = _mapper.Map<List<CustomerCode1>, List<DetailsCustomerCodeViewModel>>(customerCode);
            return View(model);
        }

        // GET: CustomerCOde/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExists(id))
            {
                return NotFound();
            }
            var customerCode = _repo.Find(id);
            var model = _mapper.Map<DetailsCustomerCodeViewModel>(customerCode);
            return View(model);
        }

        // GET:  CustomerCOde/Create
        public ActionResult Create(int id)
        {
            var customerViewModel = new CreateCustomerCodeViewModel();
            customerViewModel.ProductId = id;

            return View(customerViewModel);
        }
        // POST: CustomerCOde/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCustomerCodeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                }
                var customerCode = _mapper.Map<CustomerCode1>(model);
                // customerCode.CustomerCodeId = 1;
                customerCode.CreatedAt = DateTime.Now;
                customerCode.UpdatedAt = DateTime.Now;
                //customerCode.ProductId = model.ProductId

                var isSuccess = _repo.Create(customerCode);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong");
                    return View(model);
                }
                var Id = model.ProductId;
                // return RedirectToAction(nameof(Index));
                return RedirectToAction("Create", "ErrorMessage", new { ProductId = Id });
            }
            catch(Exception ex)
            {
                return View();
            }
        }


        // GET: CustomerCOde/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExists(id))
            {

                return NotFound();

            }
            var customerCode = _repo.Find(id);
            var model = _mapper.Map<CreateCustomerCodeViewModel>(customerCode);

            return View(model);
        }

        // POST: CustomerCOde/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( CreateCustomerCodeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                }
                var customerCode = _mapper.Map<CustomerCode1>(model);
                customerCode.UpdatedAt = DateTime.Now;
                var isSuccess = _repo.Update(customerCode);

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

        // GET: CustomerCOde/Delete/5
        public ActionResult Delete(int id)
        {
            var customerCode = _repo.Find(id);
            if (customerCode == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(customerCode);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: CustomerCOde/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CreateCustomerCodeViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                var customerCode = _repo.Find(id);
                if (customerCode == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(customerCode);
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
