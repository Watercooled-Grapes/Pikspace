using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class CameraSettings : MonoBehaviour
{
    [Range(1.8f, 24f)] public float aperture = 2.4f;
    [Range(0.00025f, 1f)] public float shutterSpeed = 1f;
    private Volume volume;
    private VolumeProfile effects;
    public static Camera cam;
    public static FilmGrain grain;
    private DepthOfField focus;
    public static MotionBlur blur;
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
    
    public static void updateZoom(float val)
    {
        // ZOOM: adjust focal range
        cam.focalLength = 30 * val;
    }
    
    public static void updateIso(float val)
    {
        // ISO: change camera brightness and apply grain (ACTUAL RANGE: 1000 - 10000)
        cam.iso = (int)val;
        grain.intensity.value = val;
    }
    
    public static void updateAperature(float val)
    {
        // APERTURE: change depth of field (ACTUAL RANGE: 0 - 1)
        cam.aperture = val;
    }
    
    public static void updateFocus(float val)
    {
        cam.focusDistance = val;
    }

    public static void updateShutter(float val)
    {
        // SHUTTER SPEED: change motion blur (ACTUAL RANGE: 1 - 100)
        cam.shutterSpeed = val;
        blur.intensity.value = (float)(val * 100 / 22.2f);
    }
}