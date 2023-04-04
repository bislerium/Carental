using Carental.Domain.Common;

namespace Carental.Domain.Entities
{
    internal class File: BaseAuditableEntity
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
