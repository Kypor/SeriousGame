using UnityEngine;

public class ColorManager : MonoBehaviour
{
    private bool rosso = false;
    private bool blu = false;
    private bool verde = false;

    public bool completed = false;

    public void SetColore(string colore, bool stato)
    {
        switch (colore)
        {
            case "Rosso":
                rosso = stato;
                break;
            case "Blu":
                blu = stato;
                break;
            case "Verde":
                verde = stato;
                break;
        }

        ControllaCombinazione();
    }

    private void ControllaCombinazione()
    {
        if (rosso && blu && verde)
        {
            Debug.Log("TUTTI POSIZIONATI!");
            completed = true;
        }
        else
            completed = false;
    }
}
