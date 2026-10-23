using learningIntergration.Contracts.Projects;

namespace learningIntergration.Services.Projects
{
    public interface IProjectService
    {
        IReadOnlyList<ProjectCardResponse> GetAll();
        ProjectDetailsResponse? GetById(int id);

    }
}
