using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Video;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class AddressablesManager
{
    public static void LoadAsset<T>(object key, Action<T> onLoadedAsset)
    {
        Addressables.LoadAssetAsync<T>(key).Completed += (asyncOperation) =>
        {
            if (asyncOperation.Status == AsyncOperationStatus.Succeeded)
                onLoadedAsset.Invoke(asyncOperation.Result);
            else
                Debug.Log("Error loading asset");
        };
    }

    public static void LoadSceneSingle(AssetReferenceSceneAsset key)
    {
        Addressables.LoadSceneAsync(key).Completed += (asyncOperation) =>
        {
            if (asyncOperation.Status == AsyncOperationStatus.Succeeded)
                Debug.Log("Scene loaded");
            else
                Debug.Log("Error loading scene");
        };
    }
}

[Serializable]
public class AssetReferenceVideoClip : AssetReferenceT<VideoClip>
{
    public AssetReferenceVideoClip(string guid) : base(guid) { }
}

[Serializable]
#if UNITY_EDITOR
public class AssetReferenceSceneAsset : AssetReferenceT<SceneAsset>
#else
public class AssetReferenceSceneAsset : AssetReference
#endif
{
    public AssetReferenceSceneAsset(string guid) : base(guid) { }
}