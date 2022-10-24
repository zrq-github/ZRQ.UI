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

namespace ZRQ.UI
{
    /// <summary>
    /// 重载实现文本高亮
    /// </summary>
    public class HighlightLabel : Label
    {

        /// <summary>
        /// 高亮画笔
        /// </summary>
        public static DependencyProperty HighlightForegroundProperty =
            DependencyProperty.Register("HighlightForeground", typeof(Brush), typeof(HighlightLabel), new PropertyMetadata(new SolidColorBrush(Colors.Red), new PropertyChangedCallback(OnHighlightForegroundChanged)));

        /// <summary>
        /// 高亮画笔
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
        /// 背景色
        /// </summary>
        public Brush backColor { get; set; } = new SolidColorBrush(Colors.Yellow);

        /// <summary>
        /// HighlightForegroundProperty 属性改变时，执行的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnHighlightForegroundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as HighlightLabel;
            control.SetHighlight();
        }

        /// <summary>
        /// 要高亮的单词
        /// </summary>
        public static DependencyProperty HighlightWordProperty { get; set; } = DependencyProperty.Register("HighlightWord", typeof(string), typeof(HighlightLabel),
                    new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnHighlightWordChanged)));

        /// <summary>
        /// 要高亮的单词
        /// </summary>
        public string HighlightWord
        {
            get
            {
                return (string)GetValue(HighlightWordProperty);
            }
            set
            {
                SetValue(HighlightWordProperty, value);
            }
        }

        /// <summary>
        /// HighlightWordProperty 属性改变时，执行的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnHighlightWordChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as HighlightLabel;
            control.SetHighlight();
        }

        static HighlightLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HighlightLabel), new FrameworkPropertyMetadata(typeof(HighlightLabel)));
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            SetHighlight();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            SetHighlight();
        }

        /// <summary>
        /// 设置高亮
        /// </summary>
        private void SetHighlight()
        {
            var textBlock = (TextBlock)GetTemplateChild("PART_TextBlock");
            if (textBlock == null)
            {
                return;
            }
            var text = Content.ToString();
            var str = HighlightWord;

            //var regex = new Regex(@"\b" + str + @"\b"); 
            //var matches = regex.Matches(text);
            if (string.IsNullOrEmpty(str))
            {
                def();
                return;
            }

            int nIndex = 0;
            var strLen = text.Length;
            var keyLen = str.Length;
            List<int> listIndex = new List<int>();
            while (nIndex < strLen)
            {
                var n = text.IndexOf(str, nIndex);
                if (n == -1)
                {
                    break;
                }
                listIndex.Add(n);
                nIndex = n + keyLen + 1;
            }

            if (!listIndex.Any())
            {
                def();
                return;
            }

            var run1s = new List<Inline>();
            nIndex = 0;

            for (int i = 0; i < listIndex.Count; i++)
            {
                var n = listIndex[i];
                var len = n - nIndex;
                if (len > 0)
                {
                    run1s.Add(new Run
                    {
                        Text = text.Substring(nIndex, len),
                        Foreground = Foreground
                    });
                }

                run1s.Add(new Run
                {
                    Text = text.Substring(n, keyLen),
                    Foreground = HighlightForeground,
                    Background = backColor
                });
                nIndex = n + keyLen + 1;
                if (i == listIndex.Count - 1 && nIndex < strLen)
                {
                    run1s.Add(new Run
                    {
                        Text = text.Substring(nIndex, strLen - nIndex),
                        Foreground = Foreground
                    });
                }
            }
            textBlock.Inlines.Clear();
            textBlock.Inlines.AddRange(run1s);
            return;

            void def()
            {
                textBlock.Inlines.Clear();
                textBlock.Inlines.AddRange(new List<Inline>() { new Run { Text = text, Foreground = Foreground } });
            }
        }
    }
}
