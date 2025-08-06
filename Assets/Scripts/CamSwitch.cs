using Unity.Cinemachine;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    [SerializeField] private CinemachineCamera[] cams;
    public CinemachineCamera cam1;
    public CinemachineCamera cam2;
    [SerializeField] private CinemachineCamera StartCamera;
    private CinemachineCamera CurrentCamera;
    void Start()
    {
        CurrentCamera = StartCamera;
        for (int i = 0; i < cams.Length; i++)
        {
            if (cams[i] == CurrentCamera)
            {
                Debug.Log("this is setting it to 20");
                cams[i].Priority = 20;
            }
            else
            {
                cams[i].Priority = 10;
            }
        }
    }

    public void switchCam(CinemachineCamera newCam)
    {
        for (int i = 0; i < cams.Length; i++)
        {
            cams[i].Priority = 10;
        }
        CurrentCamera = newCam;
        CurrentCamera.Priority = 20;
    }
}
