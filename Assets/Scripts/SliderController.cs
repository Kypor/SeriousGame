using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;


public class SliderController : MonoBehaviour
{
    MouseLook mouseLook;
    private Slider slider;
    [SerializeField] TextMeshProUGUI sensitivityText;
    public float maxValue = 2000f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mouseLook = FindAnyObjectByType<MouseLook>();
        slider = GetComponent<Slider>();
        slider.minValue = 1f;
        slider.maxValue = 2000f;
        //slider.value = mouseLook.mouseSensitivity;

        if (MouseSetting.Instance != null)
            slider.value = MouseSetting.Instance.mouseSensitivity;

        HandleSliderValueChanged();
    }

    public void HandleSliderValueChanged()
    {
        //mouseLook.mouseSensitivity = slider.value;

        if (MouseSetting.Instance != null)
            MouseSetting.Instance.mouseSensitivity = slider.value;
        sensitivityText.SetText(slider.value.ToString(format: "F0"));
    }


    
}
