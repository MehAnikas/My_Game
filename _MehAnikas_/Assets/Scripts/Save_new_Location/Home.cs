using UnityEngine;

public class Home : MonoBehaviour
{
    public GameObject press;
    public int leveltoLoad;
    public Animator anim;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            press.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                anim.SetTrigger("Boss_Scene");
                PlayerPrefs.SetFloat("Xpos", transform.position.x + 4);
                PlayerPrefs.SetFloat("Ypos", transform.position.y);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            press.SetActive(false);
        }
    }
}
