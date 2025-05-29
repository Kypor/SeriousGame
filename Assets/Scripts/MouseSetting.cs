using UnityEngine;

public class MouseSetting : MonoBehaviour
{
    public static MouseSetting Instance;
    public float mouseSensitivity = 100f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
