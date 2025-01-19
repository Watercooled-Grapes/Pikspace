using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class CameraSettings : MonoBehaviour
{
    [Range(1, 8)] public int zoom = 1;
    [Range(100, 16000)] public int iso = 400;
    [Range(1.8f, 24f)] public float aperture = 2.4f;
    [Range(0.004f, 30f)] public float shutterSpeed = 8f;
    private Volume volume;
    private VolumeProfile effects;
    private Camera cam;
    private FilmGrain grain;
    private DepthOfField focus;
    private MotionBlur blur;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        volume = gameObject.GetComponent<Volume>();
        cam = gameObject.GetComponent<Camera>();
        effects = volume.sharedProfile;
        effects.TryGet<FilmGrain>(out grain);
        effects.TryGet<DepthOfField>(out focus);
        effects.TryGet<MotionBlur>(out blur);
    }

    // Update is called once per frame
    void OnValidate()
    {
        // ZOOM: adjust focal range
        cam.focalLength = 30 * this.zoom;

        // ISO: change camera brightness and apply grain (ACTUAL RANGE: 1000 - 10000)
        cam.iso = (int) (1000 + this.iso * 10000f/16000f);
        grain.intensity.value = (float) this.iso/16000;
        
        // APERTURE: change depth of field (ACTUAL RANGE: 0 - 1)
        focus.focusDistance.value = (float)((this.aperture-1.8f)/22.2f);

        // SHUTTER SPEED: change motion blur (ACTUAL RANGE: 1 - 100)
        blur.intensity.value = (float)(this.shutterSpeed * 100 /22.2f);
    }
}
