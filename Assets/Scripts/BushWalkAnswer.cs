using UnityEngine;
using System.Collections;

public class BushwalkAnswer : MonoBehaviour
{
    public bool isCorrect;
    public GameObject correctFeedbackText;
    public GameObject wrongFeedbackText;
    public SpriteRenderer answerBox;
    public GameObject filledStar;
    public BushwalkNextButton nextButton;
    public AudioSource correctSound;
    public AudioSource wrongSound;
    public AudioSource stampSound;

    private Vector3 originalPosition;
    private bool alreadyCorrect = false;
    private static int correctCount = 0;

    void Start()
    {
        originalPosition = transform.position;
        correctCount = 0;
    }

    void OnMouseDown()
    {
        if (isCorrect)
        {
            if (alreadyCorrect)
            {
                return;
            }

            alreadyCorrect = true;
            correctCount++;

            Debug.Log("Correct Bushwalk answer!");
            correctSound.Play();

            answerBox.color = new Color(0.7f, 1f, 0.7f);

            if (correctFeedbackText != null)
            {
                correctFeedbackText.SetActive(true);
                StartCoroutine(HideCorrectFeedback());
            }

            if (correctCount == 3)
            {
                nextButton.canContinue = true;
                StartCoroutine(ShowStar());
            }
        }
        else
        {
            Debug.Log("Wrong Bushwalk answer!");
            wrongSound.Play();

            answerBox.color = new Color(1f, 0.7f, 0.7f);

            if (wrongFeedbackText != null)
            {
                wrongFeedbackText.SetActive(true);
            }

            StartCoroutine(Shake());
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
        answerBox.color = Color.white;

        if (wrongFeedbackText != null)
        {
            wrongFeedbackText.SetActive(false);
        }
    }

    IEnumerator HideCorrectFeedback()
    {
        yield return new WaitForSeconds(1.5f);
        correctFeedbackText.SetActive(false);
    }
    IEnumerator ShowStar()
    {
        yield return new WaitForSeconds(0.4f);

        filledStar.SetActive(true);
        stampSound.Play();
    }
}