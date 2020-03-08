using CleanArchitecture.Core.SharedKernel;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Entities
{
    public class Guestbook : BaseEntity
    {
        public List<GuestbookEntry> Entries { get; } = new List<GuestbookEntry>();

        public string Name { get; set; }
    }
}
