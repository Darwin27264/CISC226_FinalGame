using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // Required for the Image component
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI messageText; // Text element for displaying messages

    [Header("Amount of Time per Game")]
    [SerializeField] private float remainingTime;

    [Header("Monster Image to Flash")]
    [SerializeField] private Image flashImage; // Reference to the Image component you want to flash
    [SerializeField] private Image monsterImage; // Reference to the Monster


    [Header("Initial Splash Screen")]
    public GameObject splash;

    private bool printed2 = false;
    private bool printed5 = false;
    private bool printed30 = true;
    private bool printed60 = true;
    private bool printed120 = true;

    private void Update()
    {
        if (!splash.activeSelf)
        {
            if (remainingTime > 0)
            {
                if (remainingTime <= 2 && !printed2)
                {
                    printed2 = true;
                    // Trigger the image flash
                    StartCoroutine(FlashImage(0.05f, 0.3f, 4)); // Flash duration, interval, and count
                }
                else if (remainingTime <= 5 && !printed5)
                {
                    printed5 = true;
                    StartCoroutine(FadeText(1f, 2f, 1f, "Your Time has Run Out..."));

                }
                else if (remainingTime <= 30 && !printed30)
                {
                    printed30 = true;
                    StartCoroutine(FadeText(2f, 3f, 2f, "That sound appeared again, " +
                        "it sounded like it was about to reach the door. " +
                        "There's no time left..."));

                }
                else if (remainingTime <= 60 && !printed60)
                {
                    printed60 = true;
                    StartCoroutine(FadeText(2f, 3f, 2f, "The sound appeared again, sounding closer than last time."));

                }
                else if (remainingTime <= 120 && !printed120)
                {
                    printed120 = true;
                    StartCoroutine(FadeText(2f, 3f, 2f, "A weird activity sounded outside the door."));
                }

                // Update countdown timer
                remainingTime -= Time.deltaTime;
                int minutes = Mathf.FloorToInt(remainingTime / 60);
                int seconds = Mathf.FloorToInt(remainingTime % 60);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else if (remainingTime < 0 && remainingTime != -1) // Ensure this block only runs once
            {
                remainingTime = -1; // Mark as handled
                // Indicate that time has run out
                timerText.text = "00:00";

                StartCoroutine(FadeText(1f, 2f, 1f, "Your Time has Run Out..."));
                ChangeSceneWithDelay(3);
            }
        }
    }

    // Coroutine to fade in text over a specified duration and then fade out
    IEnumerator FadeText(float fadeInDuration, float stayDuration, float fadeOutDuration, string message)
    {
        // Fade in
        messageText.text = message; // Set the message text
        messageText.color = new Color(messageText.color.r, messageText.color.g, messageText.color.b, 0); // Start from transparent

        float currentTime = 0.0f;
        while (currentTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0, 1, currentTime / fadeInDuration);
            messageText.color = new Color(messageText.color.r, messageText.color.g, messageText.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null; // Wait for a frame
        }
        messageText.color = new Color(messageText.color.r, messageText.color.g, messageText.color.b, 1);

        // Stay fully visible for the duration of stayDuration
        yield return new WaitForSeconds(stayDuration);

        // Fade out
        currentTime = 0.0f;
        while (currentTime < fadeOutDuration)
        {
            float alpha = Mathf.Lerp(1, 0, currentTime / fadeOutDuration);
            messageText.color = new Color(messageText.color.r, messageText.color.g, messageText.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null; // Wait for a frame
        }
        messageText.color = new Color(messageText.color.r, messageText.color.g, messageText.color.b, 0);
    }

    // Coroutine to flash an image
    IEnumerator FlashImage(float minInterval, float maxInterval, int count)
    {
        flashImage.gameObject.SetActive(true); // Activate the GameObject to start flashing
        monsterImage.gameObject.SetActive(true);

        Color originalColor = flashImage.color;
        Color visibleColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0.85f);
        Color invisibleColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0);

        Color originalColorM = monsterImage.color;
        Color visibleColorM = new Color(originalColorM.r, originalColorM.g, originalColorM.b, 1);
        Color invisibleColorM = new Color(originalColorM.r, originalColorM.g, originalColorM.b, 0);

        for (int i = 0; i < count; i++)
        {
            // Make the image visible
            flashImage.color = visibleColor;
            monsterImage.color = visibleColorM;

            float interval = Random.Range(minInterval, maxInterval); // Randomize the interval
            yield return new WaitForSeconds(interval);

            // Make the image invisible
            flashImage.color = invisibleColor;
            monsterImage.color = invisibleColorM;

            interval = Random.Range(minInterval, maxInterval); // Randomize the interval again for the next cycle
            yield return new WaitForSeconds(interval);
        }

        flashImage.color = visibleColor;
        monsterImage.color = visibleColorM;

        //flashImage.gameObject.SetActive(false); // Deactivate the GameObject after flashing
    }

    public void ChangeSceneWithDelay(int sceneName)
    {
        StartCoroutine(DelaySceneLoad(sceneName));
    }

    IEnumerator DelaySceneLoad(int sceneName)
    {
        yield return new WaitForSeconds(3f); // Wait for 2 seconds
        SceneManager.LoadScene(sceneName); // Load the scene
    }
}
