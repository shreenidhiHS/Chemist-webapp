using BulkuBook.DataAccess.Repository.IRepository;
using Chemist.Models;
using Chemist.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chemist.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ChemTypeController: Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChemTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<ChemType> objChemTypeList = _unitOfWork.ChemType.GetAll();
            return View(objChemTypeList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //PSOT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ChemType obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.ChemType.Add(obj);
                _unitOfWork.save();
                TempData["success"] = "CoverType created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.categories.Find(id);
            var ChemTypeFromDbFirst = _unitOfWork.ChemType.GetFirstOrDefault(u => u.Id == id);
            if (ChemTypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(ChemTypeFromDbFirst);
        }
        //PSOT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ChemType obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.ChemType.Update(obj);
                _unitOfWork.save();
                TempData["success"] = "CoverType updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.categories.Find(id);
            var ChemTypeFromDbFirst = _unitOfWork.ChemType.GetFirstOrDefault(u => u.Id == id);
            if (ChemTypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(ChemTypeFromDbFirst);
        }
        //PSOT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.ChemType.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.ChemType.Remove(obj);
            _unitOfWork.save();
            TempData["success"] = "CoverType Deleted successfully";
            return RedirectToAction("Index");


        }

    }
}
