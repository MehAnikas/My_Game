using UnityEngine;

public class TriggerMonologTwo : MonoBehaviour
{
    public GameObject text;
    public GameObject Anika_sprite;
    public GameObject DialogBox;
    public GameObject Black;
    private int dialog_two = 0;
    public static bool Do;

    private void Start()
    {
        dialog_two = PlayerPrefs.GetInt("Dialog_2");
    }
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Dialog_2"))
        {
            PlayerPrefs.SetInt("Dialog_2", 0);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (dialog_two == 0)
            {
                text.SetActive(true);
                Anika_sprite.SetActive(true);
                DialogBox.SetActive(true);
                Black.SetActive(true);
                dialog_two = 1;
                TriggerMonolog.Do = false;
            }
            else
            {
                gameObject.SetActive(false);
            }
            PlayerPrefs.SetInt("Dialog_2", dialog_two);
        }
    }
}
