namespace UltiTourney.API.Models.Domain
{
    public class UserTourney
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public Guid TourneyId { get; set; }
        public Tourney Tourney { get; set; }
    }
}
