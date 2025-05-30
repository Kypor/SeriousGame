using UnityEngine;
using UnityEngine.InputSystem;

public class FirstRoomManager : MonoBehaviour
{
    private SettingsManager settingsManager;
    [SerializeField] GameObject ui;
    [SerializeField] GameObject player;
    [SerializeField] GameObject timeline;
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
        timeline.SetActive(true);

    }

    public void EndCutscene()
    {
        music.UnPause();
        settingsManager.enabled = true;
        ui.SetActive(true);
        player.SetActive(true);
        timeline.SetActive(false);

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
    }
}
