using UnityEngine;
using UnityEngine.SceneManagement;

public class Nezer_World : MonoBehaviour
{
    public int leveltoLoad;
    public GameObject lvl;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<Anika_Player>().aura_hunter >= 6)
            {
                SceneManager.LoadScene(leveltoLoad);
                PlayerPrefs.SetFloat("Xpos", transform.position.x + 4);
                PlayerPrefs.SetFloat("Ypos", transform.position.y);
            }
            else
            {
                lvl.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            lvl.SetActive(false);
        }
    }

}
