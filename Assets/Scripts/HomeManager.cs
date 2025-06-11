using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] GameObject homePanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject glossaryPanel;
    public void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        homePanel.SetActive(true);
        settingsPanel.SetActive(false);
        glossaryPanel.SetActive(false);
    }

    public void Start()
    {
        audioMixer.SetFloat("Music", 0);
        audioMixer.SetFloat("SFX", 0);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Entrance");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        homePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        homePanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void OpenGlossary()
    {
        homePanel.SetActive(false);
        glossaryPanel.SetActive(true);
    }

    public void CloseGlossary()
    {
        homePanel.SetActive(true);
        glossaryPanel.SetActive(false);
    }
}
