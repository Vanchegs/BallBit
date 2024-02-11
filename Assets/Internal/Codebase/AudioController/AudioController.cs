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

        private void PlayMusic() =>
            sourceAudio.Play(MusicName, 10);
    }
}
