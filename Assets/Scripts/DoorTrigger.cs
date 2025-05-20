using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private TimelineManager timelineManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timelineManager = FindAnyObjectByType<TimelineManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            timelineManager.BeginningTimeline();
            Destroy(gameObject);
        }
    }

    
}
