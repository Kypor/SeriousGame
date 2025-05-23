using UnityEngine;

public class FirstRoomManager : MonoBehaviour
{
    private SettingsManager settingsManager;
    [SerializeField] GameObject ui;
    [SerializeField] GameObject player;
    [SerializeField] GameObject timeline;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settingsManager = FindAnyObjectByType<SettingsManager>();
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
}
