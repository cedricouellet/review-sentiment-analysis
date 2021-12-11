using Microsoft.AspNetCore.Mvc;
using ReviewSentimentAnalysisAPI.Models;

namespace ReviewSentimentAnalysisAPI.Controllers
{
    /// <summary>
    /// The controller for predicting reviews.
    /// </summary>
    [ApiController]
    [Route("/predict")]
    public class ReviewController : ControllerBase
    {
        /// <summary>
        /// The predictor used for predicting reviews.
        /// </summary>
        private ReviewSentimentPredictor _predictor;

        /// <summary>
        /// Constructor for the controller.
        /// </summary>
        /// <param name="predictor">The predictor used for predicting reviews.</param>
        public ReviewController(ReviewSentimentPredictor predictor)
        {
            _predictor = predictor;
        }

        /// <summary>
        /// Listen for a POST request to the predict route.
        /// </summary>
        /// <param name="review">The review input received from the body.</param>
        /// <returns>The result of the prediction.</returns>
        [HttpPost]
        public ActionResult<ReviewSentimentPrediction> PredictReview(ReviewInput review)
        {
            return _predictor.Predict(review);
        }
    }
}
