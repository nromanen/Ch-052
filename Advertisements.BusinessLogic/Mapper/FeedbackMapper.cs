﻿using System.Text;
using Advertisements.DataAccess.Entities;
using Advertisements.DTO.Models;
using EmitMapper;
using EmitMapper.MappingConfiguration;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
=======
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d

namespace Advertisements.BusinessLogic.Mapper
{
    public static class FeedbackMapper
    {
        public static ObjectsMapper<FeedbackDTO, Feedback> CreateFeedback()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<FeedbackDTO, Feedback>(new DefaultMapConfig().
                ConvertUsing((FeedbackDTO source) => new Feedback
                {
                    Id = source.Id,
                    Text = source.Text,
                    AgreeCount = source.AgreeCount,
                    DisagreeCount = source.DisagreeCount,
<<<<<<< HEAD
                    CreationTime = source.CreationTime,
                    AdvertisementId = source.AdvertisementId,
=======
                    AdvertisementId = source.AdvertisementId,
                    ApplicationUserId = source.UserId,
                    CreationTime = source.CreationTime

>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
                }));

            return mapper;
        }

        public static ObjectsMapper<IEnumerable<FeedbackDTO>, IEnumerable<Feedback>> CreateListFeedback()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IEnumerable<FeedbackDTO>, IEnumerable<Feedback>>(new DefaultMapConfig().
                ConvertUsing<IEnumerable<FeedbackDTO>, IEnumerable<Feedback>>(a => a.Select(CreateFeedback().Map)));

            return mapper;
        }

        public static ObjectsMapper<Feedback, FeedbackDTO> CreateFeedbackDTO()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<Feedback, FeedbackDTO>(new DefaultMapConfig().
                ConvertUsing((Feedback source) => new FeedbackDTO
                {
                    Id = source.Id,
                    Text = source.Text,
                    AgreeCount = source.AgreeCount,
                    DisagreeCount = source.DisagreeCount,
                    CreationTime = source.CreationTime,
                    AdvertisementId = source.AdvertisementId,
<<<<<<< HEAD
                    RowVersion = source.RowVersion.Select(x => (int)x).ToArray()
=======
                    UserId = source.ApplicationUserId,
                    Username = source.ApplicationUser.UserName,
                    RowVersion = source.RowVersion.Select(x => (int)x).ToArray(),
                    //Avatar = System.Convert.ToBase64String(source.ApplicationUser.Avatar)
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
                }));

            return mapper;
        }

        public static ObjectsMapper<IEnumerable<Feedback>, IEnumerable<FeedbackDTO>> CreateListFeedbackDTO()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IEnumerable<Feedback>, IEnumerable<FeedbackDTO> >(new DefaultMapConfig().
                ConvertUsing<IEnumerable<Feedback>, IEnumerable<FeedbackDTO>>(a => a.Select(CreateFeedbackDTO().Map)));

            return mapper;
        }

    }
}
