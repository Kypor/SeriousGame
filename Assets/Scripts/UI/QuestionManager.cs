using System.Collections;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{

    [SerializeField] GameObject questionPanel;
    PlayerCam playerCam;

    [SerializeField] GameObject correctText;
    [SerializeField] GameObject wrongText;

    PlayerMovement playerMovement;

    public int questionStatus;

    public int numberRight;
    public int numberWrong;

    public bool questionMenu;


    void Awake()
    {
        questionPanel.SetActive(false);
        correctText.SetActive(false);
        wrongText.SetActive(false);
        questionStatus = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        numberRight = numberWrong = 0;
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        playerCam = FindAnyObjectByType<PlayerCam>();
        playerCam.enabled = true;
        questionMenu = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMenu()
    {
       playerCam.enabled = false;
       playerMovement.enabled = false;
       //Time.timeScale = 0;
       questionPanel.SetActive(true);
       correctText.SetActive(false);
       wrongText.SetActive(false);

       Cursor.visible = true;
       Cursor.lockState = CursorLockMode.None;

       questionMenu = true;
    }

    public void CloseMenu()
    {
        playerCam.enabled = true;
        playerMovement.enabled = true;
        //Time.timeScale = 1;
        questionPanel.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        questionMenu = false;
    }

    public void RightAnswer()
    {
        StartCoroutine(RightAnswerCoroutine());
        questionStatus = 1;
        numberRight++;
        Debug.Log(numberRight);

    }

    IEnumerator RightAnswerCoroutine()
    {
        Debug.Log("Risposta giusta");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        correctText.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        

        CloseMenu();
        
    }

    public void WrongAnswer()
    {
        StartCoroutine(WrongAnswerCoroutine());
        questionStatus = -1;
        numberWrong++;
        Debug.Log(numberWrong);
    }

    IEnumerator WrongAnswerCoroutine()
    {
        Debug.Log("Risposta sbagliata");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        wrongText.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        

        CloseMenu();
    }

    
}
