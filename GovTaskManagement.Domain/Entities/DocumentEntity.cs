using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Domain.Entities
{
    public class DocumentEntity
    {
        public int Id { get; set; }
        public string documentName { get; set; }
        public string documentDescription { get; set; }
        public DateTime documentUploadDate { get; set; }

        // FK
        public int TaskId { get; set; }

        // Navigation
        public TaskEntity? Task { get; set; }

        public DepartmentEntity DepartmentEntity { get; set; }
        public int DepartmentId { get; set; }



    }
}
