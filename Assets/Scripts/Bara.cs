using System.Collections;
using UnityEngine;

public class Bara : Interactable
{
    PlayerUI playerUI;
    [SerializeField] Animator bara;
    [SerializeField] private string openBara = "OpenBara";
    [SerializeField] private string closeBara = "CloseBara";
    private bool isOpen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerUI = FindAnyObjectByType<PlayerUI>();
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        if (this.tag != "Locked")
        {
            if (isOpen == false)
            {
                bara.Play(openBara);
                isOpen = true;
            }
            else if (isOpen == true)
            {
                bara.Play(closeBara);
                isOpen = false;
            }
        }
        else
        {
            Debug.Log("Chiusa");
            StartCoroutine(ShowText(3f));
        }


    }

    IEnumerator ShowText(float delay)
    {
        float timer = delay;
        while (timer > 0)
        {
            playerUI.UpdateText("La bara è chiusa");
            yield return null;
            timer -= Time.deltaTime;
        }

    }

    public void OpenBara()
    {
        this.tag = "Untagged";
        bara.Play(openBara);
    }
}
