using Plugins.Audio.Core;
using UnityEngine;

namespace Internal.Codebase.AudioController
{
    public class AudioController : MonoBehaviour
    {
        private const string MusicName = "Norm";
        
        [SerializeField] private SourceAudio sourceAudio;

        private void Start() => 
            PlayMusic();

        public void PlayMusic() =>
            sourceAudio.Play(MusicName, 100);

        public void PauseMusic(bool isPause)
        {
            if (isPause) 
                sourceAudio.Pause();
            else
                sourceAudio.UnPause();
        }
    }
}
