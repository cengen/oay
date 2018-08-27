using System;

namespace OAY.Models
{
    public interface IAuditInfo
    {
        DateTime? Opprettet { get; set; }
        DateTime? Endret { get; set; }
    }
}
