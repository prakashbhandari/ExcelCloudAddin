namespace ExcelCloudAddIn
{
    partial class ManageTaskPaneRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ManageTaskPaneRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.grpRibbon = this.Factory.CreateRibbonGroup();
            this.toggleExcelCloud = this.Factory.CreateRibbonToggleButton();
            this.tab1.SuspendLayout();
            this.grpRibbon.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.grpRibbon);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // grpRibbon
            // 
            this.grpRibbon.Items.Add(this.toggleExcelCloud);
            this.grpRibbon.Label = "ExcelCloud Settings";
            this.grpRibbon.Name = "grpRibbon";
            // 
            // toggleExcelCloud
            // 
            this.toggleExcelCloud.Checked = true;
            this.toggleExcelCloud.Label = "Show/Hide ExcelCloud";
            this.toggleExcelCloud.Name = "toggleExcelCloud";
            this.toggleExcelCloud.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleExcelCloud_Click);
            // 
            // ManageTaskPaneRibbon
            // 
            this.Name = "ManageTaskPaneRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ManageTaskPaneRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.grpRibbon.ResumeLayout(false);
            this.grpRibbon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpRibbon;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleExcelCloud;
    }

    partial class ThisRibbonCollection
    {
        internal ManageTaskPaneRibbon ManageTaskPaneRibbon
        {
            get { return this.GetRibbon<ManageTaskPaneRibbon>(); }
        }
    }
}
