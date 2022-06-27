using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [Header("Ходьба врага")]
    public float speed;
    public float distance;
    public GameObject player;
    public GameObject enemy;
    private bool moovingRight = true;
    public int health_enemy;
    public Transform groundDetection;

    [Header("Атака врага")]
    Animator anim;
    public float startAttack;
    private float timeAttack;
    Anika_Player health;
    public int start_hp;
    public int damage_enemy;
    public GameObject shield;
    public int plusCoins;
    public int plusZapolnenie;
    private bool hodit;
    public TextMeshProUGUI hp_enemy;

private void Start()
    {
        anim = GetComponent<Animator>();
        hodit = true;
        hp_enemy.text = start_hp + "/" + health_enemy.ToString();
    }

    private void Update()
    {
        hp_enemy.text = start_hp + "/" + health_enemy.ToString();
        hp_enemy.transform.eulerAngles = new Vector3(0, 0, 0);
        timeAttack -= Time.deltaTime;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (moovingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moovingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moovingRight = true;
            }
            hodit = true;
        }

        var dist = Vector2.Distance(player.transform.position, enemy.transform.position);
        if (dist <= 6)
        {
            transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position, speed * Time.deltaTime);
            if (player.transform.position.x <= enemy.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);

            }
            if (player.transform.position.x >= enemy.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }

        if (health_enemy <= 0)
        {
            Destroy(this.gameObject);
            player.GetComponent<Anika_Player>().coins += plusCoins;
            PlayerPrefs.SetInt("Coins", player.GetComponent<Anika_Player>().coins);
            player.GetComponent<Anika_Player>().zapolnenie += plusZapolnenie;
            PlayerPrefs.SetInt("Zapolnenie", player.GetComponent<Anika_Player>().zapolnenie);
        }

        if (hodit)
        {
            anim.SetInteger("Attacks", 1);
        }
        else
        {
            anim.SetInteger("Attacks", 0);
        }
    }


    public void TakeDamagetwo(int damage)
    {
        health_enemy -= damage;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && !shield.activeInHierarchy)
        {
            if (timeAttack <= 0)
            {
                player.GetComponent<Anika_Player>().health -= damage_enemy;
                timeAttack = startAttack;
            }
                anim.SetInteger("Attacks", 0);
            hodit = false;
        }
        else
        {
            hodit = true;
            anim.SetInteger("Attacks", 1);
        }
    }


}
