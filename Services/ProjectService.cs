using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.Data;
using ProjectManagementApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagementApp.Services
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _context;

        public ProjectService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetProjectsAsync(string userId)
        {
            return await _context.Projects.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<Project?> GetProjectByIdAsync(int id, string userId)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);
        }

        public async Task AddProjectAsync(Project project, string userId)
        {
            project.UserId = userId;
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(Project project, string userId)
        {
            var existingProject = await _context.Projects.FirstOrDefaultAsync(p => p.Id == project.Id && p.UserId == userId);
            if (existingProject != null)
            {
                existingProject.Name = project.Name;
                existingProject.Description = project.Description;
                existingProject.Company = project.Company;
                existingProject.Status = project.Status;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProjectAsync(int id, string userId)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }
    }
}