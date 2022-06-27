using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    Animator anim;
    public GameObject F;
    public GameObject light_;
    private int OnClick = 3;
    void Start()
    {
        anim = GetComponent<Animator>();
        OnClick = PlayerPrefs.GetInt("OnClick");
        if (OnClick == 1 || OnClick == 2)
        {
            anim.SetInteger("Fire", 0);
            light_.SetActive(true);
        };
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (OnClick == 1)
                {
                    anim.SetInteger("Fire", 0);
                    PlayerPrefs.SetFloat("Xpos", transform.position.x);
                    PlayerPrefs.SetFloat("Ypos", transform.position.y);
                    OnClick = 2;
                }
                if (OnClick == 2)
                {
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                    PlayerPrefs.SetFloat("Xpos", transform.position.x);
                    PlayerPrefs.SetFloat("Ypos", transform.position.y);
                    anim.SetInteger("Fire", 0);
                }
            }
            if (OnClick == 0)
            {
                anim.SetInteger("Fire", 1);
                F.SetActive(true);
                OnClick = 1;
            }
        }
        PlayerPrefs.SetInt("OnClick", OnClick);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            F.SetActive(false);
            anim.SetInteger("Fire", 0);
        }
    }

}
