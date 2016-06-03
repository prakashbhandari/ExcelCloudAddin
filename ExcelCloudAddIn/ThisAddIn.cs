using System;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;

namespace ExcelCloudAddIn
{
    public partial class ThisAddIn
    {
        private FrmSettings addInSettings;
        private Microsoft.Office.Tools.CustomTaskPane addInSettingsPane;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            addInSettings = new FrmSettings();
            addInSettingsPane = this.CustomTaskPanes.Add(addInSettings, "ExcelCloud AddIn Settings");
            addInSettingsPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight;
            addInSettingsPane.Width = addInSettings.Size.Width + 330;
            addInSettingsPane.Visible = true;
            addInSettingsPane.VisibleChanged += new EventHandler(addInSettings_VisibleChanged);
        }

        private void addInSettings_VisibleChanged(object sender, EventArgs e)
        {
            Globals.Ribbons.ManageTaskPaneRibbon.toggleExcelCloud.Checked = addInSettingsPane.Visible;
        }

        public Microsoft.Office.Tools.CustomTaskPane TaskPane
        {
            get
            {
                return addInSettingsPane;
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
