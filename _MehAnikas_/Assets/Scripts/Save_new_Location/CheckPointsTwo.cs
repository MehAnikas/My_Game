using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointsTwo : MonoBehaviour
{
    Animator anim;
    public GameObject F;
    private int OnClick_Two = 0;
    void Start()
    {
        anim = GetComponent<Animator>();
        OnClick_Two = PlayerPrefs.GetInt("OnClick_Two");
        if (OnClick_Two == 1 || OnClick_Two == 2)
        {
            anim.SetInteger("Fire", 0);
        };
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerPrefs.SetInt("OnClick_Two", OnClick_Two);
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if(OnClick_Two == 1)
                {
                    anim.SetInteger("Fire", 0);
                    PlayerPrefs.SetFloat("Xpos", transform.position.x);
                    PlayerPrefs.SetFloat("Ypos", transform.position.y);
                    OnClick_Two = 2;
                }
                if (OnClick_Two == 2)
                {
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                    PlayerPrefs.SetFloat("Xpos", transform.position.x);
                    PlayerPrefs.SetFloat("Ypos", transform.position.y);
                    anim.SetInteger("Fire", 0);
                }
            }
            if (OnClick_Two == 0)
            {
                anim.SetInteger("Fire", 1);
                F.SetActive(true);
                OnClick_Two = 1;
            }
        }
        PlayerPrefs.SetInt("OnClick_Two", OnClick_Two);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            F.SetActive(false);
        }
    }




}
