using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grabbable : Interactable
{
    PlayerUI playerUI;
    //PlayerInteract playerInteract;
    PlaInt plaInt;

    Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerUI = FindAnyObjectByType<PlayerUI>();
        plaInt = FindAnyObjectByType<PlaInt>();
        //playerInteract = FindFirstObjectByType<PlayerInteract>();
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.None;

    }



    protected override void Interact()
    {
        playerUI.UpdateText(string.Empty);
        gameObject.layer = LayerMask.NameToLayer("Grabbable");
        rb.useGravity = false;
        rb.isKinematic = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        //playerInteract.inHand = true;   
        plaInt.inHand = true;
        
        
    }

    public void Drop()
    {
        gameObject.layer = LayerMask.NameToLayer("Interactable");
        //playerInteract.inHand = false;
        plaInt.inHand = false;
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.interpolation = RigidbodyInterpolation.None;
    }

}
