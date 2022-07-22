using BVS.Models.Entity.ContextBVS;
using BVS.Models.Entity.Parceria;
using BVS.Models.Interface.IServiceBase;
using BVS.Models.Request;
using BVS.Models.Request.Atualizar;
using BVS.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BVS.Controllers
{
    //[ApiVersion("1.0")]
    public class InicioParceriasController : Controller
    {
        private IServiceInicioParceria _parceriaService;
        private BVSContext _context;
        public InicioParceriasController(IServiceInicioParceria parceriaService, BVSContext context)
        {
            _parceriaService = parceriaService;
            _context = context;
        }

        //[ClaimsAuthorize(ClaimTypes.InicioParceria, "Ler")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InicioParceriaResponse>>> ObterTodos()
        {
            var parcerias = await _parceriaService.ObterTodosAsync();
            
            return View(parcerias);
        }
        //[ClaimsAuthorize(ClaimTypes.InicioParceria, "Ler")]
        [HttpGet]
        public async Task<ActionResult<InicioParceriaResponse>> ObterPorId(Guid id)
        {
            var parcerias = await _parceriaService.ObterPorIdAsync(id);

            if (parcerias is null)
                return NotFound();

            //var parceriasResponse = InicioParceriaResponse.ConverteParaResponse(parcerias);
            return View(parcerias);
        }
        public async Task<IActionResult> Inserir(Guid id)
        {
            var cp = (from comp in _context.Compradores
                      select new SelectListItem()
                      {
                          Text = comp.Nome,
                          Value = comp.CadastroId.ToString()
                      }).ToList();
            cp.Insert(0, new SelectListItem()
            {
                Text = "---Selecione---",
                Value = string.Empty
            });
            ViewBag.selectComprador = cp;

            var asp = (from assoc in _context.Associados
                       select new SelectListItem()
                       {
                           Text = assoc.Nome,
                           Value = assoc.CadastroId.ToString()
                       }).ToList();
            asp.Insert(0, new SelectListItem()
            {
                Text = "---Selecione---",
                Value = string.Empty
            });
            ViewBag.selectAssociado = asp;

            var classf = Enum.GetValues(typeof(Classificacao))
             .Cast<Classificacao>()
             .Select(v => new SelectListItem
             {
                 Text = v.ToString(),
                 Value = ((int)v).ToString(),
             }).ToList();
            classf.Insert(0, new SelectListItem()
            {
                Text = "---Selecionar---",
                Value = string.Empty.ToString(),
            });
            ViewData["Classificacao"] = classf;

            var compraV = Enum.GetValues(typeof(CompraVenda))
                .Cast<CompraVenda>()
                .Select(c => new SelectListItem
                {
                    Text = c.ToString(),
                    Value = ((int)c).ToString()
                }).ToList();
            compraV.Insert(0, new SelectListItem()
            {
                Text = "---Selecionar---",
                Value = string.Empty.ToString(),
            });
            ViewData["CompraVenda"] = compraV;
            
            return View();
        }
        //[ClaimsAuthorizeAttribute(ClaimTypes.InicioParceria, "Inserir")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Inserir(InsercaoInicioParceriaRequest insercaoparceria)
        {
            var parceria = InsercaoInicioParceriaRequest.ConverterParaEntidade(insercaoparceria);            
            await _parceriaService.AdicionarAsync(parceria);            
            return RedirectToAction("ObterTodos");
        }
        public async Task<IActionResult> Atualizar(Guid id)
        {
            var cp = (from comp in _context.Compradores
                      select new SelectListItem()
                      {
                          Text = comp.Nome,
                          Value = comp.CadastroId.ToString()
                      }).ToList();
            cp.Insert(0, new SelectListItem()
            {
                Text = "---Selecione---",
                Value = string.Empty
            });
            ViewBag.selectComprador = cp;
            var asp = (from assoc in _context.Associados
                       select new SelectListItem()
                       {
                           Text = assoc.Nome,
                           Value = assoc.CadastroId.ToString()
                       }).ToList();
            asp.Insert(0, new SelectListItem()
            {
                Text = "---Selecione---",
                Value = string.Empty
            });
            ViewBag.selectAssociado = asp;

            var classf = Enum.GetValues(typeof(Classificacao))
             .Cast<Classificacao>()
             .Select(v => new SelectListItem
             {
                 Text = v.ToString(),
                 Value = ((int)v).ToString(),
             }).ToList();
            classf.Insert(0, new SelectListItem()
            {
                Text = "---Selecionar---",
                Value = string.Empty.ToString(),
            });
            ViewData["Classificacao"] = classf;

            var compraV = Enum.GetValues(typeof(CompraVenda))
                .Cast<CompraVenda>()
                .Select(c => new SelectListItem
                {
                    Text = c.ToString(),
                    Value = ((int)c).ToString()
                }).ToList();
            compraV.Insert(0, new SelectListItem()
            {
                Text = "---Selecionar---",
                Value = string.Empty.ToString(),
            });
            ViewData["CompraVenda"] = compraV;

            var parceria = await _parceriaService.ObterPorIdAsync(id);
            return View(parceria);
        }
        //[ClaimsAuthorizeAttribute(ClaimTypes.InicioParceria, "Atualizar")]
        [HttpPost]
        public async Task<ActionResult> Atualizar(AtualizarInicioParceriaRequest parceriaRequest)
        {
            var parceria = AtualizarInicioParceriaRequest.ConverterParaEntidade(parceriaRequest);
            await _parceriaService.AtualizarAsync(parceria);
            return RedirectToAction("ObterTodos");
        }
        //[ClaimsAuthorizeAttribute(ClaimTypes.InicioParceria, "Excluir")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            await _parceriaService.RemoverPorIdAsync(id);
            return RedirectToAction("ObterTodos");
        }
    }
}
