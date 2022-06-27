using UnityEngine;

public class Luch : MonoBehaviour
{
    private int damage_Luch = 6;
    private GameObject player;
    public Animator anim_cam;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim_cam.SetTrigger("Two_Cam");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<Anika_Player>().health -= damage_Luch;
        }
    }

    public void End_Two()
    {
        this.gameObject.SetActive(false);
        anim_cam.SetTrigger("Stay_Cam");
    }
}
