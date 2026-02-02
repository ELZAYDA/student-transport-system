// Infrastructure/Identity/ApplicationUser.cs
using Microsoft.AspNetCore.Identity;
using Domain.Enums;
using System;

namespace Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser  // أو IdentityUser<int> إذا أردت int كـ ID
    {
        // الخصائص الإضافية
        public string? FullName { get; set; }

        // Role لا نحتاجها هنا لأن Identity له نظام Roles مدمج
        // public UserRole Role { get; set; }

        public string? Address { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // يمكن إضافة navigation properties إذا أردت
        // لكن هذا يتطلب دمج قاعدة البيانات
    }
}