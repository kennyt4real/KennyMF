using KennyMF.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using Xamarin.Forms;

namespace KennyMF.CustomElements
{
    public class BindableStackLayout : StackLayout
    {
        public static readonly BindableProperty ItemsProperty =
            BindableProperty.Create(nameof(Items), typeof(ObservableCollection<View>), typeof(BindableStackLayout), null,
                propertyChanged: (b, o, n) =>
                {
                    (n as ObservableCollection<View>).CollectionChanged += (coll, arg) =>
                    {
                        switch (arg.Action)
                        {
                            case NotifyCollectionChangedAction.Add:
                                foreach (var v in arg.NewItems)
                                {
                                    var c = v as IUIControl;
                                    (b as BindableStackLayout).Children.Insert(c.Position, (View)v);
                                }
                                break;
                            case NotifyCollectionChangedAction.Remove:
                                (b as BindableStackLayout).Children.Remove((View)arg.OldItems[0]);
                                break;
                            case NotifyCollectionChangedAction.Move:
                                break;
                            case NotifyCollectionChangedAction.Replace:
                                break;
                        }
                    };
                });

        public ObservableCollection<View> Items
        {
            get { return (ObservableCollection<View>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
    }
}
