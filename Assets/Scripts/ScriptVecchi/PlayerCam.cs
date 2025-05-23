using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;


    //public Transform orientation;
    //public Transform player;
    public Rigidbody rb;

    public Transform cameraPosition;


    float xRotation;
    float yRotation;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }


    private void LateUpdate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 80f);

        transform.position = cameraPosition.position;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        //orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        //player.rotation = Quaternion.Euler(0, yRotation, 0);
        rb.MoveRotation(Quaternion.Euler(0, yRotation, 0));



    }
}
