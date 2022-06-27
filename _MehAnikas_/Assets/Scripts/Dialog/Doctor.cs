using System.Collections;
using UnityEngine;
using TMPro;

public class Doctor : MonoBehaviour
{
    public TextMeshProUGUI TextComponent;
    [TextArea(4, 10)]
    public string[] lines;
    public float textSpeed;
    public GameObject text;
    public GameObject Anika_normal;
    public GameObject DialogBox;
    public GameObject Black;
    public GameObject Anika_smile;
    public GameObject Anika_scared;
    public GameObject Doc_sprite;
    public GameObject Dock;
    public GameObject portal;
    public int sp;
    public int sp_1;
    public int sp_2;
    public int sp_portal;


    private int index;
    void Start()
    {
        TextComponent.text = string.Empty;
        StartDialog();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TextComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                TextComponent.text = lines[index];
            }
            if (index == sp)
            {
                Anika_normal.SetActive(false);
                Anika_smile.SetActive(true);
            }

            if (index == sp_1)
            {
                Anika_scared.SetActive(true);
                Anika_smile.SetActive(false);
            }

            if (index == sp_2)
            {
                Anika_normal.SetActive(true);
                Anika_scared.SetActive(false);
            }

            if (index == sp_portal)
            {
                portal.SetActive(true);
                Dock.GetComponent<NeroTrigger>().Boss = 1;
                PlayerPrefs.SetInt("Boss", Dock.GetComponent<NeroTrigger>().Boss);

            }

        }
    }

    void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            TextComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            TextComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Doc_sprite.SetActive(false);
            text.SetActive(false);
            Anika_normal.SetActive(false);
            Anika_scared.SetActive(false);
            Anika_smile.SetActive(false);
            DialogBox.SetActive(false);
            Black.SetActive(false);
            Doc_sprite.SetActive(false);
            TriggerMonolog.Do = true;
        }
    }
}
