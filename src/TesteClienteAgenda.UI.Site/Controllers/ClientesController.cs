using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.EntityFrameworkCore;
using TesteClienteAgenda.Application.Interfaces;
using TesteClienteAgenda.Application.ViewModels;
using TesteClienteAgenda.Domain.Interfaces.Notifications;
using TesteClienteAgenda.Domain.Models;
using TesteClienteAgenda.Domain.Notifications;
using TesteClienteAgenda.Infra.Data.Context;

namespace TesteClienteAgenda.UI.Site.Controllers
{
    public class ClientesController : BaseController
    {
        private readonly IClienteAppService _clienteAppService;
        private readonly IAgendaAppService _agendaAppService;

        public ClientesController(INotificador notificador, IClienteAppService clienteAppService, IAgendaAppService agendaAppService) : base(notificador)
        {
            _clienteAppService = clienteAppService;
            _agendaAppService = agendaAppService;
        }

        public IActionResult Error()
        {
            var Teste = GetErros();
            return View();
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _clienteAppService.ObterTodos());
        }

        public async Task<IActionResult> ManageAgenda(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteAppService.ObterPorId(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }

            foreach (var agenda in await _agendaAppService.ObterPorCliente(id.Value))
            {
                cliente.Agendas.Add(agenda);
            }

            

            return View(cliente);
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteAppService.ObterPorId(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel cliente)
        {
            cliente.Cnpj = cliente.Cnpj.Replace(".","").Replace("/","").Replace("-","");
            if (!ModelState.IsValid)
                return View(cliente);

            var clienteResult = await _clienteAppService.Adicionar(cliente);

            if(OperacaoValida())
                return RedirectToAction(nameof(Index));

            return View(cliente);

        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteAppService.ObterPorId(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClienteViewModel cliente)
        {
            cliente.Cnpj = cliente.Cnpj.Replace(".", "").Replace("/", "").Replace("-","");
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _clienteAppService.Atualizar(cliente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await ClienteExists(cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if(OperacaoValida())
                    return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteAppService.ObterPorId(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var cliente = await _clienteAppService.ObterPorId(id);
            //if (cliente == null) return NotFound();
            
            await _clienteAppService.Remover(id);


            //if (!OperacaoValida())
             //   return View(cliente);

                TempData["Sucesso"] = "Cliente excluído com sucesso!";
            return RedirectToAction(nameof(Index));

            

        }

        private async Task<bool> ClienteExists(int id)
        {
            return await _clienteAppService.ObterPorId(id) != null;
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)_clienteAppService.Dispose();
            base.Dispose(disposing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportarArquivo(ClienteViewModel cliente, int id)
        {
            if (cliente.Arquivo != null)
            {
                cliente = await _clienteAppService.LerArquivoExcelECarregarAgendas(cliente);
                return RedirectToAction(nameof(ManageAgenda), new {id = cliente.Id});
            }


            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ClienteViewModel model)
        {
            var cnpj =  model.Cnpj?.Replace(".", "").Replace("/", "").Replace("-","");
            var statusCliente = model.StatusCliente;
            var razaoSocial = model.RazaoSocial;

            return PartialView("_ListClientes", await _clienteAppService.Filtrar(cnpj, razaoSocial, statusCliente));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageAgenda(ClienteViewModel model)
        {
            await _agendaAppService.AplicarTaxa(model.Id, model.Taxa/100);

            var cliente = await _clienteAppService.ObterPorId(model.Id);

            foreach (var agenda in await _agendaAppService.ObterPorCliente(model.Id))
            {
                cliente.Agendas.Add(agenda);
            }

            return PartialView("_ListAgenda", cliente);

        }

    }
}
