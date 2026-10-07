using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("Home");
    }
}