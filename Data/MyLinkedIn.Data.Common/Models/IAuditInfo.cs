using System;

namespace MyLinkedIn.Data.Common.Models
{
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }
        bool PreserveCreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }

}