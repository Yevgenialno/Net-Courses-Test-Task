using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestTask.Data;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class FolderController : Controller
    {
        private readonly ILogger<FolderController> _logger;

        private readonly ApplicationContext _context;

        public FolderController(ILogger<FolderController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            Folder? currentFolder = _context.Folders.SingleOrDefault(f => f.Id == id);
            //TempData["FolderId"] = _context.Folders.SingleOrDefault(f => f.Id == id)?.FolderId;
            TempData["FolderId"] = currentFolder?.FolderId;
            TempData["CurrentFolder"] = currentFolder?.Name;
            List<Folder>? folders = _context.Folders.Where(f => f.FolderId == id).ToList();
            return View(folders);
        }

        [HttpPost]
        public void UploadDirectory(Folder folder)
        {
            _context.Folders.Add(folder);
            Console.WriteLine($"{folder.Id} {folder.Name} {folder.FolderId}");
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteDirectories()
        {
            _context.Database.ExecuteSqlRaw("TRUNCATE TABLE Folders");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}