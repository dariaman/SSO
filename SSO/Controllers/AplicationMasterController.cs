using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSO.Data;
using SSO.Models;
using SSO.ViewModels;

namespace SSO.Controllers
{
    public class AplicationMasterController : Controller
    {
        private readonly UserDbContext _context;

        public AplicationMasterController(UserDbContext context)
        {
            _context = context;
        }

        // GET: AplicationMaster
        public async Task<IActionResult> Index()
        {
            return View(await _context.AplicationMasterModel.ToListAsync());
        }

        // GET: AplicationMaster/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var aplicationMasterModel = await _context.AplicationMasterModel
        //        .FirstOrDefaultAsync(m => m.id == id);
        //    if (aplicationMasterModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(aplicationMasterModel);
        //}

        // GET: AplicationMaster/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AplicationMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Ket")] AplicationCreateVM AplicationVM)
        {
            if (ModelState.IsValid)
            {
                AplicationMasterModel AppModel = new AplicationMasterModel();
                AppModel.Name = AplicationVM.Name;
                AppModel.Ket = AplicationVM.Ket;
                AppModel.CreateBy = User.Identity.Name;
                //AppModel.CreateDate = DateTime.Now;
                //AppModel.IsActive = true;

                _context.Add(AppModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(AplicationVM);
        }

        // GET: AplicationMaster/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicationMasterModel = await _context.AplicationMasterModel.FindAsync(id);
            if (aplicationMasterModel == null)
            {
                return NotFound();
            }
            return View(aplicationMasterModel);
        }

        // POST: AplicationMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int? id, [Bind("id,Name,Ket,IsActive,CreateDate,CreateBy,UpdateDate,UpdateBy")] AplicationMasterModel aplicationMasterModel)
        //{
        //    if (id != aplicationMasterModel.id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(aplicationMasterModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AplicationMasterModelExists(aplicationMasterModel.id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(aplicationMasterModel);
        //}

        
        private bool AplicationMasterModelExists(int? id)
        {
            return _context.AplicationMasterModel.Any(e => e.id == id);
        }
    }
}
