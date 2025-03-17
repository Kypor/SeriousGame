using UnityEngine;

public class Piuma : Interactable
{
    PlayerUI playerUI;
    PlayerInteract playerInteract;

    Rigidbody rb;

    public Transform holder;

    //public bool inHand;

    [SerializeField] float lerpSpeed = 10f;

    private bool interacted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerInteract.inHand = false;
        //interacted = false;
        playerUI = FindAnyObjectByType<PlayerUI>();
        playerInteract = FindAnyObjectByType<PlayerInteract>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInteract.inHand == true)
        {
            if(Input.GetKey(KeyCode.Q))
            {
                Drop();
            }
        }
    }
        

    protected override void Interact()
    {
        playerUI.UpdateText(string.Empty);
        //interacted = true;
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

    private void FixedUpdate()
    {
        
        if(playerInteract.inHand == true)
        {
                
            Vector3 newPosition = Vector3.Lerp(transform.position, holder.position, Time.deltaTime * lerpSpeed);
            rb.MovePosition(newPosition);
                
                
                
        }
        
    }
}
