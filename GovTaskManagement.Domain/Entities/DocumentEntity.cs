using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Domain.Entities
{
    public class DocumentEntity
    {
        public int documentId { get; set; }
        public string documentName { get; set; }
        public string documentDescription { get; set; }
        public DateTime documentUploadDate { get; set; }



    }
}
