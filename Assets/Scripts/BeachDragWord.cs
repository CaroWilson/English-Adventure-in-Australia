using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class BeachDragWord : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 startPosition;
    private Collider2D targetCollider;
    private bool isCorrect = false;
    private static int correctCount = 0;

    public GameObject correctFeedback;
    public string correctTargetTag;
    public GameObject filledStar;
    public BeachNextButton nextButton;
    public GameObject correctHighlight;
    public AudioSource correctSound;
    public AudioSource stampSound;


    void Start()
    {
        startPosition = transform.position;
        correctCount = 0;
    }

    void OnMouseDown()
    {
        if (isCorrect)
        {
            return;
        }

        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        offset = transform.position -
                 new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    void OnMouseDrag()
    {
        if (isCorrect)
        {
            return;
        }

        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        transform.position = new Vector3(
            mousePosition.x + offset.x,
            mousePosition.y + offset.y,
            transform.position.z
        );
    }
    void OnMouseUp()
    {
        if (isCorrect)
        {
            return;
        }

        targetCollider = null;

        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        Collider2D[] colliders = Physics2D.OverlapPointAll(mousePosition);

        foreach (Collider2D collider in colliders)
        {

            if (collider.CompareTag(correctTargetTag))
            {
                targetCollider = collider;
                isCorrect = true;
                correctCount++;
                correctSound.Play();

                if (correctCount == 4)
                {
                    nextButton.canContinue = true;
                    StartCoroutine(ShowStar());
                }

                correctHighlight.SetActive(true);
                correctFeedback.SetActive(true);
                StartCoroutine(HideFeedback());
                Debug.Log("Correct target found: " + correctTargetTag);
            }
        }
        
        if (targetCollider == null)
        {
            transform.position = startPosition;
        }

        if (targetCollider != null)
        {
            Debug.Log("Dropped on: " + targetCollider.gameObject.name);
        }
    }

        IEnumerator HideFeedback()
        {
            yield return new WaitForSeconds(1.5f);
            correctFeedback.SetActive(false);
        }

    IEnumerator ShowStar()
    {
        yield return new WaitForSeconds(0.4f);

        filledStar.SetActive(true);
        stampSound.Play();
    }
}