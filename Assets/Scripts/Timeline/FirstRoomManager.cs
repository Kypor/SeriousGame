using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FirstRoomManager : MonoBehaviour
{
    private SettingsManager settingsManager;
    [SerializeField] GameObject startTimeline;
    [SerializeField] GameObject ui;
    [SerializeField] GameObject player;
    [SerializeField] GameObject timeline1;

    [SerializeField] GameObject timeline2;
    [SerializeField] AudioSource music;
    PlaMovm plaMovm;
    MouseLook mouseLook;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settingsManager = FindAnyObjectByType<SettingsManager>();
        plaMovm = FindAnyObjectByType<PlaMovm>();
        mouseLook = FindAnyObjectByType<MouseLook>();
        LockPlayerControl();
        settingsManager.enabled = false;

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

    }

    public void LockPlayerControl()
    {
        plaMovm.enabled = false;
        mouseLook.enabled = false;
    }

    public void UnlockPlayerControl()
    {
        plaMovm.enabled = true;
        mouseLook.enabled = true;
        music.Play();
        settingsManager.enabled = true;
        startTimeline.SetActive(false);
    }

    public void FallTrapStart()
    {
        music.Pause();
        settingsManager.enabled = false;
        timeline2.SetActive(true);
    }

    public void NextRoom()
    {
        SceneManager.LoadScene("SecondRoom");
    }
}
