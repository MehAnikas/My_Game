using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyutaro : MonoBehaviour
{
    private GameObject player;
    private int speed_clinock = 10;
    private int damage_gyt = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (Two_Phasa.Right == true)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed_clinock * Time.deltaTime;
        StartCoroutine(Destroy_Clinock());
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<Anika_Player>().health -= damage_gyt;
        }
    }


    IEnumerator Destroy_Clinock()
    {
        yield return new WaitForSeconds(15f);
        Destroy(this.gameObject);
    }
}
