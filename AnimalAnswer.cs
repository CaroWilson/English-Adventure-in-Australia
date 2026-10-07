using UnityEngine;
using System.Collections;

public class AnimalAnswer : MonoBehaviour
{
    public bool isCorrect;
    public GameObject correctFeedbackText;
    public SpriteRenderer answerBox;
    public GameObject wrongFeedbackText;
    public GameObject filledStar;
    public AnimalsNextButton nextButton;
    public AudioSource correctSound;
    public AudioSource wrongSound;
    public AudioSource stampSound;

    private static int correctCount = 0;
    private bool alreadyCorrect = false;
    private Vector3 originalPosition;

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

            Debug.Log("Correct answer!");
            correctSound.Play();
            correctFeedbackText.SetActive(true);
            answerBox.color = new Color(0.7f, 1f, 0.7f);
            StartCoroutine(HideCorrectFeedback());

            if (correctCount == 2)
            {
                nextButton.canContinue = true;
                StartCoroutine(ShowStar());
            }
        }
        else
        {
            Debug.Log("Wrong answer!");
            wrongSound.Play();
            wrongFeedbackText.SetActive(true);
            answerBox.color = new Color(1f, 0.7f, 0.7f);
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
        wrongFeedbackText.SetActive(false);
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