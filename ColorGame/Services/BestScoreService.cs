using ColorGame.Data;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColorGame.Services
{
    /// <summary>
    /// A service to perform all operations on DB
    /// </summary>
    public class BestScoreService
    {
        // note: in this mini-project, repository layer is ommitted
        // as we only want to access a single column in a single DB table

        private IApplicationDbContext _context;
        private AuthenticationStateProvider _provider;
        public BestScoreService(IApplicationDbContext context, AuthenticationStateProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        /// <summary>
        /// Get the best score of all time for the current user 
        /// </summary>
        /// <remarks>
        /// If the user is not currently logged in or has no score saved, returns null instead
        /// </remarks>
        /// <returns>
        /// BestScore object containing the score value
        /// </returns>
        public BestScore Get()
        {
            var userId = GetUserId();
            if (userId == null) return null;
            else return _context.BestScores.SingleOrDefault(x => x.UserId == userId);
        }

        /// <summary>
        /// Update the best score of all time for the current user 
        /// </summary>
        /// /// <remarks>
        /// If the user is not currently logged in, the call is ignored instead
        /// </remarks>
        /// <param name="score">  BestScore object with the new score value</param>
        public void Update(BestScore score)
        {
            var userId = GetUserId();
            if (userId == null) return;
            var scoreToUpdate = _context.BestScores.FirstOrDefault(x => x.UserId == userId);
            if(scoreToUpdate != null) scoreToUpdate.Value = score.Value;
            else _context.BestScores.Add(new Data.BestScore() { UserId = userId, Value = score.Value });
            _context.SaveChanges();
        }
        private string GetUserId()
        {
            var authState = _provider.GetAuthenticationStateAsync().Result;
            if (!authState.User.Identity.IsAuthenticated) return null;
            return authState.User.FindFirst(c => c.Type.Contains("nameidentifier"))?.Value;
        }

    }
}
