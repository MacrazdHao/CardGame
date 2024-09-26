using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoader : MonoBehaviour
{
    public static ImageLoader imageLoader;

    private void Start() {
        imageLoader = this;
    }
    public void LoadSpriteAsync(string Path, Action<float> UpdateProgress = null, Action<Sprite> AfterFinish = null) {
        StartCoroutine(LoadSpriteAsyncIE(Path, UpdateProgress, AfterFinish));
    }
    public static IEnumerator LoadSpriteAsyncIE(string Path, Action<float> UpdateProgress = null, Action<Sprite> AfterFinish = null)
    {
        ResourceRequest loadRequest = Resources.LoadAsync<Sprite>(Path);
        while (loadRequest.progress < 1)
        {
            if (UpdateProgress != null)
            {
                UpdateProgress(loadRequest.progress);
            }
            yield return null;
        }
        while (!loadRequest.isDone) { }
        if (AfterFinish != null)
        {
            AfterFinish(loadRequest.asset as Sprite);
        }
        yield return null;
    }
    public static Sprite LoadSprite(string Path)
    {
        Sprite sprite = Resources.Load<Sprite>(Path);
        if (sprite == null) return Resources.Load<Sprite>("Icons/UI Elements/White/1x/sign2");
        return sprite;
    }
}
