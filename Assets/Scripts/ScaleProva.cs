using UnityEngine;

public class ScaleProva : MonoBehaviour
{
    TimelineManager timelineManager;
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
        if (other.transform.parent == null)
        {
            other.transform.parent = this.transform;
        }

        if (other.tag == "Piuma" && other.transform.parent == null)
            timelineManager.AnubisTimeline();
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Uscito");
    }
}
