using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    public bool canContinue = false;


    void OnMouseDown()
    {
        if (canContinue)
        {
            Debug.Log("Next clicked!");
            SceneManager.LoadScene("Beach");
        }
    }
}