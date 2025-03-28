using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeAndParticles : MonoBehaviour
{
    Gun gun;

    [SerializeField] ParticleSystem ps;
    [SerializeField] CinemachineVirtualCamera vcam;

    // Start is called before the first frame update
    void Start()
    {
        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        gun = FindObjectOfType<Gun>();
    }

    [ContextMenu("Start Shake")]
    public void StartShake()
    {
        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 5f;
        StartCoroutine(ShakeTime());
    }

    [ContextMenu("End Shake")]
    public void EndShake()
    {
        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    }

    IEnumerator ShakeTime()
    {
        yield return new WaitForSeconds(.27f);
        EndShake();
    }

    public void Emit()
    {
        ps.transform.position = vcam.transform.position;
        ps.Play();
        Debug.Log("Particles");
    }
}
