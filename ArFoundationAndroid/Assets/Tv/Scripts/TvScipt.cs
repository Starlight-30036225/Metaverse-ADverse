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
    public TMPro.TextMeshPro[] Textboxes;
    public int agression;


    // Start is called before the first frame update
    void Start()
    {
        VP = GetComponent<UnityEngine.Video.VideoPlayer>();
        VP.Play();
        agression = 0;

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
            if (!IsPlaying)
            {
                VP.Play();
                IsPlaying = true;
                agression = 0;
                UpdateAgression();
            }
        }
        else
        {
            if (IsPlaying)
            {
                VP.Pause();
                IsPlaying = false;
                checkbeforeupdate();
               
            }
        }
    }

    private void checkbeforeupdate() {
        if (!InSight && agression <5) { 
        agression++;
        UpdateAgression();
        Invoke("checkbeforeupdate", 2);
        }
    }
    private void UpdateAgression()
    {

        switch (agression)
        {
            case 0:
                affectText("", Color.white);
                break;
            case 1:
                affectText("Please Continue watching  ---  ", Color.white);
                break;
            case 2:
                affectText("Continue watching  ---  ", Color.white);
                break;
            case 3:
                affectText("CONTINUE WATCHING  ---  ", Color.red);
                break;
            case 4:
                affectText("YOU MUST CONTINUE WATCHING  ---  ", Color.red);
                break;
            default:

                break;

        }



    }

    private void affectText(string text, Color newcolor)
    {
        text = text + text;
        text = text + text;
        text = text + text;
        text = text + text;
        for (int i = 0; i < Textboxes.Length; i++)
        {
            Textboxes[i].text = text;
            Textboxes[i].color = newcolor;

        }

    }
}
