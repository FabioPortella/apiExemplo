using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]


public class TipoCursoController: ControllerBase {
    private readonly DataContext context;

    public TipoCursoController(DataContext Context) {
        context = Context;
    }

   [HttpGet]
    public ActionResult<IEnumerable<TipoCurso>> Get(){
        try{
            return Ok(context.TipoCursos.ToList());
        }
        catch{
            return BadRequest("Erro ao obter os tipos de curso");
        }
    }

    [HttpPost]
    public ActionResult Post(TipoCurso model)
    {
        try
        {
            context.TipoCursos.Add(model);
            context.SaveChanges();
            return Ok("Tipo de curso salvo com sucesso");
        }
        catch
        {
            return BadRequest("Falha ao inserir o tipo de curso informado");
        }
    }
}

