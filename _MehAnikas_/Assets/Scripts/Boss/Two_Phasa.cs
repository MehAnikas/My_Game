using System.Collections;
using UnityEngine;

public class Two_Phasa : MonoBehaviour
{
    public Transform[] tp_sword;
    private int damage_sword = 1;

    public int health_Boss_Two_Phasa;
    private Vector3 Attack_position;

    private GameObject player;

    Animator anim;

    public Animator camera_tryas;
    public float startTiime;
    public float posTime;
    private bool Attack_;

    private int rnd;


    public float StartAttack;
    public float PostAttack;
    private bool II;

    private bool Calc;
    private int shet = 0;
    private int ind;

    private int ind_gyt = 0;

    private GameObject shield;


    public Transform megaluch;
    public GameObject megaLuch;

    public Transform[] gyt_pos;
    public GameObject gyutaro;
    private bool Gyt_Clinock;
    public static bool Right;

    public Transform Centr;
    public GameObject Two_Luch_1;
    public GameObject Two_Luch_2;

    public GameObject DialogBox;
    public GameObject TextMonolog;
    public GameObject Anika_sprite;
    public GameObject Black;
    void Start()
    {
        anim = GetComponent<Animator>();
        posTime = startTiime;
        PostAttack = StartAttack;
        player = GameObject.FindGameObjectWithTag("Player");
        shield = player.transform.Find("Shield").gameObject;
        camera_tryas.ResetTrigger("Peregod");
        camera_tryas.SetTrigger("Stay_Cam");
    }


    void Update()
    {
        if (player.transform.position.x <= gameObject.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            Right = true;
        }

        if (player.transform.position.x >= gameObject.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            Right = false;
        }
        if (posTime >= 0 && Attack_ == true)
        {
            posTime -= Time.deltaTime;
        }
        if (health_Boss_Two_Phasa <= 0)
        {
            DialogBox.SetActive(true);
            TextMonolog.SetActive(true);
            Anika_sprite.SetActive(true);
            Black.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
        {
            if (posTime <= 0 && Attack_ == true)
            {
                Attack_ = false;
                Neydacha();
            }
            if (rnd == 0 && II == true)
            {
                Calc = true;
            }
            if (Calc == true)
            {
                anim.SetTrigger("TP");
                II = false;
            }
            if (rnd == 1 && II == true)
            {
                transform.position = megaluch.position;
                anim.ResetTrigger("Stay");
                anim.SetTrigger("MegaLuch");
                camera_tryas.SetTrigger("Mega_Cam");
                II = false;
                StartCoroutine(Nach());
            }
            if (rnd == 2 && II == true)
            {
                Gyt_Clinock = true;
                 II = false;
            }
            if (Gyt_Clinock == true)
            {
                anim.SetTrigger("Gyutaro");
                transform.position = gyt_pos[ind_gyt].position;
                StartCoroutine(Stop_Gytaro());
            }
            if (rnd == 3 && II == true)
            {
                anim.SetTrigger("Two_Luch");
                transform.position = Centr.position;
                II = false;
            }
            if (shet % 2 == 0)
            {
                Attack_position = new Vector3(player.transform.position.x + 2, player.transform.position.y, 0);
            }
            if (shet % 3 == 0)
            {
                Attack_position = new Vector3(player.transform.position.x - 2, player.transform.position.y, 0);
            }
            if (PostAttack <= 0)
            {
                StartCoroutine(TPro());
                PostAttack = StartAttack;
            }
            else
            {
                PostAttack -= Time.deltaTime;
            }
        }
    }

    public void Teleport_BOSS()
    {
        gameObject.transform.position = Attack_position;
        anim.ResetTrigger("TP");
        anim.SetTrigger("TP_Out");
    }

    IEnumerator TPro()
    {
        yield return new WaitForSeconds(3f);
        rnd = Random.Range(0, 4);
        II = true;
        Calc = false;
        shet = 0;
        Gyt_Clinock = false;
    }

    public void Attack()
    {
        anim.ResetTrigger("TP");
        anim.SetTrigger("Attack");
        anim.ResetTrigger("TP_Out");
        ind = Random.Range(0, 5);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && !shield.activeInHierarchy)
        {
            shet += 1;
            player.GetComponent<Anika_Player>().health -= damage_sword;
            Attack_ = true;
            if (posTime <= 0)
            {
                gameObject.transform.position = tp_sword[ind].position;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                posTime = startTiime;
                anim.ResetTrigger("Attack");
                anim.SetTrigger("Stay");
            }
        }
    }

    public void Attack_Sword()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        Attack_ = true;
        shet = shet + 1;
        StartCoroutine(Stop_Combo());

    }

    public void Neydacha()
    {
        if (posTime <= 0)
        {
            shet += 1;
            gameObject.transform.position = tp_sword[ind].position;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            posTime = startTiime;
            anim.ResetTrigger("Attack");
            anim.SetTrigger("Stay");
        }
    }

    public void SpawnLuch()
    {
        Instantiate(megaLuch);
    }

    IEnumerator Nach()
    {
        yield return new WaitForSeconds(5f);
        anim.SetTrigger("Stay");
        camera_tryas.ResetTrigger("Mega_Cam");
        camera_tryas.SetTrigger("Stay_Cam");
    }

    IEnumerator Stop_Combo()
    {
        yield return new WaitForSeconds(5f);
        Calc = false;
    }


    IEnumerator Stop_Gytaro()
    {
        yield return new WaitForSeconds(5f);
        Gyt_Clinock = false;
    }

    public void TakeDamageIST_Boss(int damage)
    {
        health_Boss_Two_Phasa -= damage;
    }


    public void Clinock_Gyutaro()
    {
        Instantiate(gyutaro, gameObject.transform.position, Quaternion.identity);
        ind_gyt = Random.Range(0, 7);
        anim.ResetTrigger("Gyutaro");
        anim.SetTrigger("Stay");
    }

    public void Two()
    {
        Two_Luch_1.SetActive(true);
        Two_Luch_2.SetActive(true);
        anim.ResetTrigger("Two_Luch");
        anim.SetTrigger("Stay");
    }
}
