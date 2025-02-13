    using Revalsys.Controllers;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Revalsys.Entites;
using System.Text.Json.Serialization;

namespace Revalsys.Entities;

    public partial class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<LearnerCourse> LearnerCourses { get; set; } = new List<LearnerCourse>();
    }

