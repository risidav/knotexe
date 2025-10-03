using KnotExe.Data;
using KnotExe.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KnotExe.Controllers
{
    public class TimelineController : Controller
    {
        private readonly AppDbContext _context;
        public TimelineController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var posts = _context.tblPost
            //.Include(p => p.Usuario)
            //.Select(x => new Post
            //{
            //    idPost = x.idPost,
            //    PosTexto = x.PosTexto,
            //    PosData = x.PosData,
            //    PosMedia = x.PosMedia,
            //    PosidUsuario = x.PosidUsuario,
            //    PosTipo = x.PosTipo,
            //})
            //.ToList();

            var posts = _context.tblPost
            .Include(p => p.Usuario).ToList();

            //var appDbContext = _context.tblPost.Include(p => p.Usuario);
            //return View(await appDbContext.ToListAsync());


            var jogos = new List<Jogo>
            {
            };

            var viewModel = new Timeline
            {
                Posts = posts,
                Jogos = jogos
            };

            return View(viewModel);
        }
    }
}
