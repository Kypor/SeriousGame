using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grabbable : Interactable
{
    PlayerUI playerUI;
    //PlayerInteract playerInteract;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerUI = FindAnyObjectByType<PlayerUI>();

    }



    protected override void Interact()
    {
        playerUI.UpdateText(string.Empty);        
        
    }


}
