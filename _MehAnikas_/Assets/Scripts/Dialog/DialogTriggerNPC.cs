using UnityEngine;

public class DialogTriggerNPC : MonoBehaviour
{
    public GameObject F_pas;
    private bool Stay = false;
    public GameObject Miles_sp;
    public GameObject Miles_Mil;
    public GameObject Miles_Trigger;
    Animator anim;


    public GameObject text;
    public GameObject Anika_sprite;
    public GameObject DialogBox;
    public GameObject Black;
    private int dialog_6 = 0;



    public void Start()
    {
        F_pas.SetActive(false);
        anim = Miles_Mil.GetComponent<Animator>();
        anim.SetInteger("Angry", 1);
        anim.SetInteger("Obr", 1);
        dialog_6 = PlayerPrefs.GetInt("Dialog_6");
    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Dialog_6"))
        {
            PlayerPrefs.SetInt("Dialog_6", 0);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Stay = true;
                if (Stay == true)
                {
                    F_pas.SetActive(false);
                    if (dialog_6 == 0)
                    {
                        Miles_Trigger.SetActive(true);
                        text.SetActive(true);
                        Miles_sp.SetActive(true);
                        Anika_sprite.SetActive(true);
                        DialogBox.SetActive(true);
                        Black.SetActive(true);
                        dialog_6 = 1;
                        TriggerMonolog.Do = false;
                    }
                    else
                    {
                        Miles_Mil.SetActive(false);
                    }
                    PlayerPrefs.SetInt("Dialog_6", dialog_6);
                }
            }
            else
            {
                if (Stay == false)
                {
                    F_pas.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            F_pas.SetActive(false);
            Stay = false;
        }
    }
}
