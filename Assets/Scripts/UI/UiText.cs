using UnityEngine;

public class UiText : MonoBehaviour
{
    [SerializeField] GameObject[] texts;
    private int i = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        for (int j = 0; j < texts.Length; j++)
        {
            texts[j].SetActive(j == 0);
        }

        i = 0;
    }

    public void NextText()
    {
        texts[i].SetActive(false);
        i = (i + 1) % texts.Length;
        texts[i].SetActive(true);
    }

    public void PreviousText()
    {
        texts[i].SetActive(false);

        // Decrementa l'indice e torna all'ultimo se si va sotto 0
        i = (i - 1 + texts.Length) % texts.Length;

        // Attiva il nuovo testo
        texts[i].SetActive(true);
    }
}
