using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCVendasApp.Data;
using MVCVendasApp.Models;

namespace MVCVendasApp.Controllers
{
    public class VendaItensController : Controller
    {
        private readonly MVCVendasAppContext _context;

        public VendaItensController(MVCVendasAppContext context)
        {
            _context = context;
        }

        // GET: VendaItens
        public async Task<IActionResult> Index()
        {
            var mVCVendasAppContext = _context.VendaItensModel.Include(v => v.Produto).Include(v => v.Venda);
            return View(await mVCVendasAppContext.ToListAsync());
        }

        // GET: VendaItens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaItensModel = await _context.VendaItensModel
                .Include(v => v.Produto)
                .Include(v => v.Venda)
                .FirstOrDefaultAsync(m => m.VendaItensId == id);
            if (vendaItensModel == null)
            {
                return NotFound();
            }

            return View(vendaItensModel);
        }

        // GET: VendaItens/Create/VendaId
        public IActionResult Create(int id)
        {
            VendaItensModel vdm = new VendaItensModel() { VendaId = id };

            ViewData["ProdutoId"] = new SelectList(_context.ProdutoModel, "Id", "Descricao");
            //ViewData["VendaId"] = new SelectList(_context.VendaModel, "VendaId", "VendaId");
            return View(vdm);
        }

        // POST: VendaItens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendaItensId,VendaId,ProdutoId,Quantidade,ValorDeVenda")] VendaItensModel vendaItensModel)
        {
            if (ModelState.IsValid)
            {
                if( ! ValidaEstoque(vendaItensModel) )
                {
                    return View(vendaItensModel);
                }

                SalvarItemVendido(vendaItensModel);

                return RedirectToAction("DetaiLs", "Venda", new { id = vendaItensModel.VendaId } );
            }
            ViewData["ProdutoId"] = new SelectList(_context.ProdutoModel, "Id", "Id", vendaItensModel.ProdutoId);
            //ViewData["VendaId"] = new SelectList(_context.VendaModel, "VendaId", "VendaId", vendaItensModel.VendaId);
            return View(vendaItensModel);
        }

        public bool ValidaEstoque(VendaItensModel model )
        {
            var produto = _context.ProdutoModel.Find(model.ProdutoId);
            if (produto == null)
                return false;

            if (produto.Estoque < model.Quantidade)
                return false;

            return true;
        }

        public void SalvarItemVendido(VendaItensModel model )
        {
            _context.Add(model);
            BaixarEstoque(model.ProdutoId, model.Quantidade);
            _context.SaveChangesAsync();
        }

        public void BaixarEstoque( int produtoId, int quantidade )
        {
            var produto = _context.ProdutoModel.Find(produtoId);
            produto.Estoque = produto.Estoque - quantidade;
            _context.Update(produto);
        }

        // GET: VendaItens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaItensModel = await _context.VendaItensModel.FindAsync(id);
            if (vendaItensModel == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.ProdutoModel, "Id", "Id", vendaItensModel.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.VendaModel, "VendaId", "VendaId", vendaItensModel.VendaId);
            return View(vendaItensModel);
        }

        // POST: VendaItens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendaItensId,VendaId,ProdutoId,Quantidade,ValorDeVenda")] VendaItensModel vendaItensModel)
        {
            if (id != vendaItensModel.VendaItensId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var anterior = _context.VendaItensModel.Find(vendaItensModel.VendaItensId);
                    var diferenca =  vendaItensModel.Quantidade - anterior.Quantidade;
                    
                    BaixarEstoque(vendaItensModel.ProdutoId, diferenca);

                    anterior.Quantidade = vendaItensModel.Quantidade;
                    anterior.ValorDeVenda = vendaItensModel.ValorDeVenda;
                    
                    _context.Update(anterior);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaItensModelExists(vendaItensModel.VendaItensId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Venda", new { id = vendaItensModel.VendaId });
            }
            ViewData["ProdutoId"] = new SelectList(_context.ProdutoModel, "Id", "Id", vendaItensModel.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.VendaModel, "VendaId", "VendaId", vendaItensModel.VendaId);
            return View(vendaItensModel);
        }

        // GET: VendaItens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendaItensModel = await _context.VendaItensModel
                .Include(v => v.Produto)
                .Include(v => v.Venda)
                .FirstOrDefaultAsync(m => m.VendaItensId == id);
            if (vendaItensModel == null)
            {
                return NotFound();
            }

            return View(vendaItensModel);
        }

        // POST: VendaItens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendaItensModel = await _context.VendaItensModel.FindAsync(id);
            BaixarEstoque(vendaItensModel.ProdutoId, -vendaItensModel.Quantidade);
            _context.VendaItensModel.Remove(vendaItensModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Venda", new { id = vendaItensModel.VendaId });
        }

        private bool VendaItensModelExists(int id)
        {
            return _context.VendaItensModel.Any(e => e.VendaItensId == id);
        }
    }
}
