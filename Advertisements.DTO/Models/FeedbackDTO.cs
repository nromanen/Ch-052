﻿using System;
using System.Linq;
using Advertisements.DTO.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
=======
using Advertisements.DataAccess.Entities;
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d

namespace Advertisements.DTO.Models
{
    public class FeedbackDTO
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int AgreeCount { get; set; }

        public int DisagreeCount { get; set; }

        public DateTime CreationTime { get; set; }

<<<<<<< HEAD
        public int UserId { get; set; }
=======
        public string UserId { get; set; }
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d

        public int AdvertisementId { get; set; }

        public int[] RowVersion { get; set; }

<<<<<<< HEAD
        public FeedbackDTO() { }

        public FeedbackDTO(int id, string text, int agreeCount, int disagreeCount, DateTime creationTime, int advertisementId, int userId)
=======
        public string Username { get; set; }

        public string Avatar { get; set; }

        public string VotedUserId { get; set; }

        public bool Agree { get; set; }

        public FeedbackDTO() { }

        public FeedbackDTO(int id, string text, int agreeCount, int disagreeCount, DateTime creationTime, int advertisementId, string userId)
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
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
