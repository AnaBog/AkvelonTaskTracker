using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Akvelon.TaskTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected IMapper _mapper { get; }
    }
}