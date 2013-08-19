using System.Windows.Forms;

namespace LifeGame
{
    static class DialogHelper
    {
        public static string GetSavePath(string title, string filter)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = title;
            sfd.Filter = filter;

            if (sfd.ShowDialog() == DialogResult.OK)
                return sfd.FileName;
            return string.Empty;
        }

        public static string GetLoadPath(string title, string filter)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = title;
            ofd.Filter = filter;

            if (ofd.ShowDialog() == DialogResult.OK)
                return ofd.FileName;
            return string.Empty;
        }
    }
}
