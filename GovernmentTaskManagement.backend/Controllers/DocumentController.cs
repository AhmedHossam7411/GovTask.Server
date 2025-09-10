using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using GovTaskManagement.Domain.Entities;
using GovTaskManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentDto>>> GetDocuments()
        {
            return Ok(await _documentService.GetAllDocuments());
        }

        // GET: api/Document/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentDto>> GetDocumentById(int documentId)
        {
            var document = await _documentService.GetDocumentById(documentId);

            if (document is null)
            {
                return NotFound();
            }

            return Ok(document);
        }

        [HttpGet("by-Task/{id}")]
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

        [HttpDelete("{id}")]
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
