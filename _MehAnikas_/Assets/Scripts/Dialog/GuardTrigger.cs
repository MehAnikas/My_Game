using UnityEngine;

public class GuardTrigger : MonoBehaviour
{
    public GameObject text;
    public GameObject Anika_sprite;
    public GameObject DialogBox;
    private int dialog_7 = 0;
    public static bool Do;

    private void Start()
    {
        dialog_7 = PlayerPrefs.GetInt("Dialog_7");
    }
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Dialog_7"))
        {
            PlayerPrefs.SetInt("Dialog_7", 0);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (dialog_7 == 0)
            {
                text.SetActive(true);
                Anika_sprite.SetActive(true);
                DialogBox.SetActive(true);
                dialog_7 = 1;
                TriggerMonolog.Do = false;
            }
            else
            {
                gameObject.SetActive(false);

            }
            PlayerPrefs.SetInt("Dialog_7", dialog_7);
        }
    }
}
