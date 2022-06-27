using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointsThree : MonoBehaviour
{
    Animator anim;
    public GameObject F;
    private int OnClick_Three = 0;
    void Start()
    {
        anim = GetComponent<Animator>();
        OnClick_Three = PlayerPrefs.GetInt("OnClick_Three");
        if (OnClick_Three == 1 || OnClick_Three == 2)
        {
            anim.SetInteger("Fire", 0);
        };
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerPrefs.SetInt("OnClick_Three", OnClick_Three);
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (OnClick_Three == 1)
                {
                    anim.SetInteger("Fire", 0);
                    PlayerPrefs.SetFloat("Xpos", transform.position.x);
                    PlayerPrefs.SetFloat("Ypos", transform.position.y);
                    OnClick_Three = 2;
                }
                if (OnClick_Three == 2)
                {
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                    PlayerPrefs.SetFloat("Xpos", transform.position.x);
                    PlayerPrefs.SetFloat("Ypos", transform.position.y);
                    anim.SetInteger("Fire", 0);
                }
            }
            if (OnClick_Three == 0)
            {
                anim.SetInteger("Fire", 1);
                F.SetActive(true);
                OnClick_Three = 1;
            }
        }
        PlayerPrefs.SetInt("OnClick_Three", OnClick_Three);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            F.SetActive(false);
        }
    }
}
