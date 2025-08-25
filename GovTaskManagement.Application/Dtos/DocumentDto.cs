using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Application.Dtos
{
    public record DocumentDto(
        int Id,
        string Name,
        string Description,
        DateTime UploadDate,
        int TaskId
    );
}
