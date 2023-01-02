using DefaultNamespace;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttachmentsController : Controller
{
    public AttachmentService AttachmentService;

    public AttachmentsController()
    {
        AttachmentService = new AttachmentService();
    }

    // GET: api/attchments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Attachment>>> Get()
    {
        return new ObjectResult(await AttachmentService.GetAllAsync());
    }
    // GET: api/attchments/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Attachment>> GetByID(int id)
    {
        Attachment result;
        try
        {
            result = await AttachmentService.GetByIdAsync(id);
            return Ok(result);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    // POST: api/attchments
    [HttpPost]
    public async Task<ActionResult> Add([FromBody] Attachment value)
    {
        try
        {
            await AttachmentService.AddAsync(value);

            return Ok(value);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    // PUT: api/attchments
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] Attachment value)
    {
        try
        {
            await AttachmentService.UpdateAsync(value);

            return Ok(value);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    // DELETE: api/attchments/1
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteById(int id)
    {
        try
        {
            await AttachmentService.DeleteByIdAsync(id);
            return Ok();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    
}
