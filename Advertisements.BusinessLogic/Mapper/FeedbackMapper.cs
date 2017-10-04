using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertisements.DataAccess.Entities;
using Advertisements.DTO.Models;
namespace Advertisements.BusinessLogic.Mapper
{
    public class FeedBackMapper : BaseMapper
    {
        protected override IDTO GetDTO(IEntity input)
        {
            var entity = input as Feedback;

            return new FeedbackDTO
            {
                Username = entity.ApplicationUser.UserName,
                Id = entity.Id,
                Text = entity.Text,
                AgreeCount = entity.AgreeCount,
                DisagreeCount = entity.DisagreeCount,
                CreationTime = entity.CreationTime,
                AdvertisementId = entity.AdvertisementId,
                UserId = entity.ApplicationUserId,
                RowVersion = entity.RowVersion.Select(x => (int)x).ToArray()
            };
        }

        protected override IEntity GetEntity(IDTO dto)
        {
            var feedbackDTO = dto as FeedbackDTO;

            return new Feedback
            {
                Id = feedbackDTO.Id,
                Text = feedbackDTO.Text,
                AgreeCount = feedbackDTO.AgreeCount,
                DisagreeCount = feedbackDTO.DisagreeCount,
                AdvertisementId = feedbackDTO.AdvertisementId,
                CreationTime = feedbackDTO.CreationTime,
                ApplicationUserId = feedbackDTO.UserId
            };
        }
    }
}
