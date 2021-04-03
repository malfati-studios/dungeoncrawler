using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera theCamera;
    // Start is called before the first frame update
    void Start()
    {
        theCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(theCamera.transform);
        transform.rotation = Quaternion.Euler(0f,transform.rotation.eulerAngles.y, 0f);
    }
}
