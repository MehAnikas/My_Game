using UnityEngine;

public class NeroTrigger : MonoBehaviour
{
    public GameObject text;
    public GameObject text_Check;
    public GameObject Anika_sprite;
    public GameObject DialogBox;
    public GameObject Black;
    private int dialog_check_two = 0;
    public GameObject F_dok;
    public GameObject Nero_sprite;


    public int dostup_dok = 0;
    public int Boss = 0;

    private void Start()
    {
        dialog_check_two = PlayerPrefs.GetInt("Dialog_dok");
        F_dok.SetActive(false);
        dostup_dok = PlayerPrefs.GetInt("dostup_dok");
        Boss = PlayerPrefs.GetInt("Boss");
        if (Boss == 1)
        {
            text_Check.GetComponent<Doctor>().portal.SetActive(true);
        }

    }
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Dialog_dok"))
        {
            PlayerPrefs.SetInt("Dialog_dok", 0);
        }
        if (!PlayerPrefs.HasKey("dostup_dok"))
        {
            PlayerPrefs.SetInt("dostup_dok", 0);
        }
        if (!PlayerPrefs.HasKey("Boss"))
        {
            PlayerPrefs.SetInt("Boss", 0);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (dostup_dok == 1)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (dialog_check_two == 0)
                    {
                        Nero_sprite.SetActive(true);
                        text_Check.SetActive(false);
                        text.SetActive(true);
                        Anika_sprite.SetActive(true);
                        DialogBox.SetActive(true);
                        Black.SetActive(true);
                        F_dok.SetActive(false);
                        dialog_check_two = 1;
                        TriggerMonolog.Do = false;

                    }
                    else if (dialog_check_two == 1 && Treasure.potion == 1)
                    {
                        text.SetActive(false);
                        Nero_sprite.SetActive(true);
                        text_Check.SetActive(true);
                        Anika_sprite.SetActive(true);
                        DialogBox.SetActive(true);
                        F_dok.SetActive(false);
                        Black.SetActive(true);
                        dialog_check_two = 2;
                        TriggerMonolog.Do = false;
                    }
                    else
                    {
                        F_dok.SetActive(false);
                    }
                    PlayerPrefs.SetInt("Dialog_dok", dialog_check_two);
                }
                else
                {
                    F_dok.SetActive(true);
                }
            }
            PlayerPrefs.SetInt("dostup_dok", dostup_dok);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            F_dok.SetActive(false);
        }
    }

}
