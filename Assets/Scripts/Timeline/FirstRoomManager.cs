using UnityEngine;

public class FirstRoomManager : MonoBehaviour
{
    private SettingsManager settingsManager;
    [SerializeField] GameObject ui;
    [SerializeField] GameObject player;
    [SerializeField] GameObject timeline;
    PlaMovm plaMovm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settingsManager = FindAnyObjectByType<SettingsManager>();
        plaMovm = FindAnyObjectByType<PlaMovm>();
    }

    public void StartCutscene()
    {
        settingsManager.enabled = false;
        ui.SetActive(false);
        player.SetActive(false);
        timeline.SetActive(true);

    }

    public void EndCutscene()
    {
        settingsManager.enabled = true;
        ui.SetActive(true);
        player.SetActive(true);
        timeline.SetActive(false);

    }

    public void LockPlayerControl()
    {
        plaMovm.enabled = false;
    }

    public void UnlockPlayerControl()
    {
        plaMovm.enabled = true;
    }
}
