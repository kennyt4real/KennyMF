using KennyMF.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KennyMF.Entities
{
    public class Notification : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsNew { get; set; }
        public NotificationType NotificationType { get; set; }
        public string Date { get => $"{CreatedAt.DayOfWeek.ToString().ToUpper()} { CreatedAt.ToString("dd MMM yyyy")}";}

        public string Prefix
        {
            get
            {
                if (NotificationType == NotificationType.UploadSuccessful || NotificationType == NotificationType.RecordsRejected)
                    return Title.Split(' ')[0];
                return string.Empty;
            }
        }

        
        public string Suffix
        {
            get
            {
                if (NotificationType == NotificationType.UploadSuccessful || NotificationType == NotificationType.RecordsRejected)
                    return Title.Split(' ')[1];
                return string.Empty;
            }
        }
    }
}
