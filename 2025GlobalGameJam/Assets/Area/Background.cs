using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public AreaManager areaManager;

    public SpriteRenderer upper;

    public SpriteRenderer lower;
    public bool isRunning;

    public float speed = 1;

    public void OnAreaChange()
    {
        upper.sprite = areaManager.Upcomming().background;
        lower.sprite = areaManager.Current().background;
    }

    public void Update()
    {
        if (isRunning)
        {
            // Check to see if the upper background reached the lower anchor
            if (upper.transform.position.y < lower.transform.parent.position.y)
            {
                // Reset both back to their anchors
                upper.transform.localPosition = Vector3.zero;
                lower.transform.localPosition = Vector3.zero;

                areaManager.Progress();
            }

            // Scroll the background
            upper.transform.position -= speed * Time.deltaTime * upper.transform.up;
            lower.transform.position -= speed * Time.deltaTime * lower.transform.up;
        }

    }
}
