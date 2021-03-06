﻿//
// Copyright (c) Seal Report, Eric Pfirsch (sealreport@gmail.com), http://www.sealreport.org.
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. http://www.apache.org/licenses/LICENSE-2.0..
//
using DynamicTypeDescriptor;
using Seal.Converter;
using Seal.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace Seal.Model
{
    public class SecurityGroup : RootEditor
    {
        #region Editor
        protected override void UpdateEditorAttributes()
        {
            if (_dctd != null)
            {
                //Disable all properties
                foreach (var property in Properties) property.SetIsBrowsable(false);
                //Then enable
                GetProperty("Name").SetIsBrowsable(true);
                GetProperty("ViewType").SetIsBrowsable(true);
                GetProperty("Folders").SetIsBrowsable(true);
                GetProperty("Columns").SetIsBrowsable(true);
                GetProperty("SqlModel").SetIsBrowsable(true);
                GetProperty("Devices").SetIsBrowsable(true);
                GetProperty("Connections").SetIsBrowsable(true);
                GetProperty("Sources").SetIsBrowsable(true);
                GetProperty("DashboardFolders").SetIsBrowsable(true);
                GetProperty("PersonalDashboardFolder").SetIsBrowsable(true);

                GetProperty("Widgets").SetIsBrowsable(true);

                GetProperty("Culture").SetIsBrowsable(true);
                GetProperty("LogoName").SetIsBrowsable(true);
                GetProperty("PersFolderRight").SetIsBrowsable(true);

                TypeDescriptor.Refresh(this);
            }
        }
        #endregion

        string _name = "Group";
        [Category("Definition"), DisplayName("\tName"), Description("The security group name."), Id(1, 1)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private List<SecurityFolder> _folders = new List<SecurityFolder>();
        [Category("Definition"), DisplayName("Folders"), Description("The folder configurations for this group used for Web Publication of reports. By default, repository folders have no right."), Id(2, 1)]
        [Editor(typeof(EntityCollectionEditor), typeof(UITypeEditor))]
        public List<SecurityFolder> Folders
        {
            get { return _folders; }
            set { _folders = value; }
        }
        public bool ShouldSerializeFolders() { return _folders.Count > 0; }

        ViewType _viewType = ViewType.ReportsDashboards;
        [Category("Definition"), DisplayName("View type"), Description("Define if the group can view Reports and Dashboards."), Id(3, 1)]
        [TypeConverter(typeof(NamedEnumConverter))]
        [DefaultValue(ViewType.ReportsDashboards)]
        public ViewType ViewType
        {
            get { return _viewType; }
            set { _viewType = value; }
        }

        PersonalFolderRight _persFolderRight = PersonalFolderRight.None;
        [Category("Definition"), DisplayName("Personal folder"), Description("Define the right of the dedicated personal folder for each user of the group."), Id(4, 1)]
        [TypeConverter(typeof(NamedEnumConverter))]
        [DefaultValue(PersonalFolderRight.None)]
        public PersonalFolderRight PersFolderRight
        {
            get { return _persFolderRight; }
            set { _persFolderRight = value; }
        }

        private bool _sqlModel = true;
        [Category("Web Report Designer Security"), DisplayName("\t\t\tSQL Models"), Description("For the Web Report Designer: If true, SQL Models and Custom SQL for elements or restrictions can be edited through the Web Report Designer. Note that dynamic filters set for security purpose will not be applied."), Id(1, 2)]
        [DefaultValue(true)]
        public bool SqlModel
        {
            get { return _sqlModel; }
            set { _sqlModel = value; }
        }
        public bool ShouldSerializeSqlModel() { return !_sqlModel; }

        private List<SecurityDevice> _devices = new List<SecurityDevice>();
        [Category("Web Report Designer Security"), DisplayName("\t\tDevices"), Description("For the Web Report Designer: Device rights for the group. Set rights to devices through their names. By default, all devices can be selected."), Id(2, 2)]
        [Editor(typeof(EntityCollectionEditor), typeof(UITypeEditor))]
        public List<SecurityDevice> Devices
        {
            get { return _devices; }
            set { _devices = value; }
        }
        public bool ShouldSerializeDevices() { return _devices.Count > 0; }

        private List<SecuritySource> _sources = new List<SecuritySource>();
        [Category("Web Report Designer Security"), DisplayName("\t\tSources"), Description("For the Web Report Designer: Data sources rights for the group. Set rights to data source through their names. By default, all sources can be selected."), Id(3, 2)]
        [Editor(typeof(EntityCollectionEditor), typeof(UITypeEditor))]
        public List<SecuritySource> Sources
        {
            get { return _sources; }
            set { _sources = value; }
        }
        public bool ShouldSerializeSources() { return _sources.Count > 0; }

        private List<SecurityConnection> _connections = new List<SecurityConnection>();
        [Category("Web Report Designer Security"), DisplayName("\tConnections"), Description("For the Web Report Designer: Connections rights for the group. Set rights to connections through their names. By default, all connections can be selected."), Id(4, 2)]
        [Editor(typeof(EntityCollectionEditor), typeof(UITypeEditor))]
        public List<SecurityConnection> Connections
        {
            get { return _connections; }
            set { _connections = value; }
        }
        public bool ShouldSerializeConnections() { return _connections.Count > 0; }

        private List<SecurityColumn> _columns = new List<SecurityColumn>();
        [Category("Web Report Designer Security"), DisplayName("Columns"), Description("For the Web Report Designer: Columns rights for the group. Set rights to columns through the security tags or categories assigned. By default, all columns can be selected."), Id(5, 2)]
        [Editor(typeof(EntityCollectionEditor), typeof(UITypeEditor))]
        public List<SecurityColumn> Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }
        public bool ShouldSerializeColumns() { return _columns.Count > 0; }


        private bool _personalDashboardFolder = true;
        [Category("Dashboards Security"), DisplayName("Personal Dashboard Folder"), Description("If true, users of the group have a personal folder to create personal dashboards."), Id(1, 3)]
        [DefaultValue(true)]
        public bool PersonalDashboardFolder
        {
            get { return _personalDashboardFolder; }
            set { _personalDashboardFolder = value; }
        }


        private List<SecurityDashboardFolder> _dashboardFolders = new List<SecurityDashboardFolder>();
        [Category("Dashboards Security"), DisplayName("Dashboard Folders"), Description("The dashboard folder configurations for this group used for Web Publication of dashboards. By default, repository dashboard folders have no right."), Id(2, 3)]
        [Editor(typeof(EntityCollectionEditor), typeof(UITypeEditor))]
        public List<SecurityDashboardFolder> DashboardFolders
        {
            get { return _dashboardFolders; }
            set { _dashboardFolders = value; }
        }
        public bool ShouldSerializDashboards() { return _dashboardFolders.Count > 0; }


        private List<SecurityWidget> _widgets = new List<SecurityWidget>();
        [Category("Dashboards Security"), DisplayName("Widgets"), Description("For the Dashboard Designer: Widget rights for the group. Set rights to widgets through the security tags or names assigned. By default all widgets can be selected."), Id(4, 3)]
        [Editor(typeof(EntityCollectionEditor), typeof(UITypeEditor))]
        public List<SecurityWidget> Widgets
        {
            get { return _widgets; }
            set { _widgets = value; }
        }
        public bool ShouldSerializeWidgets() { return _widgets.Count > 0; }

        string _culture;
        [Category("Options"), DisplayName("Culture"), Description("The culture used for users belonging to the group. If empty, the default culture is used."), Id(1, 5)]
        [TypeConverter(typeof(Seal.Converter.CultureInfoConverter))]
        public string Culture
        {
            get { return _culture; }
            set { _culture = value; }
        }

        string _logoName;
        [Category("Options"), DisplayName("Logo file name"), Description("The logo file name used for to generate the reports. If empty, the default logo is used."), Id(3, 5)]
        public string LogoName
        {
            get { return _logoName; }
            set { _logoName = value; }
        }
    }
}
