using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Notifications.Android;

public class Notification : MonoBehaviour
{
    public AndroidNotificationChannel NotifChannel;
    public AndroidNotification Notif, ReturnNotif;

    public bool ShouldSend;
    private int identifier;
    // Start is called before the first frame update
    void Start()
    {
        NotifChannel = new AndroidNotificationChannel()
        {
            Id = "Default_Channel",
            Name = "Default Channel",
            Description = "For general use",
            Importance = Importance.High,       //Using High ensures the notification appears on screen
        };

        AndroidNotificationCenter.RegisterNotificationChannel(NotifChannel);

        Notif = new AndroidNotification()       //Notification to show on screen during runtime
        {
            Title = "Resume Watching!",
            Text = "RESUME WATCHING!",
            SmallIcon = "default",
            LargeIcon = "default",
            FireTime = System.DateTime.Now.AddSeconds(10),
            
        };

        ReturnNotif = new AndroidNotification()     //notification to show on screen when player attempts to close the app
        {
            Title = "RETURN TO APPLICATION!",
            Text = "YOU MUST RETURN TO APPLICATION!",
            SmallIcon = "default",
            LargeIcon = "default",
            FireTime = System.DateTime.Now,
            

        };
    }

    void OnApplicationPause(bool pause) {       //When application is taken out of focus, this is called
        if (pause)
        {
            identifier = AndroidNotificationCenter.SendNotification(ReturnNotif, "Default_Channel");
        }
    }

    void Quit() //dead function, ignore
    {
        //identifier = AndroidNotificationCenter.SendNotification(ReturnNotif, "Default_Channel");
    }

    public void sendNotifNow() {  //called by TV script
        identifier = AndroidNotificationCenter.SendNotification(Notif, "Default_Channel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
