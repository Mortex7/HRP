using System;
using System.Collections.Generic;

namespace HRP.Domain.Entities;

public partial class RefProject
{
    public int IdProject { get; set; }

    public string ProjectName { get; set; } = null!;

    public string ProjectDescription { get; set; } = null!;

    public virtual ICollection<AppEmployeeInProject> AppEmployeeInProjects { get; set; } = new List<AppEmployeeInProject>();
}
