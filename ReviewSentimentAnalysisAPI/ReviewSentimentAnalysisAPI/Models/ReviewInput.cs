using System.ComponentModel.DataAnnotations;

namespace ReviewSentimentAnalysisAPI
{
    /// <summary>
    /// Input for a review (of an Amazon product).
    /// </summary>
    public class ReviewInput
    {
        /// <summary>
        /// The review text of the review input.
        /// </summary>
        [Required]
        public string Review { get; set; }
    }
}