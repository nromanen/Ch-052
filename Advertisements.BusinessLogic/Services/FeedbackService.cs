using System.Linq;
using Advertisements.DTO.Models;
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Entities;
using Advertisements.BusinessLogic.Mapper;
using System.Collections.Generic;

namespace Advertisements.BusinessLogic.Services
{
    public class FeedbackService : IService<FeedbackDTO>, IFeedbackAwareService<FeedbackDTO>
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

                if (!AlreadyCommented(item.UserId))
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
                    uow.Commit();
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

        public bool AlreadyCommented(string id)
        {
            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Feedback>();
                return repo.GetAll().Where(x => x.ApplicationUserId == id).ToList().Count != 0;
            }
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
