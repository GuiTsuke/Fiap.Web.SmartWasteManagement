    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fiap.Web.SmartWasteManagement.Data.Contexts;
using Fiap.Web.SmartWasteManagement.Models;
using AutoMapper;
using Fiap.Web.SmartWasteManagement.Services;
using Fiap.Web.SmartWasteManagement.ViewModels;

namespace Fiap.Web.SmartWasteManagement.Controllers
{
    public class CaminhaoController(IMapper mapper, ICaminhaoService caminhaoService) : Controller
    {
        private readonly IMapper _mapper = mapper;

        private readonly ICaminhaoService _caminhaoService = caminhaoService;

        #region Métodos de Ação

        // GET: Caminhao
        public IActionResult Index()
        {
            IEnumerable<CaminhaoModel> caminhoes = _caminhaoService.ListarCaminhoesSemPage();
            var viewModels = _mapper.Map<IEnumerable<CaminhaoViewModel>>(caminhoes);
            return View(viewModels);
        }

        // GET: Caminhao/Create
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CaminhaoViewModel();

            return View(viewModel);
        }

        // GET: Caminhao/Details/5
        public IActionResult Details(int id)
        {

            CaminhaoModel caminhaoModel = _caminhaoService.ObterCaminhaoPorId(id)!;
            if (caminhaoModel == null)
            {
                return NotFound();
            }

            var caminhao = _mapper.Map<CaminhaoViewModel>(caminhaoModel);

            return View(caminhao);
        }



        // POST: Caminhao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CaminhaoViewModel caminhaoModel)
        {
            if (ModelState.IsValid)
            {
                var caminhao = _mapper.Map<CaminhaoModel>(caminhaoModel);

                _caminhaoService.CriarCaminhao(caminhao);                
                return RedirectToAction(nameof(Index));
            }
            return View(caminhaoModel);
        }

        // GET: Caminhao/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var caminhaoModel = _caminhaoService.ObterCaminhaoPorId(id);
            if (caminhaoModel == null)
            {
                return NotFound();
            }

            var caminhao = _mapper.Map<CaminhaoViewModel>(caminhaoModel);
            return View(caminhao);
        }

        // POST: Caminhao/Edit/5
        [HttpPost]
        public IActionResult Edit(CaminhaoViewModel caminhaoModel)
        {            
            if (ModelState.IsValid)
            {
                try
                {
                    var caminhao = _mapper.Map<CaminhaoModel>(caminhaoModel);
                    _caminhaoService.AtualizarCaminhao(caminhao);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaminhaoModelExists(caminhaoModel.Codigo))
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
            return View(caminhaoModel);
        }

        // GET: Caminhao/Delete/5
        public IActionResult Delete(int id)
        {
            var caminhaoModel = _caminhaoService.ObterCaminhaoPorId(id);
            if (caminhaoModel == null)
            {
                return NotFound();
            }

            var caminhao = _mapper.Map<CaminhaoViewModel>(caminhaoModel);

            return View(caminhao);
        }

        // POST: Caminhao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var caminhaoModel = _caminhaoService.ObterCaminhaoPorId(id);
            if (caminhaoModel != null)
            {
                _caminhaoService.DeletarCaminhao(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CaminhaoModelExists(int id)
        {
            return _caminhaoService.ListarCaminhoesSemPage().Any(e => e.Codigo == id);
        }

        #endregion
    }
}
