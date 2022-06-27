using System.Collections;
using UnityEngine;
using TMPro;

public class DialogNPC : MonoBehaviour
{
    public TextMeshProUGUI TextComponent;
    [TextArea(4, 10)]
    public string[] lines;
    public float textSpeed;
    public GameObject text;
    public GameObject Anika_normal;
    public GameObject DialogBox;
    public GameObject Black;
    public GameObject Anika_surprise;
    public GameObject Anika_scared;
    public GameObject Miles;
    public GameObject Miles_sprite;
    Animator anim;
    public int sp;
    public int sp_1;
    public int sp_2;
    public int sp_3;
    public int sp_4;
    public int sp_5;
    public int sp_6;
    public static int vhod;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        vhod = PlayerPrefs.GetInt("VHOD");
        anim = Miles.GetComponent<Animator>();
        TextComponent.text = string.Empty;
        StartDialog();
    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("VHOD"))
        {
            PlayerPrefs.SetInt("VHOD", 0);
        }
    }

    // Update is called once per frame
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
                Anika_surprise.SetActive(true);
                Anika_scared.SetActive(false);
            }
            if (index == sp_1)
            {
                Anika_normal.SetActive(true);
                Anika_surprise.SetActive(false);
                Anika_scared.SetActive(false);
            }
            if (index == sp_2)
            {
                Anika_normal.SetActive(false);
                Anika_surprise.SetActive(true);
                Anika_scared.SetActive(false);
            }
            if (index == sp_3)
            {
                Anika_normal.SetActive(false);
                Anika_surprise.SetActive(false);
                Anika_scared.SetActive(false);
                text.SetActive(false);
                Miles_sprite.SetActive(false);
                DialogBox.SetActive(true);
                Black.SetActive(false);
                anim.SetInteger("Angry", 0);
            }
            if (index == sp_4)
            {
                Anika_normal.SetActive(false);
                Anika_surprise.SetActive(false);
                Anika_scared.SetActive(true);
                text.SetActive(true);
                DialogBox.SetActive(true);
                Black.SetActive(true);
                Miles_sprite.SetActive(true);
                anim.SetInteger("Angry", 1);
            }
            if (index == sp_5)
            {
                Anika_normal.SetActive(false);
                Anika_surprise.SetActive(false);
                Anika_scared.SetActive(false);
                text.SetActive(false);
                DialogBox.SetActive(true);
                Black.SetActive(false);
                Miles_sprite.SetActive(false);
                anim.SetInteger("Obr", 0);
            }
            if (index == sp_6)
            {
                Anika_normal.SetActive(false);
                Anika_surprise.SetActive(false);
                Anika_scared.SetActive(true);
                text.SetActive(true);
                DialogBox.SetActive(true);
                Black.SetActive(true);
                Miles_sprite.SetActive(true);
                anim.SetInteger("Obr", 1);
            }

        }
        PlayerPrefs.SetInt("VHOD", vhod);
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
            Miles_sprite.SetActive(false);
            text.SetActive(false);
            Anika_normal.SetActive(false);
            Anika_scared.SetActive(false);
            DialogBox.SetActive(false);
            Black.SetActive(false);
            Anika_surprise.SetActive(false);
            TriggerMonolog.Do = true;
            vhod = 1;
            PlayerPrefs.SetInt("VHOD", vhod);
        }
    }
}
