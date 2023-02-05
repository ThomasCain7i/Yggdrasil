using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nametext;
    public TextMeshProUGUI dialogueText;


    public Animator animator;

    private Queue<string> sentences;
    private bool textIsOpen = false;
    //public AudioSource pageTurnAudio;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        
    }

    public void Update()
    {
        //audio not working
        //if(textIsOpen == true)
        {
            //pageTurnAudio.Play();
        }
      
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        //bool for audio play ref
        //textIsOpen = true;

        nametext.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();

        
    }

    public void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TpyeSentence(sentence));

        
    }

    IEnumerator TpyeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        //textIsOpen = false;
    }
}