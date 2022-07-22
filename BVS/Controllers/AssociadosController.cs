//using BVS.Attributes;
using BVS.Models.Entity.CompradorAssociado;
using BVS.Models.Entity.ContextBVS;
using BVS.Models.Interface.IServiceBase;
using BVS.Models.Request;
using BVS.Models.Request.Atualizar;
using BVS.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BVS.Controllers
{
    
    public class AssociadosController : Controller
    {
        private IServiceAssociado _serviceAssociado;
        private BVSContext _context;
        public AssociadosController(IServiceAssociado serviceAssociado, BVSContext context)
        {
            _serviceAssociado = serviceAssociado;
            _context = context;
        }
        
        //[ClaimsAuthorize(ClaimTypes.Associado, "Ler")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssociadoResponse>>> ObterTodos()
        {
            var associados = await _serviceAssociado.ObterTodosAsync();           
            return View(associados);
        }

        //[ClaimsAuthorize(ClaimTypes.Associado, "Ler")]
        [HttpGet]
        public async Task<ActionResult<AssociadoResponse>> ObterPorId(Guid id)
        {
            var associado = await _serviceAssociado.ObterPorIdAsync(id);

            if (associado is null)
                return NotFound();
            //var associadoResponse = AssociadoResponse.ConverteParaResponse(associado);
            return View(associado);
        }
        public async Task<IActionResult> Inserir()
        {
            var cp = (from comp in _context.Compradores
                      select new SelectListItem()
                 {
                     Text = comp.Nome,
                     Value = comp.CadastroId.ToString()
                 }).ToList();
            cp.Insert(0, new SelectListItem()
            {
                Text = "---Selecione uma das opções---",
                Value = string.Empty
            });
            ViewBag.selectComprador = cp;
            return View();
        }
        //[ClaimsAuthorizeAttribute(ClaimTypes.Associado, "Inserir")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Inserir(InsercaoAssociadoRequest associadoRequest)
        {
            var associado = InsercaoAssociadoRequest.ConverterParaEntidade(associadoRequest);
            await _serviceAssociado.AdicionarAsync(associado);
            
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
                Text = "---Selecione uma das opções---",
                Value = string.Empty
            });
            ViewBag.selectComprador = cp;
            var associado = await _serviceAssociado.ObterPorIdAsync(id);            
            return View(associado);
        }
      
        //[ClaimsAuthorizeAttribute(ClaimTypes.Associado, "Atualizar")]
        [HttpPost]
        public async Task<ActionResult> Atualizar(AtualizarAssociadoRequest associadoRequest)
        {
            var produto = AtualizarAssociadoRequest.ConverterParaEntidade(associadoRequest);
            await _serviceAssociado.AtualizarAsync(produto);
            return RedirectToAction("ObterTodos");
        }

        //[ClaimsAuthorizeAttribute(ClaimTypes.Associado, "Excluir")]
        
        public async Task<ActionResult> Excluir(Guid id)
        {
            await _serviceAssociado.RemoverPorIdAsync(id);
            return RedirectToAction("ObterTodos");
        }
    }
}
