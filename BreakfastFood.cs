using UnityEngine;
using System.Collections;

public class BreakfastFood : MonoBehaviour
{
    public bool isCorrect;
    public GameObject highlight;
    public GameObject feedbackText;
    public GameObject correctFeedbackText;
    public GameObject filledStar;
    public NextButton nextButton;
    public AudioSource correctSound;
    public AudioSource wrongSound;
    public AudioSource stampSound;

    private Vector3 originalPosition;
    private Vector3 originalScale;

    void Start()
    {
        originalPosition = transform.position;
        originalScale = transform.localScale;

        highlight.SetActive(false);
    }

    void OnMouseDown()
    {
        if (!isCorrect)
        {
            highlight.SetActive(true);
            feedbackText.SetActive(true);
            StartCoroutine(Shake());
            wrongSound.Play();
            Debug.Log("Wrong food!");
        }
        else
        {
            highlight.SetActive(true);
            transform.localScale = originalScale * 1.1f;
            correctFeedbackText.SetActive(true);
            nextButton.canContinue = true;

            correctSound.Play();
            StartCoroutine(ShowStar());
        }
    }
    IEnumerator Shake()
    {
        for (int i = 0; i < 6; i++)
        {
            transform.position = originalPosition + new Vector3(0.1f, 0, 0);
            yield return new WaitForSeconds(0.05f);

            transform.position = originalPosition + new Vector3(-0.1f, 0, 0);
            yield return new WaitForSeconds(0.05f);
        }

        transform.position = originalPosition;
        highlight.SetActive(false);
        feedbackText.SetActive(false);
    }

    IEnumerator ShowStar()
    {
        yield return new WaitForSeconds(0.4f);

        filledStar.SetActive(true);
        stampSound.Play();
    }
}

