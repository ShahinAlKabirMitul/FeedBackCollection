using FeedBackCollection.Entities.Model;

namespace FeedBackCollection.Contracts
{
   public interface ILogRepository
    {
        void LogInfo(LogInfo logInfo); 
       
    }
}
