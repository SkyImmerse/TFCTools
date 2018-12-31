using DarkUI.Controls;
using DarkUI.Docking;
using System.Drawing;

namespace TibiaUCStudio.Forms.Elements
{
    public partial class SpritesView : DarkToolWindow
    {
        public int CurrentPage = 0;

        public int ItemsPerPage = 99;
        public SpritesView()
        {
            InitializeComponent();
        }

        public void AddSprite(Image image, int id, string name)
        {
            spriteImageList.Images.Add(id.ToString(), image);
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
            if(CurrentPage >= MainForm.SpriteManager.SpritesCount/ItemsPerPage)
            {
                CurrentPage = MainForm.SpriteManager.SpritesCount/ ItemsPerPage;
            }

            Clear();

            for (int i = 1+CurrentPage*ItemsPerPage; i < 1 + CurrentPage * ItemsPerPage + ItemsPerPage; i++)
            {
                if (i < MainForm.SpriteManager.SpritesCount)
                {
                    var image = MainForm.SpriteManager.GetSpriteImage(i);

                    if (image != null)
                        AddSprite(image, i, i.ToString());
                }
            }

            pageCurrent.Text = (1 + CurrentPage * ItemsPerPage).ToString();
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

        }
    }
}
