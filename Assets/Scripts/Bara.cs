using UnityEngine;

public class Bara : Interactable
{
    [SerializeField] Animator bara;
    [SerializeField] private string openBara = "OpenBara";
    [SerializeField] private string closeBara = "CloseBara";
    private bool isOpen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
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
}
