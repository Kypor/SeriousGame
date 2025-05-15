using JusticeScale.Scripts.Scales;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class TimelineManager : MonoBehaviour
{
    [Header("Anubis Glowing Eye")]
    [SerializeField] GameObject anubisTimeline;
    [SerializeField] GameObject player;
    [SerializeField] AudioSource heartAudio;
    
    [SerializeField] GameObject ui;

    private SettingsManager settingsManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settingsManager = FindAnyObjectByType<SettingsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnubisTimeline()
    {
        settingsManager.enabled = false;
        ui.SetActive(false);
        heartAudio.Pause();
        player.SetActive(false);
        anubisTimeline.SetActive(true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("FirstRoom");
    }
}
