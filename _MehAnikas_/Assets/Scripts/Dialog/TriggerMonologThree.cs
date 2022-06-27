using UnityEngine;

public class TriggerMonologThree : MonoBehaviour
{
    public GameObject text;
    public GameObject Anika_sprite;
    public GameObject DialogBox;
    public GameObject Black;
    private int dialog_three = 0;
    public static bool Do;

    private void Start()
    {
        dialog_three = PlayerPrefs.GetInt("Dialog_3");
    }
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Dialog_3"))
        {
            PlayerPrefs.SetInt("Dialog_3", 0);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (dialog_three == 0)
            {
                text.SetActive(true);
                Anika_sprite.SetActive(true);
                DialogBox.SetActive(true);
                Black.SetActive(true);
                dialog_three = 1;
                TriggerMonolog.Do = false;
            }
            else
            {
                gameObject.SetActive(false);
            }
            PlayerPrefs.SetInt("Dialog_3", dialog_three);
        }
    }
}
