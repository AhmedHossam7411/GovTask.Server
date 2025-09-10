using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using GovTaskManagement.Application.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace GovernmentTaskManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet("AllDocuments")]
        public async Task<ActionResult<IEnumerable<DocumentDto>>> GetDocuments()
        {
            return Ok(await _documentService.GetAllDocuments());
        }

        [HttpGet("by-Id")]
        public async Task<ActionResult<DocumentDto>> GetDocumentById(int documentId)
        {
            var document = await _documentService.GetDocumentById(documentId);

            if (document is null)
            {
                return NotFound();
            }

            return Ok(document);
        }

        [HttpGet("by-Task")]
        public async Task<ActionResult<DocumentDto>> GetDocumentByTaskId(int documentId)
        {
            var documents = await _documentService.GetDocumentsByTaskId(documentId);
            return Ok(documents);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocument(int id, DocumentDto DocumentDto)
        {
            if (id != DocumentDto.Id)
            {
                return BadRequest();
            }
            
            var updatedDocument = await _documentService.UpdateDocument(DocumentDto);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<DocumentDto>> PostDocument(DocumentDto DocumentDto)
        {
            var document = await _documentService.CreateDocument(DocumentDto);
            return Ok(document);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteDocumentDto(int documentId)
        {
            var document = await _documentService.DeleteDocument(documentId);
            if (document == false)
            {
                return NotFound();
            }
            return Ok();
        }

      
    }
}
