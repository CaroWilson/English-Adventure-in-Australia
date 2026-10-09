using UnityEngine;
using UnityEngine.SceneManagement;

public class BushwalkNextButton : MonoBehaviour
{
    public bool canContinue = false;

    void OnMouseDown()
    {
        if (canContinue)
        {
            Debug.Log("Bushwalk Next clicked!");
            SceneManager.LoadScene("Credits");
        }
    }
}
