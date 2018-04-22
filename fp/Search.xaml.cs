using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace fp
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Search : Page
    {
        public Search()
        {
            this.InitializeComponent();
            this.DataContext = new ResaltSample();
        }
    }
    public class Resalt
    {
        public string Title { get; set; }
        public string Time { get; set; }
    }
    public class ResaltSample
    {
        public ResaltSample()
        {
            InitSampleData();
        }
        public int numberOfResalt { get; set; }
        public List<Resalt> ResaltList { get; set; }
        private void InitSampleData()
        {
            ResaltList = new List<Resalt>
            {
                new Resalt
                {
                    Title ="笔记一",Time="2018/4/19"
                },
                new Resalt
                {
                    Title ="笔记二",Time="2018/4/20"
                },
                new Resalt
                {
                    Title ="笔记三",Time="2018/4/21"
                },
                new Resalt
                {
                    Title ="笔记四",Time="2018/4/22"
                },
            };
            numberOfResalt = ResaltList.Count;
        }
    }
}
