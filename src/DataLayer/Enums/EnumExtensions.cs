using System.ComponentModel.DataAnnotations;

namespace CRM.NexPolicy.src.DataLayer.Enums
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            return value
                .GetType()
                .GetMember(value.ToString())
                .First()
                .GetCustomAttributes(false)
                .OfType<DisplayAttribute>()
                .FirstOrDefault()
                ?.Name ?? value.ToString();
        }

        public enum LeadSource
        {
            [Display(Name = "Unknown")]
            Unknown = 0,

            [Display(Name = "Website")]
            Website = 1,

            [Display(Name = "Referral")]
            Referral = 2,

            [Display(Name = "Social Media")]
            SocialMedia = 3,

            [Display(Name = "Email Campaign")]
            EmailCampaign = 4,

            [Display(Name = "Phone Call")]
            PhoneCall = 5,

            [Display(Name = "Walk-In")]
            WalkIn = 6,

            [Display(Name = "Agent Generated")]
            AgentGenerated = 7,

            [Display(Name = "Event")]
            Event = 8,

            [Display(Name = "Advertisement")]
            Advertisement = 9,

            [Display(Name = "Marketplace")]
            Marketplace = 10,

            [Display(Name = "Partner")]
            Partner = 11,

            [Display(Name = "Other")]
            Other = 12,

            [Display(Name = "Word Document Form")]
            WordDocForm = 13
        }
        public enum GenderType
        {
            [Display(Name = "Unknown")]
            Unknown = 0,

            [Display(Name = "Male")]
            Male = 1,

            [Display(Name = "Female")]
            Female = 2,

            [Display(Name = "Prefer Not To Say")]
            PreferNotToSay = 3
        }
        public enum LeadStatus
        {
            [Display(Name = "New")]
            New = 0,

            [Display(Name = "Contacted")]
            Contacted = 1,

            [Display(Name = "Qualified")]
            Qualified = 2,

            [Display(Name = "Unqualified")]
            Unqualified = 3,

            [Display(Name = "In Progress")]
            InProgress = 4,

            [Display(Name = "Converted")]
            Converted = 5,

            [Display(Name = "Disqualified")]
            Disqualified = 6,

            [Display(Name = "Lost")]
            Lost = 7
        }

    }
}
