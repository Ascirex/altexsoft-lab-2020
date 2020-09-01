using System;
using System.Collections.Generic;
using System.Text;

namespace NewHomeWork1._4.FileBuilder
{
    internal class FilePathCreator
    {
        private readonly FileListGen _fileGen = new FileListGen();

        public void StartCreatePath()
        { 
             
            _fileGen.GetStart(); 
        }
    }
}
