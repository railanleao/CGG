using BVS.Models.Interface.IServiceBase;
using BVS.Models.Request;
using BVS.Models.Request.Atualizar;
using BVS.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace BVS.Controllers
{
    //[Authorize]
    //[ApiVersion("1.0")]
    public class CompradorController : Controller
    {
        protected readonly IServiceComprador _compradorService;
        public CompradorController(IServiceComprador compradorService) =>
                _compradorService = compradorService;
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InicioParceriaResponse>>> ObterTodos()
        {
            var compradores = await _compradorService.ObterTodosAsync();                                               
            return View(compradores);
        }
       
        [HttpGet]
        public async Task<ActionResult<CompradorResponse>> ObterPorId(Guid id)
        {
            var comprador = await _compradorService.ObterPorIdAsync(id);
            if (comprador is null)
            {
                return NotFound();
            }
            return View(comprador);
        }
        public async Task<IActionResult> Inserir()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Inserir(InsercaoCompradorRequest compradorRequest)
        {
            var comprador = InsercaoCompradorRequest.ConverterParaEntidade(compradorRequest);
            await _compradorService.AdicionarAsync(comprador);
            return RedirectToAction("ObterTodos");
            
        }
        
        public async Task<IActionResult> Atualizar(Guid id)
        {
            var comprador = await _compradorService.ObterPorIdAsync(id);
            return View(comprador);
        }
        [HttpPost]
        public async Task<ActionResult> Atualizar(AtualizarCompradorRequest atualizarComprador)
        {
            var comprador = AtualizarCompradorRequest.ConverterParaEntidade(atualizarComprador);
            await _compradorService.AtualizarAsync(comprador);
            return RedirectToAction("ObterTodos");
        }
        [HttpDelete]
        public async Task<ActionResult> Excluir(Guid id)
        {
            await _compradorService.RemoverPorIdAsync(id);
            return RedirectToAction("ObterTodos");
        }
    }
}
