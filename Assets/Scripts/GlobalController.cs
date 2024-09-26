using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalController : MonoBehaviour
{
    /*
        1 总控场景，按下指定按键
        2 加载Loading场景
        3 Loading场景加载完毕
        4 执行跳转目标场景的流程
        5 更新Loading场景的提示(百分比/进度条等)
        6 进入目标场景
    */
    public static GlobalController globalController;
    public enum SceneMode { LoadingScene, MainScene, TestScene };
    public Dictionary<SceneMode, string> SceneDictionary;

    public SceneMode TargetScene;
    public Action<float> LoadingProgressUpdate; // 从加载场景中传回的回调函数
    public Action OnLoadingComplete; // Scene加载完成后的回调函数
    private float ResourceProgressRate = 0.1f;
    void Start()
    {
        globalController = this;
        SceneDictionary = new Dictionary<SceneMode, string>();
        DontDestroyOnLoad(gameObject); // 不要销毁这个加载场景
        SceneDictionary.Add(SceneMode.LoadingScene, "LoadingScene");
        SceneDictionary.Add(SceneMode.MainScene, "MainScene");
        SceneDictionary.Add(SceneMode.TestScene, "TestScene");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            LoadSceneAsync(SceneMode.MainScene);
        }
    }
    // 异步加载场景，action为回调函数
    void LoadSceneAsync(SceneMode sceneMode, Action action = null)
    {
        SceneManager.LoadScene("LoadingScene"); // 先进入加载场景作为过度场景
        OnLoadingComplete = () => // 将在加载场景加载完成后执行该函数，即进入加载场景后，开始加载目标场景
        {
            StartCoroutine(LoadSceneAsyncIE(sceneMode, action));
        };
    }
    // IEnumerator迭代函数
    // 只能通过 StartCoroutine() 执行
    // yield return null 为下一帧(帧循环)继续再执行
    // 使用 yield break 退出函数
    IEnumerator LoadSceneAsyncIE(SceneMode sceneMode, Action action = null)
    {
        float progressBuffer;
        float progress;
        if (!SceneDictionary.ContainsKey(sceneMode) || SceneDictionary[sceneMode] == null) yield break; // 字典中不存在的场景
        AsyncOperation loadingAO = SceneManager.LoadSceneAsync(SceneDictionary[sceneMode]); // 进度只有0.9f？还是因为设置了allowSceneActivation？
        loadingAO.allowSceneActivation = false; // 加载完成立即跳转场景

        progress = ResourceProgressRate; // 假设资源已经Loading完成
        progressBuffer = ResourceProgressRate; // 假设资源已经Loading完成

        while (loadingAO.progress < 0.9f)
        {
            progress = (1 - ResourceProgressRate) * loadingAO.progress / 0.9f + ResourceProgressRate;
            while (progress - progressBuffer >= 0.01f)
            {
                progressBuffer += 0.01f;
                if (LoadingProgressUpdate != null)
                {
                    LoadingProgressUpdate(progressBuffer);
                }
                yield return new WaitForSeconds(0.01f); // 等加载页面的数字/进度条变更后，即下一帧再继续执行
            }
        }
        loadingAO.allowSceneActivation = true;
        if (action != null)
        {
            action();
        }
        // 等待加载目标场景完成
        while (!loadingAO.isDone)
        {
            yield return null;
        }
        OnLoadingComplete = null;
        yield return null;
    }
}
