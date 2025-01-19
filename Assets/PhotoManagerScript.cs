using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PhotoManagerScript : MonoBehaviour
{
    private List<RenderTexture> photoData;
    [SerializeField] private Camera handheldCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        photoData = new List<RenderTexture>();
        takePhoto();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(photoData.Count);
    }

    public void addPhoto(RenderTexture photo)
    {
        photoData.Add(photo);
    }

    public RenderTexture getPhoto(int index)
    {
        if (index < 0 || index >= photoData.Count)
        {
            return null;
        }

        return photoData.ElementAt(index);
    }

    public void takePhoto()
    {
        RenderTexture photoTexture = new RenderTexture(128, 128, 16, RenderTextureFormat.ARGB32);
        Graphics.CopyTexture(handheldCamera.targetTexture, photoTexture);
        addPhoto(photoTexture);

        //Texture2D tex = new Texture2D(cameraTexture.width, cameraTexture.height, TextureFormat.ARGB32, false, false);
        //var oldRt = RenderTexture.active;
        //RenderTexture.active = cameraTexture;
        //tex.ReadPixels(new Rect(0, 0, cameraTexture.width, cameraTexture.height), 0, 0);
        //tex.Apply();
        //addPhoto(tex.GetPixels());
        //RenderTexture.active = oldRt;
        //if (Application.isPlaying)
        //    Object.Destroy(tex);
        //else
        //    Object.DestroyImmediate(tex);
    }
}
