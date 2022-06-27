using UnityEngine;

public class Torgovec : MonoBehaviour
{
    public GameObject Torg;
    public GameObject Torg_minus;
    public GameObject Torg_plus;
    public GameObject Torg_ots;
    public GameObject player;
    private bool OnStay;
    private int Torgi = 0;


    private void Start()
    {
        OnStay = true;
        Torgi = PlayerPrefs.GetInt("Torg");
    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Torg"))
        {
            PlayerPrefs.SetInt("Torg", 0);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (OnStay == true)
            {
                Torg.SetActive(true);
            }
            if (OnStay == false)
            {
                Torg.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                OnStay = false;
                Torg.SetActive(false);
                if (player.GetComponent<Anika_Player>().coins >= 500 && Torgi == 0)
                {
                    player.GetComponent<Anika_Player>().coins -= 500;
                    PlayerPrefs.SetInt("Coins", player.GetComponent<Anika_Player>().coins);
                    player.GetComponent<Anika_Player>().orujie = 2;
                    PlayerPrefs.SetInt("Oryzhie", player.GetComponent<Anika_Player>().orujie);
                    Torg.SetActive(false);
                    Torg_plus.SetActive(true);
                    Torg_ots.SetActive(false);
                    Torgi = 1;
                }
                if(Torgi == 1)
                {
                    Torg.SetActive(false);
                    Torg_ots.SetActive(true);
                }
                else
                {
                    Torg.SetActive(false);
                    Torg_ots.SetActive(true);
                    Torg_minus.SetActive(true);
                }
            }
        }
        PlayerPrefs.SetInt("Torg", Torgi);
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            OnStay = true;
            Torg.SetActive(false);
            Torg_minus.SetActive(false);
            Torg_plus.SetActive(false);
            Torg_ots.SetActive(false);
        }
    }
}
