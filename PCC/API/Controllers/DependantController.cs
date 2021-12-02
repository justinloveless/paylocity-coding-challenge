using API.Interfaces;

namespace API.Controllers;

public class DependantController : BaseApiController
{
    private readonly IDependantService _dependantService;

    public DependantController(IDependantService dependantService)
    {
        _dependantService = dependantService;
    }
    
    // TODO: Get All
    // TODO: Get 1
    // TODO: Get all by employee id
    // TODO: create
    // TODO: update
    // TODO: delete
    
}