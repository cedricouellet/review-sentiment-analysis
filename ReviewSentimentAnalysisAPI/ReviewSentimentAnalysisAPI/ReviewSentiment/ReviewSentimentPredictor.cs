using ReviewSentimentAnalysisAPI.Models;
using static ReviewSentimentAnalysisAPI.ReviewSentimentModel;

namespace ReviewSentimentAnalysisAPI
{
    /// <summary>
    /// The predictor used for predicting the sentiment of a review.
    /// </summary>
    public class ReviewSentimentPredictor
    {
        /// <summary>
        /// Predict the sentiment of a review.
        /// </summary>
        /// <param name="reviewInput">The review input to predict.</param>
        /// <returns>The result of the prediction.</returns>
        public ReviewSentimentPrediction Predict(ReviewInput reviewInput)
        {
            ModelInput predictionInput = new ModelInput(reviewInput.Review);
            ModelOutput predictionOutput = ReviewSentimentModel.Predict(predictionInput);

            string review = reviewInput.Review;
            bool sentiment = predictionOutput.Prediction;
            float probability = (float)Math.Round(predictionOutput.Probability * 100f, 2);

            return new ReviewSentimentPrediction(review, sentiment, probability);
        }
    }
}
