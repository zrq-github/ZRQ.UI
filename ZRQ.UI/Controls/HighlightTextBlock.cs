using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace ZRQ.UI.Controls
{
    /// <summary>
    /// 实现文本高亮
    /// </summary>
    public class HighlightTextBlock : TextBlock
    {
        #region Propertys
        /// <summary>
        /// 高亮背景色
        /// </summary>
        public static DependencyProperty HighlightBackgroundProperty =
            DependencyProperty.Register("HighlightBackground", typeof(Brush), typeof(HighlightTextBlock),
                new PropertyMetadata(new SolidColorBrush(Colors.Yellow), new PropertyChangedCallback(OnHighlightBackgroundChanged)));

        /// <summary>
        /// 高亮前景色
        /// </summary>
        public static DependencyProperty HighlightForegroundProperty =
            DependencyProperty.Register("HighlightForeground", typeof(Brush), typeof(HighlightTextBlock), new PropertyMetadata(new SolidColorBrush(Colors.Red), new PropertyChangedCallback(OnHighlightForegroundChanged)));

        /// <summary>
        /// 要高亮的单词
        /// </summary>
        /// <remarks>每次更改这个值会自动触发修改</remarks>
        public static DependencyProperty HighlightTestProperty =
            DependencyProperty.Register("HighlightTest", typeof(string), typeof(HighlightTextBlock),
                    new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnHighlightWordChanged)));

        #endregion

        static HighlightTextBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HighlightTextBlock), new FrameworkPropertyMetadata(typeof(HighlightTextBlock)));
        }

        /// <summary>
        /// 高亮背景色
        /// </summary>
        public Brush HighlightBackground
        {
            get
            {
                return (Brush)GetValue(HighlightBackgroundProperty);
            }
            set
            {
                SetValue(HighlightBackgroundProperty, value);
            }
        }

        /// <summary>
        /// 高亮前景色
        /// </summary>
        public Brush HighlightForeground
        {
            get
            {
                return (Brush)GetValue(HighlightForegroundProperty);
            }
            set
            {
                SetValue(HighlightForegroundProperty, value);
            }
        }

        /// <summary>
        /// 要高亮的单词
        /// </summary>
        public string HighlightTest
        {
            get
            {
                return (string)GetValue(HighlightTestProperty);
            }
            set
            {
                SetValue(HighlightTestProperty, value);
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            SetHighlight();
        }

        private static void OnHighlightBackgroundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as HighlightTextBlock;
            control?.SetHighlight();
        }

        /// <summary>
        /// HighlightForegroundProperty 属性改变时，执行的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnHighlightForegroundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as HighlightTextBlock;
            control?.SetHighlight();
        }

        /// <summary>
        /// HighlightWordProperty 属性改变时，执行的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnHighlightWordChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as HighlightTextBlock;
            control?.SetHighlight();
        }

        /// <summary>
        /// 还原高亮
        /// </summary>
        private void RestoreHightLight(ref string text)
        {
            Inlines.Clear();
            Inlines.AddRange(new List<Inline>() { new Run { Text = text, Foreground = Foreground } });
        }

        /// <summary>
        /// 设置高亮
        /// </summary>
        private void SetHighlight()
        {
            Regex regex;
            var text = Text;
            var hightlight = HighlightTest;

            // 如果高亮没有值, 还原
            if (string.IsNullOrEmpty(hightlight))
            {
                RestoreHightLight(ref text);
                return;
            }

            //regex = new Regex($@"({tb_SearchText.Text})");
            string escapeStr = Regex.Escape(hightlight);
            regex = new Regex($"({escapeStr})");

            string[] substrings = regex.Split(text);
            Inlines.Clear();
            foreach (var item in substrings)
            {
                if (regex.Match(item).Success)
                {
                    Run runx = new Run(item);
                    runx.Background = this.HighlightBackground;
                    runx.Foreground = this.HighlightForeground;
                    Inlines.Add(runx);
                }
                else
                {
                    Inlines.Add(item);
                }
            }
        }
    }
}
