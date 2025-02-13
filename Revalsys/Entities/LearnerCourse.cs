using Revalsys.Entities;
using System.Text.Json.Serialization;

namespace Revalsys.Entites
{
    public class LearnerCourse
    {
        public int LearnerId { get; set; }

        [JsonIgnore]
        public Learner Learner { get; set; }

        public int CourseId { get; set; }

        [JsonIgnore]
        public Course Course { get; set; }
    }
}
    