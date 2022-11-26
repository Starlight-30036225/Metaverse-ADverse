using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using TMPro;
using UnityEngine.Video;

public class TvScipt : MonoBehaviour
{
    UnityEngine.Video.VideoPlayer VP;  //For accessing, playing, pausing and swapping videos.
        public bool InSight;
    //public TMPro.TextMeshPro[] Textboxes;
    public FollowText Textbox;
    public Notification NotifController;
    public GameObject Cell;
    public GameObject FalseScreen;
    public VideoClip BaseVideo;
    public VideoClip Ad1;
    public VideoClip Ad2;

    private bool IsPlaying = false;
    private int agression;
    private string CurrentVid;
    private double ReturnTime;



    // Start is called before the first frame update
    void Start()
    {
        VP = GetComponent<UnityEngine.Video.VideoPlayer>();  //get the videoplayer object from the connected game object
        VP.Play(); //Starts the video (needs to be updated)
  print(VP.canSetTime);
        agression = 0;  
        UpdateAgression();
        CurrentVid = "Core";  
        VP.loopPointReached += EndReached;  //When the video reaches the end(Loop point) it will call EndReached
        Invoke("startAd1", 47);  //Plays the first ad in 47 seconds
    }


    void EndReached(UnityEngine.Video.VideoPlayer VP)
    {
        if (CurrentVid != "Core") {
            VP.clip = BaseVideo;    //Sets the video to the core video
            VP.Play();
            VP.time = ReturnTime;   //Sets the current time to the time saved when it was paused
            if (CurrentVid == "Ad1") {
                Invoke("startAd2", 69); //Plays the second ad in 69 seconds, nice
            }
            CurrentVid = "Core";
        }

    }

    void startAd1() {
        ReturnTime = VP.time;   //Saves the current video time
        VP.clip = Ad1;  //starts ad 1
        VP.Play();
        CurrentVid = "Ad1";
    }


    void startAd2()
    {
        ReturnTime = VP.time; //Saves the current video time
        VP.clip = Ad2;  //starts ad 2
        VP.Play();
        CurrentVid = "Ad2";
    }

    // Update is called once per frame
    public void Update()
    {
        if (CurrentVid == "Core") { 
           
            if (!IsPlaying)  //if the video is not playing, starts the video, edge cases
            {
                VP.Play();
                IsPlaying = true;
                UpdateAgression();
            }
        }
        else
        {
            detectHit();        //only detect hits on ads
        }

    }
    public void detectHit()
    {
        if (InSight) //checks if the screen is currently the focus of the player
        {
            if (!IsPlaying)  //if the video is not playing, starts the video, sets the agression to zero and resets all connected objects
            {
                VP.Play();   
                IsPlaying = true;
                agression = 0;
                UpdateAgression();
            }
        }
        else
        {
            if (IsPlaying)   //if the video is playing, starts the aggresion counter
            {
                VP.Pause();
                IsPlaying = false;
                checkbeforeupdate();
               
            }
        }
    }
    private void checkbeforeupdate() {
        if (!InSight && agression <6) { //If aggresion is less than its current max value, and the screen is not the focus of the user
        agression++;
        UpdateAgression();     
        Invoke("checkbeforeupdate", 3);  //recursive call to this function after 3 seconds
        }
    }
    private void UpdateAgression()
    {

        switch (agression)
        {
            case 0:
                FalseScreen.SetActive(false);
                Textbox.Setvisiblity(false);        //resets textbox, resets sounds, resets cell, resets notifs
                Textbox.TriggerSounds(false);
                Cell.SetActive(false);
                NotifController.ShouldSend = false;
                break;
            case 1:
                FalseScreen.SetActive(true);
                break;
            case 2:
                Textbox.Setvisiblity(true);  //spawns the textbox
                break;
            case 3:
                Textbox.TriggerSounds(true);  //causes the "resume watching" voices to start playing
                break;
            case 4:
                Cell.SetActive(true);   //Shows the cell on screen
                break;
            case 5:
                NotifController.ShouldSend = true;  //Allows notifs to be sent to the player if they try to exit the application
                NotifController.sendNotifNow();     //sends a notif now
                break;
            default:
                break;

        }



    }
    private void affectText(string text, Color newcolor)  //dead function ignore
    {
       // text = text + text;
        //for (int i = 0; i < Textboxes.Length; i++)
        {
            //Textboxes[i].text = text;
          //  Textboxes[i].color = newcolor;

        }

    }

}
