using UnityEngine;
using UnityEngine.UI;

public class PlaInt : MonoBehaviour
{

    private const int count = 2;
    PlaMovm plaMovm;

    public LayerMask interactable;
    public LayerMask grabbableLayer;
    

    public bool inHand;
    public Camera cam;

    PlayerUI playerUI;

    [Header("Grabbing")]
    Grabbable grabbable;
    Rigidbody grabbableRb;
    Collider grabbableCollider;
    public Transform holder;
    [SerializeField] float lerpSpeed = 10f;

    [SerializeField] float raycastDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inHand = false;
        playerUI = FindAnyObjectByType<PlayerUI>();
        plaMovm = GetComponent<PlaMovm>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);

        Vector3 forward = cam.transform.forward;
        Vector3 origin = cam.transform.position;
        if(Physics.Raycast(origin, forward, out RaycastHit hit, raycastDistance, interactable))
        {
            //Debug.Log("Interazione");
            if(inHand == false && plaMovm.isGrounded == true)
            {
                if(hit.collider.GetComponent<Interactable>() != null)
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    playerUI.UpdateText("[E] " + interactable.promptMessage);
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        interactable.BaseInteract();
                    }
                }

                if(hit.collider.GetComponent<Grabbable>() != null)
                {
                    grabbable = hit.collider.GetComponent<Grabbable>();
                    grabbableRb = hit.collider.GetComponent<Rigidbody>();
                    grabbableCollider = grabbable.GetComponent<Collider>();

                    
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        grabbableRb.rotation = holder.rotation;                        
                        //grabbableCollider.enabled = true;
                        grabbableCollider.isTrigger = true;
                        grabbable.BaseInteract();

                    }
                    
                }

                

                
            }
            
        }

        if(inHand == true)
        {
            if(Input.GetKey(KeyCode.Q))
            {
                grabbable.Drop();
                //grabbableCollider.enabled = true;
                grabbableCollider.isTrigger = false;
                //grabbable.gameObject.layer = interactable;
            }
        }

    }

    void FixedUpdate()
    {
        if(inHand == true)
        {
            Vector3 newPosition = Vector3.Lerp(grabbableRb.position, holder.position, Time.deltaTime * lerpSpeed);
            grabbableRb.MovePosition(newPosition);
            Quaternion newQuaternion = Quaternion.Lerp(grabbableRb.rotation, holder.rotation, lerpSpeed);
            grabbableRb.MoveRotation(newQuaternion);
            
        }
    }



}
