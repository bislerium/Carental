using Carental.Domain.Common;

namespace Carental.Domain.Entities
{
    public class File: BaseAuditableEntity
    {

        public string FilePath { get; set; } = null!;

        public string FullName
        {
            get
            {
                return Path.GetFileName(FilePath);
            }
        }
        public string Name { get 
            {
                return Path.GetFileNameWithoutExtension(FilePath);
            }
        }

        public string Extension { get 
            {
                return Path.GetExtension(FilePath);
            } 
        }

        public long ByteSize { get; set; }
    }
}
