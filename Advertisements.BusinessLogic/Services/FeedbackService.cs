using System.Linq;
using Advertisements.DTO.Models;
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Entities;
using Advertisements.BusinessLogic.Mapper;
using System.Collections.Generic;
using System;

namespace Advertisements.BusinessLogic.Services
{
    public class FeedbackService :IFeedbackAwareService<FeedbackDTO>
    {
        private readonly IUOWFactory _uowfactory;
        private readonly BaseMapper _mapper;
        public FeedbackService(IUOWFactory uowfactory)
        {
            _uowfactory = uowfactory;
            _mapper = new FeedBackMapper();
        }


      

        public FeedbackDTO Get(int id)
        {
            Feedback feedback;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Feedback>();
                feedback = repo.Get(id, o => o.Advertisement, o => o.ApplicationUser, o => o.Votes);
            }
            FeedbackDTO dto = _mapper.Map(feedback) as FeedbackDTO;
            return dto;
        }

        public IEnumerable<FeedbackDTO> GetByAdvertisement(int advertisementId)
        {
            IEnumerable<Feedback> feedbacks;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Feedback>();

                feedbacks = repo.GetAll(o => o.Advertisement, o => o.ApplicationUser, o => o.Votes).Where(x => x.AdvertisementId == advertisementId);
            }

            return this.UnboxFeedbacks(_mapper.MapCollection(feedbacks));
        }

        private IEnumerable<FeedbackDTO> UnboxFeedbacks(IEnumerable<IDTO> dtos)
        {
            List<FeedbackDTO> resultFeedbacks = new List<FeedbackDTO>();

            foreach (var element in dtos)
            {
                resultFeedbacks.Add(element as FeedbackDTO);
            }
            return resultFeedbacks;
        }

        public void Update(FeedbackDTO item)
        {
            Feedback feedback = _mapper.Map(item) as Feedback;
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

        public int GetCount()
        {
            int count = 0;
            using (var uow = this._uowfactory.CreateUnitOfWork())
            {
                var repository = uow.GetRepo<Feedback>();
                count = repository.GetCount();
            }
            return count;
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

    }
}
