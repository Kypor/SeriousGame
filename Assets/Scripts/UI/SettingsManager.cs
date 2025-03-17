using UnityEngine;

public class SettingsManager : MonoBehaviour
{

    public bool inMenu;
    [SerializeField] GameObject settingsPanel;
    PlayerCam playerCam;


    void Awake()
    {
        settingsPanel.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerCam = FindAnyObjectByType<PlayerCam>();
        playerCam.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(inMenu)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
    }

    public void OpenMenu()
    {
       inMenu = true;
       playerCam.enabled = false;
       Time.timeScale = 0;
       settingsPanel.SetActive(true);

       Cursor.visible = true;
       Cursor.lockState = CursorLockMode.None;
    }

    public void CloseMenu()
    {
        inMenu = false;
        playerCam.enabled = true;
        Time.timeScale = 1;
        settingsPanel.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
}
