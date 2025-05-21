using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [Header("BaseUI")]
    [SerializeField] TextMeshProUGUI promptText;




    // Start is called before the first frame update
    void Start()
    {
        promptText.text = string.Empty;


    }

    // Update is called once per frame
    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;

    }


}

