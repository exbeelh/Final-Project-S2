﻿using System.Text.Json.Serialization;

namespace ClientServerFinal.Models;

public partial class University
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();
}
