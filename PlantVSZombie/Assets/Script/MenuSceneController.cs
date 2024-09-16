using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour
{
    public GameObject inputPanelGameObject;
    public TMP_InputField nameInputField;
    public TextMeshProUGUI nameText;

    private void Start()
    {
        UpdateNameUI();
    }
    public void OnChangeNameButtonClick()
    {
        AudioManager.instance.PlayClip(Config.btn_click);
        string name = PlayerPrefs.GetString("Name", "");
        nameInputField.text = name;
        inputPanelGameObject.SetActive(true);
    }

    public void OnSubmitButtonClick()
    {
        AudioManager.instance.PlayClip(Config.btn_click);
        PlayerPrefs.SetString("Name", nameInputField.text);
        inputPanelGameObject.SetActive(false);
        UpdateNameUI();
    }

    public void UpdateNameUI()
    {
        string name = PlayerPrefs.GetString("Name","---");
        nameText.text = name;
    }

    public void OnAdventureButtonClick ()
    {
        AudioManager.instance.PlayClip(Config.btn_click);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
