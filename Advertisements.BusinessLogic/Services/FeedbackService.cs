﻿using System.Linq;
using Advertisements.DTO.Models;
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Entities;
using Advertisements.BusinessLogic.Mapper;
using System.Collections.Generic;
using System;

namespace Advertisements.BusinessLogic.Services
{
    public class FeedbackService : IFeedbackService<FeedbackDTO>
    {
        private readonly IUOWFactory _uowfactory;

        public FeedbackService(IUOWFactory uowfactory)
        {
            _uowfactory = uowfactory;
        }

        public void Create(FeedbackDTO item)
        {

            Feedback feedback = FeedbackMapper.CreateFeedback().Map(item);
            feedback.CreationTime = System.DateTime.Now;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Feedback>();

                if (!AlreadyCommented(item.UserId, item.AdvertisementId))
                {
                    repo.Create(feedback);
                    uow.BeginTransaction();
                    uow.Commit();
                }
                else
                {
                    throw new PermissionDeniedException(201);
                }
            }
        }

        public void Delete(int id)
        {
            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Feedback>();
                repo.Delete(id);
                uow.BeginTransaction();
                uow.Commit();
            }
        }

        public FeedbackDTO Get(int id)
        {
            Feedback feedback;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Feedback>();
                feedback = repo.Get(id, o => o.Advertisement, o => o.ApplicationUser, o => o.Votes);
            }
            FeedbackDTO dto = FeedbackMapper.CreateFeedbackDTO().Map(feedback);
            return dto;
        }

        public IEnumerable<FeedbackDTO> GetAll()
        {
            IEnumerable<Feedback> feedbacks;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Feedback>();

                feedbacks = repo.GetAll(o => o.Advertisement, o => o.ApplicationUser, o => o.Votes);
            }
            IEnumerable<FeedbackDTO> dtos = FeedbackMapper.CreateListFeedbackDTO().Map(feedbacks).ToList().Reverse<FeedbackDTO>();

            return dtos;
        }

        public IEnumerable<FeedbackDTO> GetByAdvertisement(int advertisementId)
        {
            IEnumerable<Feedback> feedbacks;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Feedback>();

                feedbacks = repo.GetAll(o => o.Advertisement, o => o.ApplicationUser, o => o.Votes).Where(x => x.AdvertisementId == advertisementId);
            }
            IEnumerable<FeedbackDTO> dtos = FeedbackMapper.CreateListFeedbackDTO().Map(feedbacks).ToList().Reverse<FeedbackDTO>();

            return dtos;
        }

        public void Update(FeedbackDTO item)
        {
            Feedback feedback = FeedbackMapper.CreateFeedback().Map(item);
            feedback.RowVersion = item.RowVersion.Select(x => (byte)x).ToArray();

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Feedback>();

                feedback.Votes = new List<Votes>();

                if (!AlreadyVoted(item.VotedUserId, item.Id))
                {
                    if (item.Agree)
                        ++feedback.AgreeCount;
                    else
                        ++feedback.DisagreeCount;

                    repo.Update(feedback);

                    feedback.Votes.Add(new Votes
                    {
                        ApplicationUserId = item.VotedUserId,
                        FeedbackId = item.Id,
                        Agree = item.Agree
                    });

                    uow.BeginTransaction();
                    try
                    {
                        uow.Commit();
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
                    {
                        Update(UpdateData(item));
                    }
                    
                }
                else
                {
                    throw new PermissionDeniedException(101);
                }
            }
        }

        public bool AlreadyVoted (string userId, int feedbackId)
        {
            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Votes>();
                return repo.GetAll().Where(x => x.ApplicationUserId == userId && x.FeedbackId == feedbackId).ToList().Count != 0;
            }
        }

        public bool AlreadyCommented(string id, int advId)
        {
            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Feedback>();
                return repo.GetAll().Where(x => x.ApplicationUserId == id && x.AdvertisementId == advId).ToList().Count != 0;
            }
        }

        public FeedbackDTO UpdateData(FeedbackDTO item)
        {
            FeedbackDTO feedbackToUpdate = Get(item.Id);
            feedbackToUpdate.Agree = item.Agree;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Feedback>();
                feedbackToUpdate.RowVersion = repo.Get(feedbackToUpdate.Id).RowVersion.Select(x => (int)x).ToArray();
            }

            return feedbackToUpdate;
        }

        public class PermissionDeniedException : System.Exception
        {
            public int StatusCode;
            public PermissionDeniedException () { }

            public PermissionDeniedException(int statusCode)
            {
                this.StatusCode = statusCode;
            }
        }

        public bool IsValid(FeedbackDTO item)
        {
            if (item.AdvertisementId == 0 || item.AgreeCount != 0 || item.Avatar != null || item.CreationTime != null || item.DisagreeCount != 0
                || item.Id != 0 || item.Text == null || item.UserId != null || item.Username != null || item.VotedUserId != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
