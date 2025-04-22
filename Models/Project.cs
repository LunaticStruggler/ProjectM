namespace ProjectManagementApp.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }

        public Project()
        {
            Name = string.Empty;
            Description = string.Empty;
            Company = string.Empty;
            Status = string.Empty;
            UserId = string.Empty;
        }
    }
}