using BloodDonationbd.Data;
using BloodDonationbd.DTOs;
using BloodDonationbd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace BloodDonationbd.Controllers
{
    public class Donor_InforController : Controller
    {
        private readonly AppDbContext _context;
        public Donor_InforController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var donor = _context.Tbl_Donors.ToList().OrderByDescending(x => x.Id);
            return View(donor);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DonnerDTO donor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new { success = false, message = "Error adding donor." });
                }
                var obj = new Tbl_Donor()
                {
                    Email = donor.Email,
                    Phone = donor.Phone,
                    Name = donor.Name,
                    BloodGroup=donor.BloodGroup,
                };
                _context.Tbl_Donors.Add(obj);
                await _context.SaveChangesAsync();
                return Ok(new { success = true, message = "Donor added successfully!" });
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<IActionResult> Edit(int id)
        {
            var donor = await _context.Tbl_Donors.FindAsync(id);
            return Json(donor);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Tbl_Donor donor)
        {
            if (ModelState.IsValid)
            {
                _context.Update(donor);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Donor updated successfully!" });
            }
            return Json(new { success = false, message = "Error updating donor." });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var donor = await _context.Tbl_Donors.FindAsync(id);
            if (donor != null)
            {
                _context.Tbl_Donors.Remove(donor);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Donor deleted successfully!" });
            }
            return Json(new { success = false, message = "Error deleting donor." });
        }
    }
}


