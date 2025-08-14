using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Domain.Entities
{
    public class DepartmentEntity
    {
        public int departmentId { get; set; }
        public string departmentName { get; set; }

        ApiUser ApiUser { get; set; }  // Navigation property to User associated with the department
        List<ApiUser> ApiUsers { get; set; }  // Navigation property to Users associated with the department

        public DocumentEntity DocumentEntity { get; set; }
        public List<DocumentEntity> Documents { get; set; }

    }
}
