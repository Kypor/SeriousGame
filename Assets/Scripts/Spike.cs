using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] GameObject playerTP;

    CharacterController characterController;

    void Start()
    {
        characterController = FindAnyObjectByType<CharacterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        characterController.enabled = false;
        other.transform.position = playerTP.transform.position;
        characterController.enabled = true;
        Debug.Log("peope");
    }



}
