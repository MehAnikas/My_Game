using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal_world : MonoBehaviour
{
    private void Start()
    {
        DialogNPC.vhod = PlayerPrefs.GetInt("VHOD");
    }
    public int leveltoLoad;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (DialogNPC.vhod == 1)
            {
                SceneManager.LoadScene(leveltoLoad);
                PlayerPrefs.SetFloat("Xpos", transform.position.x + 4);
                PlayerPrefs.SetFloat("Ypos", transform.position.y);
            }
        }
    }
}
