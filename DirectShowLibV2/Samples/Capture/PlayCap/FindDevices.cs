using System;

using DirectShowLib;
using xperdex.classes;
using System.Windows.Forms;

namespace PlayCap
{
    class FindDevices
    {
        public IBaseFilter FindVideoCaptureDevice(bool find_bda)
        {
            DsDevice[] devices;
            object source;
            DsDevice choosen_device = null;

            string[] deviceStrings = { //add this this list to support new devices by default
                                    "Conexant Polaris Video Capture" };

            for (int i = 0; i < deviceStrings.Length; i++)
            {
                deviceStrings[i] = INI.Default["DirectShow Player"]["Video Player/Device Name_" + i, deviceStrings[i]];
            }

            if (find_bda)
                devices = DsDevice.GetDevicesOfCat(FilterCategory.BDASourceFiltersCategory);
            else
                devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

            Log.log("***");
            Log.log("Video Capture Device List: ");
            foreach (DsDevice d in devices)
            {
                Log.log("\tdevice[" + d.Name + "]");
                foreach (string s in deviceStrings)
                {
                    if (s == d.Name && choosen_device == null)
                    {
                        Log.log("That's a match!");
                        choosen_device = d;
                    }
                }
            }
            Log.log("***");

            if (choosen_device == null)
            {
                Log.log("no match found in video capture device List");
                return null;
            }

            // Bind Moniker to a filter object
            Guid iid = typeof(IBaseFilter).GUID;
            choosen_device.Mon.BindToObject(null, null, ref iid, out source);

            if (source == null)
            {
                Log.log("failed to get IBaseFilter from choosen_device");
                return null;
            }
            // An exception is thrown if cast fail
            return (IBaseFilter)source;
        }

        public IBaseFilter FindAudioCaptureDevice()
        {
            DsDevice[] devices;
            object source;

            String wanted_name = INI.Default["DirectShow Player"]["Video Player/Audio Device Name", "Conexant Polaris Video Capture"];
            if (wanted_name.Length == 0)
                return null;

            // Get all video input devices
            devices = DsDevice.GetDevicesOfCat(FilterCategory.AudioInputDevice);

            // Take the first device
            DsDevice device = null;
            String devs = "";
            foreach (DsDevice dev in devices)
            {
                devs += "[" + dev.Name + "] ";
                //if( dev.Name == "VC500 Video" )
                if (dev.Name == wanted_name)
                {
                    device = dev;
                    break;
                }
            }

            Log.log( "Audio Capture Device List: " + devs );

            if (device == null)
            {
                MessageBox.Show("Failed to find : " + wanted_name + "\nWhat I know is: " + devs);
                return null;
            }

            // Bind Moniker to a filter object
            Guid iid = typeof(IBaseFilter).GUID;
            device.Mon.BindToObject(null, null, ref iid, out source);

            // An exception is thrown if cast fail
            return (IBaseFilter)source;
        }

        public IBaseFilter FindVideoScaleDevice()
        {
            DsDevice[] devices;
            object source;

            String wanted_name = INI.Default["DirectShow Player"]["Video Player/Video Scaling Device Name", "CSIR RTVC Scale Filter"];
            if (wanted_name.Length == 0)
                return null;

            // Get all video input devices
            devices = DsDevice.GetDevicesOfCat(FilterCategory.LegacyAmFilterCategory);

            // Take the first device
            DsDevice device = null;
            String devs = "";
            foreach (DsDevice dev in devices)
            {
                devs += "[" + dev.Name + "] ";
                //if( dev.Name == "VC500 Video" )
                if (String.Compare(dev.Name, wanted_name, true) == 0)
                {
                    device = dev;
                    break;
                }
            }

            Log.log( "Video Scale Device List: " + devs );

            if (device == null)
            {
                MessageBox.Show("Failed to find : " + wanted_name + "\nWhat I know is: " + devs);
                return null;
            }

            // Bind Moniker to a filter object
            Guid iid = typeof(IBaseFilter).GUID;
            device.Mon.BindToObject(null, null, ref iid, out source);

            // An exception is thrown if cast fail
            return (IBaseFilter)source;
        }

        public IBaseFilter FindVideoRenderDevice()
        {
            DsDevice[] devices;
            object source;

            String wanted_name = INI.Default["DirectShow Player"]["Video Player/Video Render Device Name", "ReClock Video Renderer"];
            if (wanted_name.Length == 0)
                return null;

            // Get all video input devices
            devices = DsDevice.GetDevicesOfCat(FilterCategory.LegacyAmFilterCategory);

            // Take the first device
            DsDevice device = null;
            String devs = "";
            foreach (DsDevice dev in devices)
            {
                devs += "[" + dev.Name + "] ";
                //if( dev.Name == "VC500 Video" )
                if (String.Compare(dev.Name, wanted_name, true) == 0)
                {
                    device = dev;
                    break;
                }
            }

            Log.log("Video Render Device List: " + devs);

            if (device == null)
            {
                MessageBox.Show("Failed to find : " + wanted_name + "\nWhat I know is: " + devs);
                return null;
            }

            // Bind Moniker to a filter object
            Guid iid = typeof(IBaseFilter).GUID;
            device.Mon.BindToObject(null, null, ref iid, out source);

            // An exception is thrown if cast fail
            return (IBaseFilter)source;
        }

        public IBaseFilter FindAudioRenderDevice()
        {
            DsDevice[] devices;
            object source;
            DsDevice choosen_device = null;

			string[] deviceStrings = { //add this this list to support new devices by default
                                    "USB Audio" };
			
            for (int i = 0; i < deviceStrings.Length; i++)
            {
                deviceStrings[i] = INI.Default["DirectShow Player"]["Video Player/Audio Render Device Name_" + i, deviceStrings[i]];
            }

            devices = DsDevice.GetDevicesOfCat(FilterCategory.AudioRendererCategory);

            Log.log("***");
            Log.log("Audio Render Device List: ");
            foreach (DsDevice d in devices)
            {
                Log.log( "\tdevice[" + d.Name + "]");
                foreach (string s in deviceStrings)
                {
                    int stringPosition = d.Name.IndexOf(s);
                    if (stringPosition > -1 && choosen_device == null)
                    {
                        Log.log("That's a match!");
                        choosen_device = d;
                    }
                }
            }
            Log.log("***");

            if (choosen_device == null)
            {
                Log.log("no match found");
                return null;
            }

            // Bind Moniker to a filter object
            Guid iid = typeof(IBaseFilter).GUID;
            choosen_device.Mon.BindToObject(null, null, ref iid, out source);

            if (source == null)
            {
                Log.log("failed to get IBaseFilter from choosen_device");
                return null;
            }

            // An exception is thrown if cast fail
            return (IBaseFilter)source;
        }
    }
}
