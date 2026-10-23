namespace learningIntergration.Contracts.Projects
{
    public sealed record ProjectCardResponse(
        int Id,
        string Title,
        string? Category,
        string Description,
        string[] Technologies,
        string? RepositoryUrl,
        string? LiveDemoUrl,
        string ImageUrl
    );
}
