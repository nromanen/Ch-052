using System;
using System.Linq;
using Advertisements.DTO.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Advertisements.DataAccess.Entities;
using Advertisements.BusinessLogic.Mapper;

namespace Advertisements.DTO.Models
{
    public class FeedbackDTO: IDTO
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int AgreeCount { get; set; }

        public int DisagreeCount { get; set; }

        public DateTime CreationTime { get; set; }

        public string UserId { get; set; }

        public int AdvertisementId { get; set; }

        public int[] RowVersion { get; set; }

        public string Username { get; set; }

        public string Avatar { get; set; }

        public string VotedUserId { get; set; }

        public bool Agree { get; set; }

        public FeedbackDTO() { }

        public FeedbackDTO(int id, string text, int agreeCount, int disagreeCount, DateTime creationTime, int advertisementId, string userId)
        {
            this.Id = id;
            this.Text = text;
            this.AgreeCount = agreeCount;
            this.DisagreeCount = disagreeCount;
            this.CreationTime = creationTime;
            this.AdvertisementId = advertisementId;
            this.UserId = userId;
        }

    }
}
