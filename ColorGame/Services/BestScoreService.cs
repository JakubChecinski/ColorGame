using ColorGame.Data;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColorGame.Services
{
    public class BestScoreService
    {
        // note: unit of work and repository are ommitted
        // since we only want to access a single column in a single DB table

        private IApplicationDbContext _context;
        private AuthenticationStateProvider _provider;
        public BestScoreService(IApplicationDbContext context, AuthenticationStateProvider provider)
        {
            _context = context;
            _provider = provider;
        }
        public BestScore Get()
        {
            var userId = GetUserId();
            if (userId == null) return null;
            else return _context.BestScores.SingleOrDefault(x => x.UserId == userId);
        }
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
