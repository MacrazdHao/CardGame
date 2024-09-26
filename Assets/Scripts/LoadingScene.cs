using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public Text LoadingTips;
    public Slider ProgressBar;
    // Start is called before the first frame update
    void Start()
    {
        ResourceLoader.LoadResources();

        GlobalController.globalController.LoadingProgressUpdate = UpdateLoadingTips;
        if (GlobalController.globalController.OnLoadingComplete != null) {
            GlobalController.globalController.OnLoadingComplete();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void UpdateLoadingTips(float progress)
    {
        LoadingTips.text = "已加载: " + ((int)(progress * 10000)) / 100 + "%";
        ProgressBar.value = progress;
    }
}
