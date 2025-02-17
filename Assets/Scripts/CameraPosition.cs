using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform CamPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = CamPos.position;
        
        transform.up = CamPos.up;
    }
}
