using API.CommonAPI;
using API.SchoolAPI.Add;
using API.SchoolAPI.Get;
using API.SchoolAPI.GetAll;
using API.SchoolAPI.Remove;
using API.SchoolAPI.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.SchoolAPI;

public class SchoolController : ApiController
{
    private readonly ISender _sender;

    public SchoolController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet(APIRoutes.School.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllSchoolRequest request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request.AsQuery(), cancellationToken);
        
        if(result.IsFailure)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet(APIRoutes.School.Get)]
    public async Task<IActionResult> Get([FromQuery] GetSchoolRequest request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request.AsQuery(), cancellationToken);
        
        if(result.IsFailure)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost(APIRoutes.School.Add)]
    public async Task<IActionResult> Add(AddSchoolRequest request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request.AsCommand(), cancellationToken);

        if(result.IsFailure)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPut(APIRoutes.School.Update)]
    public async Task<IActionResult> Update([FromQuery] Guid id, UpdateSchoolRequest request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request.AsCommand(id), cancellationToken);

        if(result.IsFailure)
            return BadRequest(result);

        return Ok(result);
    }
    
    [HttpDelete(APIRoutes.School.Remove)]
    public async Task<IActionResult> Remove([FromQuery] RemoveSchoolRequest request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(request.AsCommand(), cancellationToken);

        if(result.IsFailure)
            return BadRequest(result);

        return Ok(result);
    }
}