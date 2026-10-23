namespace learningIntergration.Contracts.Projects
{
    public sealed record ProjectDetailsResponse(
        int Id,
        string Title,
        string? Category,
        string Description,
        string[] Technologies,
        string? RepositoryUrl,
        string? LiveDemoUrl,
        string[] ImagesUrls
    );
}
