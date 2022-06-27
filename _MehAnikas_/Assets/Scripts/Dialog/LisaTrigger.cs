using UnityEngine;

public class LisaTrigger : MonoBehaviour
{
    public GameObject text;
    public GameObject text_Check;
    public GameObject Anika_sprite;
    public GameObject DialogBox;
    public GameObject player;
    public GameObject Black;
    private int dialog_check = 0;
    private bool Check = false;

    Animator anim;
    public GameObject F_press_key;
    public GameObject Lisa_sprite;

    public GameObject Doctor;

    private void Start()
    {
        dialog_check = PlayerPrefs.GetInt("Dialog_8");
        anim = GetComponent<Animator>();
        anim.SetInteger("Lisosavr", 1);

        F_press_key.SetActive(false);
    }
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Dialog_8"))
        {
            PlayerPrefs.SetInt("Dialog_8", 0);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (player.GetComponent<Anika_Player>().aura_hunter >= 1)
                {
                    Check = true;
                }
                if (dialog_check == 0)
                {
                    Lisa_sprite.SetActive(true);
                    text_Check.SetActive(false);
                    text.SetActive(true);
                    Anika_sprite.SetActive(true);
                    DialogBox.SetActive(true);
                    Black.SetActive(true);
                    F_press_key.SetActive(false);
                    dialog_check = 1;
                    TriggerMonolog.Do = false;
                    player.GetComponent<Anika_Player>().razhresh = 1;
                    PlayerPrefs.SetInt("Razresh", player.GetComponent<Anika_Player>().razhresh);
                    anim.SetInteger("Lisosavr", 0);

                }
                else if (dialog_check == 1 && Check == true)
                {
                    anim.SetInteger("Lisosavr", 1);
                    text.SetActive(false);
                    Lisa_sprite.SetActive(true);
                    text_Check.SetActive(true);
                    Anika_sprite.SetActive(true);
                    DialogBox.SetActive(true);
                    F_press_key.SetActive(false);
                    Black.SetActive(true);
                    dialog_check = 2;
                    TriggerMonolog.Do = false;
                    Doctor.GetComponent<NeroTrigger>().dostup_dok = 1;
                    PlayerPrefs.SetInt("dostup_dok", Doctor.GetComponent<NeroTrigger>().dostup_dok);
                }
                else
                {
                    anim.SetInteger("Lisosavr", 1);
                    F_press_key.SetActive(false);
                }
                PlayerPrefs.SetInt("Dialog_8", dialog_check);
            }
            else
            {
                F_press_key.SetActive(true);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            F_press_key.SetActive(false);
        }
    }
}
