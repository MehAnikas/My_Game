using UnityEngine;

public class Treasure : MonoBehaviour
{
    public static int potion;

    private void Start()
    {
        potion = PlayerPrefs.GetInt("Potion");
    }
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Potion"))
        {
            PlayerPrefs.SetInt("Potion", 0);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            potion = 1;
            PlayerPrefs.SetInt("Potion", potion);
            gameObject.SetActive(false);
        }
    }
}
