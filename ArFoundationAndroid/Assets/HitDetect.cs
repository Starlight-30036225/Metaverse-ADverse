
using UnityEngine;

public class HitDetect : MonoBehaviour
{
    public Material InSightMat;
    Material DefaultMat;
    MeshRenderer mr;
    public bool Insight;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        DefaultMat = mr.material;

    }

    public void Update()
    {
       detectHit();
    }
    public void detectHit() {
        if (Insight)
        {
            mr.material = InSightMat;
        }
        else
        {
            mr.material = DefaultMat;
        }
    }
}
