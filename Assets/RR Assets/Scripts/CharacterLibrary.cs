using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEditor.Experimental.GraphView;
using System;

public class CharacterLibrary : MonoBehaviour
{
    [System.Serializable]
    public class Character
    {
        public string name;
        public GameObject charObject;
        public List<Sprite> charSprite = new List<Sprite>();
        public Color32 color;
    }
    public Dictionary<string, List<Sprite>> expressions = new Dictionary<string, List<Sprite>>();
    public Dictionary<string, GameObject> spriteObject = new Dictionary<string, GameObject>();
    public List<Character> Characters = new List<Character>();
    public List<string> charNames = new List<string>();

    void Start()
    {
        foreach(Character x in Characters)
        {
            charNames.Add(x.name);
        }
    }

}
