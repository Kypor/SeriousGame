using UnityEngine;

public class PickupController : MonoBehaviour
{
    private PlayerUI playerUI;
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    private GameObject heldObj;
    private Rigidbody heldObjRB;
    public LayerMask interactLayer;

    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;

    private void Start()
    {
        playerUI = FindAnyObjectByType<PlayerUI>();
    }

    private void Update()
    {
        playerUI.UpdateText(string.Empty);

        if (heldObj == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange, interactLayer))
            {
                if (hit.collider.GetComponent<Interactable>() != null)
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    playerUI.UpdateText("[E] " + interactable.promptMessage);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        interactable.BaseInteract();
                        PickupObject(hit.transform.gameObject);
                    }
                }

            }

        }
        if (heldObj != null)
        {
            //MoveObj
            MoveObject();
            if (heldObj.tag == "Chiave")
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange, interactLayer))
                {
                    if (hit.collider.GetComponent<Bara>() != null && hit.collider.tag == "Locked")
                    {
                        Bara bara = hit.collider.GetComponent<Bara>();
                        playerUI.UpdateText("[E] Usa chiave");
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            bara.OpenBara();
                        }
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                DropObject();
            }
        }
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            //pickObj.layer = LayerMask.NameToLayer("Grabbed");
            pickObj.transform.rotation = holdArea.transform.rotation;
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.linearDamping = 10;
            heldObjRB.interpolation = RigidbodyInterpolation.None;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;
            heldObjRB.angularDamping = 10;

            heldObjRB.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        //heldObj.layer = LayerMask.NameToLayer("Interactable");
        heldObjRB.useGravity = true;
        heldObjRB.linearDamping = 1;
        heldObjRB.interpolation = RigidbodyInterpolation.Interpolate;
        heldObjRB.constraints = RigidbodyConstraints.None;
        heldObjRB.angularDamping = 0.05f;

        heldObj.transform.parent = null;
        heldObj = null;

    }

}
