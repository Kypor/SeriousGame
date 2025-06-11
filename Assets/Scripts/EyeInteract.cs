using UnityEngine;

public class EyeInteract : Interactable
{
    [SerializeField] GameObject uiBase;
    [SerializeField] GameObject infoPanel;
    [SerializeField] Animator doorAnimator;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioClip sfxDoor;

    [SerializeField] GameObject eyeCounterText;
    bool audioPlayed = false;
    PlayerUI playerUI;
    PlaMovm plaMovm;
    MouseLook playerCam;
    SettingsManager settingsManager;
    void Start()
    {
        infoPanel.SetActive(false);
        plaMovm = FindAnyObjectByType<PlaMovm>();
        playerUI = FindAnyObjectByType<PlayerUI>();
        settingsManager = FindAnyObjectByType<SettingsManager>();
        playerCam = FindAnyObjectByType<MouseLook>();
        audioPlayed = false;
        eyeCounterText.SetActive(false);
    }

    protected override void Interact()
    {
        plaMovm.enabled = false;
        uiBase.SetActive(false);
        playerUI.UpdateText(string.Empty);
        infoPanel.SetActive(true);
        playerCam.enabled = false;
        settingsManager.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseInfo()
    {
        plaMovm.enabled = true;
        uiBase.SetActive(true);
        playerCam.enabled = true;
        settingsManager.enabled = true;
        infoPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        doorAnimator.SetTrigger("open");
        if (audioPlayed == false)
        {
            sfxSource.PlayOneShot(sfxDoor);
            audioPlayed = true;
        }

        eyeCounterText.SetActive(true);

        this.gameObject.SetActive(false);
    }
}
