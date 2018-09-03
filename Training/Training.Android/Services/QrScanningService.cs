using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Training.Dependency;
using ZXing.Mobile;
using Xamarin.Forms;
using Training.Droid.Services;

[assembly: Dependency(typeof(QrScanningService))]
namespace Training.Droid.Services
{
    public class QrScanningService : IQrReaderService
    {

        public QrScanningService()
        {
        }

        readonly Context context = Android.App.Application.Context;

        async Task<string> IQrReaderService.ScannAsync()
        {
            var optionsDefault = new MobileBarcodeScanningOptions();
            var optionsCustom = new MobileBarcodeScanningOptions();

            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Lütfen QR Kodu Okutun",
                BottomText = "Bekleyin...",
            };

            var scanResult = await scanner.Scan(context, optionsCustom);
            return scanResult.Text;
        }

        //public Task<string> CallHtml()
        //{
        //    //return "file:///android_asset/read.html";
        //}
    }
}