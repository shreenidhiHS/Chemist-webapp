using BulkuBook.DataAccess.Repository.IRepository;
using Chemist.Models;
using Chemist.Models.ViewModels;
using Chemist.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Chemist.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        public IActionResult Index()
        {

            return View();
        }
        //GET

        //GET
        public IActionResult Upsert(int? id)
        {
            Company company = new();
            
            if (id == null || id == 0)
            {
               
                return View(company);
            }
            else
            {
                company = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
                return View(company);
                
            }

        }
        //PSOT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company obj)
        {

            if (ModelState.IsValid)
            {
                
                
                if (obj.Id == 0)
                {
                    _unitOfWork.Company.Add(obj);
                    TempData["success"] = "Company added successfully";
                }
                else
                {
                    _unitOfWork.Company.Update(obj);
                }
                _unitOfWork.save();
                TempData["success"] = "Company Updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    //var categoryFromDb = _db.categories.Find(id);
        //    var CoverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id==id);
        //    if (CoverTypeFromDbFirst == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(CoverTypeFromDbFirst);
        //}
        //PSOT
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeletePOST(int? id)
        //{
        //    var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.CoverType.Remove(obj);
        //    _unitOfWork.save();
        //    TempData["Success"] = "CoverType Deleted successfully";
        //    return RedirectToAction("Index");


        //}




        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var companyList = _unitOfWork.Company.GetAll();
            return Json(new { data = companyList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "error while deleting" });
            }

           

            _unitOfWork.Company.Remove(obj);
            _unitOfWork.save();
            return Json(new { success = true, message = "Delete success" });
        }

        #endregion
    }
}
