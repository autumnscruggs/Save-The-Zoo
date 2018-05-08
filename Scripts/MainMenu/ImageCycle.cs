using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ImageCycle : MonoBehaviour
{
    //list of the images
    public List<Image> images;

    void Awake()
    {
        //THIS IS HORRIBLE
        //BUT IT'S FIXED NOW
        Time.timeScale = 1f;
    }

    void Start()
    {
        //shows the first image, but hides the rest
        //sets the default image
        for (int x = 0; x < images.Count; x++)
        {
            if (x == 0)
            {
                images[x].GetComponent<CanvasRenderer>().SetAlpha(1);
            }
            else
            {
                images[x].GetComponent<CanvasRenderer>().SetAlpha(0);
            }
        }

        //start swapping coroutine
        StartCoroutine("SwapImages");
    }

    IEnumerator SwapImages()
    {
        //this loops the for loop forever
        //it's loop-ception
        while (true)
        {
            //increments the image count each time so it moves to the next one
            for (int x = 0; x < images.Count; x++)
            {
                //fade image in, wait five seconds, then fade the next one out
                StartCoroutine(FadeIn(x));
                yield return new WaitForSeconds(5f);
                StartCoroutine(FadeOut(x));
            }
        }
    }

    IEnumerator FadeOut(int x)
    {
        //fade image alpha out gradually
        for (float i = 1f; i >= 0f; i -= 0.1f)
        {
            images[x].GetComponent<CanvasRenderer>().SetAlpha(i);
            yield return new WaitForSeconds(0.1f);
        }

        //then finally set it to zero
        images[x].GetComponent<CanvasRenderer>().SetAlpha(0);

        yield return true;
    }

    IEnumerator FadeIn(int x)
    {
        //fade image alpha in gradually
        for (float i = 0f; i <= 1f; i += 0.1f)
        {
            images[x].GetComponent<CanvasRenderer>().SetAlpha(i);
            yield return new WaitForSeconds(0.1f);
        }

        //then finally set it to zero
        images[x].GetComponent<CanvasRenderer>().SetAlpha(1);

        yield return true;
    }
}