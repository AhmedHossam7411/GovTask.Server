using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Application.Mappers
{
    public static class DocumentMapper
    {
        public static DocumentDto ToDto(this DocumentEntity document)
        {
            return new DocumentDto(

               document.Id,
               document.Name,
               document.Description,
               document.UploadDate,
               document.TaskId

            );
        }
        public static DocumentEntity ToEntity(this DocumentDto entity)
        {
            return new DocumentEntity()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                UploadDate = entity.UploadDate,
                
            };
        }
        public static IEnumerable<DocumentDto> ToDto(this IEnumerable<DocumentEntity> entities)
        {
            return entities.Select(e => e.ToDto());
        }
    }
}
