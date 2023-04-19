using System;
using System.Collections.Generic;

namespace HRP.Domain.Entities;

public partial class RefPlayer
{
    public int IdPlayer { get; set; }

    public int? IdEmployee { get; set; }

    public string? PSurname { get; set; }

    public string? PName { get; set; }

    public string? PMiddleName { get; set; }

    public string? ESurname { get; set; }

    public string? EName { get; set; }

    public string? EMiddleName { get; set; }

    public int? IdSubdivision { get; set; }

    public int? IdCategory { get; set; }

    public string? EmployeeIdentificationNumber { get; set; }

    public string? DomainName { get; set; }

    public virtual RefEmployee? IdEmployeeNavigation { get; set; }
}
