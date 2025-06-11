using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SecondRoomManager : MonoBehaviour
{
    private SettingsManager settingsManager;
    [Header("Timeline")]
    [SerializeField] GameObject timeline1;

    [Header("Game Reference")]
    [SerializeField] GameObject ui;
    [SerializeField] GameObject player;
    [SerializeField] AudioSource music;

    PlaMovm plaMovm;
    MouseLook mouseLook;
    QuestionManager questionManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settingsManager = FindAnyObjectByType<SettingsManager>();
        plaMovm = FindAnyObjectByType<PlaMovm>();
        mouseLook = FindAnyObjectByType<MouseLook>();
        questionManager = FindAnyObjectByType<QuestionManager>();

        timeline1.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void StartCutscene()
    {
        music.Pause();
        settingsManager.enabled = false;
        ui.SetActive(false);
        player.SetActive(false);
        timeline1.SetActive(true);

    }

    public void EndCutscene()
    {
        music.UnPause();
        settingsManager.enabled = true;
        ui.SetActive(true);
        player.SetActive(true);
        timeline1.SetActive(false);
        plaMovm.enabled = true;
        mouseLook.enabled = true;

        questionManager.OpenMenu();

    }

    public void LockPlayerControl()
    {
        plaMovm.enabled = false;
        mouseLook.enabled = false;
    }

    public void NextRoom()
    {
        SceneManager.LoadScene("SecondRoom");
    }

    public void HomeScreen()
    {
        SceneManager.LoadScene("HomeScreen");
    }
}
