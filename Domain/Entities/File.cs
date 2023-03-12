using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class File: AuditableEntity
    {
        public string FilePath { get; set; } = null!;

        public string Name { get 
            {
                return Path.GetFileName(FilePath);
            }
        }

        public string Type { get 
            {
                return Path.GetExtension(FilePath);
            } 
        }

        public int ByteSize { get; set; }
    }
}
