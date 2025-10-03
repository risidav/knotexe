using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KnotExe.Data;
using KnotExe.Models;

namespace KnotExe.Controllers
{
    public class PostController : Controller
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult _PostComponent()
        {
            var pos = _context.tblPost.Include(c => c.Usuario).ToList();
            return View(pos);
        }

        // GET: Post
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.tblPost.Include(p => p.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Post/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.tblPost
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.idPost == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Post/Create
        public IActionResult Create()
        {
            ViewData["PosidUsuario"] = new SelectList(_context.tblUsuario, "idUsuario", "UsuNome");
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idPost,PosTexto,PosMedia,PosData,PosTipo,PosidUsuario")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PosidUsuario"] = new SelectList(_context.tblUsuario, "idUsuario", "UsuNome", post.PosidUsuario);
            return View(post);
        }

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.tblPost.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["PosidUsuario"] = new SelectList(_context.tblUsuario, "idUsuario", "UsuNome", post.PosidUsuario);
            return View(post);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idPost,PosTexto,PosMedia,PosData,PosTipo,PosidUsuario")] Post post)
        {
            if (id != post.idPost)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.idPost))
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
            ViewData["PosidUsuario"] = new SelectList(_context.tblUsuario, "idUsuario", "UsuNome", post.PosidUsuario);
            return View(post);
        }

        // GET: Post/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.tblPost
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.idPost == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.tblPost.FindAsync(id);
            if (post != null)
            {
                _context.tblPost.Remove(post);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.tblPost.Any(e => e.idPost == id);
        }
    }
}
