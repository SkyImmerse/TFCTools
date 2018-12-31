using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Docking;
using DarkUI.Forms;
using DarkUI.Win32;
using TibiaUCStudio.Forms;
using System.IO;
using TibiaUCStudio.Forms.Elements;
using Game.DAO;
using TibiaUCStudio.Core;
using Game.Core;

namespace TibiaUCStudio.Forms
{
    public partial class MainForm : Form
    {
        #region Field Region

        private List<DarkDockContent> _toolWindows = new List<DarkDockContent>();

        public static Client _client;
        private ThingsView _thingsView ;
        private SpritesView _spritesView;

        public ResourceManager ResourceManager;

        public static SpriteManager SpriteManager;
        public static Game.DAO.ThingTypeManager TTM;
        #endregion

        public MainForm()
        {
            InitializeComponent();

            ResourceManager = new ResourceManager();

            SpriteManager = new SpriteManager();

            TTM = new ThingTypeManager();
            TTM.Init();

            // Add the control scroll message filter to re-route all mousewheel events
            // to the control the user is currently hovering over with their cursor.
            Application.AddMessageFilter(new ControlScrollFilter());

            // Add the dock content drag message filter to handle moving dock content around.
            Application.AddMessageFilter(DockPanel.DockContentDragFilter);

            // Add the dock panel message filter to filter through for dock panel splitter
            // input before letting events pass through to the rest of the application.
            Application.AddMessageFilter(DockPanel.DockResizeFilter);

            // Hook in all the UI events manually for clarity.
            HookEvents();

            // Build the tool windows and add them to the dock panel
            _client = new Client();
            _thingsView = new ThingsView();
            _spritesView = new SpritesView();

            // Add the tool windows to a list
            _toolWindows.Add(_thingsView);
            _toolWindows.Add(_spritesView);
            _toolWindows.Add(_client);

            // Deserialize if a previous state is stored
            if (File.Exists("dockpanel.config"))
            {
                //DeserializeDockPanel("dockpanel.config");
            }
            else
            {
                // Add the tool window list contents to the dock panel
                foreach (var toolWindow in _toolWindows)
                    DockPanel.AddContent(toolWindow);
            }
        }


        private void HookEvents()
        {
        }

        private void mnuOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "Things";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = openFileDialog1.FileName.Split('\\');
                GameConfig.ClientVersion = int.Parse(path[path.Count() - 2].ToString().ToString());
                GameConfig.SetupVersionParamaters();
                SpriteManager.OpenSpriteFile(ResourceManager.Load(openFileDialog1.FileName.Replace(".dat", ".spr")));
                TTM.OpenThingsFile(ResourceManager.Load(openFileDialog1.FileName.Replace(".spr", ".dat")));

                _spritesView.SetPage(_spritesView.CurrentPage);

                _thingsView.SetPage(_thingsView.CurrentPage);

            }
        }

        private void mnuSaveAll_Click(object sender, EventArgs e)
        {
            
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _thingsView.SetCategory(ThingCategory.ThingCategoryItem);
        }

        private void outfitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _thingsView.SetCategory(ThingCategory.ThingCategoryCreature);
        }

        private void effectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _thingsView.SetCategory(ThingCategory.ThingCategoryEffect);
        }

        private void missilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _thingsView.SetCategory(ThingCategory.ThingCategoryMissile);
        }

        private void mnuExport_Click(object sender, EventArgs e)
        {
            SpriteManager.AntialiasingLevel = 1;
            SpriteManager.ExportAtlasSpriteFile("Tibia");
        }

        private void exportASPRAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpriteManager.AntialiasingLevel = 2;
            SpriteManager.ExportAtlasSpriteFile("Tibia (Antialiasing)");
        }
    }
}
