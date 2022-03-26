using ResourceFromLITGM.Scripts.FactoryOfGunsPath;
using UnityEngine;

namespace ServiceLocatorPath
{
    public class InstallerServiceLocator : MonoBehaviour
    {
        private SaveDataService _saveDataService;
        private FactoryOfGuns _factoryOfGuns;
        private void Awake()
        {
            if (FindObjectsOfType<InstallerServiceLocator>().Length > 1)
            {
                Destroy(gameObject);
                return;
            }
            _saveDataService = new SaveDataService();
            
            ServiceLocator.Instance.RegisterService<ISaveDataService>(_saveDataService);
            ServiceLocator.Instance.RegisterService<IFactoryOfGuns>(_factoryOfGuns);
            DontDestroyOnLoad(gameObject);
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
}