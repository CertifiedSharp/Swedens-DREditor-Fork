using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationLibrary : MonoBehaviour
{
    [System.Serializable]
    public class Animations
    {
        public string animName;
        public Animation anim;
        public AnimationClip animClip;
    }
    public Dictionary<string, Animation> animationDictionary = new Dictionary<string, Animation>();
    public List<Animations> animationList = new List<Animations>();
    void Start()
    {
        foreach(Animations a in animationList)
        {
            animationDictionary.Add(a.animName, a.anim);
        }
    }
}
