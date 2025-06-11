using UnityEngine;
using UnityEngine.UI;

public class Glossario : MonoBehaviour
{
    public GameObject panelsContainer; // Il parent dove si trovano tutti i pannelli

    public void OpenPanelByButtonName(Button button)
    {
        string panelName = button.gameObject.name;

        Transform panelTransform = panelsContainer.transform.Find(panelName);
        if (panelTransform != null)
        {
            // Disattiva tutti gli altri pannelli
            foreach (Transform child in panelsContainer.transform)
            {
                child.gameObject.SetActive(false);
            }

            // Attiva quello giusto
            panelTransform.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning($"Nessun pannello trovato con nome: {panelName}");
        }
    }
}
