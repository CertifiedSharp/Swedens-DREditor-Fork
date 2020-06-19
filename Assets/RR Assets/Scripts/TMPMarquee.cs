using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMPMarquee : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI tmp = null;

    [SerializeField]
    private float speed = 0.75f;
    public bool paused;
    public float plus;
    private float speedFactor = 1e2f;

    /**
     * TODO: X + width isn't correct apparently. Hardcode for now.
     */

    //[SerializeField]
    //private RectTransform maskRect = null;

    [SerializeField]
    private float resetX = 180.0f;

    void Update()
    {
        if (paused)
        {
            return;
        }
        if (tmp.rectTransform.localPosition.x + tmp.rectTransform.rect.width + plus < 0)
        {
            tmp.rectTransform.localPosition = new Vector3(resetX,
                tmp.rectTransform.localPosition.y, tmp.rectTransform.localPosition.z);
        }
        var translate = new Vector3(-speed * Time.deltaTime * speedFactor, 0, 0);
        tmp.rectTransform.Translate(translate);
    }
}
