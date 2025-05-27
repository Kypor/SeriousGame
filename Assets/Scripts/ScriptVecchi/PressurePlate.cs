using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] string collisionName;
    public static int counter;

    [Header("Material")]
    [SerializeField] Material greenMaterial;
    [SerializeField] Material wrongMaterial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ApplyAllObjects()
    {
        GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach(GameObject obj in allObjects )
        {
            MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
            if(obj.name == collisionName)
            {
                meshRenderer.material = wrongMaterial;
            }
        }
    }



    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision with: " + collision.gameObject.name);
        //Debug.Log(counter);
        MeshRenderer meshRenderer = collision.gameObject.GetComponent<MeshRenderer>();
        if (counter < 4)
        {
            if (collision.gameObject.name == collisionName)
            {

                switch (counter)
                {
                    case 0:
                        if (collision.gameObject.tag == "1")
                        {
                            counter = 1;
                            meshRenderer.material = greenMaterial;
                            Debug.Log(counter);
                        }
                        else
                        {
                            ApplyAllObjects();
                            counter = 0;
                        }
                        break;
                    case 1:
                        if (collision.gameObject.tag == "2")
                        {
                            counter = 2;
                            meshRenderer.material = greenMaterial;
                            Debug.Log(counter);
                        }
                        else if(collision.gameObject.tag == "1")
                        {
                            return;
                        }
                        else
                        {
                            ApplyAllObjects();
                            counter = 0;
                        }
                        break;
                    case 2:
                        if (collision.gameObject.tag == "3")
                        {
                            counter = 3;
                            meshRenderer.material = greenMaterial;
                            Debug.Log(counter);
                        }
                        else if(collision.gameObject.tag == "2")
                        {
                            return;
                        }
                        else
                        {
                            ApplyAllObjects();
                            counter = 0;
                        }
                        break;
                    case 3:
                        if (collision.gameObject.tag == "4")
                        {
                            counter = 4;
                            meshRenderer.material = greenMaterial;
                            Debug.Log(counter);
                            Debug.Log("Vittoria");
                        }
                        else if(collision.gameObject.tag == "3")
                        {
                            return;
                        }
                        else
                        {
                            ApplyAllObjects();
                            counter = 0;
                        }
                        break;


                    default:
                        Debug.Log("Caso non gestito");
                        ApplyAllObjects();
                        break;
                }

            }


            /*if(counter == 0)
            {
                if(gameObject.tag == "1")
                {
                    counter = 1;
                    Debug.Log(counter);
                }
                else
                {
                    Debug.Log("Coglione");
                    counter = 0;
                }
            }
            else if (counter == 1)
            {
                if(gameObject.tag == "2")
                {
                    counter = 2;
                    Debug.Log(counter);
                }
                else
                {
                    Debug.Log("Coglione");
                    counter = 0;
                }
            }*/



        }

    }
}
