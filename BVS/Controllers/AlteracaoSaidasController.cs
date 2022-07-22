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
    public class AlteracaoSaidasController : Controller
    {
        private IServiceAlteracaoSaida _saidaService;
        private BVSContext _context;

        public AlteracaoSaidasController(IServiceAlteracaoSaida saidaService, BVSContext context)
        {
            _saidaService = saidaService;
            _context = context;
        }

        //[ClaimsAuthorize(ClaimTypes.AlteracaoSaida, "Ler")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlteracaoSaidaResponse>>> ObterTodos()
        {
            var saidas = await _saidaService.ObterTodosAsync();
            
            return View(saidas);
        }
        //[ClaimsAuthorize(ClaimTypes.AlteracaoSaida, "Ler")]
        [HttpGet]
        public async Task<ActionResult<AlteracaoSaidaResponse>> ObterPorId(Guid id)
        {//AlteracaoSaidaResponse
            var saida = await _saidaService.ObterPorIdAsync(id);                        
            if (saida is null)
                return NotFound("Dados inválidos, verifique e tente novamente.");

            //var saidasResponse = AlteracaoSaidaResponse.ConverteParaResponse(saida);
            return View(saida);
        }
        public async Task<IActionResult> Inserir(Guid id)
        {
            ViewBag.selectParcerias = from iParc in _context.InicioParcerias
                                      where iParc.BoiId == id
                                      select iParc;

            var iniParceria = (from ini in _context.InicioParcerias
                      select new SelectListItem()
                      {
                          Text = ini.Lote,
                          Value = ini.BoiId.ToString()
                      }).ToList();
            iniParceria.Insert(0, new SelectListItem()
            {
                Text = "---Selecione---",
                Value = string.Empty
            });
            ViewBag.selectParceria = iniParceria;
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
        //[ClaimsAuthorizeAttribute(ClaimTypes.AlteracaoSaida, "Inserir")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Inserir(InsercaoAlteracaoSaidaRequest saidaRequest)
        {
            var saida = InsercaoAlteracaoSaidaRequest.ConverterParaEntidade(saidaRequest);
             await _saidaService.AdicionarAsync(saida);
            return RedirectToAction("ObterTodos", "InicioParcerias");
        }
        public async Task<IActionResult> Atualizar(Guid id)
        {
            ViewBag.selectParcerias = from iParc in _context.InicioParcerias
                                      where iParc.BoiId == id
                                      select iParc;

            var iniParceria = (from ini in _context.InicioParcerias
                               select new SelectListItem()
                               {
                                   Text = ini.Lote,
                                   Value = ini.BoiId.ToString()
                               }).ToList();
            iniParceria.Insert(0, new SelectListItem()
            {
                Text = "---Selecione---",
                Value = string.Empty
            });
            ViewBag.selectParceria = iniParceria;
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
            var saida = await _saidaService.ObterPorIdAsync(id);
            return View(saida);
        }
        //[ClaimsAuthorizeAttribute(ClaimTypes.AlteracaoSaida, "Atualizar")]
        [HttpPost]
        public async Task<ActionResult> Atualizar(AtualizarAlteracaoSaidaRequest saidaRequest)
        {
            var saida = AtualizarAlteracaoSaidaRequest.ConverterParaEntidade(saidaRequest);
            await _saidaService.AtualizarAsync(saida);
            return RedirectToAction("ObterTodos");
        }
        //[ClaimsAuthorizeAttribute(ClaimTypes.AlteracaoSaida, "Excluir")]
        
        public async Task<ActionResult> Excluir(Guid id)
        {
            await _saidaService.RemoverPorIdAsync(id);
            return RedirectToAction("ObterTodos");
        }
    }
}
