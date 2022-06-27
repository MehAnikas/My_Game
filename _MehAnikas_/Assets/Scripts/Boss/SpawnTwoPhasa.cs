using UnityEngine;

public class SpawnTwoPhasa : MonoBehaviour
{
    public GameObject One_Thasa_Boss;
    public GameObject Two_Phasa_Boss;
    public void Two_Phasa()
    {
        Two_Phasa_Boss.SetActive(true);
        One_Thasa_Boss.SetActive(false);
    }
}
