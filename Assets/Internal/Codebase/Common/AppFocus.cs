using UnityEngine;

namespace Internal.Codebase.Common
{
  public class AppFocus : MonoBehaviour
  {
    public AudioController.AudioController AudioController;
    
    void OnApplicationFocus(bool hasFocus) => 
      CheckFocus(!hasFocus);

    void OnApplicationPause(bool pauseStatus) => 
      CheckFocus(pauseStatus);

    private void CheckFocus(bool isPaused) 
    {
      if (isPaused)
        AudioController.PauseMusic(true);
      else
        AudioController.PauseMusic(false);
    }
  }
}
