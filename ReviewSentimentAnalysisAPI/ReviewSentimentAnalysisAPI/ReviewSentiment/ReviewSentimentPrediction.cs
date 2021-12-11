using System.ComponentModel.DataAnnotations;

namespace ReviewSentimentAnalysisAPI.Models
{
    /// <summary>
    /// A prediction for the sentiment of a review.
    /// </summary>
    public record ReviewSentimentPrediction
    {
        /// <summary>
        /// The review of the prediction.
        /// </summary>
        [Required]
        public string Review { get; set; }

        /// <summary>
        /// The sentiment of the prediction.
        /// </summary>
        [Required]
        public bool Sentiment { get; set; }

        /// <summary>
        /// The probability of success of the prediction (percentage).
        /// </summary>
        [Required]
        [Range(0, 100)]
        public float Probability { get; set; }

        /// <summary>
        /// Constructor for the prediction of the sentiment for a review.
        /// </summary>
        /// <param name="review">The review of the prediction.</param>
        /// <param name="sentiment">The sentiment of the prediction.</param>
        /// <param name="probability">The probability of success of the prediction (percentage).</param>
        public ReviewSentimentPrediction(string review, bool sentiment, float probability)
        {
            Review = review;
            Sentiment = sentiment;
            Probability = probability;
        }
    }
}
