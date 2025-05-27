using UnityEngine;
using System.Collections;

public class Chest : Interactable
{
    PlayerUI playerUI;
    ColorManager colorManager;
    Animator animator;
    [SerializeField] GameObject luce;
    [SerializeField] GameObject[] luciColorate;
    private bool isOpen = false;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
        playerUI = FindAnyObjectByType<PlayerUI>();
        colorManager = FindAnyObjectByType<ColorManager>();
        luce.SetActive(false);
    }



    protected override void Interact()
    {
        if (colorManager.completed == false)
        {
            StartCoroutine(ShowText(3f));
        }
        else if (colorManager.completed == true)
        {
            luce.SetActive(true);
            foreach (GameObject lucette in luciColorate)
            {
                lucette.SetActive(false);
            }
            if (isOpen == false)
                {
                    animator.Play("OpenChest");
                    isOpen = true;
                }
                else if (isOpen == true)
                {
                    animator.Play("CloseChest");
                    isOpen = false;
                }
        }

    }

    IEnumerator ShowText(float delay)
    {
        float timer = delay;
        while (timer > 0)
        {
            playerUI.UpdateText("Lo scrigno è chiuso");
            yield return null;
            timer -= Time.deltaTime;
        }

    }
}
