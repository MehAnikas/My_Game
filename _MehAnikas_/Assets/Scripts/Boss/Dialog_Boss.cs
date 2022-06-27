using System.Collections;
using UnityEngine;
using TMPro;

public class Dialog_Boss : MonoBehaviour
{
    public TextMeshProUGUI TextComponent;
    [TextArea(4, 10)]
    public string[] lines;
    public float textSpeed;
    public GameObject text;
    public GameObject Anika_sprite;
    public GameObject DialogBox;
    public GameObject Black;
    public GameObject Boss;

    public Animator anim;


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
            text.SetActive(false);
            Anika_sprite.SetActive(false);
            DialogBox.SetActive(false);
            Black.SetActive(false);
            Boss.SetActive(false);
            TriggerMonolog.Do = true;
            anim.SetTrigger("Figth_Scene");
        }
    }
}
