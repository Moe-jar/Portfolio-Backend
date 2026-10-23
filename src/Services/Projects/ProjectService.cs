using System.Linq;
using System.Collections.Generic;
using learningIntergration.Contracts.Projects;

namespace learningIntergration.Services.Projects
{
    public sealed class ProjectService : IProjectService
    {
        private static readonly ProjectCardResponse[] Projects = new[]
        {
            new ProjectCardResponse(
                1,
                "DVLD Management System",
                "Desktop",
                "A desktop application for managing driving license services.",
                new[] { "C#", ".NET", "SQL Server", "WinForms" },
                "https://github.com/example/dvld",
                null,
                "https://res.cloudinary.com/zkyjhwrd/image/upload/f_auto,q_auto/Screenshot_2025-05-16_010458"
            ),
            new ProjectCardResponse(
                2,
                "Project Showcase API",
                "Full-Stack",
                "A REST API for displaying software projects.",
                new[] { "ASP.NET Core", "REST API", "C#", "SQL Server" },
                "https://github.com/example/project-showcase",
                null,
                "https://example.com/project-showcase.jpg"
            ),
            new ProjectCardResponse(
                3,
                "Task Manager",
                "Mobile",
                "A simple application for organizing daily tasks.",
                new[] { "JavaScript", "HTML", "CSS" },
                null,
                null,
                "https://example.com/task-manager.jpg"
            ),
            new ProjectCardResponse(
                4,
                "Inventory Management System",
                "Desktop",
                "A system for managing products, stock quantities, and inventory operations.",
                new[] { "C#", ".NET", "SQL Server", "Entity Framework Core" },
                null,
                null,
                "https://example.com/inventory.jpg"
            ),
            new ProjectCardResponse(
                5,
                "Personal Portfolio",
                "Web",
                "A responsive portfolio website for showcasing projects and technical skills.",
                new[] { "JavaScript", "HTML", "CSS", "REST API" },
                null,
                "https://example.com",
                "https://example.com/portfolio.jpg"
            )
        };

        private static readonly ProjectDetailsResponse[] ProjectDetails = new[]
        {
            new ProjectDetailsResponse(
                1,
                "DVLD Management System",
                "Desktop",
                "A desktop application for managing driving license services. Features include user management, application processing, and reporting.",
                new[] { "C#", ".NET", "SQL Server", "WinForms" },
                "https://github.com/example/dvld",
                "https://example.com/dvld-live",
                new[]
                {
                    "https://example.com/dvld-1.jpg",
                    "https://example.com/dvld-2.jpg"
                }
            ),
            new ProjectDetailsResponse(
                2,
                "Project Showcase API",
                "Full-Stack",
                "REST API that exposes project metadata with paging, filtering and OpenAPI documentation. Includes sample frontend integration.",
                new[] { "ASP.NET Core", "REST API", "C#", "SQL Server" },
                "https://github.com/example/project-showcase",
                null,
                new[]
                {
                    "https://example.com/project-showcase-1.jpg"
                }
            ),
            new ProjectDetailsResponse(
                3,
                "Task Manager",
                "Mobile",
                "Cross-platform mobile app for creating and organizing tasks with local storage and optional sync.",
                new[] { "JavaScript", "HTML", "CSS" },
                null,
                "https://example.com/task-manager-live",
                new[]
                {
                    "https://example.com/task-manager-1.jpg",
                    "https://example.com/task-manager-2.jpg"
                }
            ),
            new ProjectDetailsResponse(
                4,
                "Inventory Management System",
                "Desktop",
                "Inventory system with product management, stock adjustments, and reporting dashboards.",
                new[] { "C#", ".NET", "SQL Server", "Entity Framework Core" },
                null,
                null,
                new[]
                {
                    "https://example.com/inventory-1.jpg"
                }
            ),
            new ProjectDetailsResponse(
                5,
                "Personal Portfolio",
                "Web",
                "A responsive portfolio site demonstrating projects, blog posts and contact information.",
                new[] { "JavaScript", "HTML", "CSS", "REST API" },
                null,
                "https://example.com",
                new[]
                {
                    "https://example.com/portfolio-1.jpg",
                    "https://example.com/portfolio-2.jpg"
                }
            )
        };

        public IReadOnlyList<ProjectCardResponse> GetAll()
        {
            return Projects;
        }

        public ProjectDetailsResponse? GetById(int id)
        {
            // Try to use the pre-defined details first
            var details = ProjectDetails.FirstOrDefault(d => d.Id == id);
            if (details is not null)
                return details;

            // Fallback: construct details from card data
            var card = Projects.FirstOrDefault(p => p.Id == id);
            if (card is null)
                return null;

            return new ProjectDetailsResponse(
                card.Id,
                card.Title,
                card.Category,
                card.Description,
                card.Technologies,
                card.RepositoryUrl,
                card.LiveDemoUrl,
                new string[] { } // no images available
            );
        }
    }
}