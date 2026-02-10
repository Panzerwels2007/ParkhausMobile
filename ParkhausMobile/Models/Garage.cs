using System;
using System.Collections.Generic;
using System.Text;

namespace ParkhausMobile.Models;

public class Garage
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public int FreeSpaces { get; set; }
}
