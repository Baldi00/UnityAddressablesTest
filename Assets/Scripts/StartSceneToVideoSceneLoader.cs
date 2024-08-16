using UnityEngine;

public class StartSceneToVideoSceneLoader : MonoBehaviour
{
    [SerializeField]
    private AssetReferenceSceneAsset sceneToLoad;

    private void Start()
    {
        Caching.ClearCache();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
            AddressablesManager.LoadSceneSingle(sceneToLoad);
    }
}
