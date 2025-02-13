using Revalsys.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Revalsys.Entites;

public partial class Learner
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; }

    [Required, MaxLength(15)]
    public string Mobile { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public DateTime DOB { get; set; }

    [MaxLength(10)]
    public string Gender { get; set; }

    public string ProfileImage { get; set; }

    [JsonIgnore]
    public ICollection<LearnerCourse> LearnerCourses { get; set; }
}
