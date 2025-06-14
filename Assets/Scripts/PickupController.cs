using JusticeScale.Scripts.Scales;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    private PlayerUI playerUI;
    [SerializeField] GameObject leaveObjectText;
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    private GameObject heldObj;
    private Rigidbody heldObjRB;
    public LayerMask interactLayer;
    public LayerMask scaleLayer;

    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;

    private void Start()
    {
        playerUI = FindAnyObjectByType<PlayerUI>();
        leaveObjectText.SetActive(false);
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
            RaycastHit hitScale;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitScale, pickupRange, scaleLayer))
            {
                if (hitScale.collider.GetComponent<TriggerScale>() != null)
                {
                    if (hitScale.collider.tag == "Left")
                    {
                        var leftScaleScript = hitScale.collider.GetComponent<TriggerScale>();
                        if (leftScaleScript.onScale == false)
                        {
                            playerUI.UpdateText("[F] Metti sulla bilancia");
                            if (Input.GetKeyDown(KeyCode.F))
                            {
                                DropOnScale(leftScaleScript);
                            }
                        }
                    }

                    else if (hitScale.collider.tag == "Right")
                    {
                        var rightScaleScript = hitScale.collider.GetComponent<TriggerScale>();
                        if (rightScaleScript.onScale == false)
                        {
                            playerUI.UpdateText("[F] Metti sulla bilancia");
                            if (Input.GetKeyDown(KeyCode.F))
                            {
                                DropOnScale(rightScaleScript);
                            }
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
            leaveObjectText.SetActive(true);
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

    void DropObject(Vector3? dropPosition = null)
    {
        leaveObjectText.SetActive(false);
        //heldObj.layer = LayerMask.NameToLayer("Interactable");
        heldObjRB.useGravity = true;
        heldObjRB.linearDamping = 1;
        heldObjRB.interpolation = RigidbodyInterpolation.Interpolate;
        heldObjRB.constraints = RigidbodyConstraints.None;
        heldObjRB.angularDamping = 0.05f;

        if (dropPosition.HasValue)
        {
            heldObj.transform.position = dropPosition.Value;
            heldObjRB.linearVelocity = Vector3.zero;
            heldObjRB.angularVelocity = Vector3.zero;
        }

        heldObj.transform.parent = null;
        heldObj = null;

    }

    void DropOnScale(TriggerScale triggerScale)
    {
        //Vector3 dropPos = triggerScale.GetComponent<Collider>().bounds.center + Vector3.up * 0.3f;
        Vector3 dropPos = triggerScale.dropPosition.position;

        var collider = heldObj.GetComponent<Collider>();
        DropObject(dropPos);
        triggerScale.OnScaleEnter(collider);
    }

}
