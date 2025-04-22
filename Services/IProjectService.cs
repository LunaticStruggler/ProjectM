using ProjectManagementApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagementApp.Services
{
    public interface IProjectService
    {
        Task<List<Project>> GetProjectsAsync(string userId);
        Task<Project?> GetProjectByIdAsync(int id, string userId);
        Task AddProjectAsync(Project project, string userId);
        Task UpdateProjectAsync(Project project, string userId);
        Task DeleteProjectAsync(int id, string userId);
    }
}