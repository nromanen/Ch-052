using System.Linq;
using Advertisements.DTO.Models;
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Entities;
using Advertisements.BusinessLogic.Mapper;
using System.Collections.Generic;

namespace Advertisements.BusinessLogic.Services
{
    public class FeedbackService : IService<FeedbackDTO>
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
                repo.Create(feedback);
                uow.BeginTransaction();
                uow.Commit();                     
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
                feedback = repo.Get(id, o => o.Advertisement, o => o.ApplicationUser, o => o.VotedUsers);
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

                feedbacks = repo.GetAll(o => o.Advertisement, o => o.ApplicationUser, o => o.VotedUsers);
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
                
                repo.Update(feedback);
                uow.BeginTransaction();
                uow.Commit();
            }
        }
    }
}
