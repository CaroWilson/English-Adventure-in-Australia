using UnityEngine;
using UnityEngine.SceneManagement;

public class BushwalkBackButton : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("Animals");
    }
}