using UnityEngine;

public class Hitscan : MonoBehaviour
{
    TvScipt TempTv;
    bool FoundBox;
    public TvScipt Tv;
    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit)) {
           TempTv = hit.transform.GetComponent<TvScipt>();
            print(hit.transform.name);
            if (TempTv != null)
            {
                Tv.InSight = true;
            }
            
        }
        else {
                Tv.InSight = false;
            }

    }
}
