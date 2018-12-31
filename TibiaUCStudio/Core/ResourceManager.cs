using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TibiaUCStudio.Core
{
    /// <summary>
    /// Assets Loader
    /// </summary>
    public class ResourceManager
    {

        /// <summary>
        /// Load file
        /// </summary>
        /// <param name="filename">Relative path</param>
        public FileStream Load(string filename)
        {
            var path = filename;
            if (!File.Exists(filename))
            {
                return null;
            }
            return new FileStream(path, FileMode.Open);
        }
    }

}
