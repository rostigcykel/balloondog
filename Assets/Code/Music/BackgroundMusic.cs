using UnityEngine;

namespace Assets.Code.Music
{
    public class BackgroundMusic : MonoBehaviour
    {
        Object[] myMusic; // declare this as Object array
        private int nextSongIndex;
        public bool isShuffle;

        void Awake()
        {
            myMusic = Resources.LoadAll("Music/Background", typeof(AudioClip));
        }

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (!audio.isPlaying)
            {
                if(isShuffle)
                {
                    playRandomMusic();       
                }
                else
                {
                    playNext();
                }

                Debug.Log("Music DJ Currently Playing: " + audio.clip.name);
                audio.Play();
            }
        }

        void playNext()
        {
            audio.clip = myMusic[nextSongIndex] as AudioClip;
            nextSongIndex = nextSongIndex >= myMusic.Length ? 0 : nextSongIndex + 1;
        }

        void playRandomMusic()
        {
            audio.clip = myMusic[Random.Range(0, myMusic.Length)] as AudioClip;
        }
    }
}
