using UnityEngine;
using UnityEngine.SceneManagement;

public class BeachBackButton : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("Breakfast");
    }
}