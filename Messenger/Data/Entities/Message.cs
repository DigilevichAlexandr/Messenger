using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Data.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Employee Employee { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
