using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Util;
using static Android.Views.View;
using static Android.Net.Sip.SipAudioCall;

namespace ReadingRoomClient
{
    /// <summary>
    /// 主界面
    /// </summary>
    [Activity(Label = "ReadingRoomClient", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        /// <summary>
        /// 启动时
        /// </summary>
        /// <param name="bundle"></param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            Button btn_Connect = FindViewById<Button>(Resource.Id.btn_ConnectServer);
        }
    }
}

