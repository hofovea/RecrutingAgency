using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Base;

namespace DAL.Repositories
{
    public class JobPostingRepository : BaseRepository<JobPosting, int>
    {
        public JobPostingRepository(Context context) : base(context)
        {
        }
    }
}
