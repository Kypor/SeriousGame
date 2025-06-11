using System.Collections;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject ui;

    [SerializeField] GameObject questionPanel;
    [SerializeField] GameObject[] questions;
    [SerializeField] TextMeshProUGUI correctWrongText;

    [Header("TimelineFinali")]
    [SerializeField] GameObject goodEnding;
    [SerializeField] GameObject badEnding;

    MouseLook playerCam;

    PlaMovm playerMovement;
    SettingsManager settingsManager;

    public int questionStatus;

    public int numberRight;
    public int numberWrong;
    private bool finishQuestion = false;



    void Awake()
    {
        questionPanel.SetActive(false);
        questionStatus = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        finishQuestion = false;
        numberRight = numberWrong = 0;
        settingsManager = FindAnyObjectByType<SettingsManager>();
        playerMovement = FindAnyObjectByType<PlaMovm>();
        playerCam = FindAnyObjectByType<MouseLook>();

        questions[questionStatus].SetActive(false);
        correctWrongText.SetText("");


    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     settingsManager.enabled = false;
        //     player.SetActive(false);
        //     ui.SetActive(false);
        //     goodEnding.SetActive(true);
        //     finishQuestion = false;
        // }
        if (finishQuestion == true)
        {
            CloseMenu();
            questionPanel.SetActive(false);
            if (numberRight >= numberWrong + 1)
            {
                Debug.Log("Good Ending");
                settingsManager.enabled = false;
                player.SetActive(false);
                ui.SetActive(false);
                goodEnding.SetActive(true);
                finishQuestion = false;
            }
            else
            {
                settingsManager.enabled = false;
                player.SetActive(false);
                ui.SetActive(false);
                badEnding.SetActive(true);
                Debug.Log("Bad Ending");
                finishQuestion = false;
            }


        }
    }

    public void OpenMenu()
    {

        playerCam.enabled = false;
        playerMovement.enabled = false;
        settingsManager.enabled = false;

        questionPanel.SetActive(true);
        questions[questionStatus].SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;


    }

    public void CloseMenu()
    {
        playerCam.enabled = true;
        playerMovement.enabled = true;
        settingsManager.enabled = true;
        questionPanel.SetActive(false);


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void RightAnswer()
    {
        StartCoroutine(RightAnswerCoroutine());


        numberRight++;
        if (numberRight == 3)
            finishQuestion = true;

    }

    IEnumerator RightAnswerCoroutine()
    {


        questionStatus++;

        correctWrongText.color = Color.green;
        correctWrongText.SetText("Risposta esatta!");




        yield return new WaitForSeconds(2f);

        correctWrongText.SetText("");

        questions[questionStatus - 1].SetActive(false);
        questions[questionStatus].SetActive(true);



    }

    public void WrongAnswer()
    {
        StartCoroutine(WrongAnswerCoroutine());
        numberWrong++;

    }

    IEnumerator WrongAnswerCoroutine()
    {


        correctWrongText.color = Color.red;
        correctWrongText.SetText("Risposta sbagliata...");

        yield return new WaitForSeconds(2f);

        correctWrongText.SetText("");

    }


}
