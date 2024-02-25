using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI txtComponent;
    public string[] lines;
    public float txtSpd;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        txtComponent.text = string.Empty;
        startDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(txtComponent.text == lines[index])
            {
                nextLine();
            } 
            else
            {
                StopAllCoroutines();
                txtComponent.text = lines[index];
            }
        }
    }

    void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            txtComponent.text += c;
            yield return new WaitForSeconds(txtSpd);
        }
    }

    void nextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            txtComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
