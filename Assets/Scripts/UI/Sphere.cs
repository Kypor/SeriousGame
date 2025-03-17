using UnityEngine;

public class Sphere : Interactable
{
    PlayerUI playerUI;

    public Transform holder;

    QuestionManager questionManager;
    void Start()
    {
        playerUI = FindAnyObjectByType<PlayerUI>();
        questionManager = FindAnyObjectByType<QuestionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(questionManager.questionStatus == 1)
        {
            Destroy(gameObject);
            questionManager.questionStatus = 0;
        }
        else if(questionManager.questionStatus == -1)
        {
            Debug.Log("Morirai con dolore");
            questionManager.questionStatus = 0;
        }
    }

    protected override void Interact()
    {
        
        playerUI.UpdateText(string.Empty);
        Debug.Log("Qualcosa");
        /*transform.position = holder.position;
        transform.rotation = holder.transform.rotation;
        transform.parent = holder.transform;*/
        Question();
        
        
    }

    void Question()
    {
        questionManager.OpenMenu();
    }
}
