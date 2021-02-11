using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int FullNameId { get; set; }
        public FullName FullName { get; set; }
        public string Position { get; set; }
        public int WorkingPlaceId { get; set; }
        public WorkingPlace WorkingPlace { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}
