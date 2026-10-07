using UnityEngine;
using UnityEngine.SceneManagement;

public class BeachNextButton : MonoBehaviour
{
    public bool canContinue = false;

    void OnMouseDown()
    {
        if (canContinue)
        {
            Debug.Log("Beach Next clicked!");
            SceneManager.LoadScene("Animals");
        }
    }
}