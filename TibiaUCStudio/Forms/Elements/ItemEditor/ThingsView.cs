using DarkUI.Controls;
using DarkUI.Docking;
using System.Drawing;
using System;
using Game.DAO;
using System.Linq;

namespace TibiaUCStudio.Forms.Elements
{
    public partial class ThingsView : DarkToolWindow
    {
        public int CurrentPage = 0;

        public int ItemsPerPage = 99;
        private ThingCategory Category = ThingCategory.ThingCategoryItem;

        public ThingsView()
        {
            InitializeComponent();
        }

        public void AddSprite(Image image, int id, string name)
        {
            if(image != null) spriteImageList.Images.Add(id.ToString(), image);
            spritesListView.Items.Add(name, name, id.ToString());
        }

        public void Clear()
        {
            spriteImageList.Images.Clear();
            spritesListView.Items.Clear();
        }
        public void SetPage(int currentPage)
        {
            CurrentPage = currentPage;

            if(CurrentPage < 0)
            {
                CurrentPage = 0;
            }
            if(CurrentPage >= MainForm.TTM._mThingTypes[(int)Category].Count / ItemsPerPage)
            {
                CurrentPage = MainForm.TTM._mThingTypes[(int)Category].Count / ItemsPerPage;
            }

            Clear();

            for (int i = 1+CurrentPage*ItemsPerPage; i < 1 + CurrentPage * ItemsPerPage + ItemsPerPage; i++)
            {
                if (i < MainForm.TTM._mThingTypes[(int)Category].Count)
                {
                    var image = MainForm.TTM.GetThingType((ushort)i, Category);

                    if (image != null)
                        AddSprite(image.GetSprites().Count > 0 ? MainForm.SpriteManager.GetSpriteImage(image.GetSprites()[0]) : null, i, i.ToString());
                }
            }

            pageCurrent.Text = (1 + CurrentPage * ItemsPerPage).ToString() ;
        }

        private void pageFirst_Click(object sender, System.EventArgs e)
        {
            SetPage(1);
        }

        private void pagePrev_Click(object sender, System.EventArgs e)
        {
            CurrentPage -= 1;
            SetPage(CurrentPage);
        }

        private void pageNext_Click(object sender, System.EventArgs e)
        {
            CurrentPage += 1;
            SetPage(CurrentPage);
        }

        private void pageLast_Click(object sender, System.EventArgs e)
        {
            SetPage(MainForm.SpriteManager.SpritesCount / ItemsPerPage);
        }

        private void pageCurrent_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // enter
            if(e.KeyChar == (char)13)
            {
                SetPage(int.Parse(pageCurrent.Text)/ItemsPerPage);
            }
        }

        private void spritesListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (spritesListView.SelectedItems.Count > 0)
                MainForm._client.pictureBox2.Image = MainForm.SpriteManager.CreateThingTypeSprite(MainForm.TTM.GetThingType(ushort.Parse(spritesListView.SelectedItems[0].ImageKey), Category));
        }

        internal void SetCategory(ThingCategory items)
        {
            Category = items;
            SetPage(1);
        }
    }
}
