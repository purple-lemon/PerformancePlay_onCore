using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformancePlay.Models
{
	[Table("GitHubResume")]
	public partial class GitHubResume
    {
        public int UserResumeId { get; set; }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Bio { get; set; }
        public string Blog { get; set; }
        public DateTime? PiplMatchedDate { get; set; }
    }
}
