using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovTaskManagement.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentService(IDepartmentRepository DepartmentRepository , IUnitOfWork UnitOfWork) 
        { 
          _repository = DepartmentRepository;
            _unitOfWork = UnitOfWork;
        }

        public Task<DepartmentEntity?> GetDepartmentByTaskId(int taskId)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentEntity?> GetDepartmentByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
