using UnityEngine;
using System.Collections;

public class One_Phasa : MonoBehaviour
{
    public Transform Pusk1;
    public Transform Pusk2;
    public Transform Pusk3;
    public GameObject Bullet;
    public GameObject Player;
    public int Boss_HP_One_Phases;
    private int pul;
    private bool Strike;
    public float startTime;
    public float startSpeedTime;
    private float postTime;
    public float StopTime;
    private float timeStopTime;

    Animator anim;
    public Animator anim_cam;
    public Animator anim_canv;
    public AudioSource audioPerehod;

    private void Start()
    {
        postTime = startTime;
        timeStopTime = 0;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Boss_HP_One_Phases <= 0)
        {
            anim.ResetTrigger("StartAttack");
            anim.ResetTrigger("Stay");
            anim.SetTrigger("Perehod");
            anim_cam.SetTrigger("Peregod");
            anim_canv.SetTrigger("Slep");
        }
        else
        {
            if (timeStopTime <= 0)
            {
                anim.ResetTrigger("Stay");
                anim.SetTrigger("StartAttack");
                postTime -= Time.deltaTime;
                var dist = Vector2.Distance(Player.transform.position, transform.position);
                if (dist >= 50)
                {
                    if (postTime <= 0)
                    {
                        StartCoroutine(Normal());
                        postTime = startTime;
                    }
                }
                else
                {
                    if (postTime <= 0)
                    {
                        StartCoroutine(Speed());
                        postTime = startSpeedTime;
                    }
                }
                if (pul == 0 && Strike == true)
                {
                    Instantiate(Bullet, Pusk1.position, Quaternion.identity);
                    Strike = false;
                }
                if (pul == 1 && Strike == true)
                {
                    Instantiate(Bullet, Pusk2.position, Quaternion.identity);
                    Strike = false;
                }
                if (pul == 2 && Strike == true)
                {
                    Instantiate(Bullet, Pusk3.position, Quaternion.identity);
                    Strike = false;
                }
                Strike = false;
                StartCoroutine(Stop());
            }
            else
            {
                anim.SetTrigger("Stay");
                anim.ResetTrigger("StartAttack");
                timeStopTime -= Time.deltaTime;
            }
        }
    }

    public void TakeDamageBoss(int damage)
    {
        Boss_HP_One_Phases -= damage;
    }

     IEnumerator Normal()
    {
        yield return new WaitForSeconds(0.7f);
        pul = Random.Range(0, 3);
        Strike = true;
    }

    IEnumerator Speed()
    {
        yield return new WaitForSeconds(0.2f);
        pul = Random.Range(0, 3);
        Strike = true;
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(3f);
        timeStopTime = StopTime;
        anim.ResetTrigger("StartAttack");
    }

    public void Perehod()
    {
        audioPerehod.Play();
        transform.position = new Vector2(transform.position.x + 2, transform.position.y);
    }
}
