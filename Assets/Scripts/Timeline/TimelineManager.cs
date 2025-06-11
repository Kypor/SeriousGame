using JusticeScale.Scripts.Scales;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TimelineManager : MonoBehaviour
{
    [Header("StartGame")]
    [SerializeField] GameObject startTimeline;

    [Header("Beginning")]
    [SerializeField] GameObject beginningTimeline;
    [SerializeField] GameObject anubisDialogue;
    [SerializeField] GameObject nero;
    [SerializeField] AudioSource music;

    [Header("Anubis Glowing Eye")]
    [SerializeField] GameObject anubisTimeline;
    [SerializeField] GameObject player;
    [SerializeField] AudioSource heartAudio;


    [SerializeField] GameObject ui;
    PlaMovm plaMovm;
    MouseLook mouseLook;


    private SettingsManager settingsManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plaMovm = FindAnyObjectByType<PlaMovm>();
        mouseLook = FindAnyObjectByType<MouseLook>();
        settingsManager = FindAnyObjectByType<SettingsManager>();

        plaMovm.enabled = false;
        mouseLook.enabled = false;
        settingsManager.enabled = false;


        ui.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AnubisTimeline()
    {
        music.Pause();
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
        music.Play();
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

    public void StartGame()
    {
        startTimeline.SetActive(false);
        ui.SetActive(true);
        plaMovm.enabled = true;
        mouseLook.enabled = true;
        settingsManager.enabled = true;
    }

}
