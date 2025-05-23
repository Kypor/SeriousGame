using TMPro;
using UnityEngine;

public class ParkourLogic : MonoBehaviour
{
    FirstRoomManager firstRoomManager;

    private int currentStep = 0;
    private int sequenceLenght;
    [SerializeField] GameObject[] rocks;
    private Color defaultColor;


    void Start()
    {
        firstRoomManager = FindAnyObjectByType<FirstRoomManager>();

        sequenceLenght = rocks.Length;

        if (rocks.Length > 0)
        {
            defaultColor = rocks[0].GetComponentInChildren<TextMeshProUGUI>().color;
        }
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (currentStep < sequenceLenght)
        {
            if (hit.gameObject == rocks[currentStep] && hit.gameObject.tag == "Correct")
            {
                var text = hit.gameObject.GetComponentInChildren<TextMeshProUGUI>();
                if (text != null)
                {
                    text.color = Color.green;
                }

                currentStep++;
                Debug.Log(currentStep);

                if (currentStep == sequenceLenght)
                {
                    Debug.Log("Sequenza corretta");
                    firstRoomManager.StartCutscene();
                }

            }
            else if (hit.gameObject.tag == "Wrong")
            {
                foreach (GameObject rock in rocks)
                {
                    var text = rock.gameObject.GetComponentInChildren<TextMeshProUGUI>();
                    if (text != null)
                    {
                        text.color = defaultColor;
                    }
                }

                currentStep = 0;
                Debug.Log(currentStep);
            }

        }
    }




}
