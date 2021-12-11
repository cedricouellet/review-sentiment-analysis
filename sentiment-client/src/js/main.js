const reviewInput = document.getElementById("reviewInput");
const predictButton = document.getElementById("predictButton");
const predictionDiv = document.getElementById("prediction");
const sentiment = document.getElementById("sentiment");
const review = document.getElementById("review");
const probability = document.getElementById("probability");

import apiURL from './apiURL.js';

predictButton.onclick = submitReview;

/**
 * Submit a review and get the prediction of its sentiment.
 */
function submitReview() {
  const url = `${apiURL}/predict`;

  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ review: reviewInput.value }),
  };

  fetch(url, requestOptions)
    .then(async (response) => {
      const json = await response.json();

      if (response.status !== 200) {
        handleFailure(json);
      }

      handleSucess(json);
    })
    .catch((err) => handleError(err));
}

/**
 * Handle the success case of the request
 * @param {{sentiment: boolean, review: string, probability: number}} json
 */
function handleSucess(json) {
  reviewInput.value = "";
  predictionDiv.classList.remove("hidden");

  sentiment.innerText = json.sentiment ? "positive" : "negative";
  sentiment.style.color = json.sentiment ? "green" : "red";

  review.innerText = `"${json.review}"`;

  probability.innerText = json.probability + "%";
}

/**
 * Handle the failure case of the request
 * @param {{errors: [string]}} json
 */
function handleFailure(json) {
  throw json?.errors;
}

/**
 * Handle the error for a prediction request
 * @param {{Review: string?} | any} error
 */
function handleError(error) {
  if (error?.Review) {
    alert(error.Review);
    return;
  }

  alert("Prediction Server Offline...");
}