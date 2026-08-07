using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SetRole
    {
        
            public int AdminCommiteeId { get; set; }
            public int RecipientId { get; set; }
            public byte RecipientRole { get; set; } // Matches tinyint
            public string Report { get; set; }

    
        
    }
}
