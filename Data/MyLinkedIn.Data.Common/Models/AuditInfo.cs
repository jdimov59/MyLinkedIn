using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedIn.Data.Common.Models
{
    public abstract class AuditInfo : IAuditInfo
    {
        public DateTime CreatedOn { get; set; }

        ///<summary>
        ///Opredelq dali propyrtito CreatedOn trqbva da se setva awtomatichno
        ///</summary>

        [NotMapped]
        public bool PreserveCreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
