using GovTaskManagement.Application.Dtos;
using GovTaskManagement.Application.EmailModels;
using GovTaskManagement.Application.Interfaces.Repositories;
using GovTaskManagement.Application.Interfaces.ServiceInterfaces;
using GovTaskManagement.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GovTaskManagement.Application.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public SecurityService(IUnitOfWork unitOfWork, IEmailService emailService, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task CreateAlertAsync(SecurityAlertDto dto)
        {
            var snapshot = new BehaviorWindow
            {
                SessionId = dto.Snapshot.SessionId,
                CurrentPage = dto.Snapshot.CurrentPage,
                Timestamp = dto.Snapshot.Timestamp,
                Context = dto.Snapshot.Context,
                AvgMouseSpeed = dto.Snapshot.AvgMouseSpeed,
                AvgScrollSpeed = dto.Snapshot.AvgScrollSpeed,
                ClickRate = dto.Snapshot.ClickRate,
                TypingRate = dto.Snapshot.TypingRate,
                UserAgent = dto.Snapshot.UserAgent,
                Language = dto.Snapshot.Language,
                ScreenResolution = dto.Snapshot.ScreenResolution,
                TimeZone = dto.Snapshot.TimeZone,
                Platform = dto.Snapshot.Platform,
                HardwareConcurrency = dto.Snapshot.HardwareConcurrency,
                Location = dto.Snapshot.Location,
                HackingStringDetected = dto.Snapshot.HackingStringDetected,
                DetectedPatterns = dto.Snapshot.DetectedPatterns
            };

            await _unitOfWork.BehaviorRepository.CreateAsync(snapshot);
            await _unitOfWork.SaveChangesAsync();

            var alert = new SecurityAlert
            {
                Type = dto.Type,
                Severity = dto.Severity,
                Url = dto.Url,
                Timestamp = DateTime.Parse(dto.Timestamp),
                BehaviorWindowId = snapshot.Id,
                Snapshot = snapshot,
                UserId = dto.UserId
            };

            await _unitOfWork.SecurityAlertRepository.CreateAsync(alert);
            await _unitOfWork.SaveChangesAsync();

            // Send Email to Admin
            var adminEmail = _configuration["EmailSettings:AdminEmail"];
            if (!string.IsNullOrEmpty(adminEmail))
            {
                var model = new SecurityAlertEmailModel
                {
                    Type            = dto.Type,
                    Severity        = dto.Severity,
                    UserId          = string.IsNullOrEmpty(dto.UserId)          ? "Unauthenticated" : dto.UserId,
                    UserEmail       = string.IsNullOrEmpty(dto.UserEmail)       ? "Unknown"         : dto.UserEmail,
                    DetectedPattern = string.IsNullOrEmpty(dto.DetectedPattern) ? "Unknown"         : dto.DetectedPattern,
                    Url             = dto.Url,
                    Timestamp       = dto.Timestamp,
                    Context         = snapshot.Context,
                    SessionId       = snapshot.SessionId,
                    Platform        = snapshot.Platform  ?? "Unknown",
                    UserAgent       = snapshot.UserAgent ?? "Unknown",
                    Location        = snapshot.Location  ?? "Unknown",
                };

                var subject = $"[GovTask] CRITICAL: {dto.Type} — {(string.IsNullOrEmpty(dto.UserEmail) ? dto.UserId ?? "Unknown User" : dto.UserEmail)}";
                await _emailService.SendTemplatedEmailAsync(adminEmail, subject, "SecurityAlert", model);
            }
        }

        public async Task<IEnumerable<SecurityAlert>> GetAlertsAsync()
        {
            return await _unitOfWork.SecurityAlertRepository.GetAllWithSnapshotsAsync();
        }

        public async Task ResolveAlertAsync(int id)
        {
            var alert = await _unitOfWork.SecurityAlertRepository.GetByIdAsync(id);
            if (alert != null)
            {
                alert.IsResolved = true;
                await _unitOfWork.SecurityAlertRepository.UpdateAsync(alert);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
