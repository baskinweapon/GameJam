using UnityEngine;

public class OnENableVFX : MonoBehaviour
{
    private void OnEnable() {
        var pt = GetComponent<ParticleSystem>();
        pt.Stop();
        pt.Play();
    }
}
