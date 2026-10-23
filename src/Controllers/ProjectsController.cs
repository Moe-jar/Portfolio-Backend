using learningIntergration.Contracts.Projects;
using learningIntergration.Services.Projects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learningIntergration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet] 
        public ActionResult<IReadOnlyList<ProjectCardResponse>> GetAll()
        {
            var projects = _projectService.GetAll();

            return Ok(projects);
        }
        [HttpGet("{id}")]
        public ActionResult<ProjectDetailsResponse> GetById(int id)
        {
            var project = _projectService.GetById(id);

            if (project is null)
                return NotFound();

            return Ok(project);
        }
    }
}
