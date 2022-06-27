using UnityEngine;

public class TriggerMonolgFour : MonoBehaviour
{
    public GameObject text;
    public GameObject Anika_sprite;
    public GameObject DialogBox;
    public GameObject Black;
    private int dialog_four = 0;
    public static bool Do;

    private void Start()
    {
        dialog_four = PlayerPrefs.GetInt("Dialog_4");
    }
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Dialog_4"))
        {
            PlayerPrefs.SetInt("Dialog_4", 0);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (dialog_four == 0)
            {
                text.SetActive(true);
                Anika_sprite.SetActive(true);
                DialogBox.SetActive(true);
                Black.SetActive(true);
                dialog_four = 1;
                TriggerMonolog.Do = false;
            }
            else
            {
                gameObject.SetActive(false);
            }
            PlayerPrefs.SetInt("Dialog_4", dialog_four);
        }
    }
}
