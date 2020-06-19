using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "DREditor/Dialogues/TrialDialogue", fileName = "New Trial Dialogue")]
public class TrialDialogue : DREditor.DialogueEditor.DialogueBase
{
    public List<TrialLine> Lines = new List<TrialLine>();
}
[System.Serializable]
public class TrialLine : DREditor.DialogueEditor.Line
{
    public eTrialVFX vfx;
    public eCamAnim camAnim;
}
