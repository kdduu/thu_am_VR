using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogSystem : MonoBehaviour
{
    [SerializeField]
    private SpeakerUI[] speakers;
    [SerializeField]
    private DialogData[] dialogs;
    [SerializeField]
    private bool DialogInit = true;
    [SerializeField]
    private bool dialogsDB = false;

    public int currentDialogIndex = -1;
    public int currentSpeakerIndex = 0;
    public float typingSpeed = 0.1f;
    public bool isTypingEffect = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void SetActiveObjects (SpeakerUI speaker,bool visible)
    {
        speaker.imgDialog.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.textDialog.gameObject.SetActive(visible);
        speaker.objectArrow.SetActive(false);

        Color color = speaker.imgCharachter.color;
        if(visible)
        {
            color.a = 1;
        }
        else
        {
            color.a = 0.2f;
        }
        speaker.imgCharachter.color = color;
    }

    private void SetAllClose()
    {
        for(int i =0;i<speakers.Length;i++)
        {
            SetActiveObjects(speakers[i], false);
        }
    }

    private void SetNextDialog(int currentIndex)
    {
        SetAllClose();
        currentDialogIndex = currentIndex;
        currentSpeakerIndex = dialogs[currentDialogIndex].speakerUIindex;
        SetActiveObjects(speakers[currentSpeakerIndex], true);
        speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name;
        StartCoroutine("OnTypingText");
    }

    private IEnumerator OnTypingText()
    {
        int index = 0;
        isTypingEffect = true;

        if(dialogs[currentDialogIndex].characterPath != "None")
        {
            speakers[currentSpeakerIndex].imgCharachter.sprite =
                Resources.Load<Sprite>(dialogs[currentDialogIndex].characterPath);
        }

        while(index<dialogs[currentDialogIndex].dialogue.Length+1)
        {
            speakers[currentSpeakerIndex].textDialog.text =
                dialogs[currentDialogIndex].dialogue.Substring(0, index);
            index++;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTypingEffect = false;

        speakers[currentSpeakerIndex].objectArrow.SetActive(true);
    }

    public bool UpdataDialog(int currentIndex,bool InitType)
    {
        if(DialogInit == true && InitType == true)
        {
            SetAllClose();
            SetNextDialog(currentIndex);
            DialogInit = false;
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(isTypingEffect == true)
            {
                isTypingEffect = false;
                StopCoroutine("OnTypingText");
                speakers[currentIndex].textDialog.text = dialogs[currentDialogIndex].dialogue;
                speakers[currentSpeakerIndex].objectArrow.SetActive(true);

                return false;
            }

            if(dialogs[currentDialogIndex].nextindex != -100)
            {
                SetNextDialog(dialogs[currentDialogIndex].nextindex);
            }
            else
            {
                SetAllClose();
                DialogInit = true;
                return true;
            }
        }

        return false;
    }

    private void Awake()
    {
        SetAllClose();
    }

    [System.Serializable]
    public struct SpeakerUI
    {
        public Image imgCharachter;
        public Image imgDialog;
        public Text textName;
        public Text textDialog;
        public GameObject objectArrow;
    }

    [System.Serializable]
   public struct DialogData
    {
        public int index;
        public int speakerUIindex;
        public string name;
        public string dialogue;
        public string characterPath;
        public int tweenType;
        public int nextindex;
    }
}
