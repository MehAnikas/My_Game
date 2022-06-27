using UnityEngine;

public class New_World : MonoBehaviour
{
    public int leveltoLoad;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            anim.SetTrigger("fade");
            TriggerMonolog.Do = false;
            PlayerPrefs.SetFloat("Xpos", transform.position.x +4);
            PlayerPrefs.SetFloat("Ypos", transform.position.y);
        }
    }
}
