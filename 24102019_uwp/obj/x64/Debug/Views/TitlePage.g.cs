﻿#pragma checksum "H:\ProjectC#\BACKUP\new2\new1\disc_store_management\24102019_uwp\Views\TitlePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3BC0303D0791180814CD16456E1D25C3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _24102019_uwp.Views
{
    partial class TitlePage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Windows_UI_Xaml_Automation_AutomationProperties_Name(global::Windows.UI.Xaml.DependencyObject obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                global::Windows.UI.Xaml.Automation.AutomationProperties.SetName(obj, value);
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class TitlePage_obj15_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            ITitlePage_Bindings
        {
            private global::_24102019_uwp.Views.customTitle dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj15;
            private global::Windows.UI.Xaml.Controls.TextBlock obj16;
            private global::Windows.UI.Xaml.Controls.TextBlock obj17;
            private global::Windows.UI.Xaml.Controls.TextBlock obj18;
            private global::Windows.UI.Xaml.Controls.TextBlock obj19;
            private global::Windows.UI.Xaml.Controls.TextBlock obj20;
            private global::Windows.UI.Xaml.Controls.TextBlock obj21;
            private global::Windows.UI.Xaml.Controls.TextBlock obj22;

            public TitlePage_obj15_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 15: // Views\TitlePage.xaml line 110
                        this.obj15 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.Grid)target);
                        break;
                    case 16: // Views\TitlePage.xaml line 121
                        this.obj16 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 17: // Views\TitlePage.xaml line 122
                        this.obj17 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 18: // Views\TitlePage.xaml line 123
                        this.obj18 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 19: // Views\TitlePage.xaml line 124
                        this.obj19 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 20: // Views\TitlePage.xaml line 125
                        this.obj20 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 21: // Views\TitlePage.xaml line 126
                        this.obj21 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 22: // Views\TitlePage.xaml line 127
                        this.obj22 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj15.Target as global::Windows.UI.Xaml.Controls.Grid).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::_24102019_uwp.Views.customTitle) item, 1 << phase);
            }

            public void Recycle()
            {
            }

            // ITitlePage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::_24102019_uwp.Views.customTitle)newDataRoot;
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::_24102019_uwp.Views.customTitle obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Name(obj.Name, phase);
                        this.Update_TitleID(obj.TitleID, phase);
                        this.Update_Price(obj.Price, phase);
                        this.Update_TypeName(obj.TypeName, phase);
                        this.Update_IsAvailable(obj.IsAvailable, phase);
                        this.Update_Deleted(obj.Deleted, phase);
                        this.Update_Description(obj.Description, phase);
                    }
                }
            }
            private void Update_Name(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\TitlePage.xaml line 110
                    if ((this.obj15.Target as global::Windows.UI.Xaml.Controls.Grid) != null)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Automation_AutomationProperties_Name((this.obj15.Target as global::Windows.UI.Xaml.Controls.Grid), obj, null);
                    }
                    // Views\TitlePage.xaml line 122
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj17, obj, null);
                }
            }
            private void Update_TitleID(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\TitlePage.xaml line 121
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj16, obj.ToString(), null);
                }
            }
            private void Update_Price(global::System.Decimal obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\TitlePage.xaml line 123
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj18, obj.ToString(), null);
                }
            }
            private void Update_TypeName(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\TitlePage.xaml line 124
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj19, obj, null);
                }
            }
            private void Update_IsAvailable(global::System.Boolean obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\TitlePage.xaml line 125
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj20, obj.ToString(), null);
                }
            }
            private void Update_Deleted(global::System.Boolean obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\TitlePage.xaml line 126
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj21, obj.ToString(), null);
                }
            }
            private void Update_Description(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\TitlePage.xaml line 127
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj22, obj, null);
                }
            }
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class TitlePage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            ITitlePage_Bindings
        {
            private global::_24102019_uwp.Views.TitlePage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ListView obj13;

            public TitlePage_obj1_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 13: // Views\TitlePage.xaml line 85
                        this.obj13 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        break;
                    default:
                        break;
                }
            }

            // ITitlePage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::_24102019_uwp.Views.TitlePage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::_24102019_uwp.Views.TitlePage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_lstTitle(obj.lstTitle, phase);
                    }
                }
            }
            private void Update_lstTitle(global::System.Collections.ObjectModel.ObservableCollection<global::_24102019_uwp.Views.customTitle> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\TitlePage.xaml line 85
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj13, obj, null);
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\TitlePage.xaml line 12
                {
                    this.splView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3: // Views\TitlePage.xaml line 23
                {
                    this.TitleID = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // Views\TitlePage.xaml line 28
                {
                    this.Name = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // Views\TitlePage.xaml line 33
                {
                    this.Price = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // Views\TitlePage.xaml line 38
                {
                    this.Type = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 7: // Views\TitlePage.xaml line 45
                {
                    this.Description = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // Views\TitlePage.xaml line 47
                {
                    this.IsAvailable = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 9: // Views\TitlePage.xaml line 50
                {
                    this.Deleted = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 10: // Views\TitlePage.xaml line 55
                {
                    this.BtnSave = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.BtnSave).Click += this.Save;
                }
                break;
            case 11: // Views\TitlePage.xaml line 65
                {
                    this.autobox = (global::Windows.UI.Xaml.Controls.AutoSuggestBox)(target);
                    ((global::Windows.UI.Xaml.Controls.AutoSuggestBox)this.autobox).PreviewKeyDown += this.Autobox_PreviewKeyDown;
                }
                break;
            case 12: // Views\TitlePage.xaml line 75
                {
                    this.cmdbar = (global::Windows.UI.Xaml.Controls.CommandBar)(target);
                }
                break;
            case 13: // Views\TitlePage.xaml line 85
                {
                    this.lvTitle = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.lvTitle).SelectionChanged += this.lvTitle_SelectionChanged;
                }
                break;
            case 23: // Views\TitlePage.xaml line 76
                {
                    this.BtnAdd = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.BtnAdd).Click += this.Add;
                }
                break;
            case 24: // Views\TitlePage.xaml line 77
                {
                    this.BtnModify = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.BtnModify).Click += this.Modify;
                }
                break;
            case 25: // Views\TitlePage.xaml line 78
                {
                    this.BtnDelete = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.BtnDelete).Click += this.Delete;
                }
                break;
            case 26: // Views\TitlePage.xaml line 79
                {
                    this.BtnRefresh = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.BtnRefresh).Click += this.Refresh;
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.BtnRefresh).PreviewKeyDown += this.BtnRefresh_PreviewKeyDown;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Views\TitlePage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    TitlePage_obj1_Bindings bindings = new TitlePage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            case 15: // Views\TitlePage.xaml line 110
                {                    
                    global::Windows.UI.Xaml.Controls.Grid element15 = (global::Windows.UI.Xaml.Controls.Grid)target;
                    TitlePage_obj15_Bindings bindings = new TitlePage_obj15_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element15.DataContext);
                    element15.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element15, bindings);
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element15, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

