using UnityEngine;
using TMPro;

public class Pelican : MonoBehaviour
{
    public TextMeshProUGUI Sovet;
    public GameObject Can_Pelican;
    [TextArea(3, 10)]
    public string[] sovet;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            int rnd = Random.Range(0, 8);
            Can_Pelican.SetActive(true);
            Sovet.text = sovet[rnd].ToString();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag =="Player")
        {
            Can_Pelican.SetActive(false);
        }
    }
}
