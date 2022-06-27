using UnityEngine;

public class TriggerMonolog : MonoBehaviour
{
    public GameObject text;
    public GameObject Anika_sprite;
    public GameObject DialogBox;
    public GameObject Black;
    private int dialog_one = 0;
    public static bool Do;

    private void Start()
    {
        dialog_one = PlayerPrefs.GetInt("Dialog_1");
    }
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Dialog_1"))
        {
            PlayerPrefs.SetInt("Dialog_1", 0);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (dialog_one == 0)
            {
                text.SetActive(true);
                Anika_sprite.SetActive(true);
                DialogBox.SetActive(true);
                Black.SetActive(true);
                dialog_one = 1;
                Do = false;
            }
            else
            {
                gameObject.SetActive(false);
            }
            PlayerPrefs.SetInt("Dialog_1", dialog_one);
        }
    }
}
