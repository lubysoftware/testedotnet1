using System;

namespace Lubby.Domain.Root
{
    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DetachmentDate { get; set; }
    }
}
