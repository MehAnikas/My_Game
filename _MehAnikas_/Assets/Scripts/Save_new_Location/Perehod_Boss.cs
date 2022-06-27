using UnityEngine;
using UnityEngine.SceneManagement;

public class Perehod_Boss : MonoBehaviour
{
    public GameObject location_boss;
    public void Teleportation_Boss()
    {
        SceneManager.LoadScene(location_boss.GetComponent<Home>().leveltoLoad);
        TriggerMonolog.Do = true;
    }
}
