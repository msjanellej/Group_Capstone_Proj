using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupCapstone.Data;
using GroupCapstone.Models;
using Geocoding;
using Geocoding.Google;

namespace GroupCapstone.Controllers
{
    public class AdminStoreInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminStoreInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminStoreInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.StoreInfo.ToListAsync());
        }

        // GET: AdminStoreInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeInfo = await _context.StoreInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storeInfo == null)
            {
                return NotFound();
            }

            return View(storeInfo);
        }

        // GET: AdminStoreInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminStoreInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StreetAddress,AddressCity,AddressState,AddressZip,StoreHours,PhoneNumber,Logo,CompanyVision,Email,Latitude,Longitude")] StoreInfo storeInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storeInfo);
                await _context.SaveChangesAsync();

                
                IGeocoder geocoder = new GoogleGeocoder() { ApiKey = APIKEYS.GOOGLE_MAP };
                IEnumerable<Geocoding.Address> addresses = await geocoder.GeocodeAsync(storeInfo.StreetAddress + " " + storeInfo.AddressCity + " " + storeInfo.AddressState + " " + storeInfo.AddressZip);
                storeInfo.Latitude = addresses.First().Coordinates.Latitude;
                storeInfo.Longitude = addresses.First().Coordinates.Longitude;
                _context.Update(storeInfo);
                await _context.SaveChangesAsync();





                return RedirectToAction(nameof(Index));
            }
            return View(storeInfo);
        }

        // GET: AdminStoreInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeInfo = await _context.StoreInfo.FindAsync(id);
            if (storeInfo == null)
            {
                return NotFound();
            }
            return View(storeInfo);
        }

        // POST: AdminStoreInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StreetAddress,AddressCity,AddressState,AddressZip,StoreHours,PhoneNumber,Logo,CompanyVision,Email,Latitude,Longitude")] StoreInfo storeInfo)
        {
            if (id != storeInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storeInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreInfoExists(storeInfo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(storeInfo);
        }

        // GET: AdminStoreInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeInfo = await _context.StoreInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storeInfo == null)
            {
                return NotFound();
            }

            return View(storeInfo);
        }

        // POST: AdminStoreInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storeInfo = await _context.StoreInfo.FindAsync(id);
            _context.StoreInfo.Remove(storeInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreInfoExists(int id)
        {
            return _context.StoreInfo.Any(e => e.Id == id);
        }
    }
}
