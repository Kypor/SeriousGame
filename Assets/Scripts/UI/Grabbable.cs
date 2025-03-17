using UnityEngine;

public class Grabbable : Interactable
{
    PlayerUI playerUI;
    PlayerInteract playerInteract;

    Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerUI = FindAnyObjectByType<PlayerUI>();
        playerInteract = FindFirstObjectByType<PlayerInteract>();
        rb = GetComponent<Rigidbody>();

    }

        

    protected override void Interact()
    {
        playerUI.UpdateText(string.Empty);
        rb.useGravity = false;
        rb.isKinematic = true;
        playerInteract.inHand = true;   
        
        
    }

    public void Drop()
    {
        playerInteract.inHand = false;
        rb.useGravity = true;
        rb.isKinematic = false;
    }

}
