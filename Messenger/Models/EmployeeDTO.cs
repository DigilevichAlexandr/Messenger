using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Models
{
    public class EmployeeDTO
    {
        public FullNameDTO FullName { get; set; }
        public string Position { get; set; }
        public WorkingPlaceDTO WorkingPlace { get; set; }
    }

    public class FullNameDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }

    public class WorkingPlaceDTO
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
    }
}
