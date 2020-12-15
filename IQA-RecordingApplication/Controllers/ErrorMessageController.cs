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
    public class ErrorMessageController : Controller
    {
        private readonly IErrorMessage _repo;
        private readonly IMapper _mapper;
        public ErrorMessageController(IErrorMessage repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }

        // GET: ErrorMessageController
        public ActionResult Index()
        {
            var productValue = _repo.FindAll().ToList();
            var model = _mapper.Map<List<ErrorMessage>, List<CreateErrorMessageViewModel>>(productValue);
            return View(model);
        }

        // GET: ErrorMessageController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExists(id))
            {
                return NotFound();
            }
            var errorMessage = _repo.Find(id);
            var model = _mapper.Map<CreateErrorMessageViewModel>(errorMessage);
            return View(model);
        }

        // GET: ErrorMessageController/Create
        public ActionResult Create(int ProductId)
        {
         //   ProductId = 2;

            var viewModel = new CreateErrorMessageViewModel();
            var checkBoxList = new List<ErrorMessageCheckBox>();

            viewModel.ProductId = ProductId;
            var erroViewModel = _repo.GetErrorMessage(viewModel.ProductId);
            foreach (var item in erroViewModel)
            {
                checkBoxList.Add(new ErrorMessageCheckBox()
                {
                    ErrorMessageId = item.ErrorMessageId,
                    IsChecked = false,
                    Text = item.Message,
                });

            }

            viewModel.ErrorMessageCheckBoxes = checkBoxList;

            return View(viewModel);
        }

        // POST: ErrorMessageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateErrorMessageViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                }

                var errorMessge = _mapper.Map<ErrorMessage>(model);
                
                
                if (model.ErrorMessageCheckBoxes != null )
                {
                    var emc = model.ErrorMessageCheckBoxes.Where(q => q.IsChecked == true);
                    int count = 0;
                    foreach (var item in emc)
                    {
                        count++;
                        _repo.CreatErrorTracker(new ErrorMessageTrack()
                        {
                          //  ErrorMessageTrackId = count,
                            ErrorMessageId = item.ErrorMessageId,
                            ProductId = model.ProductId,
                        });
                    }
                }

                var isSuccess = false;

                if (errorMessge.Message != string.Empty || errorMessge.Message != null) {

                    // errorMessge.ErrorMessageId = 100;
                    isSuccess = _repo.Create(errorMessge);
                    var errorMessageId = _repo.FindLatestId();

                    _repo.CreatErrorTracker(new ErrorMessageTrack()
                    {
                       // ErrorMessageTrackId = 111,
                        ErrorMessageId = errorMessageId,
                        ProductId = model.ProductId,
                    });
                }
               
               
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong");
                    return View(model);
                }
                // return RedirectToAction(nameof(Index));
                return RedirectToAction("Create", "ErrorMessage", new { ProductId = model.ProductId });

            }
            catch (Exception ex)
            {


                return View();
            }
        }

        // GET: ErrorMessageController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExists(id))
            {

                return NotFound();

            }
            var errorMessage = _repo.Find(id);
            var model = _mapper.Map<CreateErrorMessageViewModel>(errorMessage);

            return View(model);
        }

        // POST: ErrorMessageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateErrorMessageViewModel model)
        {

            try
            {
                if (!ModelState.IsValid)
                {

                    return View(model);
                }
                var product = _mapper.Map<ErrorMessage>(model);

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

        // GET: ErrorMessageController/Delete/5
        public ActionResult Delete(int id)
        {
            var errorMessage = _repo.Find(id);
            if (errorMessage == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(errorMessage);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ErrorMessageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, CreateErrorMessageViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                var errorMessage = _repo.Find(Id);
                if (errorMessage == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(errorMessage);
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
