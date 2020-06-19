using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;
using UnityEngine.UI;
using System.Xml;

public class DialogueReader : MonoBehaviour
{
    //[SerializeField] AudioSource pageClicker = null;
    //Remember to set the AudioClip in the Source
    private List<string> speakers;
    public TextMeshProUGUI speaker = null;
    [SerializeField] TextMeshProUGUI dialogue = null;

    private string lastLine;
    private string currentSpeaker;
    public CharacterLibrary lib;
    public AnimationLibrary anilib;
    public int scriptLength;
    private bool UIShown = false;
    private int x;
    //Make the shake look better and Fonts as well as whatever else bear asked
    void Update()
    {
        if (Input.GetKeyDown("return") || Input.GetKeyDown("space"))
        {
            //speaker.text = "";
            //dialogue.text = "";
            StartCoroutine(SetDialogue());
            //pageClicker.Play();
        }
    }


    IEnumerator SetDialogue()
    {
        List<CharacterLibrary.Character> charas = lib.Characters;
        List<AnimationLibrary.Animations> anims = anilib.animationList;
        speakers = lib.charNames;

        // Create an instance of StreamReader to read from a file.
        // The using statement also closes the StreamReader.

        using (StreamReader sr = new StreamReader("Assets/Scripts/TestFile.txt"))
        {
            string currentLine;
            while ((currentLine = sr.ReadLine()) != null)
            {
                x = 0;
                if (currentLine == "FadeOut")
                {
                    speaker.text = "";
                    dialogue.text = "";
                }
                // Read and display lines from the file until the end of 
                // the file is reached. Use the the space below 
                foreach (AnimationLibrary.Animations anima in anims)
                {

                    if (currentLine == anima.animName)
                    {

                        if (anima.anim != null)
                        {
                            anima.anim.Play();
                            yield return new WaitForSeconds(anima.anim.clip.length);
                            x = 1;

                        }
                        else if (anima.animClip != null)
                        {
                            foreach (CharacterLibrary.Character cha in charas)
                            {
                                if (cha.name == currentSpeaker && lastLine != "Camera" && currentLine != "Shake")
                                {

                                    cha.charObject.GetComponent<Animation>().clip = anima.animClip;
                                    cha.charObject.GetComponent<Animation>().Play();
                                    if (currentLine == "HideUI")
                                    {
                                        speaker.text = "";
                                        dialogue.text = "";
                                    }
                                    if (currentLine == "ShowUI" || currentLine == "HideUI")
                                    {
                                        UIShown = true;
                                        yield return new WaitForSeconds(cha.charObject.GetComponent<Animation>().clip.length / 2);
                                    }
                                    else
                                    {
                                        yield return new WaitForSeconds(cha.charObject.GetComponent<Animation>().clip.length / 2);
                                    }

                                    x = 1;
                                }
                                else if (lastLine == "Camera")
                                {
                                    cha.charObject.GetComponent<Animation>().clip = anima.animClip;
                                    cha.charObject.GetComponent<Animation>().Play();
                                    x = 1;

                                }
                                else if (currentLine == "Shake")
                                {
                                    cha.charObject.GetComponent<Animation>().clip = anima.animClip;
                                    cha.charObject.GetComponent<Animation>().Play();
                                    x = 1;
                                }
                            }
                        }

                    }
                }


                foreach (string oneSpeaker in speakers)
                {
                    if (currentLine == oneSpeaker)
                    {
                        Debug.Log(currentLine);
                        if (UIShown == true && currentLine != "Camera" && currentLine != "UI")
                        {
                            speaker.text = currentLine;
                        }

                        currentSpeaker = currentLine;
                        x = 1;
                    }
                }
                foreach (CharacterLibrary.Character cha in charas)
                {
                    if (UIShown == true && currentSpeaker != "Camera" && currentSpeaker != "UI" && currentSpeaker == cha.name)
                    {

                        speaker.color = cha.color;

                    }
                    foreach (Sprite expression in cha.charSprite)
                    {

                        if (expression.name == currentLine)
                        {
                            cha.charObject.GetComponent<Image>().sprite = expression;
                            x = 1;
                        }
                    }
                }

                while (x == 0)
                {
                    dialogue.text = "";
                    foreach (char letter in currentLine)
                    {
                        string let = letter.ToString();
                        dialogue.text += let;
                        yield return new WaitForSeconds(0.015f);

                    }
                    yield return new WaitForSeconds(2f);
                    x = 1;
                }
                // StartCoroutine(showDialogue(currentLine));
                lastLine = currentLine;
            }
        }
        yield return null;
    }


}
