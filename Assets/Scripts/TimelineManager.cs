using JusticeScale.Scripts.Scales;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class TimelineManager : MonoBehaviour
{

    [Header("Beginning")]
    [SerializeField] GameObject beginningTimeline;
    [SerializeField] GameObject anubisDialogue;
    [SerializeField] GameObject nero;

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

    public void BeginningTimeline()
    {
        heartAudio.Pause();
        settingsManager.enabled = false;
        ui.SetActive(false);
        beginningTimeline.SetActive(true);
        player.SetActive(false);
    }

    public void EndFirstCutscene()
    {
        nero.SetActive(false);
        anubisDialogue.SetActive(false);
        player.SetActive(true);
        beginningTimeline.SetActive(false);
        settingsManager.enabled = true;
        ui.SetActive(true);
        heartAudio.Play();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("FirstRoom");
    }

}
