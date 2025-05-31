using UnityEngine;

public class Book : Interactable
{
    PlayerUI playerUI;
    PlaMovm plaMovm;
    MouseLook playerCam;
    [SerializeField] GameObject uiInfo;
    [SerializeField] GameObject uiBase;

    SettingsManager settingsManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plaMovm = FindAnyObjectByType<PlaMovm>();
        playerUI = FindAnyObjectByType<PlayerUI>();
        settingsManager = FindAnyObjectByType<SettingsManager>();
        playerCam = FindAnyObjectByType<MouseLook>();
        uiInfo.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        plaMovm.enabled = false;
        uiBase.SetActive(false);
        playerUI.UpdateText(string.Empty);
        uiInfo.SetActive(true);
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
        uiInfo.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
