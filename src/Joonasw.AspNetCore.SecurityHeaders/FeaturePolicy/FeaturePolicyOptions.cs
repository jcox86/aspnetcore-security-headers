﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options;

namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy
{
    public class FeaturePolicyOptions
    {
        public FeaturePolicyOptions()
        {
            GeolocationOptions = new FeaturePolicyGeolocationOptions();
            MidiOptions = new FeaturePolicyMidiOptions();
            NotificationsOptions = new FeaturePolicyNotificationsOptions();
            PushOptions = new FeaturePolicyPushOptions();
            SyncXhrOptions = new FeaturePolicySyncXhrOptions();
            MicrophoneOptions = new FeaturePolicyMicrophoneOptions();
            CameraOptions = new FeaturePolicyCameraOptions();
            MagnetometerOptions = new FeaturePolicyMagnetometerOptions();
            GyroscopeOptions = new FeaturePolicyGyroscopeOptions();
            SpeakerOptions = new FeaturePolicySpeakerOptions();
            VibrateOptions = new FeaturePolicyVibrateOptions();
            FullscreenOptions = new FeaturePolicyFullscreenOptions();
            PaymentOptions = new FeaturePolicyPaymentOptions();
            AccelerometerOptions = new FeaturePolicyAccelerometerOptions();
            AmbientLightSensorOptions = new FeaturePolicyAmbientLightSensorOptions();
            AutoplayOptions = new FeaturePolicyAutoplayOptions();
            EncryptedMediaOptions = new FeaturePolicyEncryptedMediaOptions();
            PictureInPictureOptions = new FeaturePolicyPictureInPictureOptions();
            UsbOptions = new FeaturePolicyUsbOptions();
            VrOptions = new FeaturePolicyVrOptions();
        }

        public FeaturePolicyGeolocationOptions GeolocationOptions { get; set; }
        public FeaturePolicyMidiOptions MidiOptions { get; set; }
        public FeaturePolicyNotificationsOptions NotificationsOptions { get; set; }
        public FeaturePolicyPushOptions PushOptions { get; set; }
        public FeaturePolicySyncXhrOptions SyncXhrOptions { get; set; }
        public FeaturePolicyMicrophoneOptions MicrophoneOptions { get; set; }
        public FeaturePolicyCameraOptions CameraOptions { get; set; }
        public FeaturePolicyMagnetometerOptions MagnetometerOptions { get; set; }
        public FeaturePolicyGyroscopeOptions GyroscopeOptions { get; set; }
        public FeaturePolicySpeakerOptions SpeakerOptions { get; set; }
        public FeaturePolicyVibrateOptions VibrateOptions { get; set; }
        public FeaturePolicyFullscreenOptions FullscreenOptions { get; set; }
        public FeaturePolicyPaymentOptions PaymentOptions { get; set; }
        public FeaturePolicyAccelerometerOptions AccelerometerOptions { get; set; }
        public FeaturePolicyAmbientLightSensorOptions AmbientLightSensorOptions { get; set; }
        public FeaturePolicyAutoplayOptions AutoplayOptions { get; set; }
        public FeaturePolicyEncryptedMediaOptions EncryptedMediaOptions { get; set; }
        public FeaturePolicyPictureInPictureOptions PictureInPictureOptions { get; set; }
        public FeaturePolicyUsbOptions UsbOptions { get; set; }
        public FeaturePolicyVrOptions VrOptions { get; set; }

        internal enum FeaturePolicyValue
        {
            [DefaultValue("geolocation")]
            Geolocation = 0,
            [DefaultValue("midi")]
            Midi = 1,
            [DefaultValue("notifications")]
            Notifications = 2,
            [DefaultValue("push")]
            Push = 3,
            [DefaultValue("sync-xhr")]
            SyncXhr = 4,
            [DefaultValue("microphone")]
            Microphone = 5,
            [DefaultValue("camera")]
            Camera = 6,
            [DefaultValue("magnetometer")]
            Magnetometer = 7,
            [DefaultValue("gyroscope")]
            Gyroscope = 8,
            [DefaultValue("speaker")]
            Speaker = 9,
            [DefaultValue("vibrate")]
            Vibrate = 10,
            [DefaultValue("fullscreen")]
            Fullscreen = 11,
            [DefaultValue("payment")]
            Payment = 12,
            [DefaultValue("accelerometer")]
            Accelerometer = 13,
            [DefaultValue("ambient-light-sensor")]
            AmbientLightSensor = 14,
            [DefaultValue("autoplay")]
            Autoplay = 15,
            [DefaultValue("encrypted-media")]
            EncryptedMedia = 16,
            [DefaultValue("picture-in-picture")]
            PictureInPicture = 17,
            [DefaultValue("usb")]
            Usb = 18,
            [DefaultValue("vr")]
            Vr = 19
        }

        /// <summary>
        /// Override to add all values from all options
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var optionValues = new List<string>
            {
                GeolocationOptions.ToString(),
                MidiOptions.ToString(),
                NotificationsOptions.ToString(),
                PushOptions.ToString(),
                SyncXhrOptions.ToString(),
                MicrophoneOptions.ToString(),
                CameraOptions.ToString(),
                MagnetometerOptions.ToString(),
                GyroscopeOptions.ToString(),
                SpeakerOptions.ToString(),
                VibrateOptions.ToString(),
                FullscreenOptions.ToString(),
                PaymentOptions.ToString(),
                AccelerometerOptions.ToString(),
                AmbientLightSensorOptions.ToString(),
                AutoplayOptions.ToString(),
                EncryptedMediaOptions.ToString(),
                PictureInPictureOptions.ToString(),
                UsbOptions.ToString(),
                VrOptions.ToString()
            };
            return string.Join("; ", optionValues.Where(s => s.Length > 0));
        }
    }
}
