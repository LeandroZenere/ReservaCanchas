﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Web.Models;
using Web.Repos;

namespace Web.Controllers
{
    public class ListaPrecioController : Controller
    {
        private readonly ReservaCanchaContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ListaPrecioController(ReservaCanchaContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: ListaPrecio
        public async Task<IActionResult> Index()
        {
            return _context.ListaPrecio != null ?
                        View(await _context.ListaPrecio.ToListAsync()) :
                        Problem("Entity set 'ReservaCanchaContext.ListaPrecio'  is null.");
        }

        // GET: ListaPrecio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ListaPrecio == null)
            {
                return NotFound();
            }

            var listaPrecio = await _context.ListaPrecio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listaPrecio == null)
            {
                return NotFound();
            }

            return View(listaPrecio);
        }

        // GET: ListaPrecio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListaPrecio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Disponible,Precio")] ListaPrecio listaPrecio)
        {

            if (ModelState.IsValid)
            {
                _context.Add(listaPrecio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listaPrecio);
        }

        // GET: ListaPrecio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ListaPrecio == null)
            {
                return NotFound();
            }

            var listaPrecio = await _context.ListaPrecio.FindAsync(id);
            if (listaPrecio == null)
            {
                return NotFound();
            }
            return View(listaPrecio);
        }

        // POST: ListaPrecio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Disponible,Precio")] ListaPrecio listaPrecio)
        {
            if (id != listaPrecio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listaPrecio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaPrecioExists(listaPrecio.Id))
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
            return View(listaPrecio);
        }

        // GET: ListaPrecio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ListaPrecio == null)
            {
                return NotFound();
            }

            var listaPrecio = await _context.ListaPrecio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listaPrecio == null)
            {
                return NotFound();
            }

            return View(listaPrecio);
        }

        // POST: ListaPrecio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ListaPrecio == null)
            {
                return Problem("Entity set 'ReservaCanchaContext.ListaPrecio'  is null.");
            }
            var listaPrecio = await _context.ListaPrecio.FindAsync(id);
            if (listaPrecio != null)
            {
                _context.ListaPrecio.Remove(listaPrecio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListaPrecioExists(int id)
        {
            return (_context.ListaPrecio?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult ImportarListaPrecio()
        {

            return View();
        }

        [HttpPost, ActionName("MostrarDatos")]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            if (ArchivoExcel != null)
            {
                Stream stream = ArchivoExcel.OpenReadStream();

                IWorkbook MiExcel = null;

                if (Path.GetExtension(ArchivoExcel.FileName) == ".xlsx")
                {
                    MiExcel = new XSSFWorkbook(stream);
                }
                else
                {
                    MiExcel = new HSSFWorkbook(stream);
                }

                ISheet HojaExcel = MiExcel.GetSheetAt(0);

                int cantidadFilas = HojaExcel.LastRowNum;

                List<ListaPrecio> lista = new List<ListaPrecio>();

                for (int i = 1; i <= cantidadFilas; i++)
                {

                    IRow fila = HojaExcel.GetRow(i);

                    lista.Add(new ListaPrecio
                    {
                        Disponible = fila.GetCell(0).ToString(),
                        Precio = Decimal.Parse(fila.GetCell(1).ToString()),
                    });
                }

                return StatusCode(StatusCodes.Status200OK, lista);
            }
            else
            {

                return View();
            }

        }

        [HttpPost, ActionName("EnviarDatos")]
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
        {
            if (ArchivoExcel != null)
            {
                Stream stream = ArchivoExcel.OpenReadStream();

                IWorkbook MiExcel = null;

                if (Path.GetExtension(ArchivoExcel.FileName) == ".xlsx")
                {
                    MiExcel = new XSSFWorkbook(stream);
                }
                else
                {
                    MiExcel = new HSSFWorkbook(stream);
                }

                ISheet HojaExcel = MiExcel.GetSheetAt(0);

                int cantidadFilas = HojaExcel.LastRowNum;
                List<ListaPrecio> lista = new List<ListaPrecio>();

                for (int i = 1; i <= cantidadFilas; i++)
                {

                    IRow fila = HojaExcel.GetRow(i);

                    lista.Add(new ListaPrecio
                    {
                        Disponible = fila.GetCell(0).ToString(),
                        Precio = Decimal.Parse(fila.GetCell(1).ToString()),

                    });
                }

                _context.BulkInsert(lista);

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            else
            {
                return View();
            }

        }

        public IActionResult DownloadFile()
        {
            var filepath = Path.Combine(_webHostEnvironment.WebRootPath, "archivos", "ListaDePrecios.xlsx");
            return File(System.IO.File.ReadAllBytes(filepath), "application/vnd.ms-excel", System.IO.Path.GetFileName(filepath));
        }

    }

}
