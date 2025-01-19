using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;

public class PhotoManagerScript : MonoBehaviour
{
    private Stack<RenderTexture> photoData;
    [SerializeField] private Camera handheldCamera;
    bool triggerValue;


// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        photoData = new Stack<RenderTexture>();
        takePhoto();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void addPhoto(RenderTexture photo)
    {
        photoData.Push(photo);
    }

    public RenderTexture getPhoto()
    {
        return photoData.Peek();
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
        RenderTexture photoTexture = new RenderTexture(handheldCamera.targetTexture.width, handheldCamera.targetTexture.width, 16, handheldCamera.targetTexture.graphicsFormat);
        handheldCamera.Render();
        Graphics.CopyTexture(handheldCamera.targetTexture, photoTexture);
        addPhoto(photoTexture);
        Debug.Log("what");
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
