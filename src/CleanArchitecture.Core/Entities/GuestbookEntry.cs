using CleanArchitecture.Core.SharedKernel;
using System;

namespace CleanArchitecture.Core.Entities
{
    public class GuestbookEntry : BaseEntity
    {
        public DateTimeOffset DateTimeCreated { get; set; } = DateTimeOffset.UtcNow;

        public string EmailAddress { get; set; }

        public string Message { get; set; }
    }
}
