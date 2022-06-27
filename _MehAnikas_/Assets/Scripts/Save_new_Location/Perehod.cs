using UnityEngine;
using UnityEngine.SceneManagement;

public class Perehod : MonoBehaviour
{
    public GameObject tp;
    public void Teleportation()
    {
        SceneManager.LoadScene(tp.GetComponent<New_World>().leveltoLoad);
        TriggerMonolog.Do = true;
    }

}
