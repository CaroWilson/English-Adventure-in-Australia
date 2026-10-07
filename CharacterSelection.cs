using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject mia;
    public GameObject leo;

    public GameObject miaHighlight;
    public GameObject leoHighlight;

    private Vector3 miaOriginalScale;
    private Vector3 leoOriginalScale;

    void Start()
    {
        PlayerPrefs.DeleteKey("SelectedCharacter");
        
        miaOriginalScale = mia.transform.localScale;
        leoOriginalScale = leo.transform.localScale;

        miaHighlight.SetActive(false);
        leoHighlight.SetActive(false);
    }

    public void SelectMia()
    {
        mia.transform.localScale = miaOriginalScale * 1.1f;
        leo.transform.localScale = leoOriginalScale;

            miaHighlight.SetActive(true);
        leoHighlight.SetActive(false);

        PlayerPrefs.SetString("SelectedCharacter", "Mia");
    }

    public void SelectLeo()
    {
        leo.transform.localScale = leoOriginalScale * 1.1f;
        mia.transform.localScale = miaOriginalScale;

        leoHighlight.SetActive(true);
        miaHighlight.SetActive(false);

        PlayerPrefs.SetString("SelectedCharacter", "Leo");
    }

    public void StartAdventure()
    {
        Debug.Log("START BUTTON WORKS!");

        if (PlayerPrefs.HasKey("SelectedCharacter"))
        {
            SceneManager.LoadScene("Breakfast");
        }
    }
}