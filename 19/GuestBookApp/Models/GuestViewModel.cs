// Models/GuestViewModel.cs
using System.Collections.Generic;
using GuestBookApp.Models;

namespace GuestBookApp.Models
{
    public class GuestViewModel
    {
        public List<GuestEntry> Entries { get; set; } = [];
        public GuestEntry NewEntry { get; set; }
    }
}