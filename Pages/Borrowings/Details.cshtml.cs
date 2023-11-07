﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Popa_Sebastian_Ioan_Lab2.Data;
using Popa_Sebastian_Ioan_Lab2.Models;

namespace Popa_Sebastian_Ioan_Lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Popa_Sebastian_Ioan_Lab2.Data.Popa_Sebastian_Ioan_Lab2Context _context;

        public DetailsModel(Popa_Sebastian_Ioan_Lab2.Data.Popa_Sebastian_Ioan_Lab2Context context)
        {
            _context = context;
        }

      public Borrowing Borrowing { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Borrowing == null)
            {
                return NotFound();
            }



            var borrowing = await _context.Borrowing.FirstOrDefaultAsync(m => m.ID == id);
            if (borrowing == null)
            {
                return NotFound();
            }
            else 
            {
                Borrowing = borrowing;
            }
            borrowing = await _context.Borrowing
           .Include(b => b.Book)
           .Include(b => b.Member)
           .AsNoTracking()
           .FirstOrDefaultAsync(m => m.ID == id);

            var bookList = _context.Member.Select(x => new
            {
                x.ID,
                FullName = x.FirstName + " " + x.LastName
            });

            ViewData["BookID"] = new SelectList(_context.Book, "ID", "Title");
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");

            return Page();
        }
    }
}