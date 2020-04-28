using DAL.Identity;

namespace DAL.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LinkToTheProject { get; set; }
        public string DescriptionOfTasks { get; set; }
        public string UserId { get; set; }    
        public virtual User User { get; set; }
    }
}