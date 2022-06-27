using UnityEngine;

public class Boss_Trigger : MonoBehaviour
{
    public GameObject txt;
    public GameObject Anika_sprite;
    public GameObject Boss_sprite;
    public GameObject DialogBox;
    public GameObject Black;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            txt.SetActive(true);
            Anika_sprite.SetActive(true);
            Boss_sprite.SetActive(true);
            DialogBox.SetActive(true);
            Black.SetActive(true);
            TriggerMonolog.Do = false;
        }
    }
}
