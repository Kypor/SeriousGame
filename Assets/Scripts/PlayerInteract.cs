using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{

    private const int count = 2;
    PlayerMovement playerMovement;

    public LayerMask interactable;
    public LayerMask grabbableLayer;
    

    public bool inHand;
    public Camera cam;

    PlayerUI playerUI;
    LadderManager ladderManager;

    [Header("Grabbing")]
    Grabbable grabbable;
    Rigidbody grabbableRb;
    Collider grabbableCollider;
    public Transform holder;
    [SerializeField] float lerpSpeed = 10f;

    [SerializeField] float raycastDistance;

    QuestionManager questionManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questionManager = FindAnyObjectByType<QuestionManager>();
        inHand = false;
        playerUI = FindAnyObjectByType<PlayerUI>();
        ladderManager = FindAnyObjectByType<LadderManager>();
        playerMovement = GetComponent<PlayerMovement>();
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
            if(inHand == false && ladderManager.onLadder == false && playerMovement.grounded == true && questionManager.questionMenu == false)
            {
                if(hit.collider.GetComponent<Interactable>() != null)
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    playerUI.UpdateText(interactable.promptMessage);
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
                        grabbableCollider.enabled = false;
                        Debug.Log("Test");
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
                grabbableCollider.enabled = true;
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
