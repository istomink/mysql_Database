using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Bank
{
    public static class PageController
    {
        public static event Action<Page> OnChangedPage;
        public static int CountPage => Pages.Count;

        private static List<Page> Pages = new List<Page>();

        public static void AddPage(Page page)
        {
            Pages.Add(page);
            OnChangedPage?.Invoke(page);
        }

        public static void RemovePage(Page page) 
        { 
            Pages.Remove(page);
            OnChangedPage?.Invoke(Pages.Last());
        }

        public static void RemoveAtPage(int index)
        {
            Pages.RemoveAt(index);
            OnChangedPage?.Invoke(Pages.Last());
        }

        public static void RemoveLast()
        {
            Pages.Remove(Pages.Last());
            OnChangedPage?.Invoke(Pages.Last());
        }

        public static void RemoveAll()
        {
            Pages.Clear();
        }
    }
}
