using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using TMPro;

public class TvScipt : MonoBehaviour
{
    UnityEngine.Video.VideoPlayer VP;
    public bool IsPlaying = false;
    public bool InSight;
    public TMPro.TextMeshPro Textboxeone;
    public TMPro.TextMeshPro Textboxetwo; 
    public TMPro.TextMeshPro Textboxethree;
    public TMPro.TextMeshPro Textboxefour;

    // Start is called before the first frame update
    void Start()
    {
        VP = GetComponent<UnityEngine.Video.VideoPlayer>();
        VP.Play();

    }


    // Update is called once per frame
    public void Update()
    {
        detectHit();
    }
    public void detectHit()
    {
        if (InSight)
        {
            if (!IsPlaying) {
                VP.Play();
                IsPlaying = true;
                affectText(false);
            }
        }
        else
        {
            if (IsPlaying)
            {
                VP.Pause();
                IsPlaying=false;
                affectText(true);
            }
        }
    }

    private void affectText(bool active)
    {
        string text = " ";
        if (active)
        {
            text = "CONTINUE WATCHING---CONTINUE WATCHING---CONTINUE WATCHING---CONTINUE WATCHING---CONTINUE WATCHING---CONTINUE WATCHING---CONTINUE WATCHING---CONTINUE WATCHING---CONTINUE WATCHING---CONTINUE WATCHING---CONTINUE WATCHING---CONTINUE WATCHING---CONTINUE WATCHING---CONTINUE WATCHING";
        }

        Textboxeone.text = text;
        Textboxetwo.text = text;
        Textboxethree.text = text;
        Textboxefour.text = text;

    }
}
