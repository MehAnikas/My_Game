using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    private int nowdamage;
    public GameObject player;
    Anika_Player oryorujie;
    public int Get;
    private bool DoubleDamage = true;


    private void Start()
    {
       damage =  PlayerPrefs.GetInt("Damage");
        Get = PlayerPrefs.GetInt("Get");
    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Damage"))
        {
            PlayerPrefs.SetInt("Damage", 1);
        }
        if (!PlayerPrefs.HasKey("Get"))
        {
            PlayerPrefs.SetInt("Get", 0);
        }
    }

    private void Update()
    {
        if (player.GetComponent<Anika_Player>().zapolnenie >= 100)
        {
            damage += 1;
            player.GetComponent<Anika_Player>().aura_hunter++;
            player.GetComponent<Anika_Player>().zapolnenie = 0;
            DoubleDamage = false;
            PlayerPrefs.SetInt("Hunter", player.GetComponent<Anika_Player>().aura_hunter);
            PlayerPrefs.SetInt("Zapolnenie", player.GetComponent<Anika_Player>().zapolnenie);
        }

        if (player.GetComponent<Anika_Player>().orujie == 2)
        {
            if (DoubleDamage == true && Get == 0)
            {
                nowdamage = damage;
                damage = nowdamage * 2;
                DoubleDamage = false;
                Get = 1;
                PlayerPrefs.SetInt("Get", Get);
            }
        }
        PlayerPrefs.SetInt("Damage", damage);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "White")
        {
            other.GetComponent<Enemy>().TakeDamagetwo(damage);
        }

        if (other.tag == "Boss")
        {
            other.GetComponent<One_Phasa>().TakeDamageBoss(damage);
        }

        if (other.tag == "Boss_Two")
        {
            other.GetComponent<Two_Phasa>().TakeDamageIST_Boss(damage);
        }
    }
}
