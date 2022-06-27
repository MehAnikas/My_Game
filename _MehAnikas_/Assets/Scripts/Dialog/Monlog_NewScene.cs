using UnityEngine;

public class Monlog_NewScene : MonoBehaviour
{
    public GameObject text;
    public GameObject Anika_sprite;
    public GameObject DialogBox;
    public GameObject Black;
    private int dialog_5 = 0;
    public static bool Do;

    private void Start()
    {
        dialog_5 = PlayerPrefs.GetInt("Dialog_5");
    }
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Dialog_5"))
        {
            PlayerPrefs.SetInt("Dialog_5", 0);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (dialog_5 == 0)
            {
                text.SetActive(true);
                Anika_sprite.SetActive(true);
                DialogBox.SetActive(true);
                Black.SetActive(true);
                dialog_5 = 1;
                TriggerMonolog.Do = false;
            }
            else
            {
                gameObject.SetActive(false);

            }
            PlayerPrefs.SetInt("Dialog_5", dialog_5);
        }
    }
}
