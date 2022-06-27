using UnityEngine;

public class MegaLuch : MonoBehaviour
{
    private int damage_Luch = 1;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<Anika_Player>().health -= damage_Luch;
        }
    }

    public void End()
    {
        Destroy(this.gameObject);
    }
}
