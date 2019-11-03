#region Using statements
using System;
//using System.Text;
//using System.Collections;
//using System.Collections.Generic;
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
    public sealed class AudioManager
    {
        static readonly AudioManager instance = new AudioManager();

        public AudioEngine audioEngine;

        public WaveBank waveBank;
        public SoundBank soundBank;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static AudioManager()
        {
        }

        AudioManager()
        {
            try
            {
                audioEngine = new AudioEngine(".//Resources//Audio//YourXactFileHere.xgs");
                waveBank = new WaveBank(audioEngine, ".//Resources//Audio//YourWaveBankFileHere.xwb");
                soundBank = new SoundBank(audioEngine, ".//Resources//Audio//YourSoundBankFileHere.xsb");
            }
            catch
            {
                throw new Exception("Audio manager not properly initialized");
            }
            
        }

        // Gives access outside of class
        public static AudioManager Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
