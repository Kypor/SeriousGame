using UnityEngine;

public class SecondRoomTrigger : MonoBehaviour
{
    SecondRoomManager secondRoomManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        secondRoomManager = FindAnyObjectByType<SecondRoomManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            secondRoomManager.StartCutscene();
            secondRoomManager.LockPlayerControl();
            this.gameObject.SetActive(false);
        }
    }
}
