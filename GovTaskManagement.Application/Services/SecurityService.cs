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
                DetectedPatterns = dto.Snapshot.DetectedPatterns,
                PasteCount = dto.Snapshot.PasteCount,
                SuspiciousPasteDetected = dto.Snapshot.SuspiciousPasteDetected,
                DevToolsShortcutCount = dto.Snapshot.DevToolsShortcutCount,
                AbnormalInputDetected = dto.Snapshot.AbnormalInputDetected,
                DevToolsDetected = dto.Snapshot.DevToolsDetected,
                UnauthorizedAttempts = dto.Snapshot.UnauthorizedAttempts
            };

            await _unitOfWork.BehaviorRepository.CreateAsync(snapshot);
            await _unitOfWork.SaveChangesAsync();

            var alertTimestamp = DateTime.TryParse(dto.Timestamp, null,
                System.Globalization.DateTimeStyles.RoundtripKind, out var parsed)
                ? parsed
                : DateTime.UtcNow;

            var alert = new SecurityAlert
            {
                Type = dto.Type,
                Severity = dto.Severity,
                Url = dto.Url,
                Timestamp = alertTimestamp,
                BehaviorWindowId = snapshot.Id,
                Snapshot = snapshot,
                UserId = dto.UserId
            };

            await _unitOfWork.SecurityAlertRepository.CreateAsync(alert);
            await _unitOfWork.SaveChangesAsync();

            // Send Email to Admin — wrapped so a failed email never blocks the 200 response
            try
            {
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
            catch (Exception ex)
            {
                // Email failure must not surface as 500 — alert is already saved to DB
                Console.WriteLine($"[SecurityService] Email notification failed: {ex.Message}");
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
