using UnityEngine;

public class Table : MonoBehaviour
{
    public GameObject F_pussy;
    public GameObject name_table;
    private bool Stay = false;

    public void Start()
    {
        F_pussy.SetActive(false);
        name_table.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Stay = true;
                if (Stay == true)
                {
                    F_pussy.SetActive(false);
                    name_table.SetActive(true);
                }
            }
            else
            {
                if (Stay == false)
                {
                    F_pussy.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            F_pussy.SetActive(false);
            name_table.SetActive(false);
            Stay = false;
        }
    }

}
