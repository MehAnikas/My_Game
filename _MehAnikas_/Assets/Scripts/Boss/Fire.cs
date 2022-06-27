using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour
{
    private int speedfire = 15;
    public int damage_fire;
    private GameObject player;

    private void Start()
    {
        StartCoroutine(Death());
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        transform.position += transform.right * speedfire * Time.deltaTime;
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<Anika_Player>().health -= damage_fire;
            Destroy(this.gameObject);
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(20f);
        Destroy(this.gameObject);
    }

}
