using UnityEngine;

namespace ServiceLocatorPath
{
    public class InstallerServiceLocator : MonoBehaviour
    {
        [SerializeField]  private AudioManager audioManager;
        private SaveDataService _saveDataService;
        private void Awake()
        {
            if (FindObjectsOfType<InstallerServiceLocator>().Length > 1)
            {
                Destroy(gameObject);
                return;
            }
            _saveDataService = new SaveDataService();
            
            ServiceLocator.Instance.RegisterService<ISaveDataService>(_saveDataService);
            ServiceLocator.Instance.RegisterService<IAudioManager>(audioManager);
            DontDestroyOnLoad(gameObject);
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
}