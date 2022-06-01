using MelonLoader;

namespace ShowDebugTexts
{
    public class Updater : MelonMod
    {
        // Settings
        public static MelonPreferences_Category Category;
        public static MelonPreferences_Entry<UnityEngine.KeyCode> ToggleKey;
        public static MelonPreferences_Entry<bool> IsShown;
        public static MelonPreferences_Entry<float> MinimumHoldDuration;
        // Input
        public static bool IsInputUnhandeld = false;
        public static float TimeSincePressed = 0;
        public override void OnApplicationStart()
        {
            // Settings initialization
            Category = MelonPreferences.CreateCategory("ShowDebugTexts");
            ToggleKey = Category.CreateEntry<UnityEngine.KeyCode>("ToggleKey", UnityEngine.KeyCode.BackQuote);
            IsShown = Category.CreateEntry<bool>("IsShown", true);
            MinimumHoldDuration = Category.CreateEntry<float>("MinimumHoldDuration", 0.3f);
            Category.LoadFromFile(false);
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            // Enable on GameManager instantiation
            if (HFPS_GameManager.instance != null && IsShown.Value)
            {
                HFPS_GameManager.instance.debugTexts[0].transform.parent.gameObject.SetActive(true);
            }
        }
        public override void OnUpdate()
        {
            // Input
            if (UnityEngine.Input.GetKeyDown(ToggleKey.Value))
            {
                IsInputUnhandeld = true;
            }
            if (UnityEngine.Input.GetKey(ToggleKey.Value) && TimeSincePressed < MinimumHoldDuration.Value)
            {
                TimeSincePressed += UnityEngine.Time.deltaTime;
            }
            if (IsInputUnhandeld && (UnityEngine.Input.GetKeyUp(ToggleKey.Value) || TimeSincePressed >= MinimumHoldDuration.Value))
            {
                IsInputUnhandeld = false;
                if (!IsShown.Value || TimeSincePressed >= MinimumHoldDuration.Value)
                {
                    // Toggle texts
                    IsShown.Value = !IsShown.Value;
                    if (HFPS_GameManager.instance != null)
                    {
                        HFPS_GameManager.instance.debugTexts[0].transform.parent.gameObject.SetActive(IsShown.Value);
                    }
                }
                else
                {
                    // Switch AI
                }
                TimeSincePressed = 0;
            }
            // Output
            if (HFPS_GameManager.instance != null && HFPS_GameManager.instance.debugTexts[0].transform.parent.gameObject.activeSelf)
            {
                HFPS_GameManager.instance.SetDebugTexts(
                    HFPS_GameManager.instance.playerController.yandereController.aI.currentState.ToString(),
                    "Number of time turned yangire : " + HFPS_GameManager.instance.playerController.yandereController.mood.numberOfTimeSwitchedToYangire.ToString(),
                    "Anger level : " + HFPS_GameManager.instance.playerController.yandereController.mood.angerLevel.ToString());
            }
        }
        public override void OnApplicationQuit()
        {
            Category.SaveToFile(false);
        }
    }
}