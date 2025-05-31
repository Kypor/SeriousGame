using UnityEngine;

public class Fall : MonoBehaviour
{
    FirstRoomManager firstRoomManager;
    
    void Start()
    {
        firstRoomManager = FindAnyObjectByType<FirstRoomManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            firstRoomManager.FallTrapStart();
        }
    }
}
