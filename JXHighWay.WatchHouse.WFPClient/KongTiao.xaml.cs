﻿using JXHighWay.WatchHouse.Bll.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// KongTiao.xaml 的交互逻辑
    /// </summary>
    public partial class KongTiao : Page
    {
        public KongTiao()
        {
            InitializeComponent();
        }

        private void image_FS_DF_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            kongTiaoFS_DF();
        }

        void kongTiaoFS_DF()
        {
            image_FS_DF.Source = new BitmapImage(new Uri(@"Images/KongTiao/df_a.jpg", UriKind.Relative));
            image_FS_ZF.Source = new BitmapImage(new Uri(@"Images/KongTiao/zf.jpg", UriKind.Relative));
            image_FS_GF.Source = new BitmapImage(new Uri(@"Images/KongTiao/gf.jpg", UriKind.Relative));
        }

        private void image_FS_ZF_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            kongTiaoFS_ZF();
        }
        void kongTiaoFS_ZF()
        {
            image_FS_DF.Source = new BitmapImage(new Uri(@"Images/KongTiao/df.jpg", UriKind.Relative));
            image_FS_ZF.Source = new BitmapImage(new Uri(@"Images/KongTiao/zf_a.jpg", UriKind.Relative));
            image_FS_GF.Source = new BitmapImage(new Uri(@"Images/KongTiao/gf.jpg", UriKind.Relative));
        }

        private void image_FS_GF_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            kongTiaoFS_GF();
        }

        void kongTiaoFS_GF()
        {
            image_FS_DF.Source = new BitmapImage(new Uri(@"Images/KongTiao/df.jpg", UriKind.Relative));
            image_FS_ZF.Source = new BitmapImage(new Uri(@"Images/KongTiao/zf.jpg", UriKind.Relative));
            image_FS_GF.Source = new BitmapImage(new Uri(@"Images/KongTiao/gf_a.jpg", UriKind.Relative));
        }

        void kongTiaoFS_Kong()
        {
            image_FS_DF.Source = new BitmapImage(new Uri(@"Images/KongTiao/df.jpg", UriKind.Relative));
            image_FS_ZF.Source = new BitmapImage(new Uri(@"Images/KongTiao/zf.jpg", UriKind.Relative));
            image_FS_GF.Source = new BitmapImage(new Uri(@"Images/KongTiao/gf.jpg", UriKind.Relative));
        }

        private void image_MS_CS_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            kongTiaoMS_CS();
        }

        void kongTiaoMS_CS()
        {
            image_MS_CS.Source = new BitmapImage(new Uri(@"Images/KongTiao/cs_a.jpg", UriKind.Relative));
            image_MS_ZL.Source = new BitmapImage(new Uri(@"Images/KongTiao/zl.jpg", UriKind.Relative));
            image_MS_ZR.Source = new BitmapImage(new Uri(@"Images/KongTiao/zr.jpg", UriKind.Relative));
            image_MS_SF.Source = new BitmapImage(new Uri(@"Images/KongTiao/sf.jpg", UriKind.Relative));
            image_MS_ZD.Source = new BitmapImage(new Uri(@"Images/KongTiao/zd.jpg", UriKind.Relative));
        }

        private void image_MS_ZR_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            kongTiaoMS_ZR();
        }
        void kongTiaoMS_ZR()
        {
            image_MS_CS.Source = new BitmapImage(new Uri(@"Images/KongTiao/cs.jpg", UriKind.Relative));
            image_MS_ZL.Source = new BitmapImage(new Uri(@"Images/KongTiao/zl.jpg", UriKind.Relative));
            image_MS_ZR.Source = new BitmapImage(new Uri(@"Images/KongTiao/zr_a.jpg", UriKind.Relative));
            image_MS_SF.Source = new BitmapImage(new Uri(@"Images/KongTiao/sf.jpg", UriKind.Relative));
            image_MS_ZD.Source = new BitmapImage(new Uri(@"Images/KongTiao/zd.jpg", UriKind.Relative));
        }

        private void image_MS_ZL_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            kongTiaoMS_ZL();
        }

        void kongTiaoMS_ZL()
        {
            image_MS_CS.Source = new BitmapImage(new Uri(@"Images/KongTiao/cs.jpg", UriKind.Relative));
            image_MS_ZL.Source = new BitmapImage(new Uri(@"Images/KongTiao/zl_a.jpg", UriKind.Relative));
            image_MS_ZR.Source = new BitmapImage(new Uri(@"Images/KongTiao/zr.jpg", UriKind.Relative));
            image_MS_SF.Source = new BitmapImage(new Uri(@"Images/KongTiao/sf.jpg", UriKind.Relative));
            image_MS_ZD.Source = new BitmapImage(new Uri(@"Images/KongTiao/zd.jpg", UriKind.Relative));
        }

        private void image_MS_SF_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            kongTiaoMS_SF();
        }

        void kongTiaoMS_SF()
        {
            image_MS_CS.Source = new BitmapImage(new Uri(@"Images/KongTiao/cs.jpg", UriKind.Relative));
            image_MS_ZL.Source = new BitmapImage(new Uri(@"Images/KongTiao/zl.jpg", UriKind.Relative));
            image_MS_ZR.Source = new BitmapImage(new Uri(@"Images/KongTiao/zr.jpg", UriKind.Relative));
            image_MS_SF.Source = new BitmapImage(new Uri(@"Images/KongTiao/sf_a.jpg", UriKind.Relative));
            image_MS_ZD.Source = new BitmapImage(new Uri(@"Images/KongTiao/zd.jpg", UriKind.Relative));
        }

        private void image_MS_ZD_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            kongTiaoMS_ZD();
        }

        void kongTiaoMS_ZD()
        {
            image_MS_CS.Source = new BitmapImage(new Uri(@"Images/KongTiao/cs.jpg", UriKind.Relative));
            image_MS_ZL.Source = new BitmapImage(new Uri(@"Images/KongTiao/zl.jpg", UriKind.Relative));
            image_MS_ZR.Source = new BitmapImage(new Uri(@"Images/KongTiao/zr.jpg", UriKind.Relative));
            image_MS_SF.Source = new BitmapImage(new Uri(@"Images/KongTiao/sf.jpg", UriKind.Relative));
            image_MS_ZD.Source = new BitmapImage(new Uri(@"Images/KongTiao/zd_a.jpg", UriKind.Relative));
        }

        void kongTiaoMS_Kong()
        {
            image_MS_CS.Source = new BitmapImage(new Uri(@"Images/KongTiao/cs.jpg", UriKind.Relative));
            image_MS_ZL.Source = new BitmapImage(new Uri(@"Images/KongTiao/zl.jpg", UriKind.Relative));
            image_MS_ZR.Source = new BitmapImage(new Uri(@"Images/KongTiao/zr.jpg", UriKind.Relative));
            image_MS_SF.Source = new BitmapImage(new Uri(@"Images/KongTiao/sf.jpg", UriKind.Relative));
            image_MS_ZD.Source = new BitmapImage(new Uri(@"Images/KongTiao/zd.jpg", UriKind.Relative));
        }



        WatchHouseMonitoring m_Monitoring = null;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            m_Monitoring = new WatchHouseMonitoring();
            RefreshState();
        }

        void initKongTiao()
        {
            KongTiaoStateInfo vState = m_Monitoring.KongTiaoState(App.WatchHouseID);
            CheckBox_KongTiao.IsChecked = vState.IsOpen;
            Label_ShiLeiWD.Content = string.Format("{0}℃", vState.ShiLeiWD);
            //模式
            switch (vState.MoShi)
            {
                case "除湿":
                    kongTiaoMS_CS();
                    break;
                case "制冷":
                    kongTiaoMS_ZL();
                    break;
                case "制热":
                    kongTiaoMS_ZR();
                    break;
                case "送风":
                    kongTiaoMS_SF();
                    break;
                case "自动模式":
                    kongTiaoMS_ZD();
                    break;
                default:
                    kongTiaoMS_Kong();
                    break;
            }

            //风速
            switch (vState.FengShu)
            {
                case "低风":
                    kongTiaoFS_DF();
                    break;
                case "中风":
                    kongTiaoFS_ZF();
                    break;
                case "高风":
                    kongTiaoFS_GF();
                    break;
                default:
                    kongTiaoFS_Kong();
                    break;
            }
        }

        async void RefreshState()
        {
            await Task.Run(() =>
            {
                while (true)
                {

                    Action action1 = () =>
                    {
                        initKongTiao();
                    };
                    Dispatcher.BeginInvoke(action1);
                    Thread.Sleep(App.RefreshTime * 1000);
                }
            });
        }

    }
}
