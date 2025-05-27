using UnityEngine;

public class Piedistallo : MonoBehaviour
{
    ColorManager colorManager;
    public string colore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colore = this.gameObject.tag;
        colorManager = FindAnyObjectByType<ColorManager>();
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == colore && other.transform.parent == null)
        {
            colorManager.SetColore(colore, true);
            Debug.Log($"{colore} Si");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == colore && colorManager.completed == false)
        {
            colorManager.SetColore(colore, false);
            Debug.Log($"{colore} NO");
        }
    }
}
