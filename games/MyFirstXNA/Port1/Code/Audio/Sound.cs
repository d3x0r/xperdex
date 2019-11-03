#region Using statements
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.IO;
#endregion

namespace TestsForFun
{
    /// <summary>
    /// The sound class acts as a wrapper for using sounds. It makes it easier to start,
    /// and stop sounds as you would like.
    /// </summary>
    public class Sound
    {
        #region VARIABLES
        private AudioManager AudioManager = AudioManager.Instance;

        private Cue soundQue = null;
        public Cue SoundQue
        {
            get { return soundQue; }
            set { soundQue = value; }
        }

        private Timer soundTimer;

        private string soundPath;
        public string SoundPath
        {
            get { return soundPath; }
            set { soundPath = value; }
        }

        private float MaxLength = 0;
        #endregion

        #region METHODS
        public Sound()
        {
            soundTimer = new Timer(0);
            soundPath = null;
        }

        public Sound( string soundName )
        {
            soundTimer = new Timer(0);
            SoundPath = soundName;
        }

        /// <summary>
        /// Create a sound that loops after a minimum amount of time.
        /// </summary>
        /// <param name="minimumLength">Time (in milliseconds) before sound is allowed to loop.</param>
        public Sound(int minimumLength)
        {
            soundTimer = new Timer(minimumLength);
            soundPath = null;
        }

        /// <summary>
        /// Create a sound that loops after a minimum amount of time.
        /// </summary>
        /// <param name="soundsPath">Name of the sound file</param>
        /// <param name="minimumLength">Time (in milliseconds) before sound is allowed to loop.</param>
        public Sound( string soundName, int minimumLength)
        {
            soundTimer = new Timer(minimumLength);
            SoundPath = soundName;
        }

        /// <summary>
        /// Sets the maximum length a sound can play.
        /// </summary>
        /// <param name="soundLength">Length to play</param>
        public void SetLength(float soundLength)
        {
            MaxLength = soundLength;
        }

        public void Update()
        {
            if (MaxLength != 0)
            {
                if (soundTimer.Elapsed >= MaxLength)
                    StopSound();
            }
        }

        public void PlaySound()
        {
            if (soundQue != null && soundTimer.ReachedDuration)
                soundQue = null;

            if (soundQue == null && soundPath != null)
            {
                soundTimer.Start();    // Reset timer
                soundQue = AudioManager.soundBank.GetCue(soundPath);
                soundQue.Play();
            }
        }

        public void PlaySound(bool looping)
        {
            if (soundQue != null && soundQue.IsStopped)
                soundQue = null;

            if (soundQue == null && soundPath != null)
            {
                soundTimer.Start();    // Reset timer
                soundQue = AudioManager.soundBank.GetCue(soundPath);
                soundQue.Play();
            }
        }

        public void StopSound()
        {
            if (soundQue != null)
                if (soundQue.IsPlaying)
                    soundQue.Stop(AudioStopOptions.AsAuthored);
        }
        #endregion
    }
}
