﻿using System;
using System.Collections.Generic;

namespace ClientServerFinal.Models;

public partial class University
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();
}